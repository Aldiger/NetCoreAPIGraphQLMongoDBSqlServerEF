using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NortB.Data.Entities;

namespace NortB.Data
{
    public static class DbInitializer
    {
        private static ApplicationDbContext _context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            InitializeDbWithSomeData();
        }
        private static void InitializeDbWithSomeData()
        {
            #region Account
            if (!_context.Accounts.Any())
            {
                _context.Accounts.AddRange(new Account[]
                {
                    new Account { Id=1, Name="Account 1" },
                    new Account(){ Id=2, Name="Account 2" },
                    new Account(){ Id=3, Name="Account 3" },
                    new Account(){ Id=4, Name="Account 4" }
                });

                _context.Database.OpenConnection();
                try
                {
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Accounts ON");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Accounts OFF");
                }
                finally
                {
                    _context.Database.CloseConnection();
                }
            }
            #endregion
            #region Users
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(new User[]
                {
                    new User(){ 
                        Id=1,
                        Name ="Hans",
                        AccountId = 1},
                    new User(){
                        Id=2,
                        Name ="Ben",
                        AccountId = 2},
                    new User(){
                        Id=3,
                        Name ="Gary",
                        AccountId = 3},
                    new User(){
                        Id=4,
                        Name ="Mike",
                        AccountId = 4},
                });

                _context.Database.OpenConnection();
                try
                {
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
                }
                finally
                {
                    _context.Database.CloseConnection();
                }
            }
            #endregion
        }
    }
}
