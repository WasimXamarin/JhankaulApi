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
    public class HomeController : ControllerBase
    {
        private readonly IHomeRepository _homeRepository;
        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblHome>> DeleteHome(int Id)
        {
            try
            {
                var HomeDelete = await _homeRepository.GetHome(Id);
                if (HomeDelete == null)
                {
                    return NotFound($"Home Id = {Id} not found");
                }
                else
                {
                    return await _homeRepository.DeleteHome(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblHome>> CreateHome(TblHome tblHome)
        {
            try
            {
                if (tblHome == null)
                {
                    return BadRequest();
                }
                else
                {
                    var HomeCreate = _homeRepository.AddHome(tblHome);
                    return CreatedAtAction(nameof(HomeCreate), new { id = HomeCreate }, HomeCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblHome>> UpdateHome(int Id, TblHome tblHome)
        {
            try
            {
                if (Id != tblHome.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var HomeUpdate = await _homeRepository.GetHome(Id);
                if (HomeUpdate == null)
                {
                    return NotFound($"Home Id = {Id} not found");
                }
                else
                {
                    return await _homeRepository.UpdateHome(tblHome);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
    }
}
