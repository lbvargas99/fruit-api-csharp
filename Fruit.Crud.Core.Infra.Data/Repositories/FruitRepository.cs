﻿using Fruit.Crud.Core.Domain.Repositories;
using Fruit.Crud.Core.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Infra.Data.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private readonly ApplicationDbContext _db;

        public FruitRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Domain.Entities.Fruit> Create(Domain.Entities.Fruit fruit)
        {
            _db.Add(fruit);
            await _db.SaveChangesAsync();
            return fruit;
        }

        public async Task Delete(Domain.Entities.Fruit fruit)
        {
            _db.Remove(fruit);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Domain.Entities.Fruit>> GetAll()
        {
            return await _db.Fruits.ToListAsync();
        }

        public async Task<Domain.Entities.Fruit> GetById(int id)
        {
            return await _db.Fruits.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Domain.Entities.Fruit fruit)
        {
            _db.Update(fruit);
            await _db.SaveChangesAsync();
        }
    }
}
