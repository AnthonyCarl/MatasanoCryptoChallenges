using System;
using System.Linq;
using System.Text;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge2
    {
        private const string HexadecimalFormatSpecifier = "x2";

        private static readonly string[] HexMap =
            Enumerable.Range(0, 256).Select(v => v.ToString(HexadecimalFormatSpecifier)).ToArray();

        public static string HexXor(string hexA, string hexB)
        {
            if (hexA == null)
            {
                throw new ArgumentNullException("hexA");
            }
            if (hexB == null)
            {
                throw new ArgumentNullException("hexB");
            }
            if (hexA.Length != hexB.Length)
            {
                throw new ArgumentOutOfRangeException("hexA", "both hex strings must be the same length.");
            }

            var bytesA = Challenge1.FromHex(hexA);
            var bytesB = Challenge1.FromHex(hexB);

            var xorBytes = Xor(bytesA, bytesB);
            var hexResult = ToHex(xorBytes);
            
            return hexResult;
        }

        public static byte[] Xor(byte[] bytesA, byte[] bytesB)
        {
            if (bytesA == null)
            {
                throw new ArgumentNullException("bytesA");
            }
            if (bytesB == null)
            {
                throw new ArgumentNullException("bytesB");
            }
            if (bytesA.Length != bytesB.Length)
            {
                throw new ArgumentOutOfRangeException("bytesA", "Both input values must be the same length.");
            }
            
            var xorBytes = new byte[bytesA.Length];
            
            for (int i = 0; i < bytesA.Length; i++)
            {
                xorBytes[i] = (byte)(bytesA[i] ^ bytesB[i]);
            }
            return xorBytes;
        }

        public static string ToHex(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            var s = new StringBuilder(bytes.Length*2);
            Array.ForEach(bytes, b => s.Append(HexMap[b]));

            return s.ToString();
        }

        //First hit is slow, subsequent usage is much faster than doing ToString("x2") on a byte everytime
    }
}
