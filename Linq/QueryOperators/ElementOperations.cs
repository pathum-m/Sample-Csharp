using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace StandardQueryOperators
{
    public class ElementOperations
    {
        [Fact]
        public void ElementAt_ElementAtOrDefault()
        {
            var c = new List<int> { 3, 4, 5 };

            Assert.Equal(4, c.ElementAt(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ElementAt(3));
            Assert.Equal(0, c.ElementAtOrDefault(3));
        }

        [Fact]
        public void First_FirstOrDefault()
        {
            var c = new List<int> { 3, 4, 5, 6 };

            Assert.Equal(3, c.First());
            Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().First());
            Assert.Equal(0, Enumerable.Empty<int>().FirstOrDefault());

            Assert.Equal(4, c.First(e => e % 2 == 0 ));
        }

        [Fact]
        public void Last_LastOrDefault()
        {
            var c = new List<int> { 3, 4, 5 };

            Assert.Equal(5, c.Last());
            Assert.Equal(0, Enumerable.Empty<int>().LastOrDefault());
        }

        [Fact]
        public void Single_SingleOrDefault()
        {
            var c1 = new List<int> { 3 };
            var c2 = new List<int> { 3, 4 };

            Assert.Equal(3, c1.Single());
            Assert.Throws<InvalidOperationException>(() => c2.Single());
            Assert.Equal(0, Enumerable.Empty<int>().SingleOrDefault());

            Assert.Equal(4, c2.SingleOrDefault(e => e % 2 == 0));
        }
    }
}
