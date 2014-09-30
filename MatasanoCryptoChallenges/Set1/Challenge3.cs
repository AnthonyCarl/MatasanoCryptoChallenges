using System;
using System.Linq;
using System.Text;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge3
    {
        public static Challenge3Result GetBestGuessSingleByteXorKey(string hex)
        {
            var source =
                Challenge1.ByteHexToByteArray(hex);

            return GetBestGuessSingleByteXorKey(source);
        }

        public static Challenge3Result GetBestGuessSingleByteXorKey(byte[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Length == 0)
            {
                throw new ArgumentOutOfRangeException("source", "Byte array should not be empty.");
            }
            var bestGuess =
                Enumerable.Range(0, byte.MaxValue + 1)
                    .Select(x => GetResult(source, (byte) x))
                    .Aggregate((x, y) => x.WeightedValue > y.WeightedValue ? x : y);

            return bestGuess;
        }

        private static Challenge3Result GetResult(byte[] source, byte key)
        {
            var decryptedMessage = Encoding.UTF8.GetString(Array.ConvertAll(source, b => (byte) (b ^ key)));
            return new Challenge3Result(key, decryptedMessage);
        }
    }
}
