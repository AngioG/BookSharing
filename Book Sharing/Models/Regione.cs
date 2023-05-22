using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class Regione
    {
        [Key]
        public int PkRegione { get; set; }

        public string Nome { get; set; }
        public ICollection<Provincia> Province { get; set; }
    }
}
