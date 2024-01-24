using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller

{
    public class TypeSupplierController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public TypeSupplierController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypeSupplierDto>>> Get()
        {
            var result = await _unitOfWork.TypeSuppliers.GetAllAsync();
            return _mapper.Map<List<TypeSupplierDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeSupplierDto>> Get(int id)
        {
            var result = await _unitOfWork.TypeSuppliers.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<TypeSupplierDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypeSupplier>> Post(TypeSupplierDto TypeSupplierDto)
        {
            var result = _mapper.Map<TypeSupplier>(TypeSupplierDto);
            this._unitOfWork.TypeSuppliers.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            TypeSupplierDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = TypeSupplierDto.Id }, TypeSupplierDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeSupplierDto>> Put(int id, [FromBody] TypeSupplierDto TypeSupplierDto)
        {
            if (TypeSupplierDto.Id == 0)
            {
                TypeSupplierDto.Id = id;
            }

            if(TypeSupplierDto.Id != id)
            {
                return BadRequest();
            }

            if(TypeSupplierDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TypeSupplier>(TypeSupplierDto);
            _unitOfWork.TypeSuppliers.Update(result);
            await _unitOfWork.SaveAsync();
            return TypeSupplierDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.TypeSuppliers.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.TypeSuppliers.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}