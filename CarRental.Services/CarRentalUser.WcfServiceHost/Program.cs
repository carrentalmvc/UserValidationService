using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using log4net;
using System.Reflection;

namespace CarRentalUser.WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(CarRental.WcfServices.CarRentalUserService));
                host.Open();
                logger.Debug("CarRentals service is up and Running....");

                Console.ReadLine();
            }

            catch (Exception ex)
            { 
               logger.Error(string.Format("Error occurred while starting the service",ex.Message));
               host.Abort();
               Console.ReadLine();
            }
        }
    }
}
