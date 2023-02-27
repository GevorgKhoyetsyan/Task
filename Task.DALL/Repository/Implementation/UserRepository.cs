using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DALL.Data.Context;
using Task.DALL.Models;
using Task.DALL.Repository.Interface;

namespace Task.DALL.Repository.Implementation
{
    public class UserRepository : IBaseRepository<User> 
    {
        //Repository for User
        public AppDbContext context { get; }
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<User>> GetAll()
        {
            return await context.Set<User>().Include(c => c.cars).ToListAsync();
        }

        public async Task<User> GetId(int id)
        {
            var user = context.Users
               .Include(x => x.cars)
               .Where(x => x.Id == id)
               .FirstOrDefault();
            return user;
        }

        public async Task<User> Add(User user)
        {
            context.Set<User>().Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(int id, User entity)
        {
            var user = context.Users
              .Include(x => x.cars)
              .Where(x => x.Id == id)
              .FirstOrDefault();
                user.Age = entity.Age;
                user.Name = entity.Name;
                user.Email = entity.Email;
                context.Set<User>().Update(user);
                await context.SaveChangesAsync();
                return user;
        }
        public async Task<User> Delete(int id)
        {
            var entity = await context.Set<User>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<User>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
