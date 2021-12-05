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
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpRepository _signUpRepository;
        public SignUpController(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSignUps()
        {
            try
            {
                return Ok(await _signUpRepository.GetSignUps());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblSignUp>> GetSignUp(int Id)
        {
            try
            {
                var result = await _signUpRepository.GetSignUp(Id);
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
        public async Task<ActionResult<TblSignUp>> CreateSignUp(TblSignUp tblSignUp)
        {
            try
            {
                if(tblSignUp == null)
                {
                    return BadRequest();
                }
                else
                {
                    var CreateSignUp = await _signUpRepository.AddSignUp(tblSignUp);
                    return CreatedAtAction(nameof(GetSignUp), new { id = CreateSignUp.Id }, CreateSignUp);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblSignUp>> UpdateSignUp(int Id, TblSignUp tblSignUp)
        {
            try
            {
                if (Id != tblSignUp.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var SignUpUpdate = await _signUpRepository.GetSignUp(Id);
                if (SignUpUpdate == null)
                {
                    return NotFound($"Sign Up Id = {Id} not Found");
                }
                else
                {
                    return await _signUpRepository.UpdateSignUp(tblSignUp);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblSignUp>> DeleteSignUp(int Id)
        {
            try
            {
                var SignUpDelete = await _signUpRepository.GetSignUp(Id);
                if (SignUpDelete == null)
                {
                    return NotFound($"Employee Id = {Id} not Found");
                }
                else
                {
                    return await _signUpRepository.DeleteSignUp(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<TblSignUp>>> SearcSignUpt(string name)
        {
            try
            {
                var result = await _signUpRepository.SearchSignUp(name);
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
