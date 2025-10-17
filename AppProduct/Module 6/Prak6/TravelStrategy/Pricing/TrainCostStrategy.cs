using AppProduct.Module_6.Prak6.Travel.Domain;

namespace AppProduct.Module_6.Prak6.Travel.Pricing
{
    public class TrainCostStrategy : BasePricing
    {
        public override string Name => "Train";
        public override decimal Calculate(Trip t)
        {
            var basePerKm = 0.12m;
            var reservation = 5m;
            var baseCost = (decimal)t.DistanceKm * basePerKm + reservation;
            var costPerPassenger = baseCost * ClassMultiplier(t.Class) * t.RegionalCoefficient;
            var passengersFactor = DiscountFactor(t.Passengers, t.Children, t.Seniors);
            var total = costPerPassenger * passengersFactor * t.Passengers + ExtrasTotal(t);
            return decimal.Round(total, 2);
        }
    }
}
