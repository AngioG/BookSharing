// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Book_Sharing.Data;
using Book_Sharing.Models;
using Book_Sharing.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace Book_Sharing.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Pending,User")]

    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly AuthenticationManager authenticationManager;
        //private readonly RoleManager<IdentityUser> _roleManager;
        private readonly DataDbContext _context;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            //RoleManager<IdentityUser> roleManager,
            SignInManager<IdentityUser> signInManager,
            DataDbContext dbc
            )
        {

            _userManager = userManager;
            //_roleManager = roleManager;
            _signInManager = signInManager;
            _context = dbc;
           

            Regioni = _context.Regioni.ToList();
            Province = _context.Province.ToList();
        }

        [BindProperty]
        public string Regione { get; set; }
        public List<Regione> Regioni { get; set; }


        [BindProperty]
        public string Modifica { get; set; } = "true";

        public List<Provincia> Province { get; set; }

        [BindProperty]
        public DTO_Create_Utente Utente { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            //Controlla che i dati passati dall'utente siano coerenti con quelli richiesti nei decoratori
            /*if (!ModelState.IsValid)
            {
                //mostra il cshtml relativo a questa classe
                return Page();
            }*/




            var utente = await _userManager.GetUserAsync(User);
            var Dati_utente = await _context.Utenti.Include("Provincia").FirstOrDefaultAsync(u => u.IdentityUid == utente.Id);

            if (Dati_utente != null)
            {
                Utente = new DTO_Create_Utente(Dati_utente);
                Regione = Regioni.Where(r => r.Province.Contains(Dati_utente.Provincia)).FirstOrDefault().Nome;
                Utente.Exists = true;
            }
            else
                Utente = new DTO_Create_Utente();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Regione != null)
            {
                Province = _context.Province.Include("Regione").Where(p => p.Regione.Nome == Regione).ToList();
            }

            if (Modifica == "false")
            {
                Modifica = "true";
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var utenteIdentity = await _userManager.GetUserAsync(User);
            var Dati_utente = await _context.Utenti.Include("Provincia").FirstOrDefaultAsync(u => u.IdentityUid == utenteIdentity.Id);

            if (Dati_utente != null)
            {
                Dati_utente.Username = Utente.Username;
                Dati_utente.Nome = Utente.Nome;
                Dati_utente.Cognome = Utente.Cognome;
                Dati_utente.CAP = Utente.CAP.ToString("00000");
                Dati_utente.fkProvincia = (await _context.Province.FirstOrDefaultAsync(p => p.Nome == Utente.Provincia)).PkProvincia;

                _context.Utenti.Attach(Dati_utente).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return Page();
                }

            }
            else
            {
                Dati_utente = new DAO_Utente(Utente);
                Dati_utente.fkProvincia = (await _context.Province.FirstOrDefaultAsync(p => p.Nome == Utente.Provincia)).PkProvincia;
                Dati_utente.IdentityUid = utenteIdentity.Id;



                await _context.AddAsync(Dati_utente);
                await _context.SaveChangesAsync();


                //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                //var userId =  (await _userManager.GetUserAsync(User)).Id;

                await _userManager.AddToRoleAsync(utenteIdentity, "User");

                //var authenticationManager = HttpContext.AuthenticateAsync(userId);//.GetOwinContext().Authentication;


                await _signInManager.SignOutAsync();

                //var user = await  _userManager.FindByIdAsync(userId);

                await _signInManager.SignInAsync(utenteIdentity, false);

                //authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                
            }


            return RedirectToPage("../../Index");
        }
    }
}

