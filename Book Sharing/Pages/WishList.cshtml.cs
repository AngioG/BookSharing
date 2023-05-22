using Book_Sharing.Data;
using Book_Sharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Book_Sharing.Pages
{
    [Authorize(Roles ="User")]
    public class WishListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataDbContext _context;

        public WishListModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            DataDbContext dbc
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbc;
        }

        public int Risultati { get; private set; }

        public List<BookRoot> Libri { get; set; }

        //[BindProperty]
        public string Titolo { get; set; } = "";
        //[BindProperty]
        public string Autore { get; set; } = "";
        //[BindProperty]
        public int Pagina { get; set; } = 1;

        public async Task<IActionResult> OnGetAsync(string? titolo, string? autore, int? pagina)
        {
            if (titolo != null)
                Titolo = titolo;
            if (autore != null)
                Autore = autore;
            if (pagina != null)
                Pagina = (int)pagina;

            var IdentityUser = await _userManager.GetUserAsync(User);
            var DatiUtente = await _context.Utenti.Include("Provincia").FirstOrDefaultAsync(u => u.IdentityUid == IdentityUser.Id);
            var utenteLibri = _context.UtentiLibri.Where(ul => ul.fkUtente == DatiUtente.PkUtente && ul.Interesse && ul.Titolo.Contains(Titolo) && ul.Autore.Contains(Autore)).ToList();

            Risultati = utenteLibri.Count();
            

            Libri = new List<BookRoot>();

            for(int i = (Pagina-1)*6; i<Risultati; i++)
            {
                HttpClient client = new HttpClient();
                string url = $"https://www.googleapis.com/books/v1/volumes/{utenteLibri[i].IdLibro}?key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
                var result = client.GetAsync(url).Result;

                if (!result.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Error");
                }

                var jsonString = result.Content.ReadAsStringAsync().Result;
                Libri.Add(JsonConvert.DeserializeObject<BookRoot>(jsonString));
            }

            return Page();
        }
    }
}
