using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Data.StoreObjects.Mongo;
using GE.Data.TranferObjects.Models;
using GE.Data.Utility;
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


        public IResponse<List<ExchangeListItem>> GetExchangeListForUser(int userId)
        {
            var response = new Response<List<ExchangeListItem>>();

            try
            {
                var exchanges = _db.GetCollection<Exchange>("exchange").Find(Builders<Exchange>.Filter.Empty).ToList();
                var user = _db.GetCollection<User>("user").Find(Builders<User>.Filter.Where(u => u.Id == userId)).FirstOrDefault();

                response.Data = exchanges.Where(e => e.GiftLists.Any(g => user.GiftListIds.Contains(g.Id)))
                    .Select(e => new ExchangeListItem
                    {
                        Id = e.Id,
                        EndDate = e.EndDate,
                        Name = e.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        public IResponse<ExchangeDisplay> GetExchange(int exchangeId, int userId)
        {
            var response = new Response<ExchangeDisplay>();

            try
            {
                var exchange = _db.GetCollection<Exchange>("exchange").Find(Builders<Exchange>.Filter.Where(e => e.Id == exchangeId)).FirstOrDefault();
                var user = _db.GetCollection<User>("user").Find(Builders<User>.Filter.Where(u => u.Id == userId)).FirstOrDefault();

                if (exchange.GiftLists.All(gl => !user.GiftListIds.Contains(gl.Id)))
                {
                    response.NoAccess();
                    return response;
                }

                response.Data = new ExchangeDisplay
                {
                    Name = exchange.Name,
                    EndDate = exchange.EndDate,
                    GiftLists = exchange.GiftLists.Select(gl => new GiftListItemDisplay
                    {
                        Id = gl.Id,
                        UserName = gl.UserName,
                        Gifts = gl.Gifts.Select(g => new GiftDisplay
                        {
                            Description = g.Description,
                            Link = g.Link,
                            Rank = g.Rank
                        }).ToList()
                    }).ToList()
                };

            }
            catch (Exception ex)
            {
                response.Error(ex);
            }

            return response;
        }

        public void Dispose()
        {
            //do nothing
        }
    }
}
