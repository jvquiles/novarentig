using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Api.Models.Rentals
{
    public class CreateRentalDto
    {
        [JsonRequired]
        public Guid CustomerId { get; set; }
    }
}
