using System;
using Xunit;

namespace Lang.Fundementals
{
    public class ClassA : IInterfaceA
    {
        int _p = 1;

        public int P 
        { 
            get => _p; 
            set => _p = value; 
        }
    }

    // Expicit implementation
    public class ClassB : IInterfaceA
    {
        int IInterfaceA.P => 1;
    }

    public interface IInterfaceA 
    {
        int P { get; }
    }
}
