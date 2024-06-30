using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class SortingOperators
    {
        [Fact]
        public void OrderBy()
        {
            var c = new List<SimpleEntity>()
            { 
                new SimpleEntity {  P1 = 2, P2 = "G" },
                new SimpleEntity {  P1 = 1, P2 = "A" },
                new SimpleEntity {  P1 = 4, P2 = "E" },
                new SimpleEntity {  P1 = 5, P2 = "B" },
                new SimpleEntity {  P1 = 3, P2 = "D" },
            };


            Assert.Equal("A", c.OrderBy(i => i.P2).First().P2);
            Assert.Equal("G", c.OrderBy(i => i.P2).Last().P2);

            //Reference equals
            Assert.Equal(c[1], c.OrderBy(i => i.P2).First());
        }

        [Fact]
        public void OrderByDescending()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  P1 = 2, P2 = "G" },
                new SimpleEntity {  P1 = 1, P2 = "A" },
                new SimpleEntity {  P1 = 4, P2 = "E" },
                new SimpleEntity {  P1 = 5, P2 = "B" },
                new SimpleEntity {  P1 = 3, P2 = "D" },
            };


            Assert.Equal("G", c.OrderByDescending(i => i.P2).First().P2);
            Assert.Equal("A", c.OrderByDescending(i => i.P2).Last().P2);

            //Reference equals
            Assert.Equal(c[0], c.OrderByDescending(i => i.P2).First());
        }

        [Fact]
        public void ThenBy()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  P1 = 2, P2 = "B" },
                new SimpleEntity {  P1 = 1, P2 = "B" },
                new SimpleEntity {  P1 = 4, P2 = "C" },
                new SimpleEntity {  P1 = 5, P2 = "A" },
                new SimpleEntity {  P1 = 3, P2 = "A" },
            };

            var q = c
                .OrderBy(i => i.P2)
                .ThenBy(i => i.P1);

            Assert.Equal("A", q.First().P2);
            Assert.Equal(3, q.First().P1);
            Assert.Equal(c[4], q.First());
        }

        [Fact]
        public void ThenByDescending()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  P1 = 2, P2 = "B" },
                new SimpleEntity {  P1 = 1, P2 = "B" },
                new SimpleEntity {  P1 = 4, P2 = "C" },
                new SimpleEntity {  P1 = 5, P2 = "A" },
                new SimpleEntity {  P1 = 3, P2 = "A" },
            };

            var q = c
                .OrderBy(i => i.P2)
                .ThenByDescending(i => i.P1);

            Assert.Equal("A", q.First().P2);
            Assert.Equal(5, q.First().P1);
            Assert.Equal(c[3], q.First());
        }

        [Fact]
        public void Comparer()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  X = 2, Y = 4 }, // 2
                new SimpleEntity {  X = 1, Y = 2 }, // 1
                new SimpleEntity {  X = 3, Y = 7 }, // 4
                new SimpleEntity {  X = 3, Y = 6 }, // 3
            };

            // OrderBy type parameters.
            // TKey is same for both keySelector and comparer.
            // OrderBy<TSource, TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer);

            var q = c.OrderBy(i => i, new DifferenceComparer());

            Assert.Equal(c[1], q.First());

            q = c.OrderByDescending(i => i, new DifferenceComparer());

            Assert.Equal(c[2], q.First());
        }

        [Fact]
        public void Reverse()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  P1 = 2, P2 = "B" },
                new SimpleEntity {  P1 = 1, P2 = "B" },
                new SimpleEntity {  P1 = 4, P2 = "C" },
                new SimpleEntity {  P1 = 5, P2 = "A" },
                new SimpleEntity {  P1 = 3, P2 = "A" },
            };

            var q = c.Reverse<SimpleEntity>();

            Assert.Equal(c[4], q.First());

            // OrderBy is not hepfull because no ideal sort key available;
            // Following test is failing.
            //Assert.Equal(c[4], c.OrderByDescending(i => i).First());
        }
    }
}
