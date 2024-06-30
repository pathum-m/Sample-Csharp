using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class AggregationOperations
    {
        [Fact]
        public void Aggregate()
        {
            var c = new List<SimpleEntity>() 
            { 
                new SimpleEntity { P = true, X = 2, Y = 2 },
                new SimpleEntity { P = false, X = 1, Y = 2 },
                new SimpleEntity { P = false, X = 2, Y = 3 },
                new SimpleEntity { P = true, X = 4, Y = 2 },
            };

            var total = c.Aggregate
                (
                    0, 
                    (acc, e) => e.P 
                        ? acc + e.X + e.Y 
                        : acc + Math.Abs(e.X - e.Y)
                );

            Assert.Equal(12, total);
        }

        [Fact]
        public void Max()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity { X = 2, Y = 2 },
                new SimpleEntity { X = 1, Y = 2 },
                new SimpleEntity { X = 2, Y = 4 },
                new SimpleEntity { X = 4, Y = 5 },
            };

            var maxDiff = c.Max(e => Math.Abs(e.X - e.Y));

            Assert.Equal(2, maxDiff);
        }
    }
}
