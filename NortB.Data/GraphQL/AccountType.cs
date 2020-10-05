using GraphQL.Types;
using NortB.Data.Entities;

namespace NortB.Data.GraphQL
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Name= "Account";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Account.");
            Field(x => x.Name).Description("The name of the Account");
            Field(x => x.Paid).Description("Paid");
        }
    }
}