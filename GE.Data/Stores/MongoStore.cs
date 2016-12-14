using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Data.StoreObjects.Mongo;
using GE.Data.TranferObjects.Models;
using MongoDB.Driver;

namespace GE.Data.Stores
{
    internal class MongoStore : IDataStore
    {

        private readonly IMongoDatabase _db;

        public MongoStore()
        {
            IMongoClient client = new MongoClient();
            _db = client.GetDatabase("GiftExchange");
        }


        public List<ExchangeListItem> GetExchangeListForUser(int userId)
        {
            var exchanges = _db.GetCollection<Exchange>("exchange").Find(Builders<Exchange>.Filter.Empty).ToList();
            var user = _db.GetCollection<User>("user").Find(Builders<User>.Filter.Where(u => u.Id == userId)).FirstOrDefault();

            var result = exchanges.Where(e => e.GiftLists.Any(g => user.GiftListIds.Contains(g.Id)))
                .Select(e => new ExchangeListItem
                {
                    Id = e.Id,
                    EndDate = e.EndDate,
                    Name = e.Name
                }).ToList();

            return result;
        }

        public ExchangeDisplay GetExchangeDisplay(int exchangeId, int userId)
        {
            var exchanges = _db.GetCollection<Exchange>("exchange").Find(Builders<Exchange>.Filter.Where(e => e.Id == exchangeId)).FirstOrDefault();
            var user = _db.GetCollection<User>("user").Find(Builders<User>.Filter.Where(u => u.Id == userId)).FirstOrDefault();


        }

        public void Dispose()
        {
            //do nothing
        }
    }
}
