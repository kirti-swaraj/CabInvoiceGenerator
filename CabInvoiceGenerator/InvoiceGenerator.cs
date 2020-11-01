﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Invoice Generator class
    /// </summary>
    public class InvoiceGenerator
    {
        private readonly double COST_PER_KM;
        private readonly int COST_PER_MINUTE;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator()
        {
            /// Initialization of constants
            COST_PER_KM = 10;
            COST_PER_MINUTE = 1;
            MINIMUM_FARE = 5;
        }

        /// <summary>
        /// UC 1 : Calculates the fare given time and distance.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="minutes">The minutes.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException">
        /// Distance travelled is invalid
        /// or
        /// Invalid travel time
        /// </exception>
        public double CalculateFare(double distance, int minutes)
        {
            double totalFare = 0;
            try
            {
                totalFare = COST_PER_KM * distance + COST_PER_MINUTE * minutes;
            }
            catch
            {
                /// If the distance is invalid, throw exception
                if (distance <= 0)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance travelled is invalid");
                /// If the travel time is invalid throw exception
                if (minutes <= 0)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Invalid travel time");
            }
            /// Returns the maximum value between calculated total fare and minimum fare
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
}