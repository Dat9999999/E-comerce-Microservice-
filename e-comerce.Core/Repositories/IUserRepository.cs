using e_comerce.Infrastructure.Entities;

namespace e_comerce.Infrastructure.Repositories;

public interface IUserRepository
{
    public Task<ApplicationUser> GetByEmailAndPassword(string email, string password);
    public Task<ApplicationUser> AddUser(ApplicationUser user);
}