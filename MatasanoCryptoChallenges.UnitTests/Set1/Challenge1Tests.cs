using System;
using MatasanoCryptoChallenges.Set1;
using Xunit;
using Xunit.Extensions;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    public class Challenge1Tests
    {
        [Theory]
        [InlineData("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d",
            "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        [InlineData("", "")]
        public void ByteHexToBase64_EmptyString_EmptyBase64(string hexInput, string base64Output)
        {
            var actualBase64 = Challenge1.ByteHexToBase64(hexInput);
            Assert.Equal(base64Output, actualBase64);
        }

        [Fact]
        public void ByteHexToBase64_NullString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge1.ByteHexToBase64(null));
        }
    }
}
