using PositionMgmt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Domain.IRepository
{
    /// <summary>
    /// Defines methods for accessing master data such as actions and transaction types.
    /// </summary>
    public interface IMasterRepository
    {
        /// <summary>
        /// Retrieves a list of all available actions.
        /// </summary>
        Task<List<ActionMaster>> GetActions();

        /// <summary>
        /// Retrieves a list of actions by their ID.
        /// </summary>
        /// <param name="id">Action Id</param>
        //Task<ActionMaster> GetActionById(int id);

        /// <summary>
        /// Retrieves a list of all available transaction types.
        /// </summary>
        Task<List<TransactionTypeMaster>> GetTransactionTypes();

        /// <summary>
        /// Retrieves a list of TransactionType by their ID.
        /// </summary>
        /// <param name="id">Action Id</param>
        //Task<TransactionTypeMaster> GetTransactionTypeById(int id);
    }
}
