using System.Text;
using NortB.Data.Entities;

namespace NortB.Data.Core.MongoDb
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
    public interface IUserRepository : IRepository<User>
    {
    }
}
