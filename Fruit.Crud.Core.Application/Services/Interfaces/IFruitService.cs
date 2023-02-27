using Fruit.Crud.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Application.Services.Interfaces
{
    public interface IFruitService
    {
        Task<ResultService<FruitDTO>> CreateAsync(FruitDTO fruitDTO);
        Task<ResultService<ICollection<FruitDTO>>> GetAllAsync();
        Task<ResultService<FruitDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(FruitDTO fruitDTO);
        Task<ResultService> DeleteAsync(int id);

    }
}
