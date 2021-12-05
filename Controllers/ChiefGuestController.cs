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
    public class ChiefGuestController : ControllerBase
    {
        private readonly IChiefGuestRepository _chiefGuestRepository;
        public ChiefGuestController(IChiefGuestRepository chiefGuestRepository)
        {
            _chiefGuestRepository = chiefGuestRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetChiefGuests()
        {
            try
            {
                return Ok(await _chiefGuestRepository.GetChiefGuests());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblChiefGuest>> GetChiefGuest(int id)
        {
            try
            {
                var result = await _chiefGuestRepository.GetChiefGuest(id);
                if (result == null)
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
        public async Task<ActionResult<TblChiefGuest>> CreateChiefGuest(TblChiefGuest tblChiefGuest)
        {
            try
            {
                if (tblChiefGuest == null)
                {
                    return BadRequest();
                }
                else
                {
                    var CreateChiefGuest = await _chiefGuestRepository.AddChiefGuest(tblChiefGuest);
                    return CreatedAtAction(nameof(GetChiefGuest), new { id = CreateChiefGuest.Id }, CreateChiefGuest);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblChiefGuest>> UpdateChiefGuest(int id, TblChiefGuest tblChiefGuest)
        {
            try
            {
                if (id != tblChiefGuest.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var ChiefGuestUpdate = await _chiefGuestRepository.GetChiefGuest(id);
                if (ChiefGuestUpdate == null)
                {
                    return NotFound($"Employee Id = {id} not Found");
                }
                else
                {
                    return await _chiefGuestRepository.UpdateChiefGuests(tblChiefGuest);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblChiefGuest>> DeleteChiefGuest(int id)
        {
            try
            {
                var ChiefGuestDelete = await _chiefGuestRepository.GetChiefGuest(id);
                if (ChiefGuestDelete == null)
                {
                    return NotFound($"Employee Id = {id} not Found");
                }
                else
                {
                    return await _chiefGuestRepository.DeleteChiefGuests(id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblChiefGuest>>> SearcChiefGuest(string name)
        {
            try
            {
                var result = await _chiefGuestRepository.SearchChiefGuests(name);
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
