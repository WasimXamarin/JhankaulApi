using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<TblAbout>> SearchAbout(string name);
        Task<IEnumerable<TblAbout>> GetAbouts();
        Task<TblAbout> GetAbout(int Id);
        Task<TblAbout> AddAbout(TblAbout tblAbout);
        Task<TblAbout> UpdateAbout(TblAbout tblAbout);
        Task<TblAbout> DeleteAbout(int Id);

    }
}
