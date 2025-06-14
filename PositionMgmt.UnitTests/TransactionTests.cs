using Moq;
using NUnit.Framework;
using PositionMgmt.Application.IServices;
using PositionMgmt.Application.Services;
using PositionMgmt.Domain.IRepository;
using PositionMgmt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositionMgmt.UnitTests
{
    [TestFixture]
    public class TransactionTests
    {
        private Mock<ITransactionRepository> _transactionRepoMock;
        private ITransactionService _transactionService;

        [SetUp]
        public void Setup()
        {
            _transactionRepoMock = new Mock<ITransactionRepository>();
            _transactionService = new TransactionService(_transactionRepoMock.Object);
        }

        [Test]
        public async Task GetPositions_ReturnsListOfTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, TransactionTypeId = 1 },
                new Transaction { TransactionId = 2, TransactionTypeId = 2 }
            };
            _transactionRepoMock.Setup(r => r.GetPositions()).ReturnsAsync(transactions);

            // Act
            var result = await _transactionService.GetPositions();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].TransactionId);
        }

        [Test]
        public async Task GetTransactionById_ReturnsTransaction()
        {
            // Arrange
            var transaction = new Transaction { TransactionId = 1, TransactionTypeId = 1 };
            _transactionRepoMock.Setup(r => r.GetTransactionById(1)).ReturnsAsync(transaction);

            // Act
            var result = await _transactionService.GetTransactionById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.TransactionId);
        }

        [Test]
        public async Task PlaceOrder_ReturnsTrueOnSuccess()
        {
            // Arrange
            var transaction = new Transaction { TransactionId = 0, TransactionTypeId = 1 };
            _transactionRepoMock.Setup(r => r.PlaceOrder(transaction)).ReturnsAsync(true);

            // Act
            var result = await _transactionService.PlaceOrder(transaction);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CancelOrder_ReturnsTrueOnSuccess()
        {
            // Arrange
            _transactionRepoMock.Setup(r => r.CancelOrder(1)).ReturnsAsync(true);

            // Act
            var result = await _transactionService.CancelOrder(1);

            // Assert
            Assert.IsTrue(result);
        }
    }
}