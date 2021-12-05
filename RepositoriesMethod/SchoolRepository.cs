using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public SchoolRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblSchool> AddSchool(TblSchool tblSchool)
        {
            var result = await _JhankaulDbContext.TblSchools.AddAsync(tblSchool);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblSchool> DeleteSchool(int Id)
        {
            var result = await _JhankaulDbContext.TblSchools.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblSchools.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblSchool> GetSchool(int Id)
        {
            return await _JhankaulDbContext.TblSchools.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblSchool>> GetSchools()
        {
            return await _JhankaulDbContext.TblSchools.ToListAsync();
        }

        public async Task<IEnumerable<TblSchool>> SearchSchool(string schoolName)
        {
            IQueryable<TblSchool> query = _JhankaulDbContext.TblSchools;
            if(!string.IsNullOrEmpty(schoolName))
            {
                query = query.Where(a => a.SchoolName.Contains(schoolName));
            }
            return await query.ToListAsync();
        }

        public async Task<TblSchool> UpdateSchool(TblSchool tblSchool)
        {
            var result = await _JhankaulDbContext.TblSchools.FirstOrDefaultAsync(a => a.Id == tblSchool.Id);
            if(result != null)
            {
                result.SchoolName = tblSchool.SchoolName;
                result.PrincipleName = tblSchool.PrincipleName;
                result.AddressLineOne = tblSchool.AddressLineOne;
                result.AddressLineTwo = tblSchool.AddressLineTwo;
                result.AddressLineThree = tblSchool.AddressLineThree;
                result.District = tblSchool.District;
                result.State = tblSchool.State;
                result.HelpLineNumberOne = tblSchool.HelpLineNumberOne;
                result.HelpLineNumberTwo = tblSchool.HelpLineNumberTwo;
                result.NumberOfTeacherMale = tblSchool.NumberOfTeacherMale;
                result.NumberOfTeacherFemale = tblSchool.NumberOfTeacherFemale;
                result.NumberOfStudent = tblSchool.NumberOfStudent;
                result.NumberOfBoy = tblSchool.NumberOfBoy;
                result.NumberOfGirl = tblSchool.NumberOfGirl;
                result.NumberOfBus = tblSchool.NumberOfBus;
                result.PrincipleImage = tblSchool.PrincipleImage;
                result.SchoolImageOne = tblSchool.SchoolImageOne;
                result.SchoolImageTwo = tblSchool.SchoolImageTwo;
                result.SchoolImageThree = tblSchool.SchoolImageThree;
                result.SchoolImageFour = tblSchool.SchoolImageFour;
                result.SchoolImageFive = tblSchool.SchoolImageFive;
                result.YearFrom = tblSchool.YearFrom;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
