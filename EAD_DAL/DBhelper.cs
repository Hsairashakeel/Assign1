using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_DAL
{
   internal class DBhelper :IDisposable
    {
        
           String str =System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ConnectionString;

            SqlConnection _conn = null;
            public DBhelper()
            {
                _conn = new SqlConnection(str);
                _conn.Open();
            }
            public int ExecuteQuery(String sqlQuery)
            {
                SqlCommand command = new SqlCommand(sqlQuery, _conn);
                var count = command.ExecuteNonQuery();
                return count;
            }
            public Boolean Adapter(String sqlQuery)
            {

                SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, _conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;

            }
            public SqlDataReader ExecuteReader(String sqlQuery)
            {
                SqlCommand command = new SqlCommand(sqlQuery, _conn);
                return command.ExecuteReader();
            }

            public object dataInGrid(String sqlQuery)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from UsersData", _conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            public void Dispose()
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                    _conn.Close();
            }
        }
}
