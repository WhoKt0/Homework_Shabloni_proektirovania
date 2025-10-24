using System;

namespace AppProduct.Module_7.Dz7.Beverages
{
    public abstract class Beverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
                AddCondiments();
        }

        private void BoilWater() => Console.WriteLine("Кипячение воды...");
        private void PourInCup() => Console.WriteLine("Наливание в чашку...");

        protected abstract void Brew();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsCondiments()
        {
            Console.Write("Добавлять добавки? (y/n): ");
            var ans = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            return ans == "y" || ans == "yes" || ans == "да";
        }
    }
}
