using AppProduct.Module_6.Prak6.Travel.Domain;

namespace AppProduct.Module_6.Prak6.Travel.Pricing
{
    public abstract class BasePricing : ICostCalculationStrategy
    {
        public abstract string Name { get; }
        protected virtual decimal ClassMultiplier(ServiceClass c) => c == ServiceClass.Business ? 1.8m : 1.0m;
        protected virtual decimal DiscountFactor(int passengers, int children, int seniors)
        {
            decimal childDisc = 0.5m;
            decimal seniorDisc = 0.3m;
            var full = passengers;
            var discount = (children * childDisc + seniors * seniorDisc);
            var avg = (full - discount) / (decimal)System.Math.Max(1, full);
            return avg;
        }
        protected virtual decimal ExtrasTotal(Trip t)
        {
            decimal sum = 0m;
            foreach (var kv in t.Extras) sum += kv.Value;
            sum += t.ExtraBaggage * 15m;
            return sum;
        }
        public abstract decimal Calculate(Trip trip);
    }
}
