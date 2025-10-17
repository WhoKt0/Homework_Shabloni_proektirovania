using AppProduct.Module_6.Prak6.Travel.Domain;

namespace AppProduct.Module_6.Prak6.Travel.Pricing
{
    public class BusCostStrategy : BasePricing
    {
        public override string Name => "Bus";
        public override decimal Calculate(Trip t)
        {
            var basePerKm = 0.08m;
            var serviceFee = 2m;
            var baseCost = (decimal)t.DistanceKm * basePerKm + serviceFee;
            var costPerPassenger = baseCost * ClassMultiplier(t.Class) * t.RegionalCoefficient;
            var passengersFactor = DiscountFactor(t.Passengers, t.Children, t.Seniors);
            var total = costPerPassenger * passengersFactor * t.Passengers + ExtrasTotal(t);
            if (t.Passengers >= 6) total *= 0.9m;
            return decimal.Round(total, 2);
        }
    }
}
