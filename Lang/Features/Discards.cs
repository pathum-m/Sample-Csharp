using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Features
{
    public class Discards
    {
        public void Op()
        {
            // Return value is discarded
            // Output value is discarded
            
            _ = TryMatch(1, out _);
        }

        bool TryMatch(int i, out int? o)
        {
            o = i % 2 == 0 ? 1 : null;
            return o != null;
        }  
    }
}
