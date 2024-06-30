using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Concepts
{
    public class AbstractVirtual
    {
        [Fact]
        public void Virtual()
        {
            var d = new VirtualDerived();

            Assert.Equal("#", d.M1());
            Assert.Equal("#", d.M2());

            VirtualBase b = d;

            Assert.Equal("#", b.M1());
            Assert.Equal("$", b.M2());

            VirtualBase e = new VirtualDerived();

            Assert.Equal("#", e.M1());
            Assert.Equal("$", e.M2());

            Assert.Contains("VirtualDerived", e.GetTypeName());
        }

        class VirtualBase
        {
            public virtual string M1()
            {
                return "$";
            }

            public string M2()
            {
                return "$";
            }

            public string GetTypeName()
            {
                return GetType().Name;
            }
        }

        class VirtualDerived : VirtualBase
        {
            public override string M1()
            {
                return "#";
            }

            public new string M2()
            {
                return "#";
            }

            public new string GetTypeName()
            {
                return GetType().Name;
            }
        }

        [Fact]
        public void Abstract()
        { 
        
        }

        class AbstractBase
        { 
        
        }

        class AbstractDerived
        {

        }
    }
}
