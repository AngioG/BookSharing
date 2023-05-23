using Book_Sharing.Data;
using Book_Sharing.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Book_Sharing.Pages
{
    public class LibriModel : PageModel
    {
        private readonly DataDbContext _context;
        public List<Item> Libri { get; set; }
        public List<BookRoot> MostRead { get; set; }

        public LibriModel(DataDbContext dbc)
        {
            _context = dbc;
        }

        [BindProperty]
        public string Titolo { get; set; }
        [BindProperty]
        public string Autore { get; set; }
        [BindProperty]
        public string Genere { get; set; }
        [BindProperty]
        public int Pagina { get; set; } = 1;

        public int Risultati { get; private set; }

        public async Task<IActionResult> OnGetAsync(string? titolo, string? autore, int? pagina)
        {
            if (titolo != null)
                Titolo = titolo;
            if (autore != null)
                Autore = autore;
            if (pagina != null)
                Pagina = (int)pagina;
            string parametri = "";


            if (!string.IsNullOrWhiteSpace(Titolo)/* && Titolo != "Titolo..."*/)
                parametri += $"intitle:{Titolo}";

            if (!string.IsNullOrWhiteSpace(Autore)/* && Autore != "Autore..."*/)
            {
                if (!string.IsNullOrWhiteSpace(parametri))
                    parametri += "+";
                parametri += $"inauthor:{Autore}";
            }

            /*if (!string.IsNullOrWhiteSpace(Genere) && Genere != "Qualsiasi")
            {
                if (!string.IsNullOrWhiteSpace(parametri))
                    parametri += "+";
                parametri += $"insubject:{Autore}";
            }*/

            HttpClient client = new HttpClient();

            if (!string.IsNullOrWhiteSpace(parametri))
            {
                string url = $"https://www.googleapis.com/books/v1/volumes?q={parametri}&langRestrict=it&orderBy=relevance&printType=books&startIndex={(Pagina - 1) * 9}&maxResults=12&key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
                var result = client.GetAsync(url).Result;

                if (!result.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Error");
                }

                var jsonString = result.Content.ReadAsStringAsync().Result;


                var root = JsonConvert.DeserializeObject<Root>(jsonString);

                Libri = root.items;
                Risultati = root.totalItems;
            }

            else
            {
                MostRead = new List<BookRoot>();

                var Libri = _context.UtentiLibri.GroupBy(ul => ul.IdLibro).Select(ul =>
                new
                {
                    libro = ul.Key,
                    count = ul.Count()
                }).OrderByDescending(ul => ul.count).ToList();

                for(int i = 0; i < 3 &&  i < Libri.Count; i++)
                {
                    string url = $"https://www.googleapis.com/books/v1/volumes/{Libri[i].libro}?key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
                    var result = client.GetAsync(url).Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        return RedirectToPage("./Error");
                    }

                    var jsonString = result.Content.ReadAsStringAsync().Result;
                    var Result = JsonConvert.DeserializeObject<BookRoot>(jsonString);

                    if(Result != null)
                    MostRead.Add(Result);
                }
            }

            
            /*string url = $"https://www.googleapis.com/books/v1/volumes?q={parametri}&langRestrict=it&orderBy=relevance&printType=books&startIndex={(Pagina-1) * 9}&maxResults=12&key=AIzaSyDUteNVYjQSg0tod6yuUwYy2IXlfXI2ZB8";
            var result = client.GetAsync(url).Result;

            if (!result.IsSuccessStatusCode)
            {
                return RedirectToPage("./Error");
            }

            var jsonString = result.Content.ReadAsStringAsync().Result;


            var root = JsonConvert.DeserializeObject<Root>(jsonString);

            Libri = root.items;
            Risultati = root.totalItems;*/


            return Page();
        }
    }
}
