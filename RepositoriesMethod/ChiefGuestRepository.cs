using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class ChiefGuestRepository : IChiefGuestRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public ChiefGuestRepository(JhankaulContext jhankaulDbContext)
        {
            _JhankaulDbContext = jhankaulDbContext;
        }
        public async Task<TblChiefGuest> AddChiefGuest(TblChiefGuest tblChiefGuest)
        {
            var result = await _JhankaulDbContext.TblChiefGuests.AddAsync(tblChiefGuest);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblChiefGuest> DeleteChiefGuests(int Id)
        {
            var result = await _JhankaulDbContext.TblChiefGuests.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _JhankaulDbContext.TblChiefGuests.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblChiefGuest> GetChiefGuest(int Id)
        {
            return await _JhankaulDbContext.TblChiefGuests.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblChiefGuest>> GetChiefGuests()
        {
            return await _JhankaulDbContext.TblChiefGuests.ToListAsync();
        }

        public async Task<IEnumerable<TblChiefGuest>> SearchChiefGuests(string name)
        {
            IQueryable<TblChiefGuest> query = _JhankaulDbContext.TblChiefGuests;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FullName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<TblChiefGuest> UpdateChiefGuests(TblChiefGuest tblChiefGuest)
        {
            var result = await _JhankaulDbContext.TblChiefGuests.FirstOrDefaultAsync(a => a.Id == tblChiefGuest.Id);
            if (result != null)
            {
                result.ProfilePhoto = tblChiefGuest.ProfilePhoto;
                result.FullName = tblChiefGuest.FullName;
                result.EmailId = tblChiefGuest.EmailId;
                result.Gender = tblChiefGuest.Gender;
                result.MobileNumber = tblChiefGuest.MobileNumber;
                result.Profession = tblChiefGuest.Profession;
                result.Address = tblChiefGuest.Address;
                result.Year = tblChiefGuest.Year;
                result.ProfilePhoto = tblChiefGuest.ProfilePhoto;
                result.IsVisibleData = tblChiefGuest.IsVisibleData;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
