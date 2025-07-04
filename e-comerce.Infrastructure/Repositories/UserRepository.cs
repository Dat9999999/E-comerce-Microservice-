using e_comerce.Infrastructure.DTO;
using e_comerce.Infrastructure.Entities;

namespace e_comerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<ApplicationUser> GetByEmailAndPassword(string email, string password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "PersonName test",
            Gender = GenderOptions.Male.ToString()
        };
    }

    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        return user;
    }
}