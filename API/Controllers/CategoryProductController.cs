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
    public class CategoryProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public CategoryProductController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryProductDto>>> Get()
        {
            var result = await _unitOfWork.CategoryProducts.GetAllAsync();
            return _mapper.Map<List<CategoryProductDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryProductDto>> Get(int id)
        {
            var result = await _unitOfWork.CategoryProducts.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryProductDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryProduct>> Post(CategoryProductDto CategoryProductDto)
        {
            var result = _mapper.Map<CategoryProduct>(CategoryProductDto);
            this._unitOfWork.CategoryProducts.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            CategoryProductDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoryProductDto.Id }, CategoryProductDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryProductDto>> Put(int id, [FromBody] CategoryProductDto CategoryProductDto)
        {
            if (CategoryProductDto.Id == 0)
            {
                CategoryProductDto.Id = id;
            }

            if(CategoryProductDto.Id != id)
            {
                return BadRequest();
            }

            if(CategoryProductDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CategoryProduct>(CategoryProductDto);
            _unitOfWork.CategoryProducts.Update(result);
            await _unitOfWork.SaveAsync();
            return CategoryProductDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.CategoryProducts.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryProducts.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}