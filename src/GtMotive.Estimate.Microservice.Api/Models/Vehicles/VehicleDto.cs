using System;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicles
{
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string VIN { get; set; } = string.Empty;

        public DateTimeOffset ManufacturedAt { get; set; }
    }
}
