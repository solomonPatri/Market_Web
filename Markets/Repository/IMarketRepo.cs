using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;



namespace Market_Web.Markets.Repository
{
    public interface IMarketRepo
    {
        Task<List<Market>> GetAllAsync();

        Task<CreateMarketResponse> CreateMarket(CreateMarketRequest createMarketRequest);



    }
}
