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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProfiles()
        {
            try
            {
                return Ok(await _profileRepository.GetProfiles());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblProfile>> GetProfile(int Id)
        {
            try
            {
                var result = await _profileRepository.GetProfile(Id);
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
        public async Task<ActionResult<TblProfile>> CreateProfile(TblProfile tblProfile)
        {
            try
            {
                if(tblProfile == null)
                {
                    return BadRequest();
                }
                else
                {
                    var ProfileCreate = await _profileRepository.AddProfile(tblProfile);
                    return CreatedAtAction(nameof(ProfileCreate), new { Id = ProfileCreate }, ProfileCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblProfile>> UpdateProfile(int Id, TblProfile tblProfile)
        {
            try
            {
                if(Id != tblProfile.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var ProfileUpdate = await _profileRepository.UpdateProfile(tblProfile);
                if(ProfileUpdate == null)
                {
                    return NotFound($"Profile Id = {Id} not found");
                }
                else
                {
                    return await _profileRepository.UpdateProfile(tblProfile);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblProfile>> DeleteProfile(int Id)
        {
            try
            {
                var ProfileDelete = await _profileRepository.GetProfile(Id);
                if(ProfileDelete == null)
                {
                    return NotFound($"Profile Id = {Id} not found");
                }
                else
                {
                    return await _profileRepository.DeleteProfile(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
        [HttpGet("{searchFirstName}")]
        public async Task<ActionResult<TblProfile>> SearchProfileFirstName(string FirstName)
        {
            try
            {
                var result = await _profileRepository.SearchProfileName(FirstName);
                if(result.Any())
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
        [HttpGet("{searchMobileNumber}")]
        public async Task<ActionResult<TblProfile>> SearchProfileMobileNumber(string MobileNumber)
        {
            try
            {
                var result = await _profileRepository.SearchProfileMobileNumber(MobileNumber);
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
