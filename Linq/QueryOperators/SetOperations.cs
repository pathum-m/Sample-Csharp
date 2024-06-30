using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace StandardQueryOperators
{
    public class SetOperations
    {
        [Fact]
        public void Distinct()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity { P = true, X = 2, Y = 4 },
                new SimpleEntity { P = false, X = 1, Y = 2 },
                new SimpleEntity { P = false, X = 2, Y = 3 },
                new SimpleEntity { P = true, X = 4, Y = 2 },
            };

            Assert.Equal(3, c.Select(e => e.Y).Distinct().Count());
            Assert.Equal(2, c.Distinct(new DifferenceComparer()).Count());
        }

        [Fact]
        public void Intersect()
        {
            var c1 = new List<int> { 1, 2, 3, 5, 7};
            var c2 = new List<int> { 1, 3, 5, 7, 9};

            Assert.Equal(4, c1.Intersect(c2).Count());
        }

        [Fact]
        public void Except()
        {
            var c1 = new List<int> { 1, 2, 3, 5, 7 };
            var c2 = new List<int> { 1, 3, 5, 7, 9 };

            Assert.Equal(1, c1.Except(c2).Count());
            Assert.Equal(2, c1.Except(c2).First());
        }

        [Fact]
        public void Union()
        {
            var c1 = new List<int> { 1, 2, 3, 5, 7 };
            var c2 = new List<int> { 1, 3, 5, 7, 9 };

            Assert.Equal(6, c1.Union(c2).Count());
        }
    }
}
