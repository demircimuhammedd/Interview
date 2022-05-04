using System.Text;

namespace Interview.Application.Commons.Helpers
{
    public class PasswordEncryptHelper
    {
        public static string GeneratePassword(string password)
        {
            using var MD5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] outputBytes = MD5.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }
    }
}
