using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Microsoft.AspNetCore.Mvc;
using Market_Web.Markets.Dtos;

namespace Market_Web.Markets
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketController :ControllerBase
    {

        private IMarketRepo _marketRepo;

        public MarketController (IMarketRepo marketRepo)
        {

            this._marketRepo = marketRepo;

        }


        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<Market>>> GetAllMarkets()
        {

            var markets = await _marketRepo.GetAllAsync();

            return Ok(markets);



        }

        [HttpPost("create")]

        public async Task<ActionResult<MarketResponse>> CreateMarket([FromBody] MarketRequest createMarketRequest)
        {

            MarketResponse create = await _marketRepo.CreateAsync(createMarketRequest);
            return Created("", create);
        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<MarketResponse>> DeleteMarket([FromRoute] int id)
        {
            MarketResponse response = await _marketRepo.DeleteAsync(id);

            return Accepted("", response);

        }

        [HttpPut("edit/{id}")]
         
        public async Task<ActionResult<MarketResponse>> EditMarket([FromRoute] int id,[FromBody] MarketUpdateRequest market)
        {
            MarketResponse response = await _marketRepo.UpdateAsync(id, market);

            return Accepted("", response);
        }














    }
}
