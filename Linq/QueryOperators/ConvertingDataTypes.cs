using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace StandardQueryOperators
{
    public class ConvertingDataTypes
    {
        [Fact]
        public void OfType()
        {
            var c = new List<dynamic> { "abc", "cde", 123, true, "ëfg", 12.45M, false, 1, 2, 3 };

            var typeOfStringsCount = c.OfType<string>().Count();
            var typeOfIntegerCount = c.OfType<int>().Count();
            var typeOfDecimalCount = c.OfType<decimal>().Count();
            var typeOfBooleanCount = c.OfType<bool>().Count();

            Assert.Equal(3, typeOfStringsCount);
            Assert.Equal(4, typeOfIntegerCount);
            Assert.Equal(1, typeOfDecimalCount);
            Assert.Equal(2, typeOfBooleanCount);
        }

        [Fact]
        public void OfType_Cast()
        {
            var c = new List<dynamic> { "abc", "cde", 123, true, "ëfg", 12.45M, false, 1, 2, 3 };

            var c2 = c.OfType<int>().Cast<int>();

            Assert.Equal(4, c2.Count());
        }

        [Fact]
        public void ToDictionary()
        {
            var c = new List<SimpleEntity>
            {
                new SimpleEntity { X = 1, Y = 11 },
                new SimpleEntity { X = 2, Y = 21 },
                new SimpleEntity { X = 2, Y = 22 },
                new SimpleEntity { X = 3, Y = 31 },
                new SimpleEntity { X = 3, Y = 32 },
                new SimpleEntity { X = 3, Y = 33 },
                new SimpleEntity { X = 4, Y = 41 },
            };

            var c2 = c
                .GroupBy(i => i.X)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());


            Assert.Equal(4, c2.Count());
        }
    }
}
