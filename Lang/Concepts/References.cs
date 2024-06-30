using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang.Concepts
{
    public class References
    {
        [Fact]
        public void Ref()
        {
            var a = 1;
            ref var b = ref a;

            Assert.Equal(1, b);

            b++;

            Assert.Equal(2, a);
        }

        [Fact]
        public void PassValueTypeByRef()
        {
            var a = 1;

            UpdateValueTypeByRef(ref a);

            Assert.Equal(2, a);
        }

        private void UpdateValueTypeByRef(ref int i)
        {
            i++;
        }

        [Fact]
        public void PassRefereneceTypeByRef()
        {
            List<int> list = null!;

            UpdateRefereneceTypeByRef(ref list);

            Assert.Equal(2, list[0]);
        }

        private void UpdateRefereneceTypeByRef(ref List<int> list)
        {
            list = new List<int> { 2 };
        }

        [Fact]
        public void ReturnByRef()
        {
            var arr = new [] { 2, 4, 6 };

            // returned: ref local variable
            ref int returned = ref ReturnRef(arr);

            returned *= 2;

            Assert.Equal(8, arr[1]);
        }

        private ref int ReturnRef(int[] arr)
        {
            return ref arr[1];
        }

        [Fact]
        public void Params()
        {
            Assert.Equal(2, Sum(1, 1));
            Assert.Equal(5, Sum(3, 2));
        }

        private int Sum(params int[] arr)
        {
            return arr.Sum();
        }
    }
}
