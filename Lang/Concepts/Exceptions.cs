namespace Lang.Concepts
{
    public class Exceptions
    {
        [Fact]
        public void PreserveCallStack()
        {
            var st = Assert.Throws<ApplicationException>(() => Throw()).StackTrace;
            Assert.Contains("Throw()", st);
            Assert.Contains("M2()", st);
            Assert.Contains("M1()", st);
        }

        [Fact]
        public void NotPreserveCallStack()
        {
            var st = Assert.Throws<ApplicationException>(() => Throw_e()).StackTrace;
            Assert.Contains("Throw_e()", st);
            Assert.DoesNotContain("M2()", st);
            Assert.DoesNotContain("M1()", st);
        }

        private void Throw_e()
        {
            try
            {
                M1();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Throw()
        {
            try
            {
                M1();
            }
            catch
            {
                throw;
            }
        }

        private void M1()
        {
            M2();
        }

        private void M2() 
        {
            throw new ApplicationException();
        }

        [Fact]
        public void Finally()
        {
            int o;
            Assert.Equal(1, M3(out o));
            Assert.Equal(1, o);
        }

        private int M3(out int o)
        {
            try
            {
                return 1;
            }
            finally
            {
                o = 1;
            }

            return 2;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Filters(int type)
        {
            Assert.Equal(2, M4(type));
        }

        private int M4(int type)
        {
            try
            {
                if (type == 1)
                {
                    throw new ApplicationException();
                }

                throw new InvalidProgramException();
            }
            catch (Exception e) when (e is ApplicationException || e is InvalidProgramException || 1 == 1) // Any boolean expression
            {
                return 2;
            }
        }
    }
}
