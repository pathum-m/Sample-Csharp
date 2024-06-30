using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.My.InnerType
{
    public class InnerTypeImplementation
    {
        [Fact]
        public void Test()
        {
            IType o = new Factory().Create();

            Assert.Equal(2, o.Get());
        }
    }

    interface IType 
    {
        int Get();
    }

    class Factory
    {
        public IType Create() => new ITypeComponent();

        class ITypeComponent : IType 
        {
            public int Get() => 2;
        }
    }
}
