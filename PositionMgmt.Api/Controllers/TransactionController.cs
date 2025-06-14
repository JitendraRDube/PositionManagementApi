using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PositionMgmt.Application.IServices;
using PositionMgmt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositionMgmt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transService;

        public TransactionController(ITransactionService transService)
        {
            _transService = transService;
        }

        [HttpGet("GetPositions")]
        public async Task<ActionResult<List<Transaction>>> GetPositions()
        {
            var positions = await _transService.GetPositions();
            return Ok(positions);
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _transService.GetTransactionById(id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult> PlaceOrder([FromBody] Transaction transaction)
        {
            var result = await _transService.PlaceOrder(transaction);
            if (result)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Transaction/cancel/{id}
        [HttpPut("cancel/{id}")]
        public async Task<ActionResult> CancelOrder(int id)
        {
            var result = await _transService.CancelOrder(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}