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

    public class Challenge2Test
    {
        [Theory]
        [InlineData("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965", "746865206b696420646f6e277420706c6179")]
        public void HexXor_ValidData_ValidReturn(string hexA, string hexB, string hexResult)
        {
            Assert.Equal(hexResult, Challenge2.HexXor(hexA, hexB));
        }
    }
}
