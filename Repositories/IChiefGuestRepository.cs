using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IChiefGuestRepository
    {
        Task<IEnumerable<TblChiefGuest>> SearchChiefGuests(string name);
        Task<IEnumerable<TblChiefGuest>> GetChiefGuests();
        Task<TblChiefGuest> GetChiefGuest(int Id);
        Task<TblChiefGuest> AddChiefGuest(TblChiefGuest tblChiefGuest);
        Task<TblChiefGuest> UpdateChiefGuests(TblChiefGuest tblChiefGuest);
        Task<TblChiefGuest> DeleteChiefGuests(int Id);
    }
}
