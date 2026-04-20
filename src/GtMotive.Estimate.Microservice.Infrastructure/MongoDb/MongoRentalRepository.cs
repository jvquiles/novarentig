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
    public class MongoRentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<Rental> _collection;

        public MongoRentalRepository([NotNull] MongoService mongoService, [NotNull] IOptions<MongoDbSettings> options)
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Rental)))
            {
                BsonClassMap.RegisterClassMap<Rental>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(r => r.Id);
                });
            }

            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            _collection = database.GetCollection<Rental>("rentals");
        }

        public Task Add(Rental rental, CancellationToken cancellationToken)
        {
            return _collection.InsertOneAsync(rental, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<Rental>> GetAll(CancellationToken cancellationToken)
        {
            var vehicles = await _collection
                .Find(v => true)
                .ToListAsync(cancellationToken);
            return vehicles.AsReadOnly();
        }
    }
}
