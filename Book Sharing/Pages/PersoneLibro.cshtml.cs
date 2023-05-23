using Book_Sharing.Data;
using Book_Sharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Book_Sharing.Pages
{
    [Authorize(Roles = "User")]
    public class PersoneLibroModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataDbContext _context;

        public PersoneLibroModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            DataDbContext dbc
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbc;
        }

        [BindProperty]
        public bool Prestito { get; set; }
        [BindProperty]
        public bool Scambio { get; set; }
        [BindProperty]
        public bool Interesse { get; set; }


        [BindProperty]
        public string Nome { get; set; }

        [BindProperty]
        public string Provincia { get; set; }
        /*[BindProperty]
        public string Regione { get; set; }*/
        public List<Provincia> EleProvince { get; set; }


        public List<DAO_UtenteLibro> Utenti { get; set; }

        public string Titolo { get; set; }
        public string Autore { get; set; }

        public async Task<IActionResult> OnGetAsync(string? libro, string? provincia, string? mode)
        {
            if (string.IsNullOrWhiteSpace(libro))
                return NotFound();

            Utenti = _context.UtentiLibri.Include("Utente").Include("Utente.Provincia").Where(ul => ul.IdLibro == libro).ToList();

            if (Utenti.Count() == 0)
                return NotFound();

            Titolo = Utenti[0].Titolo;
            Autore = Utenti[0].Autore;

            if (provincia != null)
            {
                Provincia = provincia;
                Utenti = Utenti.Where(ul => ul.Utente.Provincia.Nome == Provincia).ToList();
            }

            if (mode == "Scambio")
                Scambio = true;

            if (mode == "Prestito")
                Prestito = true;

            if (mode == "Interesse")
                Interesse = true;

            if(string.IsNullOrEmpty(mode))
            {
                Scambio = true;
                Prestito = true;
                Interesse = true;
            }

            Utenti = Utenti.Where(ul => (ul.Scambio && Scambio) || (ul.Prestito && Prestito) || (ul.Interesse && Interesse)).ToList();

            EleProvince = _context.Province.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? libro)
        {
            if (string.IsNullOrWhiteSpace(libro))
                return NotFound();

            Utenti = _context.UtentiLibri.Include("Utente").Include("Utente.Provincia").Where(ul => ul.IdLibro == libro).ToList();

            if (Utenti.Count() == 0)
                return NotFound();

            Titolo = Utenti[0].Titolo;
            Autore = Utenti[0].Autore;

            if (Provincia != "Filtra per Provincia")
            {
                Utenti = Utenti.Where(ul => ul.Utente.Provincia.Nome == Provincia).ToList();
            }

            Utenti = Utenti.Where(ul => (ul.Scambio && Scambio) || (ul.Prestito && Prestito) || (ul.Interesse && Interesse)).ToList();

            if (!string.IsNullOrWhiteSpace(Nome))
                Utenti = Utenti.Where(ul => (ul.Utente.Nome + " " + ul.Utente.Cognome).Contains(Nome)).ToList();

            EleProvince = _context.Province.ToList();

            return Page();
        }
    }
}
