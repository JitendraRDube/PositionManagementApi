using PositionMgmt.Application.IServices;
using PositionMgmt.Domain.IRepository;
using PositionMgmt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Application.Services
{
    public class MasterServices : IMasterServices
    {
        IMasterRepository _masterRepo;
        public MasterServices(IMasterRepository masterRepo)
        {
            _masterRepo = masterRepo;
        }

        /// <summary>
        /// Retrieves a list of all available actions.
        /// </summary>
        public async Task<List<ActionMaster>> GetActions()
        {
            return await _masterRepo.GetActions();
        }

        /// <summary>
        /// Get list of securities
        /// </summary>
        public async Task<List<SecurityMaster>> GetSecurityMasters()
        {
            return await _masterRepo.GetSecurityMasters();
        }

        /// <summary>
        /// Retrieves a list of all available transaction types.
        /// </summary>
        public async Task<List<TransactionTypeMaster>> GetTransactionTypes()
        {
            return await _masterRepo.GetTransactionTypes();
        }
    }
}
