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
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpGet]
        public async Task<ActionResult<TblSchool>> GetSchools()
        {
            try
            {
                return Ok(await _schoolRepository.GetSchools());
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblSchool>> GetSchool(int Id)
        {
            try
            {
                var result = _schoolRepository.GetSchool(Id);
                if(result == null)
                {
                    return NotFound();
                }
                return await result;
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblSchool>> CreateSchool(TblSchool tblSchool)
        {
            try
            {
                if(tblSchool == null)
                {
                    return BadRequest();
                }
                else
                {
                    var SchoolCreate = await _schoolRepository.AddSchool(tblSchool);
                    return CreatedAtAction(nameof(GetSchool), new { id = SchoolCreate.Id }, SchoolCreate);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro to retrive the data from Database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblSchool>> UpdateSainik(int Id, TblSchool tblSchool)
        {
            try
            {
                if (Id != tblSchool.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var SchoolUpdate = await _schoolRepository.GetSchool(Id);
                if (SchoolUpdate == null)
                {
                    return NotFound($"Sainik Id = {Id} not Found");
                }
                else
                {
                    return await _schoolRepository.UpdateSchool(tblSchool);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TblSchool>> DeleteSchool(int Id)
        {
            try
            {
                var SchoolDelete = await _schoolRepository.GetSchool(Id);
                if (SchoolDelete == null)
                {
                    return NotFound($"Sainik Id = {Id} not Found");
                }
                else
                {
                    return await _schoolRepository.DeleteSchool(Id);
                }
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive the data from Database");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TblSchool>>> SearchSchool(string schoolName)
        {
            try
            {
                var result = await _schoolRepository.SearchSchool(schoolName);
                if (result.Any())
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
