using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GTrustDashBoard.Repository
{
    public class SystemFunctionRepo
    {
        public static List<string> GetAllRegisteredMacAddresses()
        {
            List<string> MacAddressList = new List<string>();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBConnection))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select Address from MacAddress";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MacAddressList.Add(dr.GetString(0));
                }
                dr.Close();
            }
            return MacAddressList;
        }
    }
}
