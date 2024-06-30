
namespace Lang.Features
{
    public class Dynamic
    {
        [Fact]
        public void ExpandoObjectFields()
        { 
            dynamic o = new ExpandoObject();

            o.A = "string";
            o.B = 2;

            Assert.Equal(2, o.B);

            Assert.Throws<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() => o.C);

            ((IDictionary<string, object>)o).Remove("B");

            Assert.Throws<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() => o.B);
        }

        [Fact]
        public void ExpandoObjectMethods()
        {
            dynamic o = new ExpandoObject();

            o.A = 4;

            o.Add = (Func<int, int>)((a) => a + o.A);

            Assert.Equal(5, o.Add(1));
        }
    }
}
