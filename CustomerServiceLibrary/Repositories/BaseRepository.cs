﻿using CustomerServiceLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Repositories
{
    public class BaseRepository<T>(CustomerServiceContext context) where T : BaseEntity
    {
        public IQueryable<T> GetAll() 
        {
            return context.Set<T>().AsQueryable(); // Queryable databaseden hicbirsey cekmez sadece database referans olur. bundan sonraki aksyonlar databaseden veri ceker.
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await GetAll().Where(x => x.Id == id).SingleAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            var entry = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entry.Entity;
        }
        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsyncById(long id)
        {
            var entry = await GetByIdAsync(id);
            await DeleteAsync(entry);
            await context.SaveChangesAsync();
        }
        // generic <T>
    } // task eğer geri obje veremiyeceksek generic atmayacaz
}
