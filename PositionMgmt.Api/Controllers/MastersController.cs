using Microsoft.AspNetCore.Mvc;
using PositionMgmt.Application.IServices;
using PositionMgmt.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PositionMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        IMasterServices _masterServices;
        public MastersController(IMasterServices masterServices)
        {
            _masterServices = masterServices;
        }

        /// <summary>
        /// To get ist of action i. Buy, Sell etc.
        /// </summary>
        [HttpGet("GetActions")]
        public async Task<List<ActionMaster>> GetActions()
        {
            return await _masterServices.GetActions();
        }


        /// <summary>
        /// To get list of transaction types i. INSERT, UPDATE,CANCEL etc.
        /// </summary>
        [HttpGet("GetTransactionTypes")]
        public async Task<List<TransactionTypeMaster>> GetTransactionTypes()
        {
            return await _masterServices.GetTransactionTypes();
        }
    }
}
