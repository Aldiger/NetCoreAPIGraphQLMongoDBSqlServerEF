using System.Linq;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace NortB.Data.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(ApplicationDbContext db)
        {
            Field<UserType>(
                "User",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the User." }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var user = db
                        .Users
                        .Include(a => a.Account)
                        .FirstOrDefault(i => i.Id == id);
                    return user;
                });

            Field<ListGraphType<UserType>>(
                "Users",
                resolve: context =>
                {
                    var users = db.Users.Include(a => a.Account);
                    return users;
                });

            Field<AccountType>(
                "Account",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the User." }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var user = db
                        .Accounts
                        .FirstOrDefault(i => i.Id == id);
                    return user;
                });

            Field<ListGraphType<AccountType>>(
                "Accounts",
                resolve: context =>
                {
                    var users = db.Accounts;
                    return users;
                });
        }
    }
}