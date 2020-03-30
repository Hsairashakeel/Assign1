using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_DAL
{
    internal class AdminDBHelper :IDisposable
    {
        String str = System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ConnectionString;

        SqlConnection _conn = null;
        public AdminDBHelper()
        {
            _conn = new SqlConnection(str);
            _conn.Open();
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


        public void Dispose()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }

    }
}
