using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Market_Web.Markets.Exceptions;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Market_Web.Markets.Service
{
    public class MarketQueryService:IMarketQueryService
    {
        private readonly IMarketRepo _repo;
        public MarketQueryService(IMarketRepo repo)
        {

            this._repo = repo;

        }


       public async  Task<GetAllMarketsDTO> GetAllAsync()
        {
            GetAllMarketsDTO response = await this._repo.GetAllAsync();
            if(response != null)
            {
                return response;
            }
            throw new MarketNotFoundException();
           

        }

        public async  Task<GetAllMarketsDTO> FindByNameAsync(string market)
        {
            if(market != null)
            {
                GetAllMarketsDTO response = await this._repo.FindByNameAsync(market);
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


        public async Task<MarketListNames> GetMarketListNames()
        {

            MarketListNames response = await this._repo.GetMarketListNames();
            if(response != null)
            {
                return response;

            }
            throw new MarketNotFoundException();



        }










    }
}
