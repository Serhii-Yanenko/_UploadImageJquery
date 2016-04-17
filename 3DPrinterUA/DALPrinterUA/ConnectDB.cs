using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace _3DPrinterUA.DALPrinterUA
{
    public class ConnectDB
    {
        private MySqlConnection connection;
        private string server;
        private string user;
        private string database;
        private string password;
        public ConnectDB()
        {
            this.Initialize();
        }
        private void Initialize()
        {
            this.server = "localhost";
            this.database = "3dprinterua";
            this.user = "root";
            this.password = "1111";
            string connStr = "SERVER=" + server + ";" + "DATABASE=" + database +
                ";" + "UID=" + user + ";" + "password=" + password + ";";
            this.connection = new MySqlConnection(connStr);
        }
        private bool OpenConnection()
        {
            bool isConnect = false;
            try
            {
                this.connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        break;
                    case 1045:
                        break;
                }
            }
            return isConnect;
        }
        private bool CloseConnection()
        {
            try
            {
                this.connection.Close();
                return true;
            } catch (MySqlException e)
            {
                return false;
            }
        }
        public long InsertImage(string image1Str, string image2Str, string image3Str, string image4Str, string image5Str)
        {
            long recentlyInsertedId = -1;
            string query = string.Format(@"insert into orderprint (image1,image2,image3,image4, image5, isVerified) VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}')",
                image1Str, image2Str, image3Str, image4Str, image5Str, 0);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                cmd.ExecuteNonQuery();
                recentlyInsertedId = cmd.LastInsertedId;
                this.CloseConnection();
            }
            return recentlyInsertedId;

        }

        public void VerifyOrder(long id)
        {
            string query = string.Format(@"update orderprint set isVerified='1' where id = '{0}'", id);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection(); 
            }
        }
    }
}
