using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;
using Xunit.Extensions;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class RepeatingKeyXorBreakerMinMaxTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(300)]
        public void Constructor_InvalidMinValue_Throws(int minValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RepeatingKeyXorBreakerMinMax(minValue, 11));
        }

        [Fact]
        public void Constructor_MinMaxSameValue_Created()
        {
            Assert.NotNull(new RepeatingKeyXorBreakerMinMax(2, 2));
        }

        [Fact]
        public void MaxKeyLength_ValidValue_ValueSet()
        {
            const int expectedMaxValue = 11;
            var minMax = new RepeatingKeyXorBreakerMinMax(expectedMaxValue - 1, expectedMaxValue);
            Assert.Equal(expectedMaxValue, minMax.MaxKeyLength);
        }

        [Fact]
        public void MinKeyLength_ValidValue_ValueSet()
        {
            const int expectedMinValue = 2;
            var minMax = new RepeatingKeyXorBreakerMinMax(expectedMinValue, expectedMinValue + 1);
            Assert.Equal(expectedMinValue, minMax.MinKeyLength);
        }
    }
}