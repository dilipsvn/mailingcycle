using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.IDAL
{
    /// <summary>
    /// Interface for the Design DAL.
    /// </summary>
    public interface IDesign
    {
        /// <summary>
        /// Gets the summary of designs.
        /// </summary>
        /// <returns>Summary of designs.</returns>
        DataTable GetSummary();

        /// <summary>
        /// Get the active designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>Active designs of the specified user.</returns>
        List<DesignInfo> GetList(int userId);

        /// <summary>
        /// Get all the designs of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <returns>All the designs of the specified user.</returns>
        List<DesignInfo> GetListAll(int userId);

        /// <summary>
        /// Updates the design of the specified user.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="design">Design of the user.</param>
        void Update(int userId, DesignInfo design);

        /// <summary>
        /// Gets the design details of the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design.</param>
        /// <returns>Design details of the specified design.</returns>
        DesignInfo Get(int designId);

        /// <summary>
        /// Deletes the specified design.
        /// </summary>
        /// <param name="designId">Internal identifier of the design to delete.</param>
        /// <param name="userId">Internal identifier of the user.</param>
        void Delete(int designId, int userId);

        /// <summary>
        /// Get the design statuses of the specified parameters.
        /// </summary>
        /// <param name="userId">Internal identifier of the user.</param>
        /// <param name="category">Category of the designs.</param>
        /// <param name="status">Status of the designs.</param>
        /// <returns>The design statuses of the specified parameters.</returns>
        List<DesignStatusInfo> GetDesignStatuses(int userId, int category, int status);
    }
}
