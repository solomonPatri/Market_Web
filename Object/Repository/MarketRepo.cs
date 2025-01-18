using Market_Web.Object.Model;
using Market_Web.Object.Repository;
using Market_Web.Data;
using Microsoft.EntityFrameworkCore;
using Market_Web.Object.Dtos;

namespace Market_Web.Object.Repository
{
    public class MarketRepo:IMarketRepo
    {
        private readonly AppDbContext _appdbContext;

        public MarketRepo(AppDbContext context)
        {

            this._appdbContext = context;

        }

        public async Task<List<Market>> GetAllAsync()
        {
            return await _appdbContext.Markets.ToListAsync();


        }

        public async Task<List<GetInaugurationMarket>> GetDateInauguration()
        {

            return await _appdbContext.Markets.Select(markets => new GetInaugurationMarket {Name=markets.Name,Inauguration= markets.Inauguration}).ToListAsync();

        }


        public async Task<List<GetNrEmployees>> GetNrEmployees()
        {


            return await _appdbContext.Markets.Select(markets => new GetNrEmployees { Name = markets.Name, Employee = markets.Employee }).ToListAsync();



        }











    }
}
