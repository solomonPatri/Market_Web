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


        [HttpGet("AllMarkets")]

        public async Task<ActionResult<IEnumerable<Market>>> GetAllMarkets()
        {

            var markets = await _marketRepo.GetAllAsync();

            return Ok(markets);



        }


        public async Task<ActionResult<IEnumerable<GetInaugurationMarket>>> GetInaugarationMarkets()
        {

            List<GetInaugurationMarket> market = await _marketRepo.GetDateInauguration();

            return Ok(market);





        }


        public async Task<ActionResult<IEnumerable<GetNrEmployees>>> GetEmployees()
        {

            List<GetNrEmployees> markets = await _marketRepo.GetNrEmployees();

            return Ok(markets);

        }



















    }
}
