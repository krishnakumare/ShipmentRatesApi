using System.Reflection.Metadata;

namespace WebApplication1.Model
{
    public class ShipmentResponse
    {

        public decimal Billableweight { get; set; }

        public decimal FinalPrice { get; set; }

        public PriceBreakdown? PriceBreakdown { get; set; }

    }

    public class PriceBreakdown
    {
        public decimal BaseRate { get; set; }
        public decimal Zonemultiplier { get; set; }
    }

}
