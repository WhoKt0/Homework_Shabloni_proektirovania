using System.Collections.Generic;

namespace AppProduct.Module_6.Prak6.Travel.Domain
{
    public class Trip
    {
        public TransportType Transport { get; set; }
        public double DistanceKm { get; set; }
        public ServiceClass Class { get; set; }
        public int Passengers { get; set; }
        public int Children { get; set; }
        public int Seniors { get; set; }
        public int ExtraBaggage { get; set; }
        public Dictionary<string, decimal> Extras { get; } = new Dictionary<string, decimal>();
        public decimal RegionalCoefficient { get; set; } = 1m;
    }
}
