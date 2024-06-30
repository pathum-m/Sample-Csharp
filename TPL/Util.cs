using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    public class Util
    {
        public static void HoldOnFor(int seconds, Action<DateTime> callback = null)
        {
            var ahed = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < ahed)
            {
                if (callback is not null) callback(DateTime.Now);
            };
        }
    }
}
