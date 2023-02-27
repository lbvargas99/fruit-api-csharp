using AutoMapper;
using Fruit.Crud.Core.Application.DTOs;
using Fruit.Crud.Core.Application.DTOs.Validations;
using Fruit.Crud.Core.Application.Services.Interfaces;
using Fruit.Crud.Core.Domain.Entities;
using Fruit.Crud.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Application.Services
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;

        private readonly IMapper _mapper;

        public FruitService(IFruitRepository fruitRepository, IMapper mapper)
        {
            _fruitRepository = fruitRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<FruitDTO>> CreateAsync(FruitDTO fruitDTO)
        {
            if (fruitDTO == null)
                return ResultService.Fail<FruitDTO>("Deve ser passado valores ao objeto!");

            //Valida conforme a classe criada se os campos cumprem os requisitos
            var result = new FruitDTOValidator().Validate(fruitDTO);
            if (!result.IsValid)
                return ResultService.RequestError<FruitDTO>("Os campos não cumprem os requisitos", result);

            //Transforma a DTO em entidade para salvar no banco
            var fruit = _mapper.Map<Domain.Entities.Fruit>(fruitDTO);

            //Inserir no banco e armazenar em uma var
            var data = await _fruitRepository.CreateAsync(fruit);

            //Converte o data que és uma entidade para a DTO
            return ResultService.Ok<FruitDTO>(_mapper.Map<FruitDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var fruit = await _fruitRepository.GetByIdAsync(id);
            if (fruit == null)
                return ResultService.Fail("Objeto não encontrado");

            await _fruitRepository.DeleteAsync(fruit);
            return ResultService.Ok("Objeto removido com sucesso!");
        }

        public async Task<ResultService<ICollection<FruitDTO>>> GetAllAsync()
        {
            var fruits = await _fruitRepository.GetAllAsync();
            // ^ Busca entidade - v devolve a DTO
            return ResultService.Ok<ICollection<FruitDTO>>(_mapper.Map<ICollection<FruitDTO>>(fruits));
        }

        public async Task<ResultService<FruitDTO>> GetByIdAsync(int id)
        {
            var fruit = await _fruitRepository.GetByIdAsync(id);
            if (fruit == null)
                return ResultService.Fail<FruitDTO>("Objeto não encontrado!");
            return ResultService.Ok(_mapper.Map<FruitDTO>(fruit));
        }

        public async Task<ResultService> UpdateAsync(FruitDTO fruitDTO)
        {
            if (fruitDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validation = new FruitDTOValidator().Validate(fruitDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com validação dos campos do objeto!", validation);

            var fruit = await _fruitRepository.GetByIdAsync(fruitDTO.Id);
            if (fruit == null)
                return ResultService.Fail("Objeto não encontrado!");

            fruit = _mapper.Map<FruitDTO, Domain.Entities.Fruit>(fruitDTO, fruit);
            await _fruitRepository.UpdateAsync(fruit);
            return ResultService.Ok("Objeto alterado com sucesso!");
        }
    }
}
