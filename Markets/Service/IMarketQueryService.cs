using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;

namespace Market_Web.Markets.Service
{
    public interface IMarketQueryService
    {
        Task<List<Market>> GetAllAsync();

        Task<MarketResponse> FindByNameAsync(string market);

        Task<MarketResponse> FindByIdAsync(int id);

        Task<MarketListNames> GetMarketListNames();







    }
}
