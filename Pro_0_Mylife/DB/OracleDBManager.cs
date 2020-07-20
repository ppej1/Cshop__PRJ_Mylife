using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_0_Mylife
{

    public sealed class OracleDBManager
    {
        public string LastExceptionString = string.Empty;
        public string ConnectionString = string.Empty;
        public string Address = string.Empty;
        public string Port = string.Empty;

        private OracleCommand LastExecutedCommand = null;
        private int RetryCnt = 0;
            
        public OracleConnection Connection { get; private set; }

        public bool GetConnection()
        {
           
            try
            {
                if(this.Connection != null)
                {
                    this.Connection.Close();
                    this.Connection.Dispose();
                    this.Connection = null;
                    
                }
                
                if (ConnectionString == string.Empty)
                    SetConnectionString();

                Connection = new OracleConnection(ConnectionString);
                //MessageBox.Show(ConnectionString);

                if (this.Address != String.Empty)
                    Connection.Open();
            }
            catch(Exception ex)
            {
                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                String id = string.Format("{0},{1}", info.ReflectedType.Name, info.Name);
                MessageBox.Show(ex.Message);
                return false;

            }
            
            if (Connection.State == ConnectionState.Open)
            {
                return true;
            }

            else
                return false;
        }


        #region private.........................................................

        private void SetConnectionString()
        {
            
            string user = ConfigManager.GetValue("DATABASE", "USER");
            string pwd = ConfigManager.GetValue("DATABASE", "PWD");
            string port = ConfigManager.GetValue("DATABASE", "PORT");
            string sid = ConfigManager.GetValue("DATABASE", "SID");
            string svr = ConfigManager.GetValue("DATABASE", "SERVICE_NAME");
            string addr01 = ConfigManager.GetValue("DATABASE", "D_ADDR01");

            string address01 = string.Format("ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})", addr01, port);
            string dataSource = string.Format(@"(DESCRIPTION=(ADDRESS_LIST=({0}))(CONNECT_DATA =(", address01);

            dataSource += svr == String.Empty ? string.Format("SID={0})))", sid) : string.Format("SERVICE_NAME = {0})))", svr);

            this.Address = addr01;
            this.Port = port;
            this.ConnectionString = "Data Source=" + dataSource+";USER Id=" + user + ";Password=" + pwd ;

        }

        private bool CheckDBConnected()
        {
            string query = "SELECT 1 FROM DUAL";
            OracleDataReader result = null;

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = this.Connection;
                cmd.CommandText = query;
                result = cmd.ExecuteReader();

            }
            catch                {                 }


            if (result != null && result.HasRows)
                return true;

            return false;
        }

        public int ExecuteNonQuery(string query, params object[] oParams)
        {
            lock(this)
            {
                RetryCnt = 0;

                int result = Execute_NonQuery(query);

                return result;
            }
        }


        public DataSet ExecuteDsQuery(DataSet ds, string query)
        {
            ds.Reset();

            lock (this)
            {
                RetryCnt = 0;

                return ExecuteDataAdt(ds, query);
            }
        }

        private DataSet ExecuteDataAdt(DataSet ds, String query)
        {
            try
            {
                OracleDataAdapter cmd = new OracleDataAdapter();
                cmd.SelectCommand = new OracleCommand();
                cmd.SelectCommand.Connection = this.Connection;
                cmd.SelectCommand.CommandText = query;

                LastExecutedCommand = cmd.SelectCommand;
                cmd.Fill(ds);

            }
            catch(Exception ex)
            {
                //연결 해제 여부 확인 / 재시도

                if(RetryCnt< 1 && CheckDBConnected() == false)
                {
                    RetryCnt++;

                    GetConnection();

                    Exception ex02 = new Exception("Reconnect to database");

                    ds = ExecuteDataAdt(ds, query);
                    return ds;
                }
                MessageBox.Show(ex.Message);
                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                string id = string.Format("{0}.{1}\n[{2}]", info.ReflectedType.Name, info.Name, query);

                this.LastExceptionString = ex.Message;

                return null;
            }
            return ds;
        }
        
        private int Execute_NonQuery(string query)
        {
            int result = 0;

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = this.Connection;
                cmd.CommandText = query;

                LastExecutedCommand = cmd;
                result = cmd.ExecuteNonQuery();


            }
            catch(Exception ex)
            {
                if(RetryCnt <1 && CheckDBConnected()  == false)
                {
                    RetryCnt++;


                    GetConnection();

                    result = Execute_NonQuery(query);
                    return result;
                }

                System.Reflection.MemberInfo info = System.Reflection.MethodInfo.GetCurrentMethod();
                string id = string.Format("{0}.{1}\n[{2}]",info.ReflectedType.Name,info.Name,query);

                MessageBox.Show(ex.Message);

                result = -1;
            }
            return result;
        }




        #endregion private.........................................................
    }
}
