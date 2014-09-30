using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;
using Xunit.Extensions;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge1Tests
    {
        [Fact]
        public void ByteHexToBase64_NullString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge1.ByteHexToBase64(null));
        }

        [Fact]
        public void ByteHexToByteArray_OddLengthString_Throws()
        {
            Assert.Throws<ArgumentException>(() => Challenge1.ByteHexToByteArray("thisIsOdd"));
        }

        [Theory]
        [InlineData("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d",
            "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        [InlineData("", "")]
        [InlineData("FF", "/w==")]
        [InlineData("FFFF", "//8=")]
        public void ByteHexToBase64_ValidString_ValidBase64(string hexInput, string base64Output)
        {
            var actualBase64 = Challenge1.ByteHexToBase64(hexInput);
            Assert.Equal(base64Output, actualBase64);
        }

        [Theory]
        [InlineData(
            "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t")]
        [InlineData("")]
        [InlineData("/w==")]
        [InlineData("//8=")]
        public void RoundtripBase64_EmptyString_EmptyBase64(string base64input)
        {
            var actual =  Challenge1.ToBase64(Challenge1.ToBytes(base64input));
           
            Assert.Equal(base64input, actual);
        }

        [Fact]
        public void ToByte_ArrayWithOneChar_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Challenge1.ToByte(new char[1]));
        }

        [Fact]
        public void ToByte_NullArray_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge1.ToByte(null));
        }

        [Fact]
        public void ToByte_InvalidHexCharsArray_Throws()
        {
            Assert.Throws<ArgumentException>(() => Challenge1.ToByte('Y', 'u'));
        }

        [Fact]
        public void ToByte_UppercaseValidHexCharsArray_Throws()
        {
            Assert.Equal(0xFF, Challenge1.ToByte('F', 'F'));
        }

        [Fact]
        public void ToBytes_NullString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge1.ToBytes(null));
        }

        [Theory]
        [InlineData("//8")]
        [InlineData("/w")]
        public void ToBytes_UnPaddedBase64_Throws(string unPaddedBase64)
        {
            Assert.Throws<ArgumentException>(() => Challenge1.ToBytes(unPaddedBase64));
        }
    }
}
