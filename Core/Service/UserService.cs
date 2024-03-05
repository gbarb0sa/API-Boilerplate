using Core.Entities;
using Core.Interfaces;
using Core.Models.Filters;

namespace Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;   
        }

        public async Task<User> AddAsync(User entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(User entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<User>> GetAll(GetUserRequestFilter filter)
        {
            throw new NotImplementedException();
            //return await _repository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
