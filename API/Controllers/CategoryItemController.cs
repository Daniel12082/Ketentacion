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
    public class CategoryItemController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public CategoryItemController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryItemDto>>> Get()
        {
            var result = await _unitOfWork.CategoryItems.GetAllAsync();
            return _mapper.Map<List<CategoryItemDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryItemDto>> Get(int id)
        {
            var result = await _unitOfWork.CategoryItems.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryItemDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryItem>> Post(CategoryItemDto CategoryItemDto)
        {
            var result = _mapper.Map<CategoryItem>(CategoryItemDto);
            this._unitOfWork.CategoryItems.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            CategoryItemDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoryItemDto.Id }, CategoryItemDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryItemDto>> Put(int id, [FromBody] CategoryItemDto CategoryItemDto)
        {
            if (CategoryItemDto.Id == 0)
            {
                CategoryItemDto.Id = id;
            }

            if(CategoryItemDto.Id != id)
            {
                return BadRequest();
            }

            if(CategoryItemDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CategoryItem>(CategoryItemDto);
            _unitOfWork.CategoryItems.Update(result);
            await _unitOfWork.SaveAsync();
            return CategoryItemDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.CategoryItems.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryItems.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}