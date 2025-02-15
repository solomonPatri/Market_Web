using Market_Web.Markets.Dtos;

namespace Market_Web.Markets.Service
{
    public interface IMarketCommandService
    {

        Task<MarketResponse> CreateAsync(MarketRequest createMarketRequest);


        Task<MarketResponse> DeleteAsync(int id);

        Task<MarketResponse> UpdateAsync(int id, MarketUpdateRequest mark);













    }
}
