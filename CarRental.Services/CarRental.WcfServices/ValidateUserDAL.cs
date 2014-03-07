using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CarRental.WcfServices
{
    /// <summary>
    /// This service is used to validate a CarRental user while login
    /// </summary>
    public class ValidateUserDAL
    {
        public static bool ValidateUser(CarRentalUser user)
        {
            var connString = ConfigurationManager.ConnectionStrings["CarRental_Services_String"].ToString();
            var retVal = -1;
            using (var con = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand("dbo.WcfService_ValidateUser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    var outParam = new SqlParameter("@Result", 0);
                    cmd.Parameters.Add(outParam);
                    cmd.Parameters["@Result"].Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Email", user.EmailAddress);
                    var rdr = cmd.ExecuteReader();
                    if (outParam != null)
                    {
                        retVal = outParam.Value != null ? Convert.ToInt32(outParam.Value) : -1;
                    }
                }
            }

            return (retVal > 0);
        }
    }
}