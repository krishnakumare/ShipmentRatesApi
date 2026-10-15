using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/rates")]
    public class ShipmentController : Controller
    {
        [HttpGet("calculate")]
        public ShipmentResponse calculate([FromBody] ShipmentRequest shipmentRequest)
        {
            if (shipmentRequest != null)
            {
                decimal volumetricWeight = (shipmentRequest.dimension.Length * shipmentRequest.dimension.Width * shipmentRequest.dimension.Breadth) / 5000m;
                decimal billableWeight = Math.Max(shipmentRequest.Weight, volumetricWeight);
                decimal zoneMultiplier = 0;
                switch (shipmentRequest.destinationZone)
                {
                    case "Local":
                        zoneMultiplier = 1.0m;
                        break;
                    case "Regional":
                        zoneMultiplier = 1.5m;
                        break;
                    case "International":
                        zoneMultiplier = 2.5m;
                        break;
                    default:
                        break;

                }
                decimal baseRate = 0;
                switch (shipmentRequest.serviceType)
                {
                    case "Standard":
                        baseRate = 5m;
                        break;
                    case "Express":
                        baseRate = 8m;
                        break;
                    default:
                        break;

                }

                decimal finalPrice = billableWeight * baseRate * zoneMultiplier;
                var shipmentResponse = new ShipmentResponse
                {
                    Billableweight = billableWeight,
                    FinalPrice = finalPrice,
                    PriceBreakdown = new PriceBreakdown
                    {
                        BaseRate = baseRate,
                        Zonemultiplier = zoneMultiplier
                    }
                };

                return shipmentResponse;
            }
            return new ShipmentResponse();
           
        }
    }
}
