using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CheckCenterService.DAL
{
    public class CustomerDal
    {
        public DataSet GetAllCustomer()
        {
            string sql = "select * from P_Customer";

            return SQLHelp.GetDataSet(sql, null);
        }

        public DataSet GetCustomerById(int customerId)
        {
            string sql = "select * from P_Customer where CustomerId=@CustomerId";

            List<SqlParameter> lstParamter = new List<SqlParameter>();

            SqlParameter paramter = new SqlParameter("@CustomerId", customerId);
            lstParamter.Add(paramter);

            return SQLHelp.GetDataSet(sql, lstParamter);
        }
    }
}
