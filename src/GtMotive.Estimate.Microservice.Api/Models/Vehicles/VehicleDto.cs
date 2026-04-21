using System;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicles
{
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string Vin { get; set; }

        public DateTimeOffset ManufacturedAt { get; set; }
    }
}
