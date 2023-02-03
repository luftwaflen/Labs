using DAL.Entities;
using DAL.Repository.BDRepository;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestDAL
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GetAll()
        {
            Mock a = new Mock<UserRepository>();

            List<User> expected = GetTmpUsers();
            List<User> actual = new List<User>();

            Assert.Equal(expected, actual);
        }
        public List<User> GetTmpUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User
            {
                Id = 1,
                Name = "Alex"
            });
            users.Add(new User
            {
                Id = 2,
                Name = "Bob"
            });
            users.Add(new User
            {
                Id = 3,
                Name = "Ron"
            });

            return users;
        }
    }
}