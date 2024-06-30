using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace StandardQueryOperators
{
    public class EqualityOperations
    {
        [Fact]
        public void SequenceEqual()
        {
            var c1 = new List<int> { 2, 3, 4 };
            var c2 = new List<int> { 2, 3, 4 };
            var c3 = new List<int> { 3, 2, 4 };

            Assert.True(c1.SequenceEqual(c2));
            Assert.False(c1.SequenceEqual(c3));
        }
    }
}
