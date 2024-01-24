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
    public class EventController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendContext _context;

        public EventController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get()
        {
            var result = await _unitOfWork.Events.GetAllAsync();
            return _mapper.Map<List<EventDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDto>> Get(int id)
        {
            var result = await _unitOfWork.Events.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<EventDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Event>> Post(EventDto EventDto)
        {
            var result = _mapper.Map<Event>(EventDto);
            this._unitOfWork.Events.Add(result);
            await _unitOfWork.SaveAsync();

            if (result == null)
            {
                return BadRequest();
            }
            EventDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = EventDto.Id }, EventDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDto>> Put(int id, [FromBody] EventDto EventDto)
        {
            if (EventDto.Id == 0)
            {
                EventDto.Id = id;
            }

            if(EventDto.Id != id)
            {
                return BadRequest();
            }

            if(EventDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Event>(EventDto);
            _unitOfWork.Events.Update(result);
            await _unitOfWork.SaveAsync();
            return EventDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Events.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Events.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}