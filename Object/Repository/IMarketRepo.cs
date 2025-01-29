using Market_Web.Object.Dtos;
using Market_Web.Object.Model;



namespace Market_Web.Object.Repository
{
    public interface IMarketRepo
    {
        Task<List<Market>> GetAllAsync();

        Task<CreateMarketResponse> CreateMarket(CreateMarketRequest createMarketRequest);



    }
}
