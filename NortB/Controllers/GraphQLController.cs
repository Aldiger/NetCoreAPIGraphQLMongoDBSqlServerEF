using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NortB.Data;
using NortB.Data.Core.MongoDb;
using NortB.Data.GraphQL;

namespace NortB.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IContextFactory _context;

        public GraphQLController(ApplicationDbContext db, IContextFactory context)
        {
            _db = db;
            _context = context;
        } 

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            JObject dd= new JObject();

            var schema = new Schema
            {
                Query = new AuthorQuery(_context.GetMongoDatabase())
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}