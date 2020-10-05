using System.Threading.Tasks;
using MongoDB.Driver;
using NortB.Data.Entities;

namespace NortB.Data.Core.MongoDb
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private const string Collection = "User";

        public UserRepository(IContextFactory factory) : base(factory, Collection)
        {
        }

        public override async Task Delete(int id)
        {
            await Delete(g => g.Id == id);
        }

        public override async Task<int> Add(User item)
        {
            await Database.GetCollection<User>(Collection).InsertOneAsync(item);
            return item.Id;
        }

        public override async Task Update(User item)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, item.Id);
            await Database.GetCollection<User>(Collection).ReplaceOneAsync(filter, item);
        }
    }
}