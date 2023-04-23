using Npgsql;
using TechnicalChallenge.Common.Settings;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TechnicalChallenge.Common.Services
{
    public class DbService<TConnectionString> : IDbService<TConnectionString> 
        where TConnectionString : ConnectionString
    {
        private readonly IDbConnection _db;

        public DbService(TConnectionString connectionString) 
        {
            _db = new NpgsqlConnection(connectionString.Value);
            _db.Open();
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms)).FirstOrDefault();

            return result;
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
