using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class SainikRepository : ISainikRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public SainikRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblSainik> AddSainik(TblSainik tblSainik)
        {
            var result = await _JhankaulDbContext.TblSainiks.AddAsync(tblSainik);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblSainik> DeleteSainik(int Id)
        {
            var result = await _JhankaulDbContext.TblSainiks.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblSainiks.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblSainik> GetSainik(int Id)
        {
            return await _JhankaulDbContext.TblSainiks.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblSainik>> GetSainiks()
        {
            return await _JhankaulDbContext.TblSainiks.ToListAsync();
        }

        public async Task<IEnumerable<TblSainik>> SearchSainik(string name)
        {
            IQueryable<TblSainik> query = _JhankaulDbContext.TblSainiks;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FullName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<TblSainik> UpdateSainik(TblSainik tblSainik)
        {
            var result = await _JhankaulDbContext.TblSainiks.FirstOrDefaultAsync(a => a.Id == tblSainik.Id);
            if(result != null)
            {
                result.FullName = tblSainik.FullName;
                result.MobileNumber = tblSainik.MobileNumber;
                result.EmailId = tblSainik.EmailId;
                result.Facebook = tblSainik.Facebook;
                result.Gender = tblSainik.Gender;
                result.Position = tblSainik.Position;
                result.Village = tblSainik.Village;
                result.YearFrom = tblSainik.YearFrom;
                result.YearTo = tblSainik.YearTo;
                result.ProfilePhoto = tblSainik.ProfilePhoto;
                result.IsVisibleData = result.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
