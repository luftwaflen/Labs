using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Changes
{
    public class UserEntityChange : IChangeNote<UserEntity>
    {
        public string Operation { get; set; }
        public UserEntity OriginObject { get; set; }
        public UserEntity ChangedObject { get; set; }
    }
}
