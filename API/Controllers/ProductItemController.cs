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
    public class ProductItemController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public ProductItemController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductItemDto>>> Get()
        {
            var result = await _unitOfWork.ProductItems.GetAllAsync();
            return _mapper.Map<List<ProductItemDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductItemDto>> Get(int id)
        {
            var result = await _unitOfWork.ProductItems.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProductItemDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductItem>> Post(ProductItemDto ProductItemDto)
        {
            var result = _mapper.Map<ProductItem>(ProductItemDto);
            this._unitOfWork.ProductItems.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            ProductItemDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductItemDto.Id }, ProductItemDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductItemDto>> Put(int id, [FromBody] ProductItemDto ProductItemDto)
        {
            if (ProductItemDto.Id == 0)
            {
                ProductItemDto.Id = id;
            }

            if(ProductItemDto.Id != id)
            {
                return BadRequest();
            }

            if(ProductItemDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ProductItem>(ProductItemDto);
            _unitOfWork.ProductItems.Update(result);
            await _unitOfWork.SaveAsync();
            return ProductItemDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.ProductItems.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductItems.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}