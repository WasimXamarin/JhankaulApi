using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface ISainikRepository
    {
        Task<IEnumerable<TblSainik>> SearchSainik(string name);
        Task<IEnumerable<TblSainik>> GetSainiks();
        Task<TblSainik> GetSainik(int Id);
        Task<TblSainik> AddSainik(TblSainik tblSainik);
        Task<TblSainik> UpdateSainik(TblSainik tblSainik);
        Task<TblSainik> DeleteSainik(int Id);
    }
}
