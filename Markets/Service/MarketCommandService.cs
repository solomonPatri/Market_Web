using Market_Web.Markets.Dtos;
using Market_Web.Markets.Exceptions;
using Market_Web.Markets.Repository;
using Market_Web.Markets.Model;

namespace Market_Web.Markets.Service
{
    public class MarketCommandService:IMarketCommandService
    {
        private readonly IMarketRepo _repo;

        public MarketCommandService(IMarketRepo repo)
        {
            this._repo = repo;
        }

       
        public async Task<MarketResponse> CreateAsync(MarketRequest request)
        {
            MarketResponse marketexist = await this._repo.FindByNameAsync(request);
            if (marketexist == null)
            {
                MarketResponse response = await this._repo.CreateAsync(request);
                return response;

            }
            throw new MarketAlreadyExistException();



        }


        public async Task<MarketResponse> DeleteAsync(int id)
        {
            MarketResponse marketdelete = await this._repo.FindByIdAsync(id);

            if(marketdelete != null)
            {
                MarketResponse response = await this._repo.DeleteAsync(id);

                return response;


            }
            throw new MarketNotFoundException();


        }

       public async  Task<MarketResponse> UpdateAsync(int id, MarketUpdateRequest mark)
        {

            MarketResponse marketsearched = await this._repo.FindByIdAsync(id);

            if(marketsearched != null)
            {
                if(marketsearched is MarketRequest)
                {
                    marketsearched.Name = mark.Name ?? marketsearched.Name;
                    marketsearched.Employee = mark.Employee ?? marketsearched.Employee;
                    marketsearched.Inauguration = mark.Inauguration ?? marketsearched.Inauguration;
                    marketsearched.SalesPerMonth = mark.SalesPerMonth ?? marketsearched.SalesPerMonth;


                    MarketResponse response = await this._repo.UpdateAsync(id, mark);
                    return response;

                }

                throw new MarketNotUpdateException();
            }
            throw new MarketNotFoundException();


        }












    }
}
