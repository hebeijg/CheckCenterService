using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CheckCenterService.Common;

namespace CheckCenterService.DAL
{
    public  class SQLHelp
    {
        private static string connString = ConfigurationOpteration.GetStringByKey("ConnString");// System.Configuration.ConfigurationManager.AppSettings["ConnString"];

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="sqlParameterList">参数集</param>
        /// <returns>数据集 dataset</returns>
        public static DataSet GetDataSet(string sql, List<SqlParameter> lstParamter)
        {
            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, conn);

            if (lstParamter != null)
            {
                foreach (SqlParameter parameter in lstParamter)
                {
                    cmd.Parameters.Add(parameter);
                }
            }


            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
            
                Common.LogInfo.WriteLog("GetDataSet", ex.Message);
            }


            return ds;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="sqlParameterList">参数集</param>
        /// <returns>数据集 object</returns>
        public static object ExecuteScalar(string sql, List<SqlParameter> lstParamter)
        {
            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, conn);

            if (lstParamter != null)
            {
                foreach (SqlParameter parameter in lstParamter)
                {
                    cmd.Parameters.Add(parameter);
                }
            }


            object obj = new object();

            try
            {
                obj=cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                Common.LogInfo.WriteLog("GetDataSet", ex.Message);
            }


            return obj;
        }

        /// <summary>
        /// 直接update ,delete ,insert 操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParameterList">参数集</param>
        /// <returns>影响条数</returns>
        public static object ExecuteNonQuery(string sql, List<SqlParameter> sqlParameterList)
        {
            SqlConnection conn = new SqlConnection(connString);
            object obj = new object();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (sqlParameterList != null)
                {
                    foreach (SqlParameter parameter in sqlParameterList)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                obj = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                Common.LogInfo.WriteLog("ExecuteNonQuery", ex.Message);
            }

            return obj;
        }
    }
}
