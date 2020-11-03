using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Helpers
{
    public class HashingHelper
    {
        public static string CalculateSHA256Hash(string text)
        {
            using(var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }
    }
}
