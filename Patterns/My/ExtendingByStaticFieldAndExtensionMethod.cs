namespace Patterns.My.Extending
{
    public class ExtendingByStaticFieldAndExtensionMethod
    {
        [Fact]
        public void Test()
        {
            Component c = new Component(10);

            Assert.Equal(11, c.AddItem("item1"));
            Assert.Equal(12, c.AddItem("item2"));
        }
    }

    public class Component
    {
        public int P { get; }

        public Component(int p) => P = p;
    }

    public static class ComponentExtensions
    {
        private static readonly Dictionary<string, int> list = new() { { "item1", 1 }, { "item2", 2 } };

        public static int AddItem(this Component c, string key)
        { 
            return list[key] + c.P;
        }
    }
}