using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public ProfileRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblProfile> AddProfile(TblProfile tblProfile)
        {
            var result = await _JhankaulDbContext.TblProfiles.AddAsync(tblProfile);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblProfile> DeleteProfile(int Id)
        {
            var result = await _JhankaulDbContext.TblProfiles.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblProfiles.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblProfile> GetProfile(int Id)
        {
            return await _JhankaulDbContext.TblProfiles.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblProfile>> GetProfiles()
        {
            return await _JhankaulDbContext.TblProfiles.ToListAsync();
        }

        public async Task<IEnumerable<TblProfile>> SearchProfileMobileNumber(string MobileNumber)
        {
            IQueryable<TblProfile> query = _JhankaulDbContext.TblProfiles;
            if(!string.IsNullOrEmpty(MobileNumber))
            {
                query = query.Where(a => a.MobileNumberOne.Contains(MobileNumber));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TblProfile>> SearchProfileName(string FirstName)
        {
            IQueryable<TblProfile> query = _JhankaulDbContext.TblProfiles;
            if(!string.IsNullOrEmpty(FirstName))
            {
                query = query.Where(a => a.FirstName.Contains(FirstName));
            }
            return await query.ToArrayAsync();
        }

        public async Task<TblProfile> UpdateProfile(TblProfile tblProfile)
        {
            var result = await _JhankaulDbContext.TblProfiles.FirstOrDefaultAsync(a => a.Id == tblProfile.Id);
            if(result != null)
            {
                result.RollNumber = tblProfile.RollNumber;
                result.FirstName = tblProfile.FirstName;
                result.MiddleName = tblProfile.MiddleName;
                result.LastName = tblProfile.LastName;
                result.Age = tblProfile.Age;
                result.Gender = tblProfile.Gender;
                result.Class = tblProfile.Class;
                result.DateOfBirth = tblProfile.DateOfBirth;
                result.TotalNumber = tblProfile.TotalNumber;
                result.OutOfNumber = tblProfile.OutOfNumber;
                result.PositionInClass = tblProfile.PositionInClass;
                result.FatherName = tblProfile.FatherName;
                result.MotherName = tblProfile.MotherName;
                result.MobileNumberOne = tblProfile.MobileNumberOne;
                result.MobileNumberTwo = tblProfile.MobileNumberTwo;
                result.SchoolName = tblProfile.SchoolName;
                result.StudentImage = tblProfile.StudentImage;
                result.StudentSignature = tblProfile.StudentSignature;
                result.ParentSignature = tblProfile.ParentSignature;
                result.Village = tblProfile.Village;
                result.Post = tblProfile.Post;
                result.Thana = tblProfile.Thana;
                result.District = tblProfile.District;
                result.StateName = tblProfile.StateName;
                result.Nationality = tblProfile.Nationality;
                result.IsVisibleData = tblProfile.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
