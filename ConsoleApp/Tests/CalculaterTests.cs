using Xunit;

namespace ConsoleApp.Tests
{
    public class CalculaterTests
    {
        private readonly Calculater _sut;
        public CalculaterTests()
        {
            _sut = new Calculater();
        }
        [Fact]
        public void Add_TwoNumberShouldEqualSumation()
        {
            // Given
            double expected = 5;


            // When
            double actual = _sut.Add(3,5);


            // Then

            Assert.Equal(expected,actual);
        }

    }
}