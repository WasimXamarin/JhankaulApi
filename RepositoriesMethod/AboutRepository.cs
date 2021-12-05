using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class AboutRepository : IAboutRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public AboutRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblAbout> AddAbout(TblAbout tblAbout)
        {
            var result = await _JhankaulDbContext.TblAbouts.AddAsync(tblAbout);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblAbout> DeleteAbout(int Id)
        {
            var result = await _JhankaulDbContext.TblAbouts.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblAbouts.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblAbout> GetAbout(int Id)
        {
            return await _JhankaulDbContext.TblAbouts.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblAbout>> GetAbouts()
        {
            return await _JhankaulDbContext.TblAbouts.ToListAsync();
        }

        public async Task<IEnumerable<TblAbout>> SearchAbout(string name)
        {
            IQueryable<TblAbout> query = _JhankaulDbContext.TblAbouts;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FullName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<TblAbout> UpdateAbout(TblAbout tblAbout)
        {
            var result = await _JhankaulDbContext.TblAbouts.FirstOrDefaultAsync(a => a.Id == tblAbout.Id);
            if(result != null)
            {
                result.FullName = tblAbout.FullName;
                result.MobileNumber = tblAbout.MobileNumber;
                result.EmailId = tblAbout.EmailId;
                result.Facebook = tblAbout.Facebook;
                result.Qualification = tblAbout.Qualification;
                result.Gender = tblAbout.Gender;
                result.Village = tblAbout.Village;
                result.IsVisibleData = tblAbout.IsVisibleData;
                result.ProfilePhoto = tblAbout.ProfilePhoto;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
