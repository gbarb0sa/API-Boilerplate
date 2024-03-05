using Core.Entities;
using Core.Models.Filters;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll(GetUserRequestFilter filter);
        Task<User> AddAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(User entity);
    }
}
