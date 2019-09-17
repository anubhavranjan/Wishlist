using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Wishlist.Models;

namespace Wishlist.Managers
{
    public class MongoManager
    {
        private static string connectionString = @"mongodb://localhost:27017";

        private static MongoClient mongoClient;

        static MongoManager()
        {

            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(connectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            mongoClient = new MongoClient(settings);
        }

        public class WishlistManager
        {
            private static IMongoDatabase Database = mongoClient.GetDatabase("wishlist");
            private static IMongoCollection<Wish> WishesCollection = Database.GetCollection<Wish>("wishes");

            public static void AddWish(Wish wish)
            {
                WishesCollection.InsertOne(wish);
            }

            public static void UpdateWish(Wish wish)
            {
                var filter = Builders<Wish>.Filter.Eq(w => w.Id, wish.Id);
                var result = WishesCollection.ReplaceOne(filter, wish);
            }

            public static void RemoveWish(string wishId)
            {
                var filter = Builders<Wish>.Filter.Eq(w => w.Id, wishId);
                var result = WishesCollection.DeleteOne(filter);
            }

            public static Wish GetWish(string id)
            {
                var filter = Builders<Wish>.Filter.Eq(w => w.Id, id);
                var result = WishesCollection.Find(filter).FirstOrDefault();
                return result;
            }

            public static IEnumerable<Wish> GetAllWishes()
            {
                var filter = FilterDefinition<Wish>.Empty;
                var result = WishesCollection.Find<Wish>(filter).ToList();
                return result;
            }

            public static IEnumerable<Wish> GetAllWishes(string userId)
            {
                var filter = Builders<Wish>.Filter.Eq(w => w.UserId, userId);
                var result = WishesCollection.Find(filter).ToList();
                return result;
            }
        }

    }
}
