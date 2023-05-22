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
    public class UtenteModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataDbContext _context;

        public UtenteModel(
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
        public bool Prestito { get; set; } = true;
        [BindProperty]
        public bool Scambio { get; set; } = true;
        [BindProperty]
        public bool Interesse { get; set; } = true;


        [BindProperty]
        public string Titolo { get; set; } = "";
        [BindProperty]
        public string Autore { get; set; } = "";

        public string Username { get; set; }

        public List<DAO_UtenteLibro> Utenti { get; set; }

        public async Task<IActionResult> OnGetAsync(string? utente)
        {
            if (string.IsNullOrWhiteSpace(utente) || !int.TryParse(utente, out int key))
                return NotFound();

            Utenti = _context.UtentiLibri.Include("Utente").Include("Utente.Provincia").Where(ul => ul.fkUtente == key).ToList();

            if (Utenti.Count() == 0)
                return NotFound();

            Username = Utenti[0].Utente.Username;

            Utenti = Utenti.Where(ul => (ul.Scambio && Scambio) || (ul.Prestito && Prestito) || (ul.Interesse && Interesse)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? utente)
        {
            if (string.IsNullOrWhiteSpace(utente) || !int.TryParse(utente, out int key))
                return NotFound();

            Utenti = _context.UtentiLibri.Include("Utente").Include("Utente.Provincia").Where(ul => ul.fkUtente == key).ToList();

            if (Utenti.Count() == 0)
                return NotFound();
            
            if (!string.IsNullOrWhiteSpace(Titolo))
            Utenti = Utenti.Where(ul => ul.Titolo.ToUpper().Contains(Titolo.ToUpper())).ToList();
            if (!string.IsNullOrWhiteSpace(Autore))
                Utenti = Utenti.Where(ul =>ul.Autore.ToUpper().Contains(Autore.ToUpper())).ToList();


            Utenti = Utenti.Where(ul => (ul.Scambio && Scambio) || (ul.Prestito && Prestito) || (ul.Interesse && Interesse)).ToList();

            return Page();
        }
    }
}
