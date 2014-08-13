using System;
using System.IO;
using System.Linq;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge1
    {
        public static byte[] FromHex(string hex)
        {
            if (hex == null)
            {
                throw new ArgumentNullException();
            }

            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string length must be an even number.");
            }

            var byteArray = new byte[hex.Length / 2];

            using (var sr = new StringReader(hex))
            {
                var buffer = new char[2];
                
                for (int i = 0; i < byteArray.Length; i++)
                {
                    sr.Read(buffer, 0, 2);
                    byteArray[i] = Convert.ToByte(new string(buffer), 16);
                }
            }

            return byteArray;
        }

        public static string ByteHexToBase64(string hex)
        {
            var byteArray = FromHex(hex);
            var base64 = Convert.ToBase64String(byteArray);
            return base64;
        }
    }
}
