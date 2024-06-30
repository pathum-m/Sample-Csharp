namespace Lang.Concepts
{
    public class LambdaExpressions
    {
        [Fact]
        public void DelegateTypeInference()
        { 
            var func = (int a, int b) => $"{a + b}";

            Assert.IsType<Func<int, int, string>>(func);

            var act = (int a, int b) => 
            {
                _ = a + b;
            };

            Assert.IsType<Action<int, int>>(act);
        }
    }
}
