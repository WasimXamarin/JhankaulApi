using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IOrganizerRepository
    {
        Task<IEnumerable<TblOrganizer>> SearchOrganizers(string name);
        Task<IEnumerable<TblOrganizer>> GetOrganizers();
        Task<TblOrganizer> GetOrganizer(int Id);
        Task<TblOrganizer> AddOrganizer(TblOrganizer tblOrganizer);
        Task<TblOrganizer> UpdateOrganizer(TblOrganizer tblOrganizer);
        Task<TblOrganizer> DeleteOrganizer(int Id);
    }
}
