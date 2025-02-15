using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Microsoft.AspNetCore.Mvc;
using Market_Web.Markets.Dtos;
using Market_Web.Markets.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Market_Web.Markets.Service;

namespace Market_Web.Markets
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketController :ControllerBase
    {

        private IMarketCommandService _commandservice;
        private IMarketQueryService _queryservice;

        public MarketController (IMarketCommandService command,IMarketQueryService query)
        {
            this._commandservice = command;
            this._queryservice = query;

        }


        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<Market>>> GetAllMarkets()
        {

            var markets = await _queryservice.GetAllAsync();

            return Ok(markets);



        }

        [HttpPost("create")]

        public async Task<ActionResult<MarketResponse>> CreateMarket([FromBody] MarketRequest createMarketRequest)
        {
            try
            {
                MarketResponse create = await _commandservice.CreateAsync(createMarketRequest);
                return Created("", create);

            }catch(MarketAlreadyExistException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<MarketResponse>> DeleteMarket([FromRoute] int id)
        {

            try
            {
                MarketResponse response = await _commandservice.DeleteAsync(id);

                return Accepted("", response);
            }
            catch (MarketNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpPut("edit/{id}")]

        public async Task<ActionResult<MarketResponse>> EditMarket([FromRoute] int id, [FromBody] MarketUpdateRequest market)
        {
            try
            {
                MarketResponse response = await _commandservice.UpdateAsync(id, market);

                return Accepted("", response);

            }
            catch (MarketNotUpdateException up)
            {
                return NotFound(up.Message);
            }
            catch (MarketNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }













    }
}
