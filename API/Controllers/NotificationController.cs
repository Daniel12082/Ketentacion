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
    public class NotificationController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly KetentacionBackendqContext _context;

        public NotificationController(IUnitOfWork unitOfWork, IMapper mapper, KetentacionBackendqContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> Get()
        {
            var result = await _unitOfWork.Notifications.GetAllAsync();
            return _mapper.Map<List<NotificationDto>>(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NotificationDto>> Get(int id)
        {
            var result = await _unitOfWork.Notifications.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<NotificationDto>(result);
        }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<Notification>> Post(NotificationDto NotificationDto)
        // {
        //     var result = _mapper.Map<Notification>(NotificationDto);
        //     this._unitOfWork.Notifications.Add(result);
        //     await _unitOfWork.SaveAsync();

        //     if (result == null)
        //     {
        //         return BadRequest();
        //     }
        //     NotificationDto.Id = result.Id;
        //     return CreatedAtAction(nameof(Post), new { id = NotificationDto.Id }, NotificationDto);
        // }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NotificationDto>> Put(int id, [FromBody] NotificationDto NotificationDto)
        {
            if (NotificationDto.Id == 0)
            {
                NotificationDto.Id = id;
            }

            if(NotificationDto.Id != id)
            {
                return BadRequest();
            }

            if(NotificationDto == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<Notification>(NotificationDto);
            _unitOfWork.Notifications.Update(result);
            await _unitOfWork.SaveAsync();
            return NotificationDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Notifications.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Notifications.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}