using System;

namespace AppProduct.Module_7.Lab7.Beverages
{
    public class Tea : Beverage
    {
        private readonly bool _hasTeaLeaves;
        public Tea(bool hasTeaLeaves = true) { _hasTeaLeaves = hasTeaLeaves; }
        protected override bool Brew()
        {
            if (!_hasTeaLeaves) return false;
            Console.WriteLine("Заваривание чая...");
            return true;
        }
        protected override void AddCondiments() => Console.WriteLine("Добавление лимона...");
    }
}
