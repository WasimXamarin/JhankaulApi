using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IHomeRepository
    {
        Task<TblHome> GetHome(int Id);
        Task<TblHome> AddHome(TblHome tblHome);
        Task<TblHome> UpdateHome(TblHome tblHome);
        Task<TblHome> DeleteHome(int Id);
    }
}
