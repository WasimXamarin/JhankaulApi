using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IPrizeRepository
    {
        Task<IEnumerable<TblPrize>> SearchPrize(string PrizePosition);
        Task<IEnumerable<TblPrize>> GetPrizes();
        Task<TblPrize> GetPrize(int Id);
        Task<TblPrize> AddPrize(TblPrize tblPrize);
        Task<TblPrize> UpdatePrize(TblPrize tblPrize);
        Task<TblPrize> DeletePrize(int Id);
    }
}
