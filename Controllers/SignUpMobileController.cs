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
    public class SignUpMobileController : ControllerBase
    {
        private readonly ISignUpMobileRepository _signUpMobileRepository;
        public SignUpMobileController(ISignUpMobileRepository signUpMobileRepository)
        {
            _signUpMobileRepository = signUpMobileRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSignUpMobiles()
        {
            try
            {
                return Ok(await _signUpMobileRepository.GetSignUpMobiles());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving the data form Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblSignUpMobile>> GetSignUpMobile(int Id)
        {
            try
            {
                var result = await _signUpMobileRepository.GetSignUpMobile(Id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving the data from Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblSignUpMobile>> CreateSignUpMobile(TblSignUpMobile tblSignUpMobile)
        {
            try
            {
                if (tblSignUpMobile == null)
                {
                    return BadRequest();
                }
                else
                {
                    var SignUpMobileCreate = await _signUpMobileRepository.AddSignUpMobile(tblSignUpMobile);
                    return CreatedAtAction(nameof(GetSignUpMobile), new { id = SignUpMobileCreate.Id }, SignUpMobileCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving the data from database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblSignUpMobile>> UpdateSignUpMobile(int Id, TblSignUpMobile tblSignUpMobile)
        {
            try
            {
                if (Id != tblSignUpMobile.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var SignUpMobileUpdate = await _signUpMobileRepository.GetSignUpMobile(Id);
                if (SignUpMobileUpdate == null)
                {
                    return NotFound($"Sign Up Mobile Id = {Id} not Found");
                }
                else
                {
                    return await _signUpMobileRepository.UpdateSignUpMobile(tblSignUpMobile);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblSignUpMobile>> DeleteSignUpMobile(int Id)
        {
            try
            {
                var SignUpMobileDelete = await _signUpMobileRepository.GetSignUpMobile(Id);
                if (SignUpMobileDelete == null)
                {
                    return NotFound($"Student Id = {Id} not Found");
                }
                else
                {
                    return await _signUpMobileRepository.DeleteSignUpMobile(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblSignUpMobile>>> SearcSignUpMobile(string MobileNumber)
        {
            try
            {
                var result = await _signUpMobileRepository.SearchSignUpMobile(MobileNumber);
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
