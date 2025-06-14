using Moq;
using NUnit;
using NUnit.Framework;
using PositionMgmt.Application.IServices;
using PositionMgmt.Application.Services;
using PositionMgmt.Domain.IRepository;
using PositionMgmt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PositionMgmt.UnitTests
{
    [TestFixture]
    public class MasterTests
    {
        private readonly Mock<IMasterRepository> _masterRepoMock;
        private readonly IMasterServices _masterServices;

        public MasterTests()
        {
            _masterRepoMock = new Mock<IMasterRepository>();
            _masterServices = new MasterServices(_masterRepoMock.Object);
        }

        [Test]
        public async Task GetActions_ReturnsListOfActions()
        {
            // Arrange
            var actions = new List<ActionMaster>
            {
                new ActionMaster { Id = 1, ActionType = "Buy" },
                new ActionMaster { Id = 2, ActionType = "Sell" }
            };
            _masterRepoMock.Setup(repo => repo.GetActions()).ReturnsAsync(actions);

            // Act
            var result = await _masterServices.GetActions();

            // Assert
            Assert.NotNull(result);
            Assert.Equals(2, result.Count);
            Assert.Equals("Buy", result[0].ActionType);
            Assert.Equals("Sell", result[1].ActionType);
        }

        [Test]
        public async Task GetTransactionTypes_ReturnsListOfTransactionTypes()
        {
            // Arrange
            var transactionTypes = new List<TransactionTypeMaster>
            {
                new TransactionTypeMaster { Id = 1, TransactionType = "INSERT" },
                new TransactionTypeMaster { Id = 2, TransactionType = "UPDATE" },
                new TransactionTypeMaster { Id = 2, TransactionType = "CANCEL" }
            };
            _masterRepoMock.Setup(repo => repo.GetTransactionTypes()).ReturnsAsync(transactionTypes);

            // Act
            var result = await _masterServices.GetTransactionTypes();

            // Assert
            Assert.NotNull(result);
            Assert.Equals(3, result.Count);
            Assert.Equals("INSERT", result[0].TransactionType);
        }
    }
}
