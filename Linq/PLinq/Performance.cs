using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.PLinq
{
    public class Performance
    {
        [Fact]
        public void Linq()
        {
            var nums = Enumerable.Range(0, 1000000);

        }
    }
}
