using System;

namespace AppProduct.Module_7.Lab7.Beverages
{
    public class Coffee : Beverage
    {
        private readonly bool _hasBeans;
        private readonly string _milk;
        public Coffee(bool hasBeans = true, string milk = "обычное") { _hasBeans = hasBeans; _milk = milk; }
        protected override bool Brew()
        {
            if (!_hasBeans) return false;
            Console.WriteLine("Заваривание кофе...");
            return true;
        }
        protected override void AddCondiments() => Console.WriteLine($"Добавление сахара и молока ({_milk})...");
    }
}
