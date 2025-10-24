using System;

namespace AppProduct.Module_7.Dz7.Beverages
{
    public class HotChocolate : Beverage
    {
        protected override void Brew() => Console.WriteLine("Растворение какао-порошка...");
        protected override void AddCondiments() => Console.WriteLine("Добавление маршмеллоу...");
        protected override bool CustomerWantsCondiments() => true;
    }
}
