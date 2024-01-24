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
    public class CompanyController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> Get()
        {
            var result = await _unitOfWork.Companies.GetAllAsync();
            return _mapper.Map<List<CompanyDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyDto>> Get(int id)
        {
            var result = await _unitOfWork.Companies.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompanyDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Company>> Post(CompanyDto CompanyDto)
        {
            var result = _mapper.Map<Company>(CompanyDto);
            this._unitOfWork.Companies.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            CompanyDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = CompanyDto.Id }, CompanyDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyDto>> Put(int id, [FromBody] CompanyDto CompanyDto)
        {
            if (CompanyDto.Id == 0)
            {
                CompanyDto.Id = id;
            }

            if(CompanyDto.Id != id)
            {
                return BadRequest();
            }

            if(CompanyDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Company>(CompanyDto);
            _unitOfWork.Companies.Update(result);
            await _unitOfWork.SaveAsync();
            return CompanyDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Companies.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Companies.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}