using System;
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

#nullable enable

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

        public async Task<IEnumerable<Rental>> GetAllActive(CancellationToken cancellationToken)
        {
            var rentals = await _collection
                .Find(r => r.EndedAt == null)
                .ToListAsync(cancellationToken);
            return rentals.AsReadOnly();
        }

        public async Task<Rental?> GetById(Guid id)
        {
            var rental = await _collection.Find(r => r.Id == id)
                .FirstOrDefaultAsync();
            return rental;
        }

        public async Task<bool> GetCustomerHasRentalsAtATime(Guid customerId, DateTimeOffset specificTime, CancellationToken cancellationToken)
        {
            var activeRentals = await _collection.Find(r =>
                r.CustomerId == customerId &&
                r.StartingAt <= specificTime &&
                (r.EndedAt == null || r.EndedAt >= specificTime))
                .AnyAsync(cancellationToken);
            return activeRentals;
        }

        public Task Update(Rental rental)
        {
            return _collection.ReplaceOneAsync(r => r.Id == rental.Id, rental);
        }
    }
}
