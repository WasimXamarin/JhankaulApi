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
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAbouts()
        {
            try
            {
                return Ok(await _aboutRepository.GetAbouts());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblAbout>> GetAbout(int Id)
        {
            try
            {
                var result = await _aboutRepository.GetAbout(Id);
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
        public async Task<ActionResult<TblAbout>> CreateAbout(TblAbout tblAbout)
        {
            try
            {
                if(tblAbout == null)
                {
                    return BadRequest();
                }
                else
                {
                    var AboutCreate = _aboutRepository.AddAbout(tblAbout);
                    return CreatedAtAction(nameof(AboutCreate), new { id = AboutCreate }, AboutCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblAbout>> UpdateAbout(int Id, TblAbout tblAbout)
        {
            try
            {
                if(Id != tblAbout.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var AboutUpdate = await _aboutRepository.GetAbout(Id);
                if(AboutUpdate == null)
                {
                    return NotFound($"About Id = {Id} not found");
                }
                else
                {
                    return await _aboutRepository.UpdateAbout(tblAbout);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblAbout>> DeleteAbout(int Id)
        {
            try
            {
                var AboutDelete = await _aboutRepository.GetAbout(Id);
                if(AboutDelete == null)
                {
                    return NotFound($"About Id = {Id} not found");
                }
                else
                {
                    return await _aboutRepository.DeleteAbout(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblAbout>>> SearcAbout(string name)
        {
            try
            {
                var result = await _aboutRepository.SearchAbout(name);
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
