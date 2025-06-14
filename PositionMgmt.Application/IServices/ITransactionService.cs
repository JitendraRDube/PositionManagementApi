using PositionMgmt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Application.IServices
{
    public interface ITransactionService
    {
        /// <summary>
        /// Retrieves a list of all transactions.
        /// </summary>
        /// <returns>A list of transactions.</returns>
        Task<List<Transaction>> GetPositions();


        /// <summary>
        /// Retrieves a transaction by its unique identifier.
        /// </summary>
        /// <param name="transactionId">The unique identifier of the transaction.</param>
        /// <returns>The transaction with the specified identifier, or null if not found.</returns>
        Task<Transaction> GetTransactionById(int transactionId);


        /// <summary>
        /// Place a new order in the system.
        /// </summary>
        Task<bool> PlaceOrder(Transaction transaction);

        /// <summary>
        /// Cancel an order
        /// </summary>
        Task<bool> CancelOrder(int transactionId);
    }
}
