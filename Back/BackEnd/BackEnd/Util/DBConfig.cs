using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Util
{
    public static class DBConfig
    {
        public static string connectionString { get; set; }      

        public static List<T> GetData<T>(string procedureName, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Util.DBConfig.connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            sqlCommand.Parameters.Add("@" + parameter.Key, SqlDbType.VarChar).Value = parameter.Value;
                        }
                    }                                      
                    List<T> myObjects = new List<T>();
                    using (sqlCommand)
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(reader);
                            if (dataTable.Rows.Count > 0)
                            {
                                var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                                myObjects = (List<T>)JsonConvert.DeserializeObject(serializedMyObjects, type: typeof(List<T>));
                            }
                        }
                    }
                    connection.Close();
                    return myObjects;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }

    }
}
