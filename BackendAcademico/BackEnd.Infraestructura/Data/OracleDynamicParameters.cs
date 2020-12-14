using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BackEnd.Infraestructura.Data
{
    class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();
        // int? oblga a que un entero pueda tener un nulo
        public void Add(string name, OracleDbType oracleDbType, 
            ParameterDirection parameterDirection, object value = null,
            int? size = null)
        {
            OracleParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, size.Value
                                    , value, parameterDirection);
            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType
                                    , value, parameterDirection);
            }
            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection parameterDirection)
        {
            var oracleParameter = new OracleParameter(name, oracleDbType, parameterDirection);
            oracleParameters.Add(oracleParameter);
        }

        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command,
            SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(
                command, identity);
            var oracleCommand = command as OracleCommand;
            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }
    }
}
