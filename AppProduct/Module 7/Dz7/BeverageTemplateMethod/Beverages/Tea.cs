using System;

namespace AppProduct.Module_7.Dz7.Beverages
{
    public class Tea : Beverage
    {
        protected override void Brew() => Console.WriteLine("Заваривание чая...");
        protected override void AddCondiments() => Console.WriteLine("Добавление лимона...");
    }
}
