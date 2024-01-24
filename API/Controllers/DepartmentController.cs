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
//1. CarpetaApiNombre
//2. NombreEntidad
//3. Nombre en UnitOfWork, generalmente en plural
{
    public class DepartmentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        {
            var result = await _unitOfWork.Departments.GetAllAsync();
            return _mapper.Map<List<DepartmentDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var result = await _unitOfWork.Departments.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<DepartmentDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Department>> Post(DepartmentDto DepartmentDto)
        {
            var result = _mapper.Map<Department>(DepartmentDto);
            this._unitOfWork.Departments.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            DepartmentDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = DepartmentDto.Id }, DepartmentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDto>> Put(int id, [FromBody] DepartmentDto DepartmentDto)
        {
            if (DepartmentDto.Id == 0)
            {
                DepartmentDto.Id = id;
            }

            if(DepartmentDto.Id != id)
            {
                return BadRequest();
            }

            if(DepartmentDto == null)
            {
                return NotFound();
            }

             // Por si requiero la fecha actual
            /*if (DepartmentDto.Fecha == DateTime.MinValue)
            {
                DepartmentDto.Fecha = DateTime.Now;
            }*/

            var result = _mapper.Map<Department>(DepartmentDto);
            _unitOfWork.Departments.Update(result);
            await _unitOfWork.SaveAsync();
            return DepartmentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Departments.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Departments.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}