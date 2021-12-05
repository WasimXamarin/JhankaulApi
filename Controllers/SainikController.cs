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
    public class SainikController : ControllerBase
    {
        private readonly ISainikRepository _sainikRepository;
        public SainikController(ISainikRepository sainikRepository)
        {
            _sainikRepository = sainikRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSainiks()
        {
            try
            {
                return Ok(await _sainikRepository.GetSainiks());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblSainik>> GetSainik(int Id)
        {
            try
            {
                var result = _sainikRepository.GetSainik(Id);
                if(result == null)
                {
                    return NotFound();
                }
                return await result;
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data form Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblSainik>> CreateSainik(TblSainik tblSainik)
        {
            try
            {
                if(tblSainik == null)
                {
                    return BadRequest();
                }
                else
                {
                    var SainikCreate = await _sainikRepository.AddSainik(tblSainik);
                    return CreatedAtAction(nameof(GetSainik), new { id = SainikCreate.Id }, SainikCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblSainik>> UpdateSainik(int Id, TblSainik tblSainik)
        {
            try
            {
                if(Id != tblSainik.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var SainikUpdate = await _sainikRepository.GetSainik(Id);
                if(SainikUpdate == null)
                {
                    return NotFound($"Sainik Id = {Id} not Found");
                }
                else
                {
                    return await _sainikRepository.UpdateSainik(tblSainik);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblSainik>> DeleteSainik(int Id)
        {
            try
            {
                var SainikDelete = await _sainikRepository.GetSainik(Id);
                if(SainikDelete == null)
                {
                    return NotFound($"Sainik Id = {Id} not Found");
                }
                else
                {
                    return await _sainikRepository.DeleteSainik(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TblSainik>>> SearchSainik(string name)
        {
            try
            {
                var result = await _sainikRepository.SearchSainik(name);
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }
    }
}
