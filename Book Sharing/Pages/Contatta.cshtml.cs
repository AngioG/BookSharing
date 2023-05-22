using Book_Sharing.Data;
using Book_Sharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MailKit.Security;

using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis.Differencing;
using Org.BouncyCastle.Ocsp;

namespace Book_Sharing.Pages
{
    [Authorize(Roles = "User")]
    public class ContattaModel : PageModel
    {
        private string text { get; set; } = "</head> <body style='width:100%;font-family:arial, helvetica neue, helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'> <div class='es-wrapper-color' style='background-color:#e8f5e9'><!--[if gte mso 9]> <v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'> <v:fill type='tile' color='#e8f5e9' origin='0.5, 0' position='0.5, 0'></v:fill> </v:background> <![endif]--> <table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#e8f5e9'> <tr> <td valign='top' style='padding:0;Margin:0'> <table cellpadding='0' cellspacing='0' class='es-header' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'> <tr> <td align='center' style='padding:0;Margin:0'> <table bgcolor='#ffffff' class='es-header-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#EAFBA9;width:600px'> <tr> <td class='esdev-adapt-off' align='left' bgcolor='#4caf50' style='padding:40px;Margin:0;background-color:#4caf50'> <table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td class='es-m-p0r' valign='top' align='center' style='padding:0;Margin:0;width:520px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='left' style='padding:0;Margin:0'><h1 style='Margin:0;line-height:26px;mso-line-height-rule:exactly;font-family:arial, helvetica neue, helvetica, sans-serif;font-size:22px;font-style:normal;font-weight:bold;color:#145b18;text-align:center'><strong>BookSharing</strong></h1></td> </tr> </table></td> </tr> </table></td> </tr> </table></td> </tr> </table> <table cellpadding='0' cellspacing='0' class='es-content' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'> <tr> <td align='center' style='padding:0;Margin:0'> <table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px'> <tr> <td align='left' bgcolor='#a5d6a7' style='padding:0;Margin:0;padding-top:20px;padding-left:40px;padding-right:40px;background-color:#a5d6a7'> <table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' valign='top' style='padding:0;Margin:0;width:520px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='left' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'>Hai ricevuto una richiesta riguardante il libro <b>*Titolo*</b> di <b>*Autore*</b></p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'>L\'utente *Username* *Frase*</p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'><br></p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'></p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'>*Note*</p></td> </tr> </table></td> </tr> </table></td> </tr> </table></td> </tr> </table> <table class='es-content' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'> <tr> <td align='center' style='padding:0;Margin:0'> <table class='es-content-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#ffffff;width:600px' cellspacing='0' cellpadding='0' bgcolor='#ffffff' align='center'> <tr> <td align='left' bgcolor='#a5d6a7' style='Margin:0;padding-top:10px;padding-bottom:10px;padding-left:40px;padding-right:40px;background-color:#a5d6a7'> <table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td class='es-m-p0r' valign='top' align='center' style='padding:0;Margin:0;width:520px'> <table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' class='es-m-p0r es-m-p0l' style='padding:0;Margin:0;padding-left:40px;padding-right:40px;font-size:0px'><img class='adapt-img' src='*Copertina*' alt='Copertina' style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic;font-size:12px' width='420' title='Copertina'></td> </tr> </table></td> </tr> </table></td> </tr> <tr> <td align='left' bgcolor='#a5d6a7' style='padding:0;Margin:0;padding-bottom:30px;padding-left:40px;padding-right:40px;background-color:#a5d6a7'><!--[if mso]><table style='width:520px' cellpadding='0' cellspacing='0'><tr><td style='width:180px' valign='top'><![endif]--> <table cellpadding='0' cellspacing='0' class='es-left' align='left' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left'> <tr> <td class='es-m-p20b' align='left' style='padding:0;Margin:0;width:180px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' class='es-m-p0l' style='padding:0;Margin:0;padding-top:20px;padding-bottom:20px;padding-left:40px;font-size:0'> <table border='0' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td style='padding:0;Margin:0;border-bottom:2px solid #538d22;background:unset;height:1px;width:100%;margin:0px'></td> </tr> </table></td> </tr> </table></td> </tr> </table><!--[if mso]></td><td style='width:20px'></td><td style='width:320px' valign='top'><![endif]--> <table cellpadding='0' cellspacing='0' class='es-right' align='right' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right'> <tr> <td align='left' style='padding:0;Margin:0;width:320px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='right' class='es-m-txt-c es-m-p0r' style='padding:0;Margin:0;padding-top:5px;padding-bottom:5px;padding-right:40px'><h2 style='Margin:0;line-height:34px;mso-line-height-rule:exactly;font-family:arizonia, cursive;font-size:28px;font-style:normal;font-weight:normal;color:#143601'>*Titolo*</h2></td> </tr> </table></td> </tr> </table><!--[if mso]></td></tr></table><![endif]--></td> </tr> </table></td> </tr> </table> <table cellpadding='0' cellspacing='0' class='es-content' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'> <tr> <td align='center' style='padding:0;Margin:0'> <table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px'> <tr> <td align='left' bgcolor='#a5d6a7' style='padding:0;Margin:0;padding-top:20px;padding-left:40px;padding-right:40px;background-color:#a5d6a7'> <table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' valign='top' style='padding:0;Margin:0;width:520px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='left' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'>Puoi contattarlo alla mail <b>*Email*</b><br></p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Sora, Arial, sans-serif;line-height:23px;color:#143601;font-size:15px'>Se vuoi puoi vedere <a href='https://booksharing.azurewebsites.net/Utente?utente=*pkUtente*' >i suoi interessi qui</a></p></td> </tr> </table></td> </tr> </table></td> </tr> </table></td> </tr> </table> <table cellpadding='0' cellspacing='0' class='es-footer' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'> <tr> <td align='center' style='padding:0;Margin:0'> <table bgcolor='#a5d6a7' class='es-footer-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#a5d6a7;width:600px'> <tr> <td align='left' style='padding:0;Margin:0;padding-left:40px;padding-right:40px'> <table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' valign='top' style='padding:0;Margin:0;width:520px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' class='es-m-p0r es-m-p0l' style='Margin:0;padding-top:30px;padding-bottom:30px;padding-left:40px;padding-right:40px;font-size:0'> <table border='0' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td style='padding:0;Margin:0;border-bottom:2px solid #538d22;background:unset;height:1px;width:100%;margin:0px'></td> </tr> </table></td> </tr> </table></td> </tr> </table></td> </tr> <tr> <td align='left' style='padding:0;Margin:0;padding-bottom:40px;padding-left:40px;padding-right:40px'><!--[if mso]><table style='width:520px' cellpadding='0' cellspacing='0'><tr><td style='width:40px' valign='top'><![endif]--> <table cellpadding='0' cellspacing='0' align='left' class='es-left' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left'> <tr class='es-mobile-hidden'> <td class='es-m-p20b' align='center' valign='top' style='padding:0;Margin:0;width:40px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td align='center' height='10' style='padding:0;Margin:0'></td> </tr> </table></td> </tr> </table><!--[if mso]></td><td style='width:10px'></td><td style='width:470px' valign='top'><![endif]--> <table cellpadding='0' cellspacing='0' class='es-right' align='right' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right'> <tr> <td align='left' style='padding:0;Margin:0;width:470px'> <table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr> <td style='padding:0;Margin:0'> <table cellpadding='0' cellspacing='0' class='es-menu' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'> <tr class='links'> <td align='center' valign='top' id='esd-menu-id-0' style='padding:0;Margin:0;padding-top:10px;padding-bottom:10px;padding-right:15px;border:0'><a target='_blank' href='https://booksharing.azurewebsites.net/' style='-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;display:block;font-family:Sora, Arial, sans-serif;color:#143601;font-size:12px'>Visita il sito</a></td> <td align='center' valign='top' id='esd-menu-id-1' style='Margin:0;padding-top:10px;padding-bottom:10px;padding-left:15px;padding-right:15px;border:0'><a target='_blank' href='https://booksharing.azurewebsites.net/Utente?utente=*mioPkUtente*' style='-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;display:block;font-family:Sora, Arial, sans-serif;color:#143601;font-size:12px'>Il tuo account</a></td> <td align='center' valign='top' id='esd-menu-id-2' style='padding:0;Margin:0;padding-top:10px;padding-bottom:10px;padding-left:15px;border:0'><a target='_blank' href='https://booksharing.azurewebsites.net/Identity/Account/Manage/DeletePersonalData' style='-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;display:block;font-family:Sora, Arial, sans-serif;color:#143601;font-size:12px'>Elimina account</a></td> </tr> </table></td> </tr> </table></td> </tr> </table><!--[if mso]></td></tr></table><![endif]--></td> </tr> </table></td> </tr> </table></td> </tr> </table> </div> </body> </html>";


        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataDbContext _context;
        private readonly UserDbContext _users;
        public AuthMessageSenderOptions Options { get; }
        public ContattaModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        DataDbContext dbc,
        UserDbContext udb,
        IOptions<AuthMessageSenderOptions> optionsAccessor
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbc;
            _users = udb;
            Options = optionsAccessor.Value;
        }
        public DAO_UtenteLibro UtenteLibro { get; set; }
        [BindProperty]
        public int Modalità { get; set; }
        [BindProperty]
        public string Descrizione { get; set; }
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || !int.TryParse(id, out int key))
                return NotFound();
            UtenteLibro = await _context.UtentiLibri.Include("Utente").FirstOrDefaultAsync(ul => ul.Id == key);
            if (UtenteLibro == null)
                return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null || !int.TryParse(id, out int key))
                return NotFound();
            UtenteLibro = await _context.UtentiLibri.Include("Utente").FirstOrDefaultAsync(ul => ul.Id == key);
            if (UtenteLibro == null)
                return NotFound();
            var MessaggioInviare = new MimeMessage();
            var IdentityUser = await _userManager.GetUserAsync(User);
            var DatiDestinatario = await _context.Utenti.Include("Provincia").FirstOrDefaultAsync(u => u.IdentityUid == IdentityUser.Id);
            if (DatiDestinatario == null)
                return RedirectToPage("Error");
            MessaggioInviare.From.Add(new MailboxAddress(DatiDestinatario.Username, "booksharing.contatta@gmail.com"));
            var Destinatario = await _users.Users.FirstOrDefaultAsync(u => u.Id == UtenteLibro.Utente.IdentityUid);
            if (Destinatario == null)
                return RedirectToPage("Error");
            MessaggioInviare.To.Add(new MailboxAddress(UtenteLibro.Utente.Nome + " " + UtenteLibro.Utente.Cognome, Destinatario.Email));
            MessaggioInviare.Subject = "Richiesta su " + UtenteLibro.Titolo;
            string mode = "";
            switch (Modalità)
            {
                case 0:
                    {
                        return Page();
                    }
                case 1:
                    {
                        mode = "vorrebbe scambiarti il libro";
                        break;
                    }
                case 2:
                    {
                        mode = "vorrebbe prestarti il libro!";
                        break;
                    }
                case 3:
                    {
                        mode = "vorrebbe prestarti o scambiarti il libro!";
                        break;
                    }
                case 4:
                    {
                        mode = "vorrebbe ricevere il libro in prestito!";
                        break;
                    }
                case 5:
                    {
                        mode = "vorrebbe ricevere il libro in cambio di un altro!";
                        break;
                    }
            }
            HttpClient httpClient = new HttpClient();
            string url = $"https://www.googleapis.com/books/v1/volumes/{UtenteLibro.IdLibro}?key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
            var result = httpClient.GetAsync(url).Result;
            if (!result.IsSuccessStatusCode)
            {
                return RedirectToPage("./Error");
            }
            var jsonString = result.Content.ReadAsStringAsync().Result;
            var BookData = JsonConvert.DeserializeObject<BookRoot>(jsonString);

            var DatiMittente = await _context.Utenti.FirstOrDefaultAsync(u => u.IdentityUid == IdentityUser.Id);
            if(DatiMittente == null)
                return RedirectToPage("./Error");

            string note = string.IsNullOrWhiteSpace(Descrizione) ? "Lui non ha lasciato alcuna nota, sta a te contattarlo!" : $"Ecco cosa ha scritto:<br>{Descrizione}";
            text = text.Replace("*Titolo*", UtenteLibro.Titolo).Replace("*Autore*", UtenteLibro.Autore).Replace("*Frase*", mode).Replace("*Username*", DatiMittente.Username).Replace("*Copertina*", BookData.volumeInfo.imageLinks.thumbnail).Replace("*Email*", IdentityUser.Email).Replace("*Note*", note).Replace("*mioPkUtente*", DatiMittente.PkUtente.ToString()).Replace("*pkUtente*", DatiDestinatario.PkUtente.ToString());

            MessaggioInviare.Body = new TextPart("html")
            {
                Text = text
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("booksharing.contatta@gmail.com", "pcsspbrogtamvgou"/*Options.ContactPsw*/);
                client.Send(MessaggioInviare);
                client.Disconnect(true);
            }
            return RedirectToPage("Index");
        }
    }
}
