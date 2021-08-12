using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcEmployees
{
    public class EmployeeAdapter
    {
        public static DataTable GetempwithDep()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["SQLConnectionString"];
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_getEmpDep"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@typeId", typeId);
                        cmd.Connection = con;
                        con.Open();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        con.Close();
                        return dt;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}