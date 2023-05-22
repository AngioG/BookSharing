using Book_Sharing.Data;
using Book_Sharing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Book_Sharing.Pages
{
    public class LibroModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataDbContext _context;

        public LibroModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            DataDbContext dbc
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbc;
        }

        public string Autori { get; set; }
        public BookRoot Result { get; set; }
        public DAO_Utente DatiUtente { get; set; }

        public int Prestiti { get; set; }
        public int Scambi { get; set; }
        public int Interessati { get; set; }

        public int PrestitiProvincia { get; set; }
        public int ScambiProvincia { get; set; }
        public int InteressatiProvincia { get; set; }

        public DAO_UtenteLibro UtenteLibro { get; set; }
        /*[BindProperty]
        public string Modalità { get; set; } = null;*/

        public async Task<IActionResult> OnGetAsync(string? id, string? mode)
        {
            if (id == null)
                return NotFound();

            HttpClient client = new HttpClient();
            string url = $"https://www.googleapis.com/books/v1/volumes/{id}?key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
            var result = client.GetAsync(url).Result;

            if (!result.IsSuccessStatusCode)
            {
                return RedirectToPage("./Error");
            }

            var jsonString = result.Content.ReadAsStringAsync().Result;
            Result = JsonConvert.DeserializeObject<BookRoot>(jsonString);

            if (Result == null)
                return NotFound();

            var IdentityUser = await _userManager.GetUserAsync(User);


            if (IdentityUser != null)
            {

                DatiUtente = await _context.Utenti.Include("Provincia").FirstOrDefaultAsync(u => u.IdentityUid == IdentityUser.Id);
                if (DatiUtente != null && !String.IsNullOrWhiteSpace(mode))
                {
                    var utenteLibro = await _context.UtentiLibri.FirstOrDefaultAsync(ul => ul.IdLibro == id && ul.fkUtente == DatiUtente.PkUtente);

                    if (utenteLibro == null)
                    {
                        utenteLibro = new DAO_UtenteLibro();
                        utenteLibro.fkUtente = DatiUtente.PkUtente;
                        utenteLibro.IdLibro = id;
                        utenteLibro.Autore = Result.volumeInfo.authors == null ? "Anonimo" : Result.volumeInfo.authors[0];
                        utenteLibro.Titolo = Result.volumeInfo.title;

                        await _context.UtentiLibri.AddAsync(utenteLibro);
                        await _context.SaveChangesAsync();
                    }

                    if (mode == "Scambio")
                    {
                        utenteLibro.Scambio = !utenteLibro.Scambio;
                    }
                    else if (mode == "Prestito")
                    {
                        utenteLibro.Prestito = !utenteLibro.Prestito;
                    }
                    else if (mode == "Interesse")
                    {
                        utenteLibro.Interesse = !utenteLibro.Interesse;
                    }

                    if (!utenteLibro.Scambio && !utenteLibro.Prestito && !utenteLibro.Interesse)
                        _context.UtentiLibri.Remove(utenteLibro);
                    else
                        _context.UtentiLibri.Attach(utenteLibro).State = EntityState.Modified;


                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        return RedirectToPage("Error");
                    }
                }

                if(DatiUtente != null)
                {
                    UtenteLibro = await _context.UtentiLibri.FirstOrDefaultAsync(ul => ul.IdLibro == id && ul.fkUtente == DatiUtente.PkUtente);
                }

            }

            var utenti_libri = _context.UtentiLibri.Where(ul => ul.IdLibro == Result.id);
            Prestiti = await utenti_libri.CountAsync(ul => ul.Prestito);
            Scambi = await utenti_libri.CountAsync(ul => ul.Scambio);
            Interessati = await utenti_libri.CountAsync(ul => ul.Interesse);

            int nAutori = Result.volumeInfo.authors.Count;
            if (nAutori == 0)
                Autori = "Anonimo";
            if (nAutori == 1)
                Autori = Result.volumeInfo.authors[0];
            else
            {
                for (int i = 0; i < nAutori; i++)
                {
                    Autori += Result.volumeInfo.authors[i];
                    if (i != nAutori - 1)
                    {
                        if (i == nAutori - 2)
                            Autori += " e ";
                        else
                            Autori += ", ";
                    }
                }

            }



            utenti_libri = utenti_libri.Include("Utente").Include("Utente.Provincia");
            if (DatiUtente != null && DatiUtente.Provincia != null)
            {
                PrestitiProvincia = await utenti_libri.CountAsync(ul => ul.Prestito && ul.Utente.Provincia == DatiUtente.Provincia);
                ScambiProvincia = await utenti_libri.CountAsync(ul => ul.Scambio && ul.Utente.Provincia == DatiUtente.Provincia);
                InteressatiProvincia = await utenti_libri.CountAsync(ul => ul.Interesse && ul.Utente.Provincia == DatiUtente.Provincia);
            }


            if (UtenteLibro == null)
                UtenteLibro = new DAO_UtenteLibro();

            return Page();

        }
    }
}
