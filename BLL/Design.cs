using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Irmac.MailingCycle.Model;
using Irmac.MailingCycle.IDAL;

namespace Irmac.MailingCycle.BLL
{
    /// <summary>
    /// A Business Component used to manage Design Utilities.
    /// </summary>
    public class Design
    {
        /// <summary>
        /// Gets the summary of designs.
        /// </summary>
        /// <returns>Summary of designs.</returns>
        public DataTable GetSummary()
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            DataTable summary = dao.GetSummary();

            return summary;
        }

        /// <summary>
        /// Get the designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Designs of the specified user.</returns>
        public List<DesignInfo> GetList(int userId)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            List<DesignInfo> designs = dao.GetList(userId);

            return designs;
        }

        /// <summary>
        /// Get all the designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>All the designs of the specified user.</returns>
        public List<DesignInfo> GetListAll(int userId)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            List<DesignInfo> designs = dao.GetListAll(userId);

            return designs;
        }

        /// <summary>
        /// Updates the design of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="design">Design of the user.</param>
        public void Update(int userId, DesignInfo design)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            try
            {
                dao.Update(userId, design);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the design details of the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design.</param>
        /// <returns>Design details of the specified design.</returns>
        public DesignInfo Get(int designId)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            DesignInfo design = dao.Get(designId);

            return design;
        }

        /// <summary>
        /// Deletes the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design to delete.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        public void Delete(int designId, int userId)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            try
            {
                dao.Delete(designId, userId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the design statuses of the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="category">Category of the designs.</param>
        /// <param name="status">Status of the designs.</param>
        /// <returns>The design statuses of the specified parameters.</returns>
        public List<DesignStatusInfo> GetDesignStatuses(int userId, int category,
            int status)
        {
            // Get an instance of the Design DAO using the DALFactory
            IDesign dao = (IDesign)DALFactory.DAO.Create(DALFactory.Module.Design);

            List<DesignStatusInfo> designs = 
                dao.GetDesignStatuses(userId, category, status);

            return designs;
        }
    }
}
