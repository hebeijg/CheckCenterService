using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CheckCenterService.DAL;
using CheckCenterService.Model;

namespace CheckCenterService.BLL
{
    public class CustomerBll
    {
        public DataSet GetAllCustomer()
        {
            CustomerDal dal = new CustomerDal();

            return dal.GetAllCustomer();
        }

        public CustomerInfo GetCustomerById(int customerId)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            CustomerDal customerDal = new CustomerDal();

            DataSet ds = customerDal.GetCustomerById(customerId);

            if(ds!=null &&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                customerInfo = ConvertToModel(ds.Tables[0].Rows[0]);
            }

            return customerInfo;
        }

        private CustomerInfo ConvertToModel(DataRow dr)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            if(dr!=null)
            {
                if(dr["CustomerId"] is DBNull==false)
                {
                    int customerId = 0;
                    int.TryParse(dr["CustomerId"].ToString(), out customerId);
                    customerInfo.CustomerId = customerId;
                }

                if(dr["CustomerName"] is DBNull==false)
                {
                    customerInfo.CustomerName = dr["CustomerName"].ToString();
                }

                if (dr["CustomerAddress"] is DBNull == false)
                {
                    customerInfo.CustomerAddress = dr["CustomerAddress"].ToString();
                }

                if (dr["CustomerContact"] is DBNull == false)
                {
                    customerInfo.CustomerContact = dr["CustomerContact"].ToString();
                }

                if (dr["CreatedUserId"] is DBNull == false)
                {
                    int createdUserId = 0;
                    int.TryParse(dr["CreatedUserId"].ToString(), out createdUserId);

                    customerInfo.CreatedUserId = createdUserId;
                }

                if (dr["CreatedUserId"] is DBNull == false)
                {
                    DateTime createDate = DateTime.MaxValue;
                    DateTime.TryParse(dr["CreateDate"].ToString(), out createDate);

                    customerInfo.CreatedDate = createDate;
                }

                if (dr["ModeifityUserId"] is DBNull == false)
                {
                    int modiftyUserId = 0;
                    int.TryParse(dr["ModeifityUserId"].ToString(), out modiftyUserId);

                    customerInfo.ModeifityUserId = modiftyUserId;
                }

                if (dr["ModifityDate"] is DBNull == false)
                {
                    DateTime modiftyDate = DateTime.MaxValue;
                    DateTime.TryParse(dr["ModifityDate"].ToString(), out modiftyDate);

                    customerInfo.ModifityDate = modiftyDate;
                }
            }
            return customerInfo;
        }
    }
}
