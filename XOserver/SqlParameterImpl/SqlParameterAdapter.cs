using DALContract;
using System;
using System.Data.SqlClient;

namespace SqlParameterImpl
{
    public class SqlParameterAdapter : IParameter
    {
        public SqlParameter Parameter { get; set; }
    }
}
