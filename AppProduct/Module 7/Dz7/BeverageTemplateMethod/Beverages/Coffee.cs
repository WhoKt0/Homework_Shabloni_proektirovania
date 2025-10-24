using System;

namespace AppProduct.Module_7.Dz7.Beverages
{
    public class Coffee : Beverage
    {
        protected override void Brew() => Console.WriteLine("Заваривание кофе...");
        protected override void AddCondiments() => Console.WriteLine("Добавление сахара и молока...");
    }
}
