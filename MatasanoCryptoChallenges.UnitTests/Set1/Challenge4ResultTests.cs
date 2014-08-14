using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge4ResultTests
    {
        [Fact]
        public void Constructor_NullHex_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Challenge4Result(null, new Challenge3Result(0x00, string.Empty)));
        }

        [Fact]
        public void Constructor_NullResult_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Challenge4Result(string.Empty, null));
        }

        [Fact]
        public void Key_ValidKeyOnResult_SameKey()
        {
            const byte expectedKey = 0x88;
            var result = new Challenge4Result(string.Empty, new Challenge3Result(expectedKey, string.Empty));
            Assert.Equal(expectedKey, result.Key);
        }

        [Fact]
        public void DecryptedMessage_ValidKeyOnResult_SameKey()
        {
            const string expectedDecryptedMessage = "yo";
            var result = new Challenge4Result(string.Empty, new Challenge3Result(0x00, expectedDecryptedMessage));
            Assert.Equal(expectedDecryptedMessage, result.DecryptedMessage);
        }
    }
}