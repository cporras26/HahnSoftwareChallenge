using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalChallenge.Common.Settings;

namespace TechnicalChallenge.Common.Services
{
    public interface IDbService<TConnectionString> where TConnectionString : ConnectionString
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms);
        Task<int> EditData(string command, object parms);
    }
}
