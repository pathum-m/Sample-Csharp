using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Switch
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(-1)]
        [InlineData(10)]
        public void SwitchStatement(int i)
        {
            switch (i)
            {
                case 1: // Constant pattern
                    break;
                case > 1 and < 5: // Relational pattern
                    break;
                case 5:
                    break;
                case 9 or > 5 when (i != 10): // Case guard: boolean expression
                    break;
                default:
                    break;
            }
        }
    }
}
