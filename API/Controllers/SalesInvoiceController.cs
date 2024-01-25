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
//1. CarpetaApiNombre
//2. NombreEntidad
//3. Nombre en UnitOfWork, generalmente en plural
{
    public class SalesInvoiceController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public SalesInvoiceController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SalesInvoiceDto>>> Get()
        {
            var result = await _unitOfWork.SalesInvoices.GetAllAsync();
            return _mapper.Map<List<SalesInvoiceDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesInvoiceDto>> Get(int id)
        {
            var result = await _unitOfWork.SalesInvoices.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<SalesInvoiceDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SalesInvoice>> Post(SalesInvoiceDto SalesInvoiceDto)
        {
            var result = _mapper.Map<SalesInvoice>(SalesInvoiceDto);
            this._unitOfWork.SalesInvoices.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            SalesInvoiceDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = SalesInvoiceDto.Id }, SalesInvoiceDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesInvoiceDto>> Put(int id, [FromBody] SalesInvoiceDto SalesInvoiceDto)
        {
            if (SalesInvoiceDto.Id == 0)
            {
                SalesInvoiceDto.Id = id;
            }

            if(SalesInvoiceDto.Id != id)
            {
                return BadRequest();
            }

            if(SalesInvoiceDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (SalesInvoiceDto.Fecha == DateTime.MinValue)
            {
                SalesInvoiceDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<SalesInvoice>(SalesInvoiceDto);
            _unitOfWork.SalesInvoices.Update(result);
            await _unitOfWork.SaveAsync();
            return SalesInvoiceDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.SalesInvoices.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.SalesInvoices.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}