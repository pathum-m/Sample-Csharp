namespace Lang.Features
{
    public class CastingOperations
    {
        [Fact]
        public void As()
        {
            object a = 1;
            Assert.Equal(1, a as int?);

            Assert.Null(a as bool?);
            Assert.Throws<InvalidCastException>(() => (bool?)a);
        }

        [Fact]
        public void Cast()
        {
            
        }
    }
}
