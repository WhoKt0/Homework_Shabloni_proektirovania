using System;
using System.Collections.Generic;
using AppProduct.Module_6.Prak6.Travel.Domain;
using AppProduct.Module_6.Prak6.Travel.Pricing;

namespace AppProduct.Module_6.Prak6.Travel.Context
{
    public class TravelBookingContext
    {
        private readonly Dictionary<TransportType, ICostCalculationStrategy> _strategies;
        public TravelBookingContext(Dictionary<TransportType, ICostCalculationStrategy> strategies)
        {
            _strategies = strategies;
        }
        public decimal Calculate(Trip trip)
        {
            if (!_strategies.TryGetValue(trip.Transport, out var strategy))
                throw new InvalidOperationException("Нет стратегии для выбранного транспорта");
            return strategy.Calculate(trip);
        }
    }
}
