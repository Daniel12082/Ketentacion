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
    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var result = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            var result = await _unitOfWork.Orders.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<OrderDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Post(OrderDto OrderDto)
        {
            var result = _mapper.Map<Order>(OrderDto);
            this._unitOfWork.Orders.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            OrderDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = OrderDto.Id }, OrderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> Put(int id, [FromBody] OrderDto OrderDto)
        {
            if (OrderDto.Id == 0)
            {
                OrderDto.Id = id;
            }

            if(OrderDto.Id != id)
            {
                return BadRequest();
            }

            if(OrderDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Order>(OrderDto);
            _unitOfWork.Orders.Update(result);
            await _unitOfWork.SaveAsync();
            return OrderDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Orders.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Orders.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}