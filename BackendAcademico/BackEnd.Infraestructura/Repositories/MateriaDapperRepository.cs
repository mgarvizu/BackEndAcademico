using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Core.Entities;
using BackEnd.Core.Interfaces;
using BackEnd.Infraestructura.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace BackEnd.Infraestructura.Repositories
{
    public class MateriaDapperRepository : IMateriaDapperRepository
    {
        private readonly IConfiguration _configuration;
        public MateriaDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("OracleDBConnection");
            var con = new OracleConnection(connectionString);
            return con;
        }

        public async Task<object> GetMateriasTodosAsync() 
        {
            object result = null;

            try
            {
                var dyparam = new OracleDynamicParameters();
                dyparam.Add("PERCURSORMATERIAALL", OracleDbType.RefCursor,
                 ParameterDirection.Output);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETMATERIASALL";

                        result = await SqlMapper.QueryAsync(con, query,
                            param: dyparam, commandType: CommandType.StoredProcedure);
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return result;
        }

        public async Task<object> GetMateriasComboTodosAsync()
        {
            object result = null;

            try
            {
                var dyparam = new OracleDynamicParameters();
                dyparam.Add("PERCURSORMATERIACOMBO", OracleDbType.RefCursor,
                ParameterDirection.Output);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETMATERIASCOMBO";

                        result = await SqlMapper.QueryAsync(con, query,
                            param: dyparam, commandType: CommandType.StoredProcedure);
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return result;
        }

        public async Task<object> GetMateriasSiglaAsync(string sigla)
        {
            object result = null;

            try
            {
                var dyparam = new OracleDynamicParameters();
                dyparam.Add("PERCURSORMATPARAM", OracleDbType.RefCursor,
              ParameterDirection.Output);
                dyparam.Add("MAT", OracleDbType.Varchar2, ParameterDirection.Input,
                            sigla);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETMATERIAPARAM";

                        result = await SqlMapper.QueryAsync(con, query,
                            param: dyparam, commandType: CommandType.StoredProcedure);
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return result;
        }

        public async Task<object> GetMateriasNombreMatAsync(string nombre)
        {
            object result = null;

            try
            {                
                var dyparam = new OracleDynamicParameters();
                dyparam.Add("PERCURSORMATPARAM", OracleDbType.RefCursor,
              ParameterDirection.Output);
                dyparam.Add("MAT", OracleDbType.Varchar2, ParameterDirection.Input,
                            nombre);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETMATERIAPARAM";

                        result = await SqlMapper.QueryAsync(con, query,
                            param: dyparam, commandType: CommandType.StoredProcedure);
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return result;
        }


    }
}
