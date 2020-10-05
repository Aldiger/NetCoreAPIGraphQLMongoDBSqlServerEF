using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GraphQL.SystemTextJson;
namespace NortB.Data.GraphQL
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        [JsonConverter(typeof(ObjectDictionaryConverter))]
        public Dictionary<string, object> Variables
        {
            get; set;
        }

    }
}
