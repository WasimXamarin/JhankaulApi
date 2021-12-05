using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<TblSchool>> SearchSchool(string schoolName);
        Task<IEnumerable<TblSchool>> GetSchools();
        Task<TblSchool> GetSchool(int Id);
        Task<TblSchool> AddSchool(TblSchool tblSchool);
        Task<TblSchool> UpdateSchool(TblSchool tblSchool);
        Task<TblSchool> DeleteSchool(int Id);
    }
}
