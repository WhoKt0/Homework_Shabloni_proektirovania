using System;
using AppProduct.Module_6.Lab6.Weather.Abstractions;

namespace AppProduct.Module_6.Lab6.Weather.Observers
{
    public class EmailAlert : IObserver
    {
        public string Name { get; }
        private readonly string _email;
        private readonly float? _threshold;
        public EmailAlert(string email, float? threshold = null) { _email = email; Name = $"Email<{email}>"; _threshold = threshold; }
        public void Update(float temperature)
        {
            if (_threshold.HasValue && temperature < _threshold.Value) return;
            Console.WriteLine($"{Name}: уведомление о температуре {temperature}°C");
        }
    }
}
