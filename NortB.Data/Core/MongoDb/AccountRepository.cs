
using System.Threading.Tasks;
using MongoDB.Driver;
using NortB.Data.Entities;

namespace NortB.Data.Core.MongoDb
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private const string Collection = "Account";

        public AccountRepository(IContextFactory factory) : base(factory, Collection)
        {
        }

        public override async Task Delete(int id)
        {
            await Delete(g => g.Id == id);
        }

        public override async Task<int> Add(Account item)
        {
            await Database.GetCollection<Account>(Collection).InsertOneAsync(item);
            return item.Id;
        }

        public override async Task Update(Account item)
        {
            var filter = Builders<Account>.Filter.Eq(s => s.Id, item.Id);
            await Database.GetCollection<Account>(Collection).ReplaceOneAsync(filter, item);
        }
    }
}
