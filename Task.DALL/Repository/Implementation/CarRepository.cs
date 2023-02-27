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
    public class CarRepository : IBaseRepository<Car>
    {
        //Repository for Car
        public AppDbContext context { get; }
        public CarRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Car>> GetAll()
        {
            return await context.Set<Car>().ToListAsync();
        }
        public async Task<Car> GetId(int id)
        {
            return await context.Cars.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Car> Add(Car user)
        {
            context.Set<Car>().Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Car> Update(int id, Car entity)
        {
            var car = await context.Cars.FirstOrDefaultAsync(s => s.Id == id);
            car.Name = entity.Name;
            car.Price = entity.Price;
            car.userId = entity.userId;
            context.Set<Car>().Update(car);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Car> Delete(int id)
        {
            var entity = await context.Set<Car>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<Car>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
