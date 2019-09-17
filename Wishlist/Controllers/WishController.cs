using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Wishlist.Managers;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    [Route("api/wish")]
    [ApiController]
    public class WishController : ControllerBase
    {
        // GET: api/Wish/
        [HttpGet]
        public IEnumerable<Wish> Get()
        {
            return MongoManager.WishlistManager.GetAllWishes();
        }

        // GET: api/Wish/sdagfdsggsa
        [HttpGet("{userId}")]
        public IEnumerable<Wish> Get(string userId)
        {
            return MongoManager.WishlistManager.GetAllWishes(userId);
        }

        // POST: api/Wish
        [HttpPost]
        public void Post([FromBody] Wish wish)
        {
            wish.UpdatedOn = DateTime.UtcNow;
            MongoManager.WishlistManager.AddWish(wish);
        }

        // PUT: api/Wish/5
        [HttpPut]
        public void Put([FromBody] Wish wish)
        {
            wish.UpdatedOn = DateTime.UtcNow;
            MongoManager.WishlistManager.UpdateWish(wish);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MongoManager.WishlistManager.RemoveWish(id);
        }
    }
}
