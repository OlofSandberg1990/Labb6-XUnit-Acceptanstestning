using Labb6_XUnit_Acceptanstestning.Models;
using Xunit;

namespace XUnit_Acceptanstestning.XUnitTest
{
    public class CalculatorTests
    {
        //Skapar en instsans av Calculator här istället för att skapa nya i varje metods Arrange
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(10, 20, 30)]
        [InlineData(-20, -20, -40)]
        [InlineData(30, -40, -10)]
        [InlineData(100, -7, 93)]
        public void GivenTwoNumbers_WhenAdded_ThenReturnsCorrectSum(double num1, double num2, double expected)
        {            
            //Act
            double actual = _calculator.Addition(num1, num2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(0, 3, -3)]
        [InlineData(100, 200, -100)]
        [InlineData(-5, -2, -3)]
        [InlineData(5.5, 2.5, 3)]
        public void GivenTwoNumbers_WhenSubtracted_ThenReturnsCorrectDifference(double num1, double num2, double expected)
        {            

            //Act
            double actual = _calculator.Subtraction(num1, num2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(10, 0, 0)]
        [InlineData(-12, -4, 48)]
        [InlineData(100, 10, 1000)]
        [InlineData(2, 0.5, 1)]
        public void GivenTwoNumbers_WhenMultiplied_ThenReturnsCorrectProduct(double num1, double num2, double expected)
        {            
            //Act
            double actual = _calculator.Multiplication(num1, num2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(10, 5, 2)]
        [InlineData(-4, -10, 0.4)]
        [InlineData(10, 100, 0.1)]
        [InlineData(1, 4, 0.25)]
        public void GivenTwoNumbers_WhenDivided_ThenReturnsCorrectQuotient(double num1, double num2, double expected)
        {
            //Act
            double actual = _calculator.Division(num1, num2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenTwoNumbers_WhenDividedByZero_ThenThrowsDivideByZeroException()
        {
            //Arrange
            double num1 = 15;
            double num2 = 0;

            //Act
            var exception = Assert.Throws<DivideByZeroException>(() => _calculator.Division(num1, num2));
            var expected = exception.Message;
            var actual = $"Division med 0 är ej tillåtet.";

            //Assert
            Assert.Equal(expected,actual);
        }
    }
}
