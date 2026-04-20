using System;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Entities
{
    /// <summary>
    /// Unit tests for the Vehicle entity.
    /// </summary>
    public class VehicleTests
    {
        /// <summary>
        /// Verifies that creating a Vehicle instance with a manufacturing date more than five years in the past throws
        /// a DomainException.
        /// </summary>
        /// <remarks>This test ensures that the Vehicle constructor enforces the business rule restricting
        /// vehicles to those manufactured within the last five years. The test passes if a DomainException is thrown
        /// when attempting to create a Vehicle with an invalid manufacturing date.</remarks>
        [Fact]
        public void VehicleShouldThrowDomainExceptionWhenManufacturedAtIsMoreThan5YearsOld()
        {
            var vin = "1GBHK29255E164128";
            var manufacturedAt = DateTimeOffset.Now.AddYears(-6);

            Assert.Throws<DomainException>(() => new Vehicle(vin, manufacturedAt));
        }

        /// <summary>
        /// Verifies that a Vehicle instance is created successfully when the manufactured date is within the last five
        /// years.
        /// </summary>
        /// <remarks>This test ensures that the Vehicle constructor accepts a manufactured date up to five
        /// years in the past and correctly initializes all properties.</remarks>
        [Fact]
        public void VehicleShouldCreateSuccessfullyWhenManufacturedAtIsWithin5Years()
        {
            var vin = "1GBHK29255E164128";
            var manufacturedAt = DateTimeOffset.Now.AddYears(-3);
            var vehicle = new Vehicle(vin, manufacturedAt);
            Assert.NotNull(vehicle);
            Assert.Equal(vin, vehicle.Vin);
            Assert.Equal(manufacturedAt, vehicle.ManufacturedAt);
        }
    }
}
