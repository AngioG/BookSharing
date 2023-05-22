using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class DAO_Utente
    {
        [Key]
        public int PkUtente { get; set; }

        [Required, IsUnique(ErrorMessage = "Questo username è già in uso"), UsernameLenght(ErrorMessage = "Il nome utente deve essere lungo da tre a 20 caratteri")]
        public string Username { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required, StringLength(5, MinimumLength = 5)]
        public string CAP { get; set; }

        [Required]
        public int fkProvincia { get; set; }
        public Provincia Provincia { get; set; }

        [Required]
        public string IdentityUid { get; set; }

        public ICollection<DAO_UtenteLibro> Posseduti { get; }

        public DAO_Utente()
        {

        }

        public DAO_Utente(DTO_Create_Utente dati)
        {
            Username = dati.Username;
            Nome = dati.Nome;
            Cognome = dati.Cognome;
            CAP = dati.CAP.ToString("00000");

        }
    }
}
