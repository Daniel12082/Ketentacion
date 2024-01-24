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
    public class InvoiceController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> Get()
        {
            var result = await _unitOfWork.Invoices.GetAllAsync();
            return _mapper.Map<List<InvoiceDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDto>> Get(int id)
        {
            var result = await _unitOfWork.Invoices.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<InvoiceDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Invoice>> Post(InvoiceDto InvoiceDto)
        {
            var result = _mapper.Map<Invoice>(InvoiceDto);
            this._unitOfWork.Invoices.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            InvoiceDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = InvoiceDto.Id }, InvoiceDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceDto>> Put(int id, [FromBody] InvoiceDto InvoiceDto)
        {
            if (InvoiceDto.Id == 0)
            {
                InvoiceDto.Id = id;
            }

            if(InvoiceDto.Id != id)
            {
                return BadRequest();
            }

            if(InvoiceDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Invoice>(InvoiceDto);
            _unitOfWork.Invoices.Update(result);
            await _unitOfWork.SaveAsync();
            return InvoiceDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Invoices.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Invoices.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}