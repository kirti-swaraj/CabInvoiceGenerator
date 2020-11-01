// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RideType.cs" company="Bridgelabz">
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
    /// UC 5 : RideType defined as NORMAL and PREMIUM
    /// </summary>
    public enum RideType
    {
        NORMAL,
        PREMIUM,
        WRONG_RIDE_TYPE
    }
}