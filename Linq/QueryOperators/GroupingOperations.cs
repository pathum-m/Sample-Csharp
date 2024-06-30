using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class GroupingOperations
    {
        [Fact]
        public void GroupBy()
        {
            var c = new List<SimpleEntity>()
            {
                new SimpleEntity {  P1 = 2, P2 = "B" },
                new SimpleEntity {  P1 = 1, P2 = "B" },
                new SimpleEntity {  P1 = 4, P2 = "C" },
                new SimpleEntity {  P1 = 5, P2 = "A" },
                new SimpleEntity {  P1 = 3, P2 = "A" },
            };

            var queryExpression = from e in c
                                  group e by e.P2;

            Assert.Equal(3, queryExpression.Count());
            Assert.Equal("B", queryExpression.First().Key);
            Assert.Equal(2, queryExpression.First().Count());

            IEnumerable<IGrouping<string, SimpleEntity>> methodExpression = c.GroupBy(i => i.P2);

            // IGrouping is of IEnumerable<T> with a Key property.
            // IGrouping<out TKey, out TElement> : IEnumerable<TElement>
        }
    }
}
