using Fruit.Crud.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Domain.Repositories
{
    public interface IFruitRepository
    {
        Task<Entities.Fruit> GetByIdAsync(int id);
        Task<ICollection<Entities.Fruit>> GetAllAsync();
        Task<Entities.Fruit> CreateAsync(Entities.Fruit fruit);
        Task UpdateAsync(Entities.Fruit fruit);
        Task DeleteAsync(Entities.Fruit fruit);
    }
}
