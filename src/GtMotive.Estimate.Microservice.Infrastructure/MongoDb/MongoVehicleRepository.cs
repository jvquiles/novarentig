using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoVehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _collection;

        public MongoVehicleRepository([NotNull] MongoService mongoService, [NotNull] IOptions<MongoDbSettings> options)
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(v => v.Id);
                });
            }

            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            _collection = database.GetCollection<Vehicle>("vehicles");
        }

        public Task Add(Vehicle vehicle, CancellationToken cancellationToken)
        {
            return _collection.InsertOneAsync(vehicle, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<Vehicle>> GetAll(CancellationToken cancellationToken)
        {
            var vehicles = await _collection.Find(v => v.ManufacturedAt > System.DateTimeOffset.Now.AddYears(-5)).ToListAsync(cancellationToken);
            return vehicles.AsReadOnly();
        }
    }
}
