using System;
using Microsoft.Extensions.DependencyInjection;
using NortB.Data;
using NortB.Data.Core;
using NortB.Data.Entities;

namespace NortB.Services
{
    public class StartUpServices
    {
        public static void Init(IServiceCollection services, string connectionString, string server, string databaseName, string username, string password)
        {
            StartUpData.Init(services, connectionString, server,databaseName,username,password);
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            var serviceProvider = services.BuildServiceProvider();
            DbInitializer.Initialize(serviceProvider);

            #region MongoDb

            services.AddTransient<Services.Mongo.IUserService, Services.Mongo.UserService> ();

            #endregion
        }
    }
}
