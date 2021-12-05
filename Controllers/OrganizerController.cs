using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerRepository _organizerRepository;
        public OrganizerController(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrganizers()
        {
            try
            {
                return Ok(await _organizerRepository.GetOrganizers());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblOrganizer>> GetOrganizer(int id)
        {
            try
            {
                var result = await _organizerRepository.GetOrganizer(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblOrganizer>> CreateOrganizer(TblOrganizer tblOrganizer)
        {
            try
            {
                if(tblOrganizer == null)
                {
                    return BadRequest();
                }
                else
                {
                    var CreateOrganizer = await _organizerRepository.AddOrganizer(tblOrganizer);
                    return CreatedAtAction(nameof(GetOrganizer), new { id = CreateOrganizer.Id }, CreateOrganizer);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblOrganizer>> UpdateOrgainzer(int id, TblOrganizer tblOrganizer)
        {
            try
            {
                if(id != tblOrganizer.Id)
                {
                    return BadRequest();
                }
                var OrganizerUpdate = await _organizerRepository.GetOrganizer(id);
                if(OrganizerUpdate == null)
                {
                    return NotFound($"Organizer Id = {id} not Found");
                }
                else
                {
                    return await _organizerRepository.UpdateOrganizer(tblOrganizer);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblOrganizer>> DeleteOrganizer(int id)
        {
            try
            {
                var OrganizerDelete = await _organizerRepository.GetOrganizer(id);
                if(OrganizerDelete == null)
                {
                    return NotFound($"Organizer Id = {id} not Found");
                }
                else
                {
                    return await _organizerRepository.DeleteOrganizer(id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblOrganizer>>> SearchOrganizer(string name)
        {
            try
            {
                var result = await _organizerRepository.SearchOrganizers(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
    }
}
