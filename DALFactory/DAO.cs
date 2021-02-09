using System;
using System.Reflection;
using System.Configuration;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.DALFactory
{
	public enum Module
	{
        Common = 1,
        Registration,
        Design,
        Farm,
        Schedule,
        Order,
        Product,
        Message,
        ShoppingCart,
        AccaProcess
	};

	/// <summary>
	/// Factory implementaion for the DAL objects.
	/// </summary>
	public class DAO
	{
		public static object Create(Module module)
		{
            // Look up the DAL implementation.
            string path = ConfigurationManager.AppSettings["WebDAL"];
            string className = path + "." + module.ToString();

            // Load the appropriate assembly and class.
            return Assembly.Load(path).CreateInstance(className);
		}
	}
}
