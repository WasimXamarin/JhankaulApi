using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class OrganizerRepository : IOrganizerRepository
    {
        public readonly JhankaulContext _JhankaulDbContext;
        public OrganizerRepository(JhankaulContext jhankaulDbContext)
        {
            _JhankaulDbContext = jhankaulDbContext;
        }
        public async Task<TblOrganizer> AddOrganizer(TblOrganizer tblOrganizer)
        {
            var result = await _JhankaulDbContext.TblOrganizers.AddAsync(tblOrganizer);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblOrganizer> DeleteOrganizer(int Id)
        {
            var result = await _JhankaulDbContext.TblOrganizers.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblOrganizers.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblOrganizer> GetOrganizer(int Id)
        {
            return await _JhankaulDbContext.TblOrganizers.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblOrganizer>> GetOrganizers()
        {
            return await _JhankaulDbContext.TblOrganizers.ToListAsync(); 
        }

        public async Task<IEnumerable<TblOrganizer>> SearchOrganizers(string name)
        {
            IQueryable<TblOrganizer> query = _JhankaulDbContext.TblOrganizers;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FullName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<TblOrganizer> UpdateOrganizer(TblOrganizer tblOrganizer)
        {
            var result = await _JhankaulDbContext.TblOrganizers.FirstOrDefaultAsync(a => a.Id == tblOrganizer.Id);
            if(result != null)
            {
                result.ProfilePhoto = tblOrganizer.ProfilePhoto;
                result.FullName = tblOrganizer.FullName;
                result.EmailId = tblOrganizer.EmailId;
                result.Gender = tblOrganizer.Gender;
                result.MobileNumber = tblOrganizer.MobileNumber;
                result.Profession = tblOrganizer.Profession;
                result.Address = tblOrganizer.Address;
                result.Year = tblOrganizer.Year;
                result.ProfilePhoto = tblOrganizer.ProfilePhoto;
                result.IsVisibleData = tblOrganizer.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
