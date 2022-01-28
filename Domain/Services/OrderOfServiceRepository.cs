using MongoDB.Bson;
using MongoDB.Driver;
using ProjectOs.Domain.Interface;
using ProjectOs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectOs.Domain.Services
{
    public class OrderOfServiceRepository : IOrderOfServiceRepository
    {
        private const string databaseName = "OrderOfService";
        private const string collectionName = "OSs";
        public readonly IMongoCollection<OrderOfService> OSCollection;
        private readonly FilterDefinitionBuilder<OrderOfService> filterBuilder = Builders<OrderOfService>.Filter;

        public OrderOfServiceRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            OSCollection = database.GetCollection<OrderOfService>(collectionName);
        }

        public async Task<long> CountAsync()
        {
            return await OSCollection.Find(new BsonDocument()).CountDocumentsAsync();
        }

        public async Task<IEnumerable<OrderOfService>> GetAllOrderOfServiceAsync(DateTime dataOpeningOSInicial, DateTime dataOpeningOSFinal, int? page)
        {
            var builder = Builders<OrderOfService>.Filter;
            FilterDefinition<OrderOfService> filters = builder.Empty;

            if (dataOpeningOSInicial != default(DateTime))
            {
                var dataOpeningOsFilter = builder.Gte(dataI => dataI.DataOpeningaOS, dataOpeningOSInicial);
                filters &= dataOpeningOsFilter;
            }

            if (dataOpeningOSFinal != default(DateTime))
            {
                var dataOpeningOsFilterF = builder.Lte(dataF => dataF.DataOpeningaOS, dataOpeningOSFinal);
                filters &= dataOpeningOsFilterF;
            }

            var find = OSCollection.Find(filters);

            int pagina = page.GetValueOrDefault(1) == 0 ? 1 : page.GetValueOrDefault(1);
            int pageSize = 15;

            return await find.Skip((pagina - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<OrderOfService> GetOneOrderOfServiceAsync(Guid id)
        {
            var filter = filterBuilder.Eq(orderOfService => orderOfService.Id, id);
            return await OSCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateOrderOfServiceAsync(OrderOfService orderOfService)
        {
            await OSCollection.InsertOneAsync(orderOfService);
        }

        public async Task UpdateOrderOfServiceAsync(OrderOfService orderOfService)
        {
            var filter = filterBuilder.Eq(existingOS => existingOS.Id, orderOfService.Id);
            await OSCollection.ReplaceOneAsync(filter, orderOfService);
        }

        public async Task DeleteOrderOfServiceAsync(Guid id)
        {
            var filter = filterBuilder.Eq(orderOfService => orderOfService.Id, id);
            await OSCollection.DeleteOneAsync(filter);
        }
    }
}
