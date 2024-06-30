using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StandardQueryOperators
{
    public class FilteringOperations
    {
        [Fact]
        public void OfType()
        {
            var c = new List<dynamic> { "abc", "cde", 123, true, "ëfg", 12.45M, false, 1, 2, 3 };

            Assert.Equal(4, c.OfType<int>().Count());

            Assert.Throws<InvalidCastException>(() =>
            {
                c.Cast<int>().Count();
            });
        }

        [Fact]
        public void Where()
        {
            var c = new List<int> { 0, 1, 2, 3, 4, 5, 6 };

            var queryExpression = from i in c
                                  where i % 2 == 0
                                  select i;

            Assert.Equal(4, queryExpression.Count());

            var methodExpression = c.Where(i => i % 2 == 0);

            Assert.Equal(4, methodExpression.Count());
        }
    }
}
