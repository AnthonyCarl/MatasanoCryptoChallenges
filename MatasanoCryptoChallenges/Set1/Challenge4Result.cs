using System;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge4Result
    {
        private readonly IChallenge3Result _result;

        public byte Key
        {
            get { return _result.Key; }
        }

        public string DecryptedMessage
        {
            get { return _result.DecryptedMessage; }
        }

        public decimal WeightedValue
        {
            get { return _result.WeightedValue; }
        }

        public string Hex { get; private set; }

        public Challenge4Result(string hex, IChallenge3Result result)
        {
            if (hex == null)
            {
                throw new ArgumentNullException("hex");
            }
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }
            Hex = hex;
            _result = result;
        }
    }
}