using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class PrizeRepository : IPrizeRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public PrizeRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblPrize> AddPrize(TblPrize tblPrize)
        {
            var result = await _JhankaulDbContext.TblPrizes.AddAsync(tblPrize);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblPrize> DeletePrize(int Id)
        {
            var result = await _JhankaulDbContext.TblPrizes.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblPrizes.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<TblPrize> GetPrize(int Id)
        {
            return await _JhankaulDbContext.TblPrizes.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<IEnumerable<TblPrize>> GetPrizes()
        {
            return await _JhankaulDbContext.TblPrizes.ToListAsync();
        }

        public async Task<IEnumerable<TblPrize>> SearchPrize(string PrizePosition)
        {
            IQueryable<TblPrize> query = _JhankaulDbContext.TblPrizes;
            if (!string.IsNullOrEmpty(PrizePosition))
            {
                query = query.Where(a => a.PrizePosition.Contains(PrizePosition));
            }
            return await query.ToListAsync();
        }

        public async Task<TblPrize> UpdatePrize(TblPrize tblPrize)
        {
            var result = await _JhankaulDbContext.TblPrizes.FirstOrDefaultAsync(a => a.Id == tblPrize.Id);
            if (result != null)
            {
                result.PrizeName = tblPrize.PrizeName;
                result.PrizeDescription = tblPrize.PrizeDescription;
                result.Year = tblPrize.Year;
                result.IsVisibleData = tblPrize.IsVisibleData;
                result.PrizePhoto = tblPrize.PrizePhoto;
                result.PrizePosition = tblPrize.PrizePosition;
                result.PrizeClass = tblPrize.PrizeClass;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
