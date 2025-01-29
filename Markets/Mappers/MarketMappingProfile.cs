using AutoMapper;
using Market_Web.Markets.Dtos;
using Market_Web.Markets.Model;
    
    
 namespace Market_Web.Markets.Mappers
{
    public class MarketMappingProfile:Profile
    {
        public MarketMappingProfile()
        {

            CreateMap<CreateMarketRequest, Market>();
            CreateMap<Market, CreateMarketResponse>();





        }











    }
}
