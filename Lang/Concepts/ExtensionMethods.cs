using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Concepts
{
    public class ExtensionMethods_InterfaceExtentions
    {
        [Fact]
        public void InterfaceExtentions()
        {
            ImplementationA o = new();

            Assert.Equal(3, o.M1(2));
        }
    }

    public class ImplementationA : InterfaceA { }

    public interface InterfaceA { }

    public static class InterfaceAExtentions 
    {
        public static int M1(this InterfaceA interfaceA, int i)
        {
            return i + 1;
        }
    }

    public class ExtensionMethods_ClassExtensions
    {
        [Fact]
        public void ClassExtensions()
        {
            ImplementationA o = new();

            Assert.Equal(3, o.M1(2));
        }
    }

    public class A 
    {
        protected int f1 = 1;
        public int f2 = 2;
    }

    public static class AExtentions
    {
        public static int M1(this A a, int i)
        {
            return a.f2 + 1; 
            // Has access on instance level
            // Is a limitation from sub-classing, subclass has access on protected level
            // Comparable to decorator
        }
    }
}
