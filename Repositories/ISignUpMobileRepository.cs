using JhankaulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface ISignUpMobileRepository
    {
        Task<IEnumerable<TblSignUpMobile>> SearchSignUpMobile(string MobileNumber);
        Task<IEnumerable<TblSignUpMobile>> GetSignUpMobiles();
        Task<TblSignUpMobile> GetSignUpMobile(int Id);
        Task<TblSignUpMobile> AddSignUpMobile(TblSignUpMobile tblSignUpMobile);
        Task<TblSignUpMobile> UpdateSignUpMobile(TblSignUpMobile tblSignUpMobile);
        Task<TblSignUpMobile> DeleteSignUpMobile(int Id);
    }
}
