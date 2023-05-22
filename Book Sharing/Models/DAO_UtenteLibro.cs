using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Sharing.Models
{
    public class DAO_UtenteLibro
    {
        [Key]
        public int Id { get; set; } 


        [Required]
        public string IdLibro { get; set; }

        public string Titolo { get; set; }
        public string Autore { get; set; }

        public bool Prestito { get; set; }
        public bool Scambio { get; set; }
        public bool Interesse { get; set; }


        [Required]
        public int fkUtente { get; set; }
        public DAO_Utente Utente { get; set; }
    }
}
