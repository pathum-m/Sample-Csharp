using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Patterns
    {
        [Fact]
        public void ConstantPattern_If()
        {
            bool matched = false;

            int a = 1;
            
            if (a is 1)
            {
                matched = true;
            }

            Assert.True(matched);

            matched = false;

            if (a is not 2)
            {
                matched = true;
            }

            Assert.True(matched);
        }

        [Fact]
        public void PropertyPattern_If()
        {
            var matched = false;

            A a = new()
            {
                P1 = 1,
                P2 = 2,
                P3 = 3,
                B = new()
                {
                    P1 = 1,
                    P2 = 2
                }
            };

            if (a is { P1 : 1, P2 : 2})
            {
                matched = true;
            }

            Assert.True(matched);

            matched = false;

            if (a is { P1: 1, B: { P1: 1 } })
            {
                matched = true;
            }

            Assert.True(matched);
        }

        [Fact]
        public void ExtendedPropertyPattern_If()
        {
            var matched = false;

            A a = new() 
            { 
                P1 = 1, 
                P2 = 2, 
                P3 = 3, 
                B = new()
                { 
                    P1 = 1,
                    P2 = 2
                }
            };

            if (a is { P1: 1, B.P1: 1 })
            {
                matched = true;
            }

            Assert.True(matched);

            matched = false;

            if (a is { B.P2: > 1 })
            {
                matched = true;
            }

            Assert.True(matched);
        }

        class A
        {
            public int P1 { get; set; }
            public int P2 { get; set; }
            public int P3 { get; set; }
            public B B { get; set; }
        }

        class B
        { 
            public int P1 { get; set; }
            public int P2 { get; set; }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        public void RelationalConstantPatterns_Switch(int i)
        {
            var v = i switch
            {
                1 => 2,
                > 1 and < 5 when (i != 3) => 3,
                _ => -1
            };
        }

        [Fact]
        public void Var_If()
        {
            var t = (P1: 2, P2: 3);

            if (t is var r && r.P1 == 2)
            { 
                
            }
        }
    }
}
