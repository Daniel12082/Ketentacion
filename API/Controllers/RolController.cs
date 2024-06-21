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
using Persistence.Data;

namespace API.Controller

{
    public class RolController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public RolController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolDto>>> Get()
        {
            var result = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Get(int id)
        {
            var result = await _unitOfWork.Roles.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<RolDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> Post(RolDto RolDto)
        {
            var result = _mapper.Map<Rol>(RolDto);
            this._unitOfWork.Roles.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            RolDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = RolDto.Id }, RolDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto RolDto)
        {
            if (RolDto.Id == 0)
            {
                RolDto.Id = id;
            }

            if(RolDto.Id != id)
            {
                return BadRequest();
            }

            if(RolDto == null)
            {
                return NotFound();
            }


            var result = _mapper.Map<Rol>(RolDto);
            _unitOfWork.Roles.Update(result);
            await _unitOfWork.SaveAsync();
            return RolDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Roles.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Roles.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}