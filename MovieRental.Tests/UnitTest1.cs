using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental.Code;

namespace MovieRental.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Regular_And_2_DaysRented()
        {
            // Arrange
            var movie = new Movie("The Happy Boy", PriceCode.Regular);
            var target = new Customer("ian");
            target.AddRental(new Rental(movie, 2));
            var expected = @"Rental Record for ian 
	The Happy Boy	2
Amount owed is 2
You earned 1 frequent renter points";

            // Act
            var actual = target.Statement();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Regular_And_5_DaysRented()
        {
            // Arrange
            var movie = new Movie("The Happy Boy", PriceCode.Regular);
            var target = new Customer("ian");
            target.AddRental(new Rental(movie, 5));
            var expected = @"Rental Record for ian 
	The Happy Boy	6.5
Amount owed is 6.5
You earned 1 frequent renter points";

            // Act
            var actual = target.Statement();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_NewRelease_And_3_DaysRented()
        {
            // Arrange
            var movie = new Movie("The Happy Boy", PriceCode.NewRelease);
            var target = new Customer("ian");
            target.AddRental(new Rental(movie, 3));
            var expected = @"Rental Record for ian 
	The Happy Boy	9
Amount owed is 9
You earned 2 frequent renter points";

            // Act
            var actual = target.Statement();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Childrens_And_2_DaysRented()
        {
            // Arrange
            var movie = new Movie("The Happy Boy", PriceCode.Childrens);
            var target = new Customer("ian");
            target.AddRental(new Rental(movie, 2));
            var expected = @"Rental Record for ian 
	The Happy Boy	1.5
Amount owed is 1.5
You earned 1 frequent renter points";

            // Act
            var actual = target.Statement();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Childrens_And_4_DaysRented()
        {
            // Arrange
            var movie = new Movie("The Happy Boy", PriceCode.Childrens);
            var target = new Customer("ian");
            target.AddRental(new Rental(movie, 4));
            var expected = @"Rental Record for ian 
	The Happy Boy	3
Amount owed is 3
You earned 1 frequent renter points";

            // Act
            var actual = target.Statement();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}