using System;

namespace AppProduct.Module_7.Lab7.Beverages
{
    public class HotChocolate : Beverage
    {
        private readonly bool _hasCocoa;
        public HotChocolate(bool hasCocoa = true) { _hasCocoa = hasCocoa; }
        protected override bool Brew()
        {
            if (!_hasCocoa) return false;
            Console.WriteLine("Растворение какао-порошка...");
            return true;
        }
        protected override void AddCondiments() => Console.WriteLine("Добавление маршмеллоу...");
    }
}
