using AppProduct.Module_6.Prak6.Travel.Domain;

namespace AppProduct.Module_6.Prak6.Travel.Pricing
{
    public class AirplaneCostStrategy : BasePricing
    {
        public override string Name => "Airplane";
        public override decimal Calculate(Trip t)
        {
            var basePerKm = 0.25m;
            var fuelSurcharge = 35m;
            var airportTax = 20m;
            var baseCost = (decimal)t.DistanceKm * basePerKm + fuelSurcharge + airportTax;
            var costPerPassenger = baseCost * ClassMultiplier(t.Class) * t.RegionalCoefficient;
            var passengersFactor = DiscountFactor(t.Passengers, t.Children, t.Seniors);
            var total = costPerPassenger * passengersFactor * t.Passengers + ExtrasTotal(t);
            return decimal.Round(total, 2);
        }
    }
}
