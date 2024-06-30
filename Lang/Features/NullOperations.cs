namespace Lang.Features
{
    public class NullOperations
    {
        [Fact]
        public void Is()
        {
            int r = 0;
            int? n = 1;

            if (n is int n1)
            {
                r = n1;
            }

            Assert.Equal(1, r);
        }

        [Fact]
        public void IsNotNull()
        {
            int r = 0;
            int? n = 1;

            if (n is not null)
            {
                r = n ?? r;
            }

            Assert.Equal(1, r);
        }

        [Fact]
        public void NullConditional()
        {
            object? obj = null;

            Assert.Throws<NullReferenceException>(() => obj!.ToString());
            Assert.Null(obj?.ToString());

            List<int>? list = null;

            Assert.Throws<NullReferenceException>(() => list![0]);
            Assert.Null(list?[0]);
        }

        [Theory]
        [InlineData(4)]
        public void NullForgiving(int i)
        {
            string? a = "";

            if (i % 2 == 0)
            {
                a = null;
            }

            Assert.Throws<NullReferenceException>(() => a!.ToString());
        }

        [Fact]
        public void NullCoalescingAssignment()
        {
            // Initialize if null
            List<int>? list = null;

            (list ??= new List<int>()).Add(1);
            
            list.Add(2);

            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);

            int? a = null;
            list.Add(a ?? 3);

            Assert.Equal(3, list[2]);

            // throw if null
            int? b = null;

            Assert.Throws<ArgumentNullException>(() => b ?? throw new ArgumentNullException());
        }
    }
}
