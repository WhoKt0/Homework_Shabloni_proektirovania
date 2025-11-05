using System;

namespace LogisticsAdapterFactory.External
{
    public class ExternalLogisticsServiceA
    {
        public int ShipItem(int itemId) { Console.WriteLine($"[ExtA] Ship item #{itemId}"); return itemId + 1000; }
        public string TrackShipment(int shipmentId) => $"[ExtA] Shipment {shipmentId} -> Delivered";
        public double Quote(double weightKg) => 10.0 + weightKg * 0.9;
    }
}
