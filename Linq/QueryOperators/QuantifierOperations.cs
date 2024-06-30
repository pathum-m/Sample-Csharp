using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class QuantifierOperations
    {
        [Fact]
        public void Any()
        {
            var c = new List<int> { 0, 2, 4, 5, 6 };

            Assert.True(c.Any(e => e % 2 == 1));
            Assert.False(c.All(e => e % 2 == 1));
        }

        [Fact]
        public void All()
        {
            var c = new List<int> { 0, 2, 4, 6 };

            Assert.True(c.All(e => e % 2 == 0));
            Assert.True(c.Any(e => e % 2 == 0));
        }

        [Fact]
        public void Contains()
        {
            var c = new List<int> { 0, 2, 4, 5, 6 };

            Assert.True(c.Contains(5));
            Assert.False(c.Contains(1));
        }
    }
}
