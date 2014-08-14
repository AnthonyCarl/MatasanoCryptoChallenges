using System;
using System.Diagnostics.CodeAnalysis;
using MatasanoCryptoChallenges.Set1;
using Xunit;

namespace MatasanoCryptoChallenges.UnitTests.Set1
{
    [ExcludeFromCodeCoverage]
    public class Challenge3ResultTests
    {
        [Fact]
        public void Constructor_NullHexString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Challenge3Result(0x00, null));
        }
    }
}