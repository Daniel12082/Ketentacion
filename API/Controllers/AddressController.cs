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
    public class AddressController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public AddressController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
        {
            var result = await _unitOfWork.Addresses.GetAllAsync();
            return _mapper.Map<List<AddressDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Get(int id)
        {
            var result = await _unitOfWork.Addresses.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<AddressDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> Post(AddressDto AddressDto)
        {
            var result = _mapper.Map<Address>(AddressDto);
            this._unitOfWork.Addresses.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            AddressDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = AddressDto.Id }, AddressDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Put(int id, [FromBody] AddressDto AddressDto)
        {
            if (AddressDto.Id == 0)
            {
                AddressDto.Id = id;
            }

            if(AddressDto.Id != id)
            {
                return BadRequest();
            }

            if(AddressDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Address>(AddressDto);
            _unitOfWork.Addresses.Update(result);
            await _unitOfWork.SaveAsync();
            return AddressDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Addresses.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Addresses.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}