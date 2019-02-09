using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace MicroDB
{
    public class MicroDB
    {
        private string connStr;
        private SqlConnection conn;

        public MicroDB()
        {
            connStr = "DATA SOURCE=.;INITIAL CATALOG=SIGECO;USER=sigeco;PASSWORD=sigeco;";
        }

        private void LogError(Exception ex)
        {
            if (!System.IO.Directory.Exists("C:\\SIGECO_LOGS"))
                System.IO.Directory.CreateDirectory("C:\\SIGECO_LOGS");
            System.IO.File.AppendAllText("C:\\SIGECO_LOGS\\error_log.json", "\n"+JsonConvert.SerializeObject(ex));
        }

        private bool Conectar()
        {
            conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }
            catch(SqlException ex)
            {
                LogError(ex);
                return false;
            }
            return false;
        }

        private bool Desconectar()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    if (conn.State == System.Data.ConnectionState.Closed)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool ExecuteSqlCommand(string strSQL)
        {
            try
            {
                Conectar();

                int? result = null;

                SqlCommand cmd = new SqlCommand(strSQL, conn);
                result=cmd.ExecuteNonQuery();

                Desconectar();

                if (result != null)
                    return true;
                else
                    return false;

            }
            catch (SqlException ex)
            {
                LogError(ex);
                return false;
            }

        }

        public object ExecuteScalar(string strSQL)
        {
            object o = null;

            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand(strSQL, conn);
                o = cmd.ExecuteScalar();

                Desconectar();
            }
            catch (SqlException ex)
            {
                LogError(ex);
            }

            return ParseJson(o);
        }

        public object ExecuteReader(string strSQL)
        {
            object o = null;

            try
            {
                Conectar();

                SqlDataAdapter cmd = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                cmd.Fill(ds);

                o = ds.Tables[0];

                Desconectar();
            }
            catch (SqlException ex)
            {
                LogError(ex);
            }
            
            return ParseJson(o);
        }

        public List<DataRow> ExecuteReaderList(string strSQL)
        {
            DataTable dt = null;
            List<DataRow> dr = null;

            try
            {
                Conectar();

                SqlDataAdapter cmd = new SqlDataAdapter(strSQL, conn);
                DataSet ds = new DataSet();
                cmd.Fill(ds);

                dt = ds.Tables[0];
                dr = dt.Select().ToList();

                Desconectar();
            }
            catch (SqlException ex)
            {
                LogError(ex);
            }

            return dr;
        }

        private object ParseJson(object o)
        {
            object o_ret = null;

            try {
                o_ret = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(o));
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            
            return o_ret;
        }

    }
}
