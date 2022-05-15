using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthRepository : RepositoryBase<User> , IAuthRepository
    {
        public AuthRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public async Task<User> GetUser(string email)
        {
            var user = await FindByCondition(user => user.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            if (await FindByCondition(user => user.Email == email).FirstOrDefaultAsync() == null)
                return false;
            return true;
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
