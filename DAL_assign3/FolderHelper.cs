using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_assign3
{
    internal class FolderHelper : IDisposable
    {
        String str = System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ConnectionString;
        MySqlConnection _conn = null;
        public FolderHelper()
        {
            try
            {
                _conn = new MySqlConnection(str);
                _conn.Open();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public int ExecuteQuery(String MysqlQuery)
        {
            MySqlCommand command = new MySqlCommand(MysqlQuery, _conn);
            var count = command.ExecuteNonQuery();
            return count;
        }
        

        public MySqlDataReader ExecuteReader(String MysqlQuery)
        {
            MySqlCommand command = new MySqlCommand(MysqlQuery, _conn);
            return command.ExecuteReader();
        }
        public Boolean Adapter(String MysqlQuery)
        {

            MySqlDataAdapter sda = new MySqlDataAdapter(MysqlQuery, _conn);
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
