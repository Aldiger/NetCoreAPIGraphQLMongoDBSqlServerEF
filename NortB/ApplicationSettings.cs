using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NortB
{
    public class ApplicationSettings
    {
        public string MongoServer { get; set; }
        public string MongoDatabase { get; set; }
        public string MongoUser { get; set; }
        public string MongoPassword { get; set; }
    }
}
