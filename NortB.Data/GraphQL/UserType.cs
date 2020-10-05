using GraphQL.Types;
using NortB.Data.Entities;

namespace NortB.Data.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("User's ID.");
            Field(x => x.Name).Description("The name of the User");
            Field(x => x.Account, type: typeof(ListGraphType<AccountType>)).Description("User's accounts");
        }
    }
}