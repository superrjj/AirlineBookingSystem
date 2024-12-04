using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
     class DBConnect
    {

        SqlConnection connect = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string con;
        public string myConnection()
        {
            con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\INIMAF\Downloads\Group-3 System\AirlineBookingSystem\AirlineBookingSystem\AirlineBookingDB.mdf"";Integrated Security=True";
            return con;
        }

        public DataTable getTable(string qury)
        {
            connect.ConnectionString = myConnection();
            cmd = new SqlCommand(qury, connect);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

    }
}
