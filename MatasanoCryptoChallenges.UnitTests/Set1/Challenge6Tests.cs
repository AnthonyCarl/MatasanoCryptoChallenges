using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge6Tests
    {
        [Fact]
        public void HammingDistance_ValidData_CorrectDistance()
        {
            var actualDistance = Challenge6.HammingDistance("this is a test", "wokka wokka!!!");
            Assert.Equal(37, actualDistance);
        }

        [Fact]
        public void HammingDistance_NullValueA_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge6.HammingDistance(null, new byte[0]));
        }

        [Fact]
        public void HammingDistance_NullValueB_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Challenge6.HammingDistance(new byte[0], null));
        }

        [Fact]
        public void HammingDistance_MismatchByteArraySizes_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Challenge6.HammingDistance(new byte[0], new byte[1]));
        }
    }
}