using Market_Web.Markets.Model;
using Market_Web.Markets.Repository;
using Market_Web.Data;
using Microsoft.EntityFrameworkCore;
using Market_Web.Markets.Dtos;
using AutoMapper;

namespace Market_Web.Markets.Repository
{
    public class MarketRepo:IMarketRepo
    {
        private readonly AppDbContext _appdbContext;
        private readonly IMapper _mapper;

        public MarketRepo(AppDbContext context,IMapper mapper)
        {

            this._appdbContext = context;
            this._mapper = mapper;

        }

        public async Task<List<Market>> GetAllAsync()
        {
            return await _appdbContext.Markets.ToListAsync();


        }

        public async Task<MarketResponse> CreateAsync(MarketRequest createMarketRequest)
        {

            Market market = _mapper.Map<Market>(createMarketRequest);

            _appdbContext.Markets.Add(market);

            await _appdbContext.SaveChangesAsync();
            MarketResponse response = _mapper.Map<MarketResponse>(market);
            return response;

        }

        public async Task<MarketResponse>  DeleteAsync(int id)
        {

            Market mark = await _appdbContext.Markets.FindAsync(id);

            MarketResponse response = _mapper.Map<MarketResponse>(mark);

            await _appdbContext.SaveChangesAsync();

            return response;

        }

        public async Task<MarketResponse> UpdateAsync(int id, MarketUpdateRequest market)
        {

            Market mark = await _appdbContext.Markets.FindAsync(id);

            if (market.Name!= null)
            {
                mark.Name = market.Name; 


            }

            if (market.Employee.HasValue)
            {
                mark.Employee = market.Employee.Value;

            }

            if (market.Inauguration.HasValue)
            {
                mark.Inauguration = market.Inauguration.Value;
            }


            if (market.SalesPerMonth.HasValue)
            {

                mark.SalesPerMonth = market.SalesPerMonth.Value;

            }

            _appdbContext.Markets.Update(mark);

            await _appdbContext.SaveChangesAsync();

            MarketResponse response = _mapper.Map<MarketResponse>(mark);

            return response;

        }

        public async Task<MarketResponse> FindByNameAsync(MarketRequest market)
        {

            Market marketsearched = await _appdbContext.Markets.FirstOrDefaultAsync(m => m.Name.Equals(market.Name));


            MarketResponse response = _mapper.Map<MarketResponse>(marketsearched);

            return response;


        }


        public async Task<MarketResponse> FindByIdAsync(int id)
        {

            Market marketsearched = await _appdbContext.Markets.FindAsync(id);

            MarketResponse response = _mapper.Map<MarketResponse>(marketsearched);

            return response;


        }











    }
}
