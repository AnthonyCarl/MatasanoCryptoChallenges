using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge3Tests
    {
        [Fact]
        public void GetBestGuessSingleByteXorKey_ValidHex_CorrectKey()
        {
            var result = Challenge3.GetBestGuessSingleByteXorKey("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736");
            Assert.Equal(0X58, result.Key);
        }

        [Fact]
        public void GetBestGuessSingleByteXorKey_Challenge5Data_CorrectKey()
        {
            int keyLength = 3;
            var hexModulo = keyLength * 2;
            var someKey = Challenge5Data.EncryptedHexValue
                .Select((c, i) => new { ByteNumber = (i % hexModulo) / 2, c })
                .GroupBy(c => c.ByteNumber)
                .Select(
                    g =>
                        Challenge3.GetBestGuessSingleByteXorKey(new string(g.Select(x => x.c).ToArray())).Key);
            var key = Encoding.UTF8.GetString(someKey.ToArray());

            Assert.Equal(Challenge5Data.Key, key);
        }

        [Fact]
        public void GetBestGuessSingleByteXorKey_NullByteArray_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge3.GetBestGuessSingleByteXorKey((byte[])null));
        }

        [Fact]
        public void GetBestGuessSingleByteXorKey_EmptyByteArray_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Challenge3.GetBestGuessSingleByteXorKey(new byte[0]));
        }
    }
}