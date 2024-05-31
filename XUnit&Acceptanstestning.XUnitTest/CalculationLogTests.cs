using Labb6_XUnit_Acceptanstestning.Models;
using Xunit;

namespace XUnit_Acceptanstestning.XUnitTest
{
    public class CalculationLogTests
    {
        [Fact]
        //Testar att konverteringen av .ToString retunerar korrekt
        public void GivenCalculationLog_WhenToString_ThenReturnsCorrectFormat()
        {
            //Arrange
            var log = new CalculationLog(10, 5, 15, "+");

            //Act
            string actual = log.ToString();
            string expected = "10 + 5 = 15";

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
