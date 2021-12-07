using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<TblProfile>> SearchProfileName(string FirstName);
        Task<IEnumerable<TblProfile>> SearchProfileMobileNumber(string MobileNumber);
        Task<IEnumerable<TblProfile>> GetProfiles();
        Task<TblProfile> GetProfile(int Id);
        Task<TblProfile> UpdateProfile(TblProfile tblProfile);
        Task<TblProfile> AddProfile(TblProfile tblProfile);
        Task<TblProfile> DeleteProfile(int Id);
    }
}
