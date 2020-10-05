using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace NortB.Data.Core.MongoDb
{
    public interface IContextFactory
    {
        IMongoDatabase GetMongoDatabase();
    }
}
