// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace NUnitTestProject1
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    public class Tests
    {
        public InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// UC 1 : Given the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            // Arrange
            double expectedFare = 40;
            double distance = 3;
            int minutes = 10;
            invoiceGenerator = new InvoiceGenerator();
            // Act
            double actualFare = invoiceGenerator.CalculateFare(distance, minutes);
            //Assert
            Assert.AreEqual(expectedFare, actualFare);
        }
        /// <summary>
        /// UC 2 & 3 : Given multiple rides should return invoice summary with aggregate totalFare and average Fare
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            // Arrange
            Ride[] rides = { new Ride(4, 8), new Ride(6, 10), new Ride(10, 12), new Ride(1, 4) };
            InvoiceSummary expectedSummary = new InvoiceSummary(4, 244,61);
            invoiceGenerator = new InvoiceGenerator();
            // Act
            InvoiceSummary actualSummary = invoiceGenerator.CalculateFare(rides);
            //Assert
            Assert.AreEqual(expectedSummary, actualSummary);
        }
        /// <summary>
        /// UC 4 : Given the user id, invoice service gets list of rides and returns invoice summary.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRides_ShouldReturnInvoiceSummary()
        {
            // Arrange
            invoiceGenerator = new InvoiceGenerator();
            string userId1 = "USER1";
            string userId2 = "USER2";
            Ride[] rides1 = { new Ride(4, 8), new Ride(6, 10), new Ride(10, 12), new Ride(1, 4) };
            Ride[] rides2 = { new Ride(1,5 ), new Ride(4, 7), new Ride(5, 8) };
            invoiceGenerator.AddRides(userId1, rides1);
            invoiceGenerator.AddRides(userId2, rides2);
            InvoiceSummary expectedSummary1 = new InvoiceSummary(4, 244, 61);
            InvoiceSummary expectedSummary2 = new InvoiceSummary(3, 120, 40);

            // Act
            InvoiceSummary actualSummary1 = invoiceGenerator.GetInvoiceSummary(userId1);
            InvoiceSummary actualSummary2 = invoiceGenerator.GetInvoiceSummary(userId2);

            //Assert
            Assert.AreEqual(expectedSummary1, actualSummary1);
            Assert.AreEqual(expectedSummary2, actualSummary2);
        }
    }
}