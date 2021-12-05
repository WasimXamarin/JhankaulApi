using JhankaulAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JhankaulAPI.Repositories
{
    public interface ISignUpRepository
    {
        Task<IEnumerable<TblSignUp>> SearchSignUp(string name);
        Task<IEnumerable<TblSignUp>> GetSignUps();
        Task<TblSignUp> GetSignUp(int id);
        Task<TblSignUp> AddSignUp(TblSignUp tblSignUp);
        Task<TblSignUp> UpdateSignUp(TblSignUp tblSignUp);
        Task<TblSignUp> DeleteSignUp(int id);

    }
}
