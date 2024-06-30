using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Deconstruction
    {
        [Fact]
        public void Deconstruct()
        { 
            A a = new() { P1 = 1, P2 = 2 };

            var (p1, p2) = a;

            Assert.Equal(1, p1);
            Assert.Equal(2, p2);
        }

        class A
        {
            public int P1 { get; set; }
            public int P2 { get; set; }

            public void Deconstruct(out int p1, out int p2)
            {
                p1 = P1;
                p2 = P2;
            }
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        public void Deconstruct_Switch(int a, int b)
        {
            var t = (a, b);

            var v = t switch
            {
                (1, 2) => 1,
                ( > 2, _) => 2,
                (_, _) => -1
            };
        }
    }
}
