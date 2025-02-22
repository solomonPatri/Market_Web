using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Microsoft.AspNetCore.Mvc;
using Market_Web.Markets.Dtos;
using Market_Web.Markets.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Market_Web.Markets.Service;
using Microsoft.Extensions.FileProviders;

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

        public async Task<ActionResult<GetAllMarketsDTO>> GetAllMarkets()
        {
            try
            {
                GetAllMarketsDTO markets = await _queryservice.GetAllAsync();

                return Ok(markets);
            }catch(MarketNotFoundException nf)
            {
               return NotFound(nf.Message);
            }


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

        [HttpGet("GetMarketNames")]

        public async Task<ActionResult<MarketListNames>> GetMarketListNames()
        {

            try
            {
                MarketListNames response = await _queryservice.GetMarketListNames();

                return Accepted("", response);

            }catch(MarketNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpGet("find/name/{name}")]

        public async Task<ActionResult<GetAllMarketsDTO>> FindByName([FromRoute]string name)
        {
            try
            {
                GetAllMarketsDTO response = await _queryservice.FindByNameAsync(name);

                return Accepted("", response);


            }catch(MarketNotFoundException nf)
            {

                return NotFound(nf.Message);
            }

        }

        [HttpGet("find/id/{id}")]

        public async Task<ActionResult<MarketResponse>> GetById([FromRoute]int id)
        {

            try
            {
                MarketResponse response = await _queryservice.FindByIdAsync(id);

                return Accepted("", response);
            }catch(MarketNotFoundException nf)
            {
                return NotFound(nf.Message);

            }








        }








    }
}
