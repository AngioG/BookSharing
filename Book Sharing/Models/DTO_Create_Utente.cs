using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class DTO_Create_Utente
    {
        [Required, IsUnique(ErrorMessage = "Questo username è già in uso"), UsernameLenght(ErrorMessage = "Il nome utente deve essere lungo da tre a 20 caratteri")]
        public string Username { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public string Provincia { get; set; }

        [Required]
        public int CAP { get; set; }

        public bool Exists { get; set; } = false;

        public DTO_Create_Utente()
        {

        }

        public DTO_Create_Utente(DAO_Utente dati)
        {
            Username = dati.Username;
            Nome = dati.Nome;
            Cognome = dati.Cognome;
            Provincia = dati.Provincia.Nome;
            CAP = int.Parse(dati.CAP);
        }
    }
}
