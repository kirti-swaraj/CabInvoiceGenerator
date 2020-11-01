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
    using System;

    public class Tests
    {
        public InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// UC 1 & 5  : Given the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            // Arrange
            double expectedFareNormal = Math.Max(10 * 3 + 1 * 10, 5);
            double expectedFarePremium = Math.Max(15 * 3 + 2 * 10, 20);
            double distance = 3;
            int minutes = 10;
            // UC 1
            InvoiceGenerator invoiceGenerator1 = new InvoiceGenerator(RideType.NORMAL);
            // UC 5
            InvoiceGenerator invoiceGenerator2 = new InvoiceGenerator(RideType.PREMIUM);
            // Act
            double actualFareNormal = invoiceGenerator1.CalculateFare(distance, minutes);
            double actualFarePremium = invoiceGenerator2.CalculateFare(distance, minutes);
            //Assert
            Assert.AreEqual(expectedFareNormal, actualFareNormal);
            Assert.AreEqual(expectedFarePremium, actualFarePremium);
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
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
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
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
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
        /// <summary>
        /// Given the invalid travel distance should throw custom exception.
        /// </summary>
        [Test]
        public void GivenInvalidTravelDistance_ShouldThrowCustomException()
        {
            /// Arrange            
            double distance = -4;
            int minutes = 10;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            try
            {
                var actual = invoiceGenerator.CalculateFare(distance, minutes);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Distance travelled is invalid", e.Message);
            }
        }

        /// <summary>
        /// Given the invalid travel time should throw custom exception.
        /// </summary>
        [Test]
        public void GivenInvalidTravelTime_ShouldThrowCustomException()
        {
            /// Arrange            
            double distance = 5;
            int minutes = -20;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            try
            {
                var actual = invoiceGenerator.CalculateFare(distance, minutes);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid travel time", e.Message);
            }
        }

        /// <summary>
        /// Given the null ride data should throw custom exception.
        /// </summary>
        [Test]
        public void GivenNullRideData_ShouldThrowCustomException()
        {
            /// Arrange
            Ride[] rides = null;
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            try
            {
                InvoiceSummary actualSummary = invoiceGenerator.CalculateFare(rides);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Rides are null", e.Message);
            }
        }

        /// <summary>
        /// Given the invalid user id should throw custom exception.
        /// </summary>
        [Test]
        public void GivenInvalidUserId_ShouldThrowCustomException()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            try
            {
                InvoiceSummary actualSummary = invoiceGenerator.GetInvoiceSummary("USER");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid UserID", e.Message);
            }
        }

        /// <summary>
        /// Given the invalid ride type should throw custom exception.
        /// </summary>
        [Test]
        public void GivenInvalidRideType_ShouldThrowCustomException()
        {
            try
            {
                invoiceGenerator = new InvoiceGenerator(RideType.WRONG_RIDE_TYPE);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Ride Type", e.Message);
            }
        }
    }
}