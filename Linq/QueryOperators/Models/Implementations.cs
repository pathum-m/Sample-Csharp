using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StandardQueryOperators
{
    class DifferenceComparer : IComparer<SimpleEntity>, IEqualityComparer<SimpleEntity>
    {
        public int Compare(SimpleEntity e1, SimpleEntity e2)
        {
            var diff = (e1.Y - e1.X) - (e2.Y - e2.X);

            return diff > 0
                ? 1
                : diff == 0
                    ? 0
                    : -1;
        }

        public bool Equals(SimpleEntity e1, SimpleEntity e2)
        {
            return Math.Abs(e1.Y - e1.X) == Math.Abs(e2.Y - e2.X);
        }

        public int GetHashCode(SimpleEntity obj)
        {
            return Math.Abs(obj.Y - obj.X);
        }
    }
}
