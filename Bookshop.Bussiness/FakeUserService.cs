using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Business.Interfaces;
using Bookshop.Entities;

namespace Bookshop.Business
{
    public class FakeUserService : IUserService
    {
        private readonly List<User> users;

        public FakeUserService()
        {
            users = new List<User>
            {
                new User
                {
                    Id=1, 
                    Email="user@test.com", 
                    Name="User", 
                    LastName="One", 
                    Password="123", 
                    UserName="userOne",
                    Role="Admin"
                },
                new User
                {
                    Id=2,
                    Email="user2@test.com",
                    Name="User",
                    LastName="Two",
                    Password="123",
                    UserName="userTwo",
                    Role="Editor"
                },
            };
        }

        public User ValidateUser(string userName, string password) => users.FirstOrDefault(u=> u.UserName == userName && u.Password == password);
    }
}
