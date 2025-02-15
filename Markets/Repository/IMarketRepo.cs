using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;



namespace Market_Web.Markets.Repository
{
    public interface IMarketRepo
    {
        Task<List<Market>> GetAllAsync();


        Task<MarketResponse> CreateAsync(MarketRequest createMarketRequest);


        Task<MarketResponse> DeleteAsync(int id);

        Task<MarketResponse> UpdateAsync(int id, MarketUpdateRequest mark);
        Task<MarketResponse> FindByNameAsync(MarketRequest market);

        Task<MarketResponse> FindByIdAsync(int id);



    }
}
