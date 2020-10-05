using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace NortB.Data.Core.MongoDb
{
    public class ContextFactory : IContextFactory
    {
        private IMongoDatabase _database;

        private readonly string _server;
        private readonly string _databaseName;
        private readonly string _databaseUsername;
        private readonly string _databasePassword;

        public ContextFactory(string mongoDbServer, string databaseName, string databaseUsername, string databasePassword)
        {
            _server = mongoDbServer;
            _databaseName = databaseName;
            _databaseUsername = databaseUsername;
            _databasePassword = databasePassword;
        }

        public IMongoDatabase GetMongoDatabase()
        {
            var credentials = MongoCredential.CreateCredential(_databaseName, _databaseUsername, _databasePassword);
            var settings = new MongoClientSettings
            {
                Credentials = new[] { credentials },
                Server = new MongoServerAddress(_server)
            };
            return _database ?? (_database = new MongoClient(settings).GetDatabase(_databaseName));
        }
    }
}
