using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Changes
{
    public class UserEntityChange : IChangeNote<UserEntity>
    {
        private IRepository<UserEntity, UserEntityChange> _repository;
        public string Operation { get; set; }
        public UserEntity OriginObject { get; set; }
        public UserEntity ChangedObject { get; set; }

        public void ExecuteOperation()
        {
            var dictionary = new Dictionary<string, Action<UserEntity>>();
            dictionary.Add("Update", _repository.Update);
            dictionary[Operation].Invoke(ChangedObject);
        }
    }
}
