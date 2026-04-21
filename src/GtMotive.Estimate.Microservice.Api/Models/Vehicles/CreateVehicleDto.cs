using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.Models.Vehicles
{
    public class CreateVehicleDto
    {
        [JsonRequired]
        public string Vin { get; set; }

        [JsonRequired]
        public DateTimeOffset ManufacturedAt { get; set; }
    }
}
