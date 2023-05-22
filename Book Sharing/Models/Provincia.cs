using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class Provincia
    {
        [Key]
        public int PkProvincia { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int fkRegione { get;set; }
        public Regione Regione { get; set; }

        public ICollection<DAO_Utente> Utenti { get; set; }
    }
}
