using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [CollectionDefinition(nameof(TestCollections))]
    public class RentalsTests(GenericInfrastructureTestServerFixture genericInfrastructureTestServerFixture)
        : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        [Fact]
        public async Task RentalShouldThrowExceptionWhenCreatingWithNonValidPayload()
        {
            var client = genericInfrastructureTestServerFixture.Server.CreateClient();

            using var emptyPayload = new StringContent("{}");
            using var content = new StringContent(
                JsonSerializer.Serialize(emptyPayload),
                Encoding.UTF8,
                "application/json");

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await client.PostAsync(new Uri("api/Rentals", UriKind.Relative), content));
        }
    }
}
