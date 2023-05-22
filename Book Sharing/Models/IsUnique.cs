using System.ComponentModel.DataAnnotations;

namespace Book_Sharing.Models
{
    public class IsUnique : ValidationAttribute
    {
        private static List<string> _uniqueNames = new List<string>();

        public override bool IsValid(object? value)
        {
            if (value.GetType() != typeof(string))
                return false;

            string usr = (string)value;


            if(_uniqueNames.Contains(usr))return false;

            return true;
        }

    }
}
