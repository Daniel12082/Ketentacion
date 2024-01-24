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
    public class DeparmentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public DeparmentController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DeparmentDto>>> Get()
        {
            var result = await _unitOfWork.Deparments.GetAllAsync();
            return _mapper.Map<List<DeparmentDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeparmentDto>> Get(int id)
        {
            var result = await _unitOfWork.Deparments.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<DeparmentDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Deparment>> Post(DeparmentDto DeparmentDto)
        {
            var result = _mapper.Map<Deparment>(DeparmentDto);
            this._unitOfWork.Deparments.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            DeparmentDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = DeparmentDto.Id }, DeparmentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeparmentDto>> Put(int id, [FromBody] DeparmentDto DeparmentDto)
        {
            if (DeparmentDto.Id == 0)
            {
                DeparmentDto.Id = id;
            }

            if(DeparmentDto.Id != id)
            {
                return BadRequest();
            }

            if(DeparmentDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Deparment>(DeparmentDto);
            _unitOfWork.Deparments.Update(result);
            await _unitOfWork.SaveAsync();
            return DeparmentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Deparments.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Deparments.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}