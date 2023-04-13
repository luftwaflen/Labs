using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Changes
{
    public class UserEntityChange : IChangeNote<UserEntity>
    {
        private IRepository<UserEntity, UserEntityChange> _repository;
        public ChangeOperation Operation { get; set; }
        public UserEntity OriginObject { get; set; }
        public UserEntity ChangedObject { get; set; }
    }
}
