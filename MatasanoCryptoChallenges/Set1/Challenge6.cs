using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge6
    {
        public static Encoding Encoder = Encoding.UTF8;
        public static readonly int[] SetBitCountMap = GenerateSetBitsCountMap();

        private static int[] GenerateSetBitsCountMap()
        {
            var result = new int[byte.MaxValue];
            for (byte currentByte = 0; currentByte < byte.MaxValue; currentByte++)
            {
                result[currentByte] = Enumerable.Range(0, 8).Count(j => IsBitSet(currentByte, j));
            }
            return result;
        }

        private static bool IsBitSet(byte value, int bitNumber)
        {
            return (value & (1 << bitNumber - 1)) != 0;
        }

        public static int HammingDistance(string valueA, string valueB)
        {
            return HammingDistance(Encoder.GetBytes(valueA), Encoder.GetBytes(valueB));
        }

        public static int HammingDistance(byte[] valueA, byte[] valueB)
        {
            if (valueA == null)
            {
                throw new ArgumentNullException("valueA");
            }
            if (valueB == null)
            {
                throw new ArgumentNullException("valueB");
            }
            if (valueA.Length != valueB.Length)
            {
                throw new ArgumentOutOfRangeException("valueA", "Both values must be the same length.");
            }
            var xorValue = Challenge2.Xor(valueA, valueB);
            return xorValue.Sum(x => SetBitCountMap[x]);
        }
    }
}