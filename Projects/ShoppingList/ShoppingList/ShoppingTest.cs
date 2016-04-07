using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    public struct Product
    {
        public string product;
        public double price;

        public Product(string product, double price)
        {
            this.product = product;
            this.price = price;
        }
    }

    [TestClass]
    public class ShoppingTest
    {
        [TestMethod]
        public void TotalPriceTest()
        {
            var shoppingList = new Product[] { new Product("milk", 2.5), new Product("vegetables", 7.75), new Product("fruits", 5.25),
            new Product ("chocolate", 3.5)};
            Assert.AreEqual(19, CalculateTotalPrice(shoppingList));
        }

        [TestMethod]
        public void FindCheapestTest()
        {
            var shoppingList = new Product[] { new Product("chips", 7.24), new Product("soda", 8.75), new Product("juice", 3.85),
            new Product ("coffee", 3.65), new Product ("tea", 3.70)};
            Assert.AreEqual(new Product("coffee", 3.65), FindCheapest(shoppingList));
        }

        [TestMethod]
        public void FindMostExpensiveTest()
        {
            var shoppingList = new Product[] { new Product("chips", 7.24), new Product("soda", 8.75), new Product("juice", 3.85),
            new Product ("coffee", 3.65), new Product ("tea", 3.75)};
            Assert.AreEqual(1, FindPositionOfMostExpensive(shoppingList));
        }

        [TestMethod]
        public void RemoveMostExpensiveTest()
        {
            var shoppingList = new Product[] { new Product("pizza", 7.24), new Product("water", 5.75), new Product("juice", 7.85),
            new Product ("coffee", 3.65), new Product ("cheese", 6.75)};
            RemoveMostExpensive(shoppingList);
            bool test = shoppingList[2].product != "juice";
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddNewProductTest()
        {
            var actual = new Product[] { new Product("pizza", 7.24), new Product("water", 5.75) };
            var expected = new Product[] { new Product("pizza", 7.24), new Product("water", 5.75), new Product("wine", 11.32) };
            CollectionAssert.AreEqual(expected, AddNewProduct(actual, new Product("wine", 11.32)));
        }

        [TestMethod]
        public void CalculateAveragePriceTest()
        {
            var shoppingList = new Product[] { new Product("chips", 7.00), new Product("soda", 8.50), new Product("juice", 3.00),
            new Product ("coffee", 2.50), new Product ("tea", 4.00)};
            Assert.AreEqual(5, CalculateAveragePrice(shoppingList));
        }

        double CalculateTotalPrice(Product[] product)
        {
            double totalPrice = 0;
            for (int i = 0; i < product.Length; i++)
            {
                totalPrice += product[i].price;
            }
            return totalPrice;
        }

        Product FindCheapest(Product[] shoppingList)
        {
            Product min = shoppingList[0];
            for (int i = 1; i < shoppingList.Length; i++)
            {
                if (shoppingList[i].price < min.price)
                    min = shoppingList[i];
            }
            return min;
        }
        int FindPositionOfMostExpensive(Product[] shoppingList)
        {
            int expensive = 0;
            for (int i = 1; i < shoppingList.Length; i++)
            {
                if (shoppingList[i].price > shoppingList[expensive].price)
                    expensive = i;
            }
            return expensive;
        }

        void RemoveMostExpensive(Product[] shoppingList)
        {
            int position = FindPositionOfMostExpensive(shoppingList);
            shoppingList[position] = shoppingList[position + 1];
            Array.Resize(ref shoppingList, shoppingList.Length - 1);

        }
        Product[] AddNewProduct(Product[] shoppingList, Product product)
        {
            Array.Resize(ref shoppingList, shoppingList.Length + 1);
            shoppingList[shoppingList.Length - 1] = product;
            return shoppingList;
        }

        double CalculateAveragePrice(Product[] shoppingList)
        {
            return CalculateTotalPrice(shoppingList) / shoppingList.Length;
        }
    }
}