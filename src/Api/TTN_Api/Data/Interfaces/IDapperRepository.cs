using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace TTN_Tracker.Data
{
    public interface IDapperRepository
    {
        T Get<T>(string sp, object parms, CommandType commandType = CommandType.Text);
        List<T> GetAll<T>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetAsync<T>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure);
        // Task<T> GetTextAsync<T>(string sp, object parms);
        Task<List<T>> GetAllAsync<T>(string sp, object parms, CommandType cmdType = CommandType.StoredProcedure);

    }
}