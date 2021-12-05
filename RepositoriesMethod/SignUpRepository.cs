using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public SignUpRepository(JhankaulContext jhankaulDbContext)
        {
            _JhankaulDbContext = jhankaulDbContext;
        }
        public async Task<TblSignUp> AddSignUp(TblSignUp tblSignUp)
        {
            var result = await _JhankaulDbContext.TblSignUps.AddAsync(tblSignUp);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblSignUp> DeleteSignUp(int Id)
        {
            var result = await _JhankaulDbContext.TblSignUps.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblSignUps.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblSignUp> GetSignUp(int Id)
        {
            return await _JhankaulDbContext.TblSignUps.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblSignUp>> GetSignUps()
        {
            return await _JhankaulDbContext.TblSignUps.ToListAsync();
        }

        public async Task<IEnumerable<TblSignUp>> SearchSignUp(string name)
        {
            IQueryable<TblSignUp> query = _JhankaulDbContext.TblSignUps;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FullName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<TblSignUp> UpdateSignUp(TblSignUp tblSignUp)
        {
            var result = await _JhankaulDbContext.TblSignUps.FirstOrDefaultAsync(a => a.Id == tblSignUp.Id);
            if (result != null)
            {
                result.FullName = tblSignUp.FullName;
                result.MobileNumber = tblSignUp.MobileNumber;
                result.EmailId = tblSignUp.EmailId;
                result.Password = tblSignUp.Password;
                result.ProfilePhoto = tblSignUp.ProfilePhoto;
                result.IsVisibleData = tblSignUp.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
