using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicles
{
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string Vin { get; set; }

        public DateTimeOffset ManufacturedAt { get; set; }

        public IReadOnlyCollection<RentalDto> Rentals { get; set; } = [];
    }
}
