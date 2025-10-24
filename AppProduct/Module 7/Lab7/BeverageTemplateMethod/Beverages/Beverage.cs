using System;

namespace AppProduct.Module_7.Lab7.Beverages
{
    public abstract class Beverage
    {
        public void PrepareRecipe(bool addCondiments = true)
        {
            BoilWater();
            if (!Brew()) { Console.WriteLine("Ингредиентов нет — приготовление отменено."); return; }
            PourInCup();
            if (addCondiments) AddCondiments();
        }

        private void BoilWater() => Console.WriteLine("Кипячение воды...");
        private void PourInCup() => Console.WriteLine("Наливание в чашку...");

        protected abstract bool Brew();
        protected abstract void AddCondiments();
    }
}
