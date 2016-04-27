using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOOP
{
    class Supermarket
    {
        private string product;
        private double price;

     Supermarket (string product, double price)
        {
            this.product = product;
            this.price = price;
        }
    Supermarket ()
        {
            this.product ="";
            this.price = 0;
        }
    private double CalculateTotalPrice(Supermarket[] product)
        {
            double totalPrice = 0;
            for (int i=0; i<product.Length; i++)
            {
                totalPrice += product[i].price;
            }
            return totalPrice;
        }
    private Supermarket FindCheapest (Supermarket[] product)
        {
            Supermarket min = product[0];
            for (int i=1; i < product.Length; i++)
            {
                if (min.price > product[i].price)
                    min = product[i];
            }
            return min;
        }
     private int FindPositionOfMostExpensive(Supermarket[] shoppingList)
        {
            int expensive = 0;
            for (int i = 1; i < shoppingList.Length; i++)
            {
                if (shoppingList[i].price > shoppingList[expensive].price)
                    expensive = i;
            }
            return expensive;
        }

      private void RemoveMostExpensive( ref Supermarket[] shoppingList)
        {
            int position = FindPositionOfMostExpensive(shoppingList);
            for (int i = position; i < shoppingList.Length - 1; i++)
            {
                shoppingList[i] = shoppingList[i + 1];
            }
            Array.Resize(ref shoppingList, shoppingList.Length - 1);

        }
       private Supermarket[] AddNewProduct(ref Supermarket[] shoppingList, Supermarket product)
        {
            Array.Resize(ref shoppingList, shoppingList.Length + 1);
            shoppingList[shoppingList.Length - 1] = product;
            return shoppingList;
        }

       private double CalculateAveragePrice(Supermarket[] shoppingList)
        {
            return CalculateTotalPrice(shoppingList) / shoppingList.Length;
        }

       static void Main(string[] args)
        {
            Supermarket[] product = new Supermarket[] { new Supermarket("chips", 7.00), new Supermarket("soda", 8.50), new Supermarket("juice", 3.00),
            new Supermarket ("coffee", 2.50), new Supermarket ("tea", 4.00)};
            Supermarket a = new Supermarket();
            Supermarket[] newList = new Supermarket[product.Length+1];
            Supermarket b = new Supermarket("cheese", 7.45);

            double totalPrice = a.CalculateTotalPrice(product);
            Console.Write("The total price is {0}\n", totalPrice);

            Supermarket min = a.FindCheapest(product);
            Console.Write("The cheapest product is {0} with price of {1} \n",min.product, min.price);

            a.RemoveMostExpensive(ref product);
            for (int i=0; i<product.Length; i++)
            {
                Console.Write(" {0} ", product[i].product);
            }

            newList = a.AddNewProduct(ref product, b);
            for (int i = 0; i < product.Length; i++)
            {
                Console.Write("\n {0} ", product[i].product);
            }

            double avgPrice = a.CalculateAveragePrice(product);
            Console.Write("\nThe average price is {0}\n", avgPrice);
        }
    }
}
