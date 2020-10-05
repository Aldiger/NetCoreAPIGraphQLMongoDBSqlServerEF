using System.Collections.Generic;
using System.Linq;
using NortB.Data.Core.MongoDb;
using NortB.Services.Dto;
using NortB.Services.Result;

namespace NortB.Services.Services.Mongo
{
    public interface IUserService
    {
        UserResult GetUsers();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private const string AllKey = "All";

        public UserService(
            IUserRepository userRepository,
            IAccountRepository accountRepository
            )
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }


        public UserResult GetUsers()
        {
            var result = new UserResult();
           var data= (from u in _userRepository.GetAllQueryable()
                //join b in _accountRepository.GetAllQueryable()
                //    on u.AccountId equals b.Id
                select new UserDto
                {
                    //AccountName = b.Name,
                    Id = u.Id,
                    Name = u.Name
                }).ToList();
            
            if (!data.Any())
            {
                result.ValidationResults = new List<ValidationResult> { new ValidationResult("No user found.") };
                return result;
            }

            result.Users = data;
            return result;
        }

       
    }
}
