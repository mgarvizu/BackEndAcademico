using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BackEnd.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using BackEnd.Infraestructura.Data;
using BackEnd.Core.Entities;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackEnd.Infraestructura.Repositories
{

    public class EstudianteDapperRepository : IEstudianteDapperRepository
    {
        private readonly IConfiguration _configuration;
        public EstudianteDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<object> GetEstudiantesBDTodosAsync()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("PERCURSOR", OracleDbType.RefCursor,
                    ParameterDirection.Output);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETESTUDIANTESTODOS";
                        result = await SqlMapper.QueryAsync<Estudiante>(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return result;
        }

        public async Task<object> GetEstudiantesBD3Async(int idPar, string nombre)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("PERCURSORESTPARAM", OracleDbType.RefCursor,
                  ParameterDirection.Output);
                dyParam.Add("ID_ESTU", OracleDbType.Int32, ParameterDirection.Input,
                             idPar);
                dyParam.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input,
                           nombre);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETESTUDIANTEPARAM";
                        result = await SqlMapper.QueryAsync<Estudiante>(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return result;
        }

        public async Task<bool> AddEstudianteAsync(Estudiante estudiante)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ci", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.CI);
                dyParam.Add("nombres", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.NOMBRES);
                dyParam.Add("apellidos", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.APELLIDOS);
                dyParam.Add("fechaNacimiento", OracleDbType.Date, ParameterDirection.Input,
                           estudiante.FECHA_NACIMIENTO);

                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_ADDESTUDIANTE";
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

        public async Task<bool> UpdateEstudianteAsync(Estudiante estudiante)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("idEstudiante", OracleDbType.Varchar2, ParameterDirection.Input,
                          estudiante.ID_ESTUDIANTE);
                dyParam.Add("ci", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.CI);
                dyParam.Add("nombres", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.NOMBRES);
                dyParam.Add("apellidos", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.APELLIDOS);
                dyParam.Add("fechaNacimiento", OracleDbType.Date, ParameterDirection.Input,
                           estudiante.FECHA_NACIMIENTO);

                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "Update estudiante " +
                        "set NOMBRES=:nombres, APELLIDOS=:apellidos, CI=:ci , FECHA_NACIMIENTO=:fechaNacimiento" +
                        " where ID_ESTUDIANTE=:idEstudiante";
                        result = await SqlMapper.ExecuteAsync(con, query, param: dyParam,
                            commandType: CommandType.Text);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return (int)result > 0 ? true : false;


        }

        public async Task<bool> DeleteEstudianteAsync(Estudiante estudiante)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("idEstudiante", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.ID_ESTUDIANTE);

                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "delete estudiante" +
                        " where ID_ESTUDIANTE=:idEstudiante";
                        result = await SqlMapper.ExecuteAsync(con, query, param: dyParam,
                            commandType: CommandType.Text);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return (int)result > 0 ? true : false;


        }

        public async Task<object> GetEstudiantesBDExist(Estudiante estudiante)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("PERCURSORESTEXIST", OracleDbType.RefCursor,
                  ParameterDirection.Output);
                dyParam.Add("CI", OracleDbType.Varchar2, ParameterDirection.Input,
                             estudiante.CI);
                dyParam.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.NOMBRES);
                dyParam.Add("APELLIDO", OracleDbType.Varchar2, ParameterDirection.Input,
                           estudiante.APELLIDOS);
                dyParam.Add("FECHA", OracleDbType.Date, ParameterDirection.Input,
                           estudiante.FECHA_NACIMIENTO);
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var query = "SP_GETESTUDIANTEEXIST";
                        result = await SqlMapper.QueryAsync<Estudiante>(con, query, param: dyParam,
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
            return result;
        }
        // con esta funcion registras 10 estudiantes al azar 
        public async Task<bool> AddEstudianteAutomatic()
        {            
            object result = null;
            
            try
            {
                var dyParam = new OracleDynamicParameters();
                using (IDbConnection con = GetConnection())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        var _estudiantes= GeneradorEstudiante();

                        foreach (Estudiante nuevoInsert in _estudiantes)
                        {

                            dyParam.Add("ci", OracleDbType.Varchar2, ParameterDirection.Input,
                                        nuevoInsert.CI);
                            dyParam.Add("nombres", OracleDbType.Varchar2, ParameterDirection.Input,
                                       nuevoInsert.NOMBRES);
                            dyParam.Add("apellidos", OracleDbType.Varchar2, ParameterDirection.Input,
                                       nuevoInsert.APELLIDOS);
                            dyParam.Add("fechaNacimiento", OracleDbType.Date, ParameterDirection.Input,
                                       nuevoInsert.FECHA_NACIMIENTO);
                            result = await AddEstudianteAsync(nuevoInsert);
                            dyParam = new OracleDynamicParameters();
                        }
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return true;
        }

        private IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("OracleDBConnection");
            var con = new OracleConnection(connectionString);
            return con;
        }
        private List<Estudiante> GeneradorEstudiante()
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();

            var RandomNombres = new string[] { "Juan", "Maria", "Rodrigo", "Jose", "Marco", "Osvaldo", "Juana", "Rocio", "Lucia", "Mariel", "Tito", "Andres", "Roxana", "Leticia", "Ruth", "Mario", "Miriam", "Ruben", "Daniel", "Omar", "Carlos" };
            var RandomApellidos = new string[] { "Carvajal", "Lopez", "Conde", "Roque", "Rocha", "Martinez", "Lucana", "Arce", "Quintana", "Rodriguez", "Alvarez", "Quispe", "Mamani", "Rojas", "Vaca", "Barba", "Soria", "Gonzales", "Palacios", "Reyes" };

            string[] nombres = nombresAlAzar(RandomNombres);
            string[] apellidos = nombresAlAzar(RandomApellidos);
            string[] carnets = ciAlAzar();
            DateTime[] fechas = fechasAlAzar();


            for (int i = 0; i < 10; i++)
            {
                Estudiante nuevo = new Estudiante();
                nuevo.CI = carnets[i];
                nuevo.NOMBRES = nombres[i];
                nuevo.APELLIDOS = apellidos[i];
                nuevo.FECHA_NACIMIENTO = fechas[i];

                listaEstudiantes.Add(nuevo);
            }

            return listaEstudiantes;
        }

        private string[] nombresAlAzar(string[] randomString)
        {
            #region variables a ser usadas por nombre
            string[] nombres = new string[10];
            Random random = new Random();
            int posicion = 0;
            int posicionNombre = 0;
            string nombre = "";
            var RandomNombres = randomString;
            #endregion


            while (posicionNombre < 10)
            {
                posicion = random.Next(0, RandomNombres.Length - 1);
                nombre = RandomNombres[posicion];
                if (Array.IndexOf(nombres, nombre) < 0) 
                {
                    nombres[posicionNombre] = nombre;
                    posicionNombre++;
                }                
            }
            return nombres;
        }

        private string[] ciAlAzar()
        {
            string[] cis = new string[10];
            string ci = "";
            int posicion = 0;
            Random random = new Random();

            while (posicion < 10)
            {
                ci = random.Next(1000000, 9999999).ToString();
                if (Array.IndexOf(cis, ci) < 0)
                {
                    cis[posicion] = ci;
                    posicion++;
                }
            }
            return cis;
        }


        private DateTime[] fechasAlAzar()
        {

            DateTime[] fechas = new DateTime[10];
            DateTime fecha = new DateTime();
            int posicion = 0;
            Random random = new Random();

            while (posicion < 10)
            {
               fecha = RandomDay();
                if (Array.IndexOf(fechas, fecha) < 0)
                {
                    fechas[posicion] = fecha;
                    posicion++;
                }
            }
            return fechas;
        }
        private DateTime RandomDay() 
        { 
            DateTime start = new DateTime(1984, 1, 1); 
            Random gen = new Random();
            DateTime end = new DateTime(2000, 12, 31);

            int range = (end - start).Days;
            return start.AddDays(gen.Next(range)); 
        }


    }
}
