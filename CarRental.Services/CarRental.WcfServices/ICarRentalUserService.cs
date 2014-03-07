using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WcfServices
{
    [ServiceContract]
    public interface ICarRentalUserService
    {
        [OperationContract]
        bool ValidateUser(CarRentalUser user);
    }
}
