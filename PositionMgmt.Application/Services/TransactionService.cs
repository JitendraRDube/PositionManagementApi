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
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transRepo)
        {
            _transactionRepository = transRepo;
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _transactionRepository.GetTransactions();
        }

        public async Task<List<Transaction>> GetPositions()
        {
            var transactions = await _transactionRepository.GetTransactions();
            var positions = transactions.GroupBy(x => x.Symbol).Select(y => new Transaction { Quantity = y.Sum(x => x.ActionTypeId == 1 ? x.Quantity : -x.Quantity), Symbol = y.Key }).ToList();
            return await Task.FromResult(positions);
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            return await _transactionRepository.GetTransactionById(transactionId);
        }

        public async Task<bool> PlaceOrder(Transaction transaction)
        {
            return await _transactionRepository.PlaceOrder(transaction);
        }

        public async Task<bool> CancelOrder(int transactionId)
        {
            return await _transactionRepository.CancelOrder(transactionId);
        }
    }
}
