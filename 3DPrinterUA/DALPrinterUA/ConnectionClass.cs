using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace _3DPrinterUA.DALPrinterUA
{
    public class ConnectionClass
    {
        public ConnectionClass()
        {

        }
        private string dataBaseName;
        public string DataBaseName{
            get {
                return this.dataBaseName;
            }
            set
            {
                this.dataBaseName = value;
            }
        }
        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
        private static ConnectionClass _instance = null;
        public static ConnectionClass Instance()
        {
            
                if(_instance == null)
                {
                    _instance = new ConnectionClass();
                }
                return _instance;
            

        }
        public bool IsConnect()
        {
            bool result = true;
            if(Connection == null)
            {
                if (String.IsNullOrEmpty(dataBaseName))
                {
                    result = false;
                }
                string connstring = string.Format("Server=localhost; database={0};UID = root; password = 1111", dataBaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
                result = true;
            }
            return result;
        }
        public void Close()
        {
            connection.Close();
        }

    }
}