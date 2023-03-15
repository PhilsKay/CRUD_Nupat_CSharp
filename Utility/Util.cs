using System.Text.RegularExpressions;

namespace Nupat_CSharp.Utility
{
    public static class Util
    {

        public static bool IsValidEmail(string email)
        {
            if (email != null)
            {
                return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                    && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
            }

            return false;
        }
    }
}
