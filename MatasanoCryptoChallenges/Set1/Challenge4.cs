using System;
using System.Linq;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge4
    {
        public static Challenge4Result GetBestGuessSingleByteEncryptedHex(string[] encryptedHexData)
        {
            if (encryptedHexData == null)
            {
                throw new ArgumentNullException("encryptedHexData");
            }
            var bestGuess =
                encryptedHexData.AsParallel()
                    .Select(x => new Challenge4Result(x, Challenge3.GetBestGuessSingleByteXorKey(x)))
                    .Aggregate((x, y) => x.WeightedValue > y.WeightedValue ? x : y);
            return bestGuess;
        }
    }
}