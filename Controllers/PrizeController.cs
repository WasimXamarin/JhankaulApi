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
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeRepository _prizeRepository;
        public PrizeController(IPrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPrize()
        {
            try
            {
                return Ok(await _prizeRepository.GetPrizes());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblPrize>> GetPrize(int Id)
        {
            try
            {
                var result = await _prizeRepository.GetPrize(Id);
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
        public async Task<ActionResult<TblPrize>> CreatePrize(TblPrize tblPrize)
        {
            try
            {
                if(tblPrize == null)
                {
                    return BadRequest();
                }
                else
                {
                    var PrizeCreate = _prizeRepository.AddPrize(tblPrize);
                    return CreatedAtAction(nameof(GetPrize), new { id = PrizeCreate }, PrizeCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblPrize>> UpdatePrize(int id, TblPrize tblPrize)
        {
            try
            {
                if(id != tblPrize.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var PrizeUpdate = await _prizeRepository.GetPrize(id);
                if(PrizeUpdate == null)
                {
                    return NotFound($"Prize Id = {id} not found");
                }
                else
                {
                    return await _prizeRepository.UpdatePrize(tblPrize);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblPrize>> DeletePrize(int id)
        {
            try
            {
                var PrizeDelete = await _prizeRepository.GetPrize(id);
                if (PrizeDelete == null)
                {
                    return NotFound($"Prize Id = {id} not Found");
                }
                else
                {
                    return await _prizeRepository.DeletePrize(id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblPrize>>> SearcPrize(string PrizePosition)
        {
            try
            {
                var result = await _prizeRepository.SearchPrize(PrizePosition);
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
