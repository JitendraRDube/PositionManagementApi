using PositionMgmt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Application.IServices
{
    public interface IMasterServices
    {
        /// <summary>
        /// Retrieves a list of all available actions.
        /// </summary>
        Task<List<ActionMaster>> GetActions();

        /// <summary>
        /// Retrieves a list of all available transaction types.
        /// </summary>
        Task<List<TransactionTypeMaster>> GetTransactionTypes();
    }
}
