using Market_Web.Object.Model;
using Market_Web.Object.Repository;
using Market_Web.Data;
using Microsoft.EntityFrameworkCore;
using Market_Web.Object.Dtos;
using AutoMapper;

namespace Market_Web.Object.Repository
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

        public async Task<CreateMarketResponse> CreateMarket(CreateMarketRequest createMarketRequest)
        {

            Market market = _mapper.Map<Market>(createMarketRequest);

            _appdbContext.Markets.Add(market);

            await _appdbContext.SaveChangesAsync();
            CreateMarketResponse response = _mapper.Map<CreateMarketResponse>(market);
            return response;






        }










    }
}
