using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Concepts
{
    public class Operators
    {
        [Fact]
        public void Increment()
        {
            var a = 1;
            
            Assert.Equal(2, ++a);
            Assert.Equal(2, a++);
            Assert.Equal(3, a);
        }
    }
}
