using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.Models.Rentals
{
    public class CreateRentalDto
    {
        [JsonRequired]
        public Guid VehicleId { get; set; }

        [JsonRequired]
        public Guid UserId { get; set; }
    }
}
