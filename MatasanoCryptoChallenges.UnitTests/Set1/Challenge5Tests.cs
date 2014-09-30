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
            var result = Challenge5.RepeatingKeyXor(Challenge5Data.Key, Challenge5Data.DecryptedValue);
            Assert.Equal(Challenge5Data.EncryptedHexValue, result);
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