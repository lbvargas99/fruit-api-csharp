﻿using AutoMapper;
using Fruit.Crud.Core.Application.DTOs;
using Fruit.Crud.Core.Application.DTOs.Validations;
using Fruit.Crud.Core.Application.Services.Interfaces;
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

        public async Task<ResultService<FruitDTO>> Create(FruitDTO fruitDTO)
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
            var data = await _fruitRepository.Create(fruit);

            //Converte o data que és uma entidade para a DTO
            return ResultService.Ok<FruitDTO>(_mapper.Map<FruitDTO>(data));
        }
    }
}