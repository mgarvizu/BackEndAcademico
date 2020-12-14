using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BackEnd.Core.Interfaces;
using System.Threading.Tasks;
using BackEnd.Infraestructura.Data;
using BackEnd.Core.Entities;
using Dapper;

namespace BackEnd.Infraestructura.Repositories
{
    public class InscripcionDapperRepository : IInscripcionDapperRepository
    {
        private readonly IConfiguration _configuration;

        public InscripcionDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("OracleDBConnection");
            var con = new OracleConnection(connectionString);
            return con;
        }

        public async Task<object> GetInscripcionAll()
        {
            object result = null;
            var dyparam = new OracleDynamicParameters(); 
                dyparam.Add("PERCURSORMATALL", OracleDbType.RefCursor,
                ParameterDirection.Output);
            try
            {
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETMATERIAALL";
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

        public async Task<object> GetEstInsEnMat(string materia)
        {
            object result = null;

            try
            {
                var dyparam = new OracleDynamicParameters();

                dyparam.Add("PERCURSORINSCRIPMATPARAM", OracleDbType.RefCursor,
                ParameterDirection.Output);

                dyparam.Add("MAT", OracleDbType.Varchar2,
                    ParameterDirection.Input, materia);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETINSCRIPCIONMATPARAM";
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

        public async Task<object> GetLisMatDeEst(string carnet)
        {
            object result = null;

            try
            {
                var dyparam = new OracleDynamicParameters();

                dyparam.Add("PERCURSORINSCRIPLISMATESTPARAM", OracleDbType.RefCursor,
                ParameterDirection.Output);

                dyparam.Add("ci", OracleDbType.Varchar2,
                    ParameterDirection.Input, carnet);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETINSCRIPLISMATESTPARAM";
                        result = await SqlMapper.QueryAsync(con, query,
                            param: dyparam, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message); ;
            }

            return result;
        }

        public async Task<bool> AddInscripcionAsync(Inscripcion inscripcion)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("mat", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_MATERIA);
                dyParam.Add("est", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_ESTUDIANTE);
                dyParam.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input,
                          inscripcion.DESCRIPCION);
              
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_ADDINSCRIPCION";
                        result = await SqlMapper.ExecuteAsync(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return (int)result > 0 ? true : false;


        }

        public async Task<bool> UpdateInscripcionAsync(Inscripcion inscripcion)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("I_ID", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_INSCRIPCION);
                dyParam.Add("I_MAT", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_MATERIA);
                dyParam.Add("I_EST", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_ESTUDIANTE);
                dyParam.Add("I_DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input,
                          inscripcion.DESCRIPCION);

                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_UPDATEINSCRIPCION";
                        result = await SqlMapper.ExecuteAsync(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return (int)result > 0 ? true : false;


        }

        public async Task<bool> DeleteInscripcionAsync(Inscripcion inscripcion)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("id", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_INSCRIPCION);
                dyParam.Add("mat", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_MATERIA);
                dyParam.Add("est", OracleDbType.Int32, ParameterDirection.Input,
                           inscripcion.ID_ESTUDIANTE);
                dyParam.Add("descripcion", OracleDbType.Varchar2, ParameterDirection.Input,
                          inscripcion.DESCRIPCION);

                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_DELETEINSCRIPCION";
                        result = await SqlMapper.ExecuteAsync(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return (int)result > 0 ? true : false;


        }
    }
}
