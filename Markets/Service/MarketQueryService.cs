using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Market_Web.Markets.Exceptions;

namespace Market_Web.Markets.Service
{
    public class MarketQueryService:IMarketQueryService
    {
        private readonly IMarketRepo _repo;
        public MarketQueryService(IMarketRepo repo)
        {

            this._repo = repo;

        }


       public async  Task<List<Market>> GetAllAsync()
        {

            return await this._repo.GetAllAsync();

        }

        public async  Task<MarketResponse> FindByNameAsync(MarketRequest market)
        {
            if(market != null)
            {
                MarketResponse response = await this._repo.FindByNameAsync(market);
                return response;

            }
            throw new MarketNotFoundException();

        }

      public async  Task<MarketResponse> FindByIdAsync(int id)
        {

            if (id != 0)
            {
                MarketResponse response = await this._repo.FindByIdAsync(id);
                return response;

            }
            throw new MarketNotFoundException();
        }












    }
}
