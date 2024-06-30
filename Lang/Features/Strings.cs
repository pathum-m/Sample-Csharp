using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Strings
    {
        [Fact]
        public void StringBuilder()
        {
            var s = "aBcDeF";
            var si = "AbCdEf";

            var sb = new StringBuilder(s);

            for (var i = 0; i < sb.Length; i++)
            {
                sb[i] = char.IsLower(sb[i]) ? char.ToUpper(sb[i]) : char.ToLower(sb[i]);
            }

            Assert.Equal(si, sb.ToString());
        }

        [Fact]
        public void Linq()
        {
            var s = "aBcDeF";
            var si = "AbCdEf";

            var a = string.Join("", s.Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)));

            Assert.Equal(si, a);
        }
    }
}
