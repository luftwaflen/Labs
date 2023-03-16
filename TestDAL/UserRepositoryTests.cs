using DAL.Entities;
using DAL.Repository.DbRepository;
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

            List<UserEntity> expected = GetTmpUsers();
            List<UserEntity> actual = new List<UserEntity>();

            Assert.Equal(expected, actual);
        }
        public List<UserEntity> GetTmpUsers()
        {
            List<UserEntity> users = new List<UserEntity>();

            users.Add(new UserEntity
            {
                Id = 1,
                Name = "Alex"
            });
            users.Add(new UserEntity
            {
                Id = 2,
                Name = "Bob"
            });
            users.Add(new UserEntity
            {
                Id = 3,
                Name = "Ron"
            });

            return users;
        }
    }
}