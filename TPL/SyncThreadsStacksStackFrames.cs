using System;
using System.Collections.Generic;
using System.Text;

namespace TPL
{
    public class SyncThreadsStacksStackFrames
    {
        public void Execute()
        {
            Func1(2, 3);
        }

        private int Func1(int p1, int p2)
        {
            return p1 + Func2(p2);
        }

        private int Func2(int p1)
        {
            return p1;
        }
    }
}
