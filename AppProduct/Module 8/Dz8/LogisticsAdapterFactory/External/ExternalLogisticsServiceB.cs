using System;

namespace LogisticsAdapterFactory.External
{
    public class ExternalLogisticsServiceB
    {
        public string SendPackage(string packageInfo) { Console.WriteLine($"[ExtB] Send: {packageInfo}"); return "TRACK-XYZ"; }
        public string CheckPackageStatus(string trackingCode) => $"[ExtB] {trackingCode} -> InTransit";
        public double Estimate(string region, double weightKg) => region == "EU" ? 15 + weightKg : 12 + weightKg*1.1;
    }
}
