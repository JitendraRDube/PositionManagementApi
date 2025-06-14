using PositionMgmt.Domain.IRepository;
using PositionMgmt.Domain.Models;
using PositionMgmt.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Infrastructure.Repository
{
    /// <summary>
    /// Repository for managing transactions in the Position Management system.
    /// </summary>
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PositionMgmtDBContext _positionsDBContext;
        private readonly IMasterRepository _masterRepo;
        //private readonly BaseRepository _baseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for position management.</param>
        /// <param name="masterRepo">The master repository for accessing master data.</param>
        public TransactionRepository(PositionMgmtDBContext context, IMasterRepository masterRepo)
        {
            _positionsDBContext = context;
            _masterRepo = masterRepo;
            //_baseRepository = new BaseRepository(context);
        }

        /// <summary>
        /// Retrieves a list of all transactions (positions).
        /// </summary>
        public async Task<List<Transaction>> GetPositions()
        {
            var transactions = _positionsDBContext.Transactions.ToList();
            var actionTypes = _positionsDBContext.ActionMasters.ToList();
            var transactionTypes = _positionsDBContext.TransactionTypeMasters.ToList();
            foreach (var transaction in transactions)
            {
                transaction.ActionType = actionTypes.Find(x => x.Id == transaction.ActionTypeId).ActionType;
                transaction.TransactionType = transactionTypes.Find(x => x.Id == transaction.TransactionTypeId).TransactionType;
            }
            return await Task.FromResult(transactions);
        }

        /// <summary>
        /// Retrieves a transaction by its unique identifier.
        /// </summary>
        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            var transaction = _positionsDBContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);
            return await Task.FromResult(transaction);
        }

        /// <summary>
        /// Cancels an order by updating its transaction type to 'Cancelled'.
        /// </summary>
        public async Task<bool> PlaceOrder(Transaction transaction)
        {
            if (transaction.TransactionId <= 0)
            {
                transaction.TradeId = 1;
                transaction.Version = 1;
                transaction.CreatedDate = DateTime.Now;
                _positionsDBContext.Transactions.Add(transaction);
            }
            else
            {
                var existingTrans = _positionsDBContext.Transactions.FirstOrDefault(t => t.TransactionId == transaction.TransactionId);
                existingTrans.Version += existingTrans.Version;
                transaction.ModifyDate = DateTime.Now;
                _positionsDBContext.Transactions.Update(existingTrans);
            }
            int result = await _positionsDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> CancelOrder(int transactionId)
        {
            _positionsDBContext.Update(new Transaction { TransactionId = transactionId, TransactionTypeId = 3, ModifyDate = DateTime.Now });
            int result = await _positionsDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
