using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MySQLClient;
using System.Data;
using System.Configuration;

namespace MySQLClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //connect
            string connetctionString = "server=localhost;user=root;database=membership;password=12345678";
            
            MySqlConnection mySqlConnection = new MySqlConnection(connetctionString);

            //Task task = mySqlConnector.OpenAsync();  //비동기 처리
            try
            {
                mySqlConnection.Open();

                //login
                MySqlCommand mySqlCommand1 = new MySqlCommand();
                mySqlCommand1.Connection = mySqlConnection;
                mySqlCommand1.CommandText = "select * from membership.users where user_password = 1234 limit 0, 10";
                mySqlCommand1.Prepare();

                MySqlDataReader dataReader = mySqlCommand1.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["name"]+ " " + dataReader["email"]);
                }
                dataReader.Close();

                //register
                MySqlCommand mySqlCommand2 = new MySqlCommand();
                mySqlCommand2.Connection = mySqlConnection;
                mySqlCommand2.CommandText = "insert into users (user_id, user_password, name, email) values ( @user_id, @user_password, @name, @email)";
                mySqlCommand2.Prepare();

                mySqlCommand2.Parameters.AddWithValue("@user_id", "abc001");
                mySqlCommand2.Parameters.AddWithValue("@user_password", "2222");
                mySqlCommand2.Parameters.AddWithValue("@name", "신지용");
                mySqlCommand2.Parameters.AddWithValue("@email", "abc001@abc001.com");
                mySqlCommand2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
