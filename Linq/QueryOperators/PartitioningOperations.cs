using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class PartitioningOperations
    {
        [Fact]
        public void Skip()
        {
            var c = new List<int> { 2, 3, 4, 5, 6};

            Assert.Equal(4, c.Skip(2).First());
        }

        [Fact]
        public void SkipWhile()
        {
            var c = new List<int> { 2, 3, 4, 5, 6 };

            Assert.Equal(4, c.SkipWhile(e => e < 4).First());
        }

        [Fact]
        public void Take()
        {
            var c = new List<int> { 2, 3, 4, 5, 6 };

            Assert.Equal(4, c.Take(3).Last());
        }

        [Fact]
        public void TakeWhile()
        {
            var c = new List<int> { 2, 3, 4, 5, 6 };

            Assert.Equal(4, c.TakeWhile(e => e < 5).Last());
        }

        [Fact]
        public void Chunk()
        {
            var c = new List<int> { 2, 3, 4, 5, 6 };

            // Not availabel in current language version.
            //Assert.Equal(4, c.Chunk().Last());
        }
    }
}
