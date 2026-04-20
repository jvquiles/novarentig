using System;

namespace GtMotive.Estimate.Microservice.Api.Models.Rentals
{
    public class RentalDto
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTimeOffset StartingAt { get; set; }

        public DateTimeOffset? EndedAt { get; set; }
    }
}
