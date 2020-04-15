using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL_assign3
{
    internal class DBhelper : IDisposable
    {
        String str = System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ConnectionString;
        MySqlConnection _conn = null;
        public DBhelper()
        {
            _conn = new MySqlConnection(str);
            _conn.Open();
        }
        public int ExecuteQuery(String sqlQuery)
        {
            MySqlCommand command = new MySqlCommand(sqlQuery, _conn);
            var count = command.ExecuteNonQuery();
            return count;
        }
        public MySqlDataReader ExecuteReader(String sqlQuery)
        {
            MySqlCommand command = new MySqlCommand(sqlQuery, _conn);
            return command.ExecuteReader();
        }
        public Boolean Adapter(String sqlQuery)
        {

            MySqlDataAdapter sda = new MySqlDataAdapter(sqlQuery, _conn);
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
