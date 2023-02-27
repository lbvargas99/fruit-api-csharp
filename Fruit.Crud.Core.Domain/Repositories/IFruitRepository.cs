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
        Task<Entities.Fruit> GetById(int id);
        Task<ICollection<Entities.Fruit>> GetAll();
        Task<Entities.Fruit> Create(Entities.Fruit fruit);
        Task Update(Entities.Fruit fruit);
        Task Delete(Entities.Fruit fruit);
    }
}
