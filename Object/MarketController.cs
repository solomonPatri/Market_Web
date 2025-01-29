using Market_Web.Object.Model;
using Market_Web.Object.Repository;
using Microsoft.AspNetCore.Mvc;
using Market_Web.Object.Dtos;

namespace Market_Web.Object
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

        public async Task<ActionResult<CreateMarketResponse>> CreateMarket([FromBody] CreateMarketRequest createMarketRequest)
        {

            CreateMarketResponse create = await _marketRepo.CreateMarket(createMarketRequest);
            return Created("", create);
        }
       



















    }
}
