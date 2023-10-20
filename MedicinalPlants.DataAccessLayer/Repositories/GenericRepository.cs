using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(T t)
        {
            _appDbContext.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);

        }

        public async Task<List<T>> GetListAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T t)
        {

            await _appDbContext.AddAsync(t);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {
            _appDbContext.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }

}
