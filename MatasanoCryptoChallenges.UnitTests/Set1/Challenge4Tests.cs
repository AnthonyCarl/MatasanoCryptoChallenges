using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge4Tests
    {
        [Fact]
        public void GetBestGuessSingleByteEncryptedHex_ValidData_CorrectEncryptedHex()
        {
            var bestGuess = Challenge4.GetBestGuessSingleByteEncryptedHex(Challenge4Data.Data);
            Assert.Equal("7b5a4215415d544115415d5015455447414c155c46155f4058455c5b523f", bestGuess.Hex);
        }

        [Fact]
        public void GetBestGuessSingleByteEncryptedHex_NullData_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge4.GetBestGuessSingleByteEncryptedHex(null));
        }
    }
}