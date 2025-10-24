using System;
using AppProduct.Module_7.Lab7.Beverages;

namespace AppProduct.Module_7.Lab7.BeverageApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Чай:");
            Beverage tea = new Tea();
            tea.PrepareRecipe();

            Console.WriteLine("\nКофе (без сахара/молока):");
            Beverage coffee = new Coffee();
            coffee.PrepareRecipe(addCondiments: false);

            Console.WriteLine("\nГорячий шоколад:");
            Beverage choco = new HotChocolate();
            choco.PrepareRecipe();

            Console.WriteLine("\nПустая банка чая:");
            Beverage teaNo = new Tea(hasTeaLeaves: false);
            teaNo.PrepareRecipe();
        }
    }
}
