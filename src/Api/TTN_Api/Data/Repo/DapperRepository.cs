using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TTN_Tracker.Data
{
    public class DapperRepository : IDapperRepository
    {
        private static string _connectionString;

        public DapperRepository(string connectionString) => _connectionString = connectionString;

        private IDbConnection Conn => new SqlConnection(_connectionString);
        public void Dispose()
        {

        }

        // public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        // {
        //     if (string.IsNullOrEmpty(sp))
        //     {
        //         throw new System.ArgumentException($"'{nameof(sp)}' cannot be null or empty.", nameof(sp));
        //     }

        //     if (parms is null)
        //     {
        //         throw new System.ArgumentNullException(nameof(parms));
        //     }

        //     // if (commandType == null)
        //     // {
        //     //     throw new System.ArgumentNullException(nameof(commandType));
        //     // }

        //     throw new NotImplementedException();
        // }

        public T Get<T>(string sp, object parms, CommandType commandType = CommandType.Text)
        {
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return Conn.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure)
        {
            // using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return Conn.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public async Task<T> GetAsync<T>(string sp, object parms, CommandType cmdType = CommandType.StoredProcedure)
        {
            var result = await Conn.QueryAsync<T>(sp, parms, commandType: cmdType);
            return result.FirstOrDefault();
        }
        // public async Task<T> GetTextAsync<T>(string sp, object parms)
        // {
        //     var result = await Conn.QueryAsync<T>(sp, parms, commandType: CommandType.Text);
        //     return result.FirstOrDefault();
        // }
        public async Task<List<T>> GetAllAsync<T>(string sp, object parms, CommandType cmdType = CommandType.StoredProcedure)
        {
            var result = await Conn.QueryAsync<T>(sp, parms, commandType: cmdType);
            return result.ToList();
        }

        // public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        // {
        //     T result;
        //     using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
        //     try
        //     {
        //         if (Conn.State == ConnectionState.Closed)
        //             db.Open();

        //         using var tran = Conn.BeginTransaction();
        //         try
        //         {
        //             result = Conn.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
        //             tran.Commit();
        //         }
        //         catch (Exception ex)
        //         {
        //             tran.Rollback();
        //             throw ex;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        //     finally
        //     {
        //         if (db.State == ConnectionState.Open)
        //             db.Close();
        //     }

        //     return result;
        // }

        // public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        // {
        //     T result;
        //     using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
        //     try
        //     {
        //         if (db.State == ConnectionState.Closed)
        //             db.Open();

        //         using var tran = db.BeginTransaction();
        //         try
        //         {
        //             result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
        //             tran.Commit();
        //         }
        //         catch (Exception ex)
        //         {
        //             tran.Rollback();
        //             throw ex;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        //     finally
        //     {
        //         if (db.State == ConnectionState.Open)
        //             db.Close();
        //     }

        //     return result;
        // }
    }
}