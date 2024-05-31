using Labb6_XUnit_Acceptanstestning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnit_Acceptanstestning.XUnitTest
{
    public class MenuTests
    {
        [Fact]
        //Verifierar att GetValidDoubleFromUser retunerar korrekt värde
        public void GivenValidDouble_WhenGetValidDoubleFromUser_ReturnsDouble()
        {
            //Arrange
            var menu = new Menu();
            var input = new StringReader("25,5");
            Console.SetIn(input);

            //Act
            double actual = menu.GetValidDoubleFromUser();
            double expected = 25.5;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        //Verifierar att GetValidDoubleFromUser repeteras tills korrekt värde anges
        public void GivenInvalidDouble_WhenGetValidDoubleFromUser_RepeatsUntilValidInput()
        {
            //Arrange
            var menu = new Menu();
            var input = new StringReader("25,5ABC\n25,5");
            Console.SetIn(input);

            //Act
            double actual = menu.GetValidDoubleFromUser();
            double expected = 25.5;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        //Verifierar att GetValidDoubleFromUser returnerar en double
        public void GivenAnyInput_WhenGetValidDoubleFromUser_ReturnsTypeDouble()
        {
            //Arrange
            var menu = new Menu();
            var input = new StringReader("25,5");
            Console.SetIn(input);
                     
            //Act
            double actual = menu.GetValidDoubleFromUser();

            //Assert
            Assert.IsType<double>(actual);
        }
    }
}
