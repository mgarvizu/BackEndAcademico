using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BackEnd.Core.Entities;
using BackEnd.Core.Interfaces;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Infraestructura.Repositories
{
   
    public class EstudianteRepository : IEstudianteRepository
    {       
        private readonly IConfiguration _configuration;
        public EstudianteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Estudiante> GetEstudiantes() {

            var est = Enumerable.Range(1,10).Select (x => new Estudiante
            {
                ID_ESTUDIANTE = x,
                CI = (x *20000).ToString(),
                NOMBRES = $"Nombre {x}",
                APELLIDOS = $"Apellido {x}",
                FECHA_NACIMIENTO = new DateTime(new Random().Next(1980,2020), new Random().Next(1, 12), new Random().Next(1, 31))
            });
            return est;
        }

        public IEnumerable<Estudiante> GetEstudiantesBD1()
        {
           // string strCon = _configuration.GetSection("ConnectionsStrings")
           //                 .GetSection("OracleDBConnection").Value;

            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            using (OracleConnection connection = new OracleConnection(strCon))
                using (OracleCommand command = connection.CreateCommand())
                {
                    try
                    {
                        connection.Open();
                        command.CommandText = "select * from estudiante";
                        OracleDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listaEstudiantes.Add(new Estudiante()
                            {
                                ID_ESTUDIANTE = reader.GetInt32(0),
                                CI = reader.GetString(1),
                                NOMBRES = reader.GetString(2),
                                APELLIDOS = reader.GetString(3),
                                FECHA_NACIMIENTO = reader.GetDateTime(4)
                            });
                        }
                        reader.Dispose();
                    }
                    catch (Exception err)
                    {

                        throw new Exception(err.Message);
                    }
                }
            return listaEstudiantes;
        }

        public IEnumerable<Estudiante> GetEstudiantesBD2(int idPar)
        {
            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            using (OracleConnection connection = new OracleConnection(strCon))
            using (OracleCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"select * from estudiante where ID_ESTUDIANTE = :id";
                    
                    OracleParameter id = new OracleParameter();
                    id.ParameterName = "id";
                    id.Value = idPar;
                    command.Parameters.Add(id);

                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaEstudiantes.Add(new Estudiante()
                        {
                            ID_ESTUDIANTE = reader.GetInt32(0),
                            CI = reader.GetString(1),
                            NOMBRES = reader.GetString(2),
                            APELLIDOS = reader.GetString(3),
                            FECHA_NACIMIENTO = reader.GetDateTime(4)
                        });
                    }
                    reader.Dispose();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
            return listaEstudiantes;
        }

        public IEnumerable<Estudiante> GetEstudiantesBD3(int idPar)
        {
            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            using (OracleConnection connection = new OracleConnection(strCon))
            using (OracleCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.BindByName = true; // sirve para que puedas enviar en cualquier ordern

                    command.CommandText = $"select * from estudiante where ID_ESTUDIANTE = :id" +
                        " and nombres=:nombres and apellidos=:apellidos";

                   

                    OracleParameter nombres = new OracleParameter();
                    nombres.ParameterName = "nombres";
                    nombres.Value = "juan";
                    command.Parameters.Add(nombres);

                    OracleParameter apellidos = new OracleParameter();
                    apellidos.ParameterName = "apellidos";
                    apellidos.Value = "peres";
                    command.Parameters.Add(apellidos);

                    OracleParameter id = new OracleParameter();
                    id.ParameterName = "id";
                    id.Value = idPar;
                    command.Parameters.Add(id);


                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listaEstudiantes.Add(new Estudiante()
                        {
                            ID_ESTUDIANTE = reader.GetInt32(0),
                            CI = reader.GetString(1),
                            NOMBRES = reader.GetString(2),
                            APELLIDOS = reader.GetString(3),
                            FECHA_NACIMIENTO = reader.GetDateTime(4)
                        });
                    }
                    reader.Dispose();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
            return listaEstudiantes;
        }

        // generar CRUD para estudiante

        public bool AddEstudiante(Estudiante estudiante) {

            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            int result = 0;
            using (OracleConnection connection = new OracleConnection(strCon))
            using (OracleCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.BindByName = true; // sirve para que puedas enviar en cualquier ordern

                    command.CommandText = "insert into estudiante (CI, NOMBRES, APELLIDOS, FECHA_NACIMIENTO)" +
                        " values(:ci, :nombres, :apellidos, :fechaNacimiento)";


                    #region parametros para hacer el bind
                    OracleParameter nombres = new OracleParameter();
                    nombres.ParameterName = "nombres";
                    nombres.Value = estudiante.NOMBRES;
                    command.Parameters.Add(nombres);

                    OracleParameter apellidos = new OracleParameter();
                    apellidos.ParameterName = "apellidos";
                    apellidos.Value = estudiante.APELLIDOS;
                    command.Parameters.Add(apellidos);

                    OracleParameter ci = new OracleParameter();
                    ci.ParameterName = "ci";
                    ci.Value = estudiante.CI;
                    command.Parameters.Add(ci);

                    OracleParameter fechaNacimiento = new OracleParameter();
                    fechaNacimiento.ParameterName = "fechaNacimiento";
                    fechaNacimiento.Value = estudiante.FECHA_NACIMIENTO;
                    // puedes darle un tipo de dato
                    // fechaNacimiento.DbType = System.Data.DbType.Date;
                    command.Parameters.Add(fechaNacimiento);
                    #endregion

                    result = command.ExecuteNonQuery();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
            return result > 0 ? true : false;
        }

        public bool UpdateEstudiante(Estudiante estudiante)
        {

            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            int result = 0;
            using (OracleConnection connection = new OracleConnection(strCon))
            using (OracleCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.BindByName = true; // sirve para que puedas enviar en cualquier ordern

                    command.CommandText = "Update estudiante " +
                        "set NOMBRES=:nombres, APELLIDOS=:apellidos, CI=:ci , FECHA_NACIMIENTO=:fechaNacimiento" +
                        " where ID_ESTUDIANTE=:idEstudiante";



                    #region parametros para hacer el bind
                    OracleParameter idEstudiante = new OracleParameter();
                    idEstudiante.ParameterName = "idEstudiante";
                    idEstudiante.Value = estudiante.ID_ESTUDIANTE;
                    command.Parameters.Add(idEstudiante);

                    OracleParameter nombres = new OracleParameter();
                    nombres.ParameterName = "nombres";
                    nombres.Value = estudiante.NOMBRES;
                    command.Parameters.Add(nombres);

                    OracleParameter apellidos = new OracleParameter();
                    apellidos.ParameterName = "apellidos";
                    apellidos.Value = estudiante.APELLIDOS;
                    command.Parameters.Add(apellidos);

                    OracleParameter ci = new OracleParameter();
                    ci.ParameterName = "ci";
                    ci.Value = estudiante.CI;
                    command.Parameters.Add(ci);

                    OracleParameter fechaNacimiento = new OracleParameter();
                    fechaNacimiento.ParameterName = "fechaNacimiento";
                    fechaNacimiento.Value = estudiante.FECHA_NACIMIENTO;
                    // puedes darle un tipo de dato
                    // fechaNacimiento.DbType = System.Data.DbType.Date;
                    command.Parameters.Add(fechaNacimiento);
                    #endregion

                    result = command.ExecuteNonQuery();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
            return result > 0 ? true : false;
        }

        public bool DeleteEstudiante(Estudiante estudiante)
        {

            string strCon = _configuration.GetConnectionString("OracleDBConnection");
            // string strCon = "Data Source=DW; user id=webacad; password=cefalopatia; Min Pool Size=1";
            int result = 0;
            using (OracleConnection connection = new OracleConnection(strCon))
            using (OracleCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.BindByName = true; // sirve para que puedas enviar en cualquier ordern

                    command.CommandText = "delete estudiante" +                        
                        " where ID_ESTUDIANTE=:idEstudiante";



                    #region parametros para hacer el bind
                    OracleParameter idEstudiante = new OracleParameter();
                    idEstudiante.ParameterName = "idEstudiante";
                    idEstudiante.Value = estudiante.ID_ESTUDIANTE;
                    command.Parameters.Add(idEstudiante);                   
                    #endregion

                    result = command.ExecuteNonQuery();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
            return result > 0 ? true : false;
        }
    }
}
