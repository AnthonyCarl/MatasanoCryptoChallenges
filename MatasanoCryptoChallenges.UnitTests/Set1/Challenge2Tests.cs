using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MatasanoCryptoChallenges.Set1;
using Xunit;
using Xunit.Extensions;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge2Tests
    {
        [Fact]
        public void ToHex_NUllByte_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge2.ToHex(null));
        }

        [Theory]
        [InlineData((byte)0xff, "ff")]
        [InlineData((byte)0x00, "00")]
        public void ToHex_ValidSingleByte_ValidResults(byte testByte, string result)
        {
            Assert.Equal(result, Challenge2.ToHex(new [] {testByte}));
        }

        [Theory]
        [InlineData("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965", "746865206b696420646f6e277420706c6179")]
        [InlineData("","","")]
        public void HexXor_ValidData_ValidReturn(string hexA, string hexB, string hexResult)
        {
            Assert.Equal(hexResult, Challenge2.HexXor(hexA, hexB));
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException))]
        [InlineData(null, "", typeof(ArgumentNullException))]
        [InlineData("", null, typeof(ArgumentNullException))]
        [InlineData("ff", "ffee", typeof(ArgumentOutOfRangeException))]
        public void HexXor_InvalidInputs_Throws(string hexA, string hexB, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => Challenge2.HexXor(hexA, hexB));
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException))]
        [InlineData(null, 0, typeof(ArgumentNullException))]
        [InlineData(0, null, typeof(ArgumentNullException))]
        [InlineData(0, 1, typeof(ArgumentOutOfRangeException))]
        public void Xor_InvalidData_Throws(int? bytesALength, int? bytesBLenth, Type exceptionType)
        {
            Assert.Throws(exceptionType,
                () =>
                    Challenge2.Xor(GetSequentialByteArrayOrNull(bytesALength), GetSequentialByteArrayOrNull(bytesBLenth)));
        }

        private byte[] GetSequentialByteArrayOrNull(int? length)
        {
            return length.HasValue
                ? Enumerable.Range(0, length.Value).Select(i => (byte)i).ToArray()
                : null;
        }
    }
}