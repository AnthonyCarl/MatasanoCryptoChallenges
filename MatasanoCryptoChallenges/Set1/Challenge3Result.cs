using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge3Result : IChallenge3Result
    {
        private const int CommonLetterFactor = 2;
        private const string PositiveWeightNonWordCharacters = @"\s'";

        //Maybe revisit using this
        //private static readonly Regex PositiveWeight = new Regex(@"[\w" + PositiveWeightNonWordCharacters + @"]",
        //    RegexOptions.Compiled);

        private static readonly Regex NegativeWeightChars = 
            new Regex(@"(?![" + PositiveWeightNonWordCharacters + @"])\W", RegexOptions.Compiled);

        private static readonly char[] EnglishCommonUpperLettersAscending =
        {
            'U', 'C', 'D', 'L', 'H', 'R', 'S', ' ', 'N', 'I', 'O', 'A', 'T', 'E'
        };

        private readonly Lazy<decimal> _weightedLazy;

        public decimal WeightedValue
        {
            get { return _weightedLazy.Value; }
        }

        public byte Key { get; private set; }

        public string DecryptedMessage { get; private set; }

        public Challenge3Result(byte key, string decryptedMessage)
        {
            if (decryptedMessage == null)
            {
                throw new ArgumentNullException("decryptedMessage");
            }

            Key = key;
            DecryptedMessage = decryptedMessage;
            _weightedLazy = new Lazy<decimal>(() => CalculateWeight(DecryptedMessage));
        }

        private static decimal CalculateWeight(string decryptedMessage)
        {
            var commonLetterWeight =
                EnglishCommonUpperLettersAscending
                    .Select((c, i) => decryptedMessage.Count(x => char.ToUpperInvariant(x) == c) * (i + 1) * CommonLetterFactor)
                    .Sum();
            return (commonLetterWeight - NegativeWeightChars.Matches(decryptedMessage).Count) /
                   (decimal) decryptedMessage.Length;
        }
    }
}