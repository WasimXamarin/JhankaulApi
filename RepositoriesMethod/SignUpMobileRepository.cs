using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class SignUpMobileRepository : ISignUpMobileRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public SignUpMobileRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }

        public async Task<TblSignUpMobile> AddSignUpMobile(TblSignUpMobile tblSignUpMobile)
        {
            var result = await _JhankaulDbContext.TblSignUpMobiles.AddAsync(tblSignUpMobile);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblSignUpMobile> DeleteSignUpMobile(int Id)
        {
            var result = await _JhankaulDbContext.TblSignUpMobiles.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblSignUpMobiles.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblSignUpMobile> GetSignUpMobile(int Id)
        {
            return await _JhankaulDbContext.TblSignUpMobiles.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblSignUpMobile>> GetSignUpMobiles()
        {
            return await _JhankaulDbContext.TblSignUpMobiles.ToListAsync()_;
        }

        public async Task<IEnumerable<TblSignUpMobile>> SearchSignUpMobile(string MobileNumber)
        {
            IQueryable<TblSignUpMobile> query = _JhankaulDbContext.TblSignUpMobiles;
            if(!string.IsNullOrEmpty(MobileNumber))
            {
                query = query.Where(a => a.MobileNumber.Contains(MobileNumber));
            }
            return await query.ToArrayAsync();
        }

        public async Task<TblSignUpMobile> UpdateSignUpMobile(TblSignUpMobile tblSignUpMobile)
        {
            var result = await _JhankaulDbContext.TblSignUpMobiles.FirstOrDefaultAsync(a => a.Id == tblSignUpMobile.Id);
            if(result != null)
            {
                result.MobileNumber = tblSignUpMobile.MobileNumber;
                result.Password = tblSignUpMobile.MobileNumber;
                result.IsVisibleData = tblSignUpMobile.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
