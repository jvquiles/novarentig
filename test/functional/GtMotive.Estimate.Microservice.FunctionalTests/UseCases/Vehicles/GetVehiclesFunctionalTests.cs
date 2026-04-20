using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.UseCases.Vehicles
{
    [Collection(TestCollections.Functional)]
    public partial class GetVehiclesFunctionalTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task GivenVehiclesInRepositoryWhenGetAllThenReturnsAllVehicles()
        {
            var repo = new FakeVehicleRepository();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<VehiclesProfile>(), NullLoggerFactory.Instance);
            var mapper = config.CreateMapper();
            var sut = new GetVehiclesHandler(repo, mapper);
            var request = new GetVehiclesRequest();
            await repo.Add(new Vehicle("VIN1", System.DateTimeOffset.Now), CancellationToken.None);
            await repo.Add(new Vehicle("VIN2", System.DateTimeOffset.Now), CancellationToken.None);

            // Act
            var vehicles = await sut.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(vehicles);
            var list = vehicles.ToList();
            Assert.Equal(2, list.Count);
        }
    }
}
