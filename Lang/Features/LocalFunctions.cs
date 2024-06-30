using System;
using Xunit;

namespace Lang.Features
{
    public class LocalFunctions
    {
        [Fact]
        public void LocalFunctions2()
        {
            Assert.Equal("_Local", LocalFunction("_"));

            string LocalFunction(string p)
            {
                return p + "Local";
            }
        }
    }
}
