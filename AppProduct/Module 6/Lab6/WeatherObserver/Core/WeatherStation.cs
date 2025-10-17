using System;
using System.Collections.Generic;
using AppProduct.Module_6.Lab6.Weather.Abstractions;

namespace AppProduct.Module_6.Lab6.Weather.Core
{
    public class WeatherStation : ISubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        private float temperature;

        public void RegisterObserver(IObserver observer)
        {
            if (observer == null) return;
            if (!observers.Contains(observer)) observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer == null) return;
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers) o.Update(temperature);
        }

        public void SetTemperature(float newTemperature)
        {
            temperature = newTemperature;
            NotifyObservers();
        }
    }
}
