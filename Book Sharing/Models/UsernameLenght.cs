using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class UsernameLenght : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value.GetType() != typeof(string))
                return false;

            string usr = (string)value;


            if (usr.Length < 4 || usr.Length > 20)
                return false;

            return true;
        }

    }
}
