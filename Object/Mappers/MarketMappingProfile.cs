using AutoMapper;
using Market_Web.Object.Dtos;
using Market_Web.Object.Model;
    
    
 namespace Market_Web.Object.Mappers
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
