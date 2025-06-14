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


        public async Task<List<Transaction>> GetPositions()
        {
            return await _transactionRepository.GetPositions();
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
