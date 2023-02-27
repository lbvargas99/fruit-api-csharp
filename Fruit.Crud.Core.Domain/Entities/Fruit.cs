using Fruit.Crud.Core.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Domain.Entities
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }

        public Fruit(string description, int valueA, int valueB)
        {
            Validation(description, valueA, valueB);
        }

        public Fruit(int id, string description, int valueA, int valueB)
        {
            DomainValidationException.When(id < 0, "ID inválido.");
            Id = id;
            Validation(description, valueA, valueB);
        }

        private void Validation(string description, int valueA, int valueB)
        {
            DomainValidationException.When(string.IsNullOrEmpty(description), "Descrição deve ser informado.");
            DomainValidationException.When(valueA < 0, "Valor A deve ser informado.");
            DomainValidationException.When(valueB < 0, "Valor B deve ser informado.");
        }
    }
}
