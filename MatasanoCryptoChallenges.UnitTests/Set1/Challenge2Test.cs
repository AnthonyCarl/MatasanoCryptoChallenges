using MatasanoCryptoChallenges.Set1;
using Xunit;
using Xunit.Extensions;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    public class Challenge2Test
    {
        [Theory]
        [InlineData("1c0111001f010100061a024b53535009181c", "686974207468652062756c6c277320657965", "746865206b696420646f6e277420706c6179")]
        [InlineData("","","")]
        public void HexXor_ValidData_ValidReturn(string hexA, string hexB, string hexResult)
        {
            Assert.Equal(hexResult, Challenge2.HexXor(hexA, hexB));
        }
    }
}