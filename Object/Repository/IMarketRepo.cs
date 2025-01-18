using Market_Web.Object.Dtos;
using Market_Web.Object.Model;



namespace Market_Web.Object.Repository
{
    public interface IMarketRepo
    {
        Task<List<Market>> GetAllAsync();

        Task<List<GetInaugurationMarket>> GetDateInauguration();

        Task<List<GetNrEmployees>> GetNrEmployees();




    }
}
