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
    public class PaymentMethodController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public PaymentMethodController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaymentMethodDto>>> Get()
        {
            var result = await _unitOfWork.PaymentMethods.GetAllAsync();
            return _mapper.Map<List<PaymentMethodDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentMethodDto>> Get(int id)
        {
            var result = await _unitOfWork.PaymentMethods.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<PaymentMethodDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentMethod>> Post(PaymentMethodDto PaymentMethodDto)
        {
            var result = _mapper.Map<PaymentMethod>(PaymentMethodDto);
            this._unitOfWork.PaymentMethods.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            PaymentMethodDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = PaymentMethodDto.Id }, PaymentMethodDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentMethodDto>> Put(int id, [FromBody] PaymentMethodDto PaymentMethodDto)
        {
            if (PaymentMethodDto.Id == 0)
            {
                PaymentMethodDto.Id = id;
            }

            if(PaymentMethodDto.Id != id)
            {
                return BadRequest();
            }

            if(PaymentMethodDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<PaymentMethod>(PaymentMethodDto);
            _unitOfWork.PaymentMethods.Update(result);
            await _unitOfWork.SaveAsync();
            return PaymentMethodDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.PaymentMethods.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.PaymentMethods.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}