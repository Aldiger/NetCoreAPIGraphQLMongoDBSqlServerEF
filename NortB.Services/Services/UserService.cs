using System;
using System.Collections.Generic;
using System.Linq;
using NortB.Data.Core;
using NortB.Data.Entities;
using NortB.Services.Dto;

namespace NortB.Services
{
    public interface IUserService
    {
        IList<UserDto> GetUsers();
    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public UserService(IUserRepository userRepository,
            IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public IList<UserDto> GetUsers()
        {
            return (from u in _userRepository.GetAll()
                join b in _accountRepository.GetAll()
                    on u.AccountId equals b.Id
                select new UserDto
                {
                    AccountName = b.Name,
                    Id = u.Id,
                    Name = u.Name
                }).ToList();
        }
    }
}
