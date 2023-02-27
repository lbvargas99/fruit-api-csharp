using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Application.DTOs
{
    public class FruitDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
}
