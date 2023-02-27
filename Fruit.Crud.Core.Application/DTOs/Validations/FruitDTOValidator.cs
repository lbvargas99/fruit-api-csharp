using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Application.DTOs.Validations
{
    public class FruitDTOValidator : AbstractValidator<FruitDTO>
    {
        public FruitDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");

            RuleFor(x => x.ValueA)
                .NotEmpty()
                .NotNull()
                .WithMessage("Valor A deve ser informado!");
                    
            RuleFor(x => x.ValueB)
                .NotEmpty()
                .NotNull()
                .WithMessage("Valor B deve ser informado!");
        }
    }
}
