using System;
using System.Collections.Generic;
using System.Text;

namespace Irmac.MailingCycle.BLLServiceLoader
{
    /// <summary>
    /// Service loader object that loads the service access instance.
    /// </summary>
    public class ServiceAccess
    {
        private static ServiceAccess instance;

        private ServiceAccess()
        {
            //
        }

        public static ServiceAccess GetInstance()
        {
            if (instance == null)
            {
                instance = new ServiceAccess();
            }

            return instance;
        }

        public Common.CommonService GetCommon()
        {
            // Load the appropriate service.
            return new Common.CommonService();
        }

        public Registration.RegistrationService GetRegistration()
        {
            // Load the appropriate service.
            return new Registration.RegistrationService();
        }

        public Order.OrderService GetOrder()
        {
            // Load the appropriate service.
            return new Order.OrderService();
        }

        public Farm.FarmService GetFarm()
        {
            // Load the appropriate service.
            return new Farm.FarmService();
        }

        public Design.DesignService GetDesign()
        {
            // Load the appropriate service.
            return new Design.DesignService();
        }

        public Message.MessageService GetMessage()
        {
            return new Message.MessageService();
        }

        public Schedule.ScheduleService GetSchedule()
        {
            // Load the appropriate service.
            return new Schedule.ScheduleService();
        }

        public Product.ProductService GetProduct()
        {
            return new Product.ProductService();
        }

        public ShoppingCart.ShoppingCartService GetShoppingCart()
        {
            return new ShoppingCart.ShoppingCartService();
        }

        public Acca.AccaService GetAcca()
        {
            return new Acca.AccaService();
        }
    }
}
