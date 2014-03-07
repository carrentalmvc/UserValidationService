using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WcfServices
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CarRentalUserService : ICarRentalUserService
    {
        public bool ValidateUser(CarRentalUser user)
        {
            try
            {
                if (user != null)
                {
                    return ValidateUserDAL.ValidateUser(user);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }

           
        }
    }
}
