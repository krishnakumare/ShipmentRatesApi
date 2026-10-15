using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{

    public class ShipmentRequest
    {
        [Range(1,70.0, ErrorMessage = "Weight must be greater than 0 and less than 70 ")]
        public decimal Weight { get; set; }

        public Dimension? dimension { get; set; }

        public string? serviceType { get; set; }


        public string? destinationZone { get; set; }
    }
    public class Dimension
    {
        [Range(1,int.MaxValue, ErrorMessage = "Length must be greater than zero") ]
        
        public int Length { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Breadth must be greater than zero")]
        public int Breadth { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Width must be greater than zero")]
        public int Width { get; set; }
    }
    
    
}
