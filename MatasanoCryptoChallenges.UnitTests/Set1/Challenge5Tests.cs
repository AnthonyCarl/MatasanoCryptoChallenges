using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge5Tests
    {
        [Fact]
        public void RepeatingKeyXor_ValidData_ValidResult()
        {
            var result = Challenge5.RepeatingKeyXor("ICE", "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal");
            Assert.Equal("0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f", result);
        }

        [Fact]
        public void RepeatingKeyXor_NullSource_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge5.RepeatingKeyXor("key", null));
        }

        [Fact]
        public void RepeatingKeyXor_NullKey_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge5.RepeatingKeyXor(null, "source"));
        }

        [Fact]
        public void RepeatingKeyXor_NullByteSource_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge5.RepeatingKeyXor(new byte[0], null));
        }

        [Fact]
        public void RepeatingKeyXor_NullByteKey_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge5.RepeatingKeyXor(null, new byte[0]));
        }
    }
}