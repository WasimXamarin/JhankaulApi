using JhankaulAPI.Models;
using JhankaulAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.RepositoriesMethod
{
    public class HomeRepository : IHomeRepository
    {
        private readonly JhankaulContext _JhankaulDbContext;
        public HomeRepository(JhankaulContext jhankaulContext)
        {
            _JhankaulDbContext = jhankaulContext;
        }
        public async Task<TblHome> AddHome(TblHome tblHome)
        {
            var result = await _JhankaulDbContext.TblHomes.AddAsync(tblHome);
            await _JhankaulDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TblHome> DeleteHome(int Id)
        {
            var result = await _JhankaulDbContext.TblHomes.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result != null)
            {
                _JhankaulDbContext.TblHomes.Remove(result);
                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TblHome>> GetHome()
        {
            return await _JhankaulDbContext.TblHomes.ToListAsync();
        }

        public async Task<TblHome> GetHome(int Id)
        {
            return await _JhankaulDbContext.TblHomes.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<TblHome> UpdateHome(TblHome tblHome)
        {
            var result = await _JhankaulDbContext.TblHomes.FirstOrDefaultAsync(a => a.Id == tblHome.Id);
            if(result != null)
            {
                result.NumberOfMale = tblHome.NumberOfMale;
                result.NumberOfFemale = tblHome.NumberOfFemale;
                result.History = tblHome.History;
                result.ImageOne = tblHome.ImageOne;
                result.ImageTwo = tblHome.ImageTwo;
                result.ImageThree = tblHome.ImageThree;
                result.ImageFour = tblHome.ImageFour;
                result.ImageFive = tblHome.ImageFive;

                await _JhankaulDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
