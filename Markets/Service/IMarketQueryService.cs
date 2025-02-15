using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;

namespace Market_Web.Markets.Service
{
    public interface IMarketQueryService
    {
        Task<List<Market>> GetAllAsync();

        Task<MarketResponse> FindByNameAsync(MarketRequest market);

        Task<MarketResponse> FindByIdAsync(int id);








    }
}
