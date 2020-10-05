using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NortB.Data.Core.MongoDb;
using NortB.Data.Entities;

namespace NortB.Data
{
    public class StartUpData
    {
        public static async void Init(IServiceCollection services, string connectionString, string server, string databaseName, string username, string password)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connectionString));

            #region MongoDB

            services.AddScoped<IContextFactory, ContextFactory>(provider => new ContextFactory(server, databaseName, username, password));
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            var factory = new ContextFactory(server, databaseName, username, password);
            //await CreateIndexesForUserCollection(factory.GetMongoDatabase());
            //await CreateIndexesForAccountCollection(factory.GetMongoDatabase());

            #endregion

        }


        public static async Task CreateIndexesForUserCollection(IMongoDatabase database)
        {
            var collection = database.GetCollection<User>("User");
            await collection.Indexes.CreateManyAsync(new List<CreateIndexModel<User>>
            {
                new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(_ => _.Id))
            });
        }

        public static async Task CreateIndexesForAccountCollection(IMongoDatabase database)
        {
            var collection = database.GetCollection<Account>("Account");
            await collection.Indexes.CreateManyAsync(new List<CreateIndexModel<Account>>
            {
                new CreateIndexModel<Account>(Builders<Account>.IndexKeys.Ascending(_ => _.Id))
            });
        }


    }
}
