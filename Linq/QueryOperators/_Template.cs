using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace StandardQueryOperators
{
    public class SampleOprations
    {
        [Fact]
        public void Range()
        {
            var list = Enumerable.Range(1, 10).Select(e => e * 7);
        }
    }
}
