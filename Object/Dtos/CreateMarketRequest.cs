using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Market_Web.Object.Dtos
{
    public class CreateMarketRequest
    {

        public string Name { get; set; }

        public int Employee { get; set; }

        public DateOnly Inauguration { get; set; }

        public double SalesPerMonth { get; set; }





    }
}
