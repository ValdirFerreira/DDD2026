using Domain.Interfaces;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios.Genericos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PesquisaContext _context;

        public Repository(PesquisaContext context)
        {
            _context = context;
        }


        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
