using DALContract;
using System;
using System.Data;
using SqlParameterImpl;
using System.Data.SqlClient;
using InfraAttributes;

namespace DALImpl
{
    [Register(typeof(IDAL))]
    [Policy(Policy.Singleton)]
    public class DAL: IDAL    {
        private string rMyConn = "DESKTOP-PBFVGRF\\SQLEXPRESS";
        private string _connectionString;

        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DAL()
        {
            _connectionString = ("Server =" + rMyConn + @"Database = DataBase; Trusted_Connection = True;");
        }
        private SqlCommand getCommand(string spName, params IParameter[] parameters)
        {
            var con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand commandSP = new SqlCommand();
            commandSP.CommandText = spName;
            commandSP.CommandType = CommandType.StoredProcedure;
            foreach (var parameter in parameters)
            {
                var paramAdapter = parameter as SqlParameterAdapter;
                commandSP.Parameters.Add(paramAdapter.Parameter);
            }

            commandSP.Connection = con;
            return commandSP;
        }

        public IParameter CreateParameter(string paramName, object value)
        {
            var retval = new SqlParameterAdapter();
            retval.Parameter = new SqlParameter(paramName, value);
            return retval as IParameter;
        }

        public DataSet ExecuteQuery(string spName, params IParameter[] parameters)
        {
            DataSet dataSet = new DataSet();
            var commandSP = getCommand(spName, parameters);
            try
            {  
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandSP);
                dataAdapter.Fill(dataSet);
            }
            catch
            {
                dataSet.Tables.Add();
            }
            commandSP.Connection.Close();
            return dataSet;

        }
        public void ExecuteNonQuery(string spName, params IParameter[] parameters)
        {
            var commandSP = getCommand(spName, parameters);
            commandSP.ExecuteNonQuery();
            commandSP.Connection.Close();
        }
    }
}