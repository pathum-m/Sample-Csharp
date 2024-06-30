using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Tuples
    {
        [Fact]
        public void Declaration()
        {
            (int, string) t1 = (2, "*");

            Assert.Equal(2, t1.Item1);
            Assert.Equal("*", t1.Item2);

            (int P1, string P2) t2 = (2, "*");

            Assert.Equal(2, t2.P1);
            Assert.Equal("*", t2.P2);

            var t3 = (P1: 2, P2: "*");

            Assert.Equal(2, t3.P1);
            Assert.Equal("*", t3.P2);

            int a = 2;
            string b = "**";

            var t4 = (a, b);
            Assert.Equal(2, t4.a);
            Assert.Equal("**", t4.b);
        }

        [Fact]
        public void Deconstruction()
        {
            var t = (1, 2);

            var (a, b) = t;

            Assert.Equal(1, a);
            Assert.Equal(2, b);

            int c, d;

            (c, d) = t;
            Assert.Equal(1, c);
            Assert.Equal(2, d);

            var (_, e) = t;
            Assert.Equal(2, e);
        }

        [Fact]
        public void Equality()
        {
            var t1 = (1, 2);
            var t2 = (1, 2);
            var t3 = (2, 2);

            Assert.Equal(t1, t2);
            Assert.True(t1 == t2);
            Assert.NotEqual(t1, t3);
            Assert.False(t1 == t3);
        }
    }
}
