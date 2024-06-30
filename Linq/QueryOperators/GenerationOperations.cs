using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class GenerationOperations
    {
        [Fact]
        public void DefaultIfEmpty_Empty()
        {
            var c = new List<string>() { "aaa", "bbb" };
            var q = c.DefaultIfEmpty("xxx");

            Assert.Equal("aaa", q.First());

            var c2 = Enumerable.Empty<string>();
            var q2 = c2.DefaultIfEmpty("xxx");

            Assert.Equal("xxx", q2.First());
        }

        [Fact]
        public void Range()
        {
            var c = Enumerable.Range(1, 5);

            Assert.Equal(1, c.First());
            Assert.Equal(5, c.Last());
        }

        [Fact]
        public void Repeat()
        {
            var c = Enumerable.Repeat(1, 5);

            Assert.Equal(1, c.First());
            Assert.Equal(1, c.First());
            Assert.Equal(5, c.Count());
        }
    }
}
