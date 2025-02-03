using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Market_Web.Markets.Dtos
{
    public class MarketRequest
    {

        public string Name { get; set; }

        public int Employee { get; set; }

        public DateOnly Inauguration { get; set; }

        public double SalesPerMonth { get; set; }





    }
}
