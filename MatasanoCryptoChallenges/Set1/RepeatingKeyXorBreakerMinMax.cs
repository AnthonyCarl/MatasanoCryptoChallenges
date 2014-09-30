using System;

namespace MatasanoCryptoChallenges.Set1
{
    public class RepeatingKeyXorBreakerMinMax
    {
        public RepeatingKeyXorBreakerMinMax(int minKeyLength, int maxKeyLength)
        {
            if (minKeyLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minKeyLength", minKeyLength, "Min Key length must at leaset 1.");
            }

            if (maxKeyLength < minKeyLength)
            {
                throw new ArgumentOutOfRangeException("maxKeyLength", maxKeyLength,
                    "Max key length can not be less than min key length.");
            }

            MaxKeyLength = maxKeyLength;

            MinKeyLength = minKeyLength;
        }

        public int MaxKeyLength { get; private set; }


        public int MinKeyLength { get; private set; }
    }
}