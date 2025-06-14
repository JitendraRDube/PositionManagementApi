using PositionMgmt.Domain.IRepository;
using PositionMgmt.Domain.Models;
using PositionMgmt.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Infrastructure.Repository
{
    public class MasterRepository : IMasterRepository
    {

        PositionMgmtDBContext _positionsDBContext;
        public MasterRepository(PositionMgmtDBContext context)
        {
            _positionsDBContext = context;
        }


        /// <summary>
        /// Retrieves a list of all available actions.
        /// </summary>
        public async Task<List<ActionMaster>> GetActions()
        {
            List<ActionMaster> actions = _positionsDBContext.ActionMasters.ToList();
            return actions;
        }

        /// <summary>
        /// Retrieves a list of all available transaction types.
        /// </summary>
        public async Task<List<TransactionTypeMaster>> GetTransactionTypes()
        {
            List<TransactionTypeMaster> types = _positionsDBContext.TransactionTypeMasters.ToList();
            return types;
        }

        public async Task<List<SecurityMaster>> GetSecurityMasters()
        {
            List<SecurityMaster> securities = _positionsDBContext.SecurityMasters.ToList();
            return await Task.FromResult(securities);
        }
    }
}
