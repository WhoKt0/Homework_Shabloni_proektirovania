using LogisticsAdapterFactory.Abstractions;
using LogisticsAdapterFactory.External;
using System;

namespace LogisticsAdapterFactory.Adapters
{
    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceA _ext;
        public LogisticsAdapterA(ExternalLogisticsServiceA ext) => _ext = ext;

        public void DeliverOrder(string orderId)
        {
            // Simple mapping: parse orderId to int (demo purposes).
            _ext.ShipItem(int.TryParse(orderId, out var id) ? id : 0);
        }

        public string GetDeliveryStatus(string orderId)
        {
            var shipmentId = int.TryParse(orderId, out var id) ? id + 1000 : 1000;
            return _ext.TrackShipment(shipmentId);
        }

        public double CalculateCost(double weightKg, string region) => _ext.Quote(weightKg);
    }
}
