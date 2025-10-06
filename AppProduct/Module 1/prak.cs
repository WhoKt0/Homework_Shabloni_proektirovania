using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Module_1
{
    abstract class Vehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }

        protected Vehicle(string brand, string model, int year)
        {
            Brand = brand; Model = model; Year = year;
        }

        public virtual void StartEngine() => Console.WriteLine($"{Brand} {Model} engine started.");
        public virtual void StopEngine() => Console.WriteLine($"{Brand} {Model} engine stopped.");
        public override string ToString() => $"{Brand} {Model} ({Year}) [{Id.ToString().Substring(0, 8)}]";
    }

    class Car : Vehicle
    {
        public int Doors { get; }
        public string Transmission { get; }
        public Car(string brand, string model, int year, int doors, string transmission)
            : base(brand, model, year) { Doors = doors; Transmission = transmission; }
    }

    class Motorcycle : Vehicle
    {
        public string BodyType { get; }
        public bool HasBox { get; }
        public Motorcycle(string brand, string model, int year, string bodyType, bool hasBox)
            : base(brand, model, year) { BodyType = bodyType; HasBox = hasBox; }
    }

    class Garage
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        private readonly List<Vehicle> vehicles = new List<Vehicle>();
        public Garage(string name) { Name = name; }

        public IReadOnlyCollection<Vehicle> Vehicles => vehicles.AsReadOnly();

        public void Add(Vehicle v) { if (v == null) return; vehicles.Add(v); }
        public bool Remove(Guid vehicleId)
        {
            var v = vehicles.FirstOrDefault(x => x.Id == vehicleId);
            if (v == null) return false;
            vehicles.Remove(v); return true;
        }

        public override string ToString() => $"{Name} [{Id.ToString().Substring(0, 6)}]";
    }

    interface IGarageRepo
    {
        void Add(Garage g);
        bool Remove(Guid garageId);
        Garage? Find(Guid garageId);
        IReadOnlyCollection<Garage> GetAll();
    }

    class InMemoryGarageRepo : IGarageRepo
    {
        private readonly List<Garage> list = new List<Garage>();
        public void Add(Garage g) { if (g == null) return; if (list.Any(x => x.Id == g.Id)) return; list.Add(g); }
        public bool Remove(Guid id) { var g = Find(id); if (g == null) return false; list.Remove(g); return true; }
        public Garage? Find(Guid id) => list.FirstOrDefault(x => x.Id == id);
        public IReadOnlyCollection<Garage> GetAll() => list.AsReadOnly();
    }

    interface IFleetService
    {
        void AddGarage(Garage g);
        bool RemoveGarage(Guid garageId);
        bool AddVehicleToGarage(Guid garageId, Vehicle v);
        bool RemoveVehicleFromGarage(Guid garageId, Guid vehicleId);
        IEnumerable<(Garage, Vehicle)> Find(Func<Vehicle, bool> predicate);
    }

    class FleetService : IFleetService
    {
        private readonly IGarageRepo repo;
        public FleetService(IGarageRepo repo) { this.repo = repo; }

        public void AddGarage(Garage g) => repo.Add(g);
        public bool RemoveGarage(Guid id) => repo.Remove(id);

        public bool AddVehicleToGarage(Guid garageId, Vehicle v)
        {
            var g = repo.Find(garageId); if (g == null) return false;
            g.Add(v); return true;
        }

        public bool RemoveVehicleFromGarage(Guid garageId, Guid vehicleId)
        {
            var g = repo.Find(garageId); if (g == null) return false;
            return g.Remove(vehicleId);
        }

        public IEnumerable<(Garage, Vehicle)> Find(Func<Vehicle, bool> predicate)
        {
            foreach (var g in repo.GetAll())
                foreach (var v in g.Vehicles.Where(predicate))
                    yield return (g, v);
        }
    }

    class Program3
    {
        static void Main()
        {
            IGarageRepo repo = new InMemoryGarageRepo();
            IFleetService fleet = new FleetService(repo);

            var g1 = new Garage("Central");
            var g2 = new Garage("West");

            fleet.AddGarage(g1);
            fleet.AddGarage(g2);

            var car = new Car("Toyota", "Corolla", 2018, 4, "automatic");
            var bike = new Motorcycle("Yamaha", "MT-07", 2020, "naked", true);

            fleet.AddVehicleToGarage(g1.Id, car);
            fleet.AddVehicleToGarage(g2.Id, bike);

            Console.WriteLine("Гаражи и их машины:");
            foreach (var garage in repo.GetAll())
            {
                Console.WriteLine($"- {garage}:");
                foreach (var v in garage.Vehicles) Console.WriteLine($"   • {v}");
            }

            Console.WriteLine("\nПоиск мотоциклов:");
            foreach (var (gr, v) in fleet.Find(v => v is Motorcycle))
                Console.WriteLine($" - {v} в {gr.Name}");

            fleet.RemoveVehicleFromGarage(g1.Id, car.Id);
            Console.WriteLine($"\nПосле удаления из {g1.Name}:");
            foreach (var v in g1.Vehicles) Console.WriteLine($" - {v}");
            Console.WriteLine("\nГотово.");
        }
    }
}
