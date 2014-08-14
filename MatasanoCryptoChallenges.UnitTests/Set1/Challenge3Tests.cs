using System.Diagnostics.CodeAnalysis;
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
    }
}