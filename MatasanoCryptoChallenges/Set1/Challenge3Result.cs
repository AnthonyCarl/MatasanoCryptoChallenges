using System;
using System.Text.RegularExpressions;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge3Result
    {
        private static readonly Regex PositiveWeight = new Regex(@"[\w ']", RegexOptions.Compiled);
        private static readonly Regex NegativeWeight = new Regex(@"(?![ '])\W", RegexOptions.Compiled);

        private readonly Lazy<int> _weightedLazy;

        public int WeightedValue { get { return _weightedLazy.Value; } }

        public byte Key { get; private set; }

        public string DecryptedMessage { get; private set; }

        public Challenge3Result(byte key, string decryptedMessage)
        {
            if (decryptedMessage == null)
            {
                throw new ArgumentNullException(decryptedMessage);
            }

            Key = key;
            DecryptedMessage = decryptedMessage;
            _weightedLazy =
                new Lazy<int>(
                    () =>
                        PositiveWeight.Matches(DecryptedMessage).Count - NegativeWeight.Matches(DecryptedMessage).Count);
        }
    }
}