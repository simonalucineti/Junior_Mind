using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    public struct Products
    {
        public string product;
        public double price;

        public Products(string product, double price)
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
            var shoppingList = new Products[] { new Products("milk", 2.5), new Products("vegetables", 7.75), new Products("fruits", 5.25),
            new Products ("chocolate", 3.5)};
            Assert.AreEqual(19, CalculateTotalPrice(shoppingList));
        }

        [TestMethod]
        public void FindCheapestTest()
        {
            var shoppingList = new Products[] { new Products("chips", 7.24), new Products("soda", 8.75), new Products("juice", 3.85),
            new Products ("coffee", 3.65), new Products ("tea", 3.70)};
            Assert.AreEqual(new Products("coffee", 3.65), FindCheapest(shoppingList));
        }

        [TestMethod]
        public void FindMostExpensiveTest()
        {
            var shoppingList = new Products[] { new Products("chips", 7.24), new Products("soda", 8.75), new Products("juice", 3.85),
            new Products ("coffee", 3.65), new Products ("tea", 3.75)};
            Assert.AreEqual(1, FindPositionOfMostExpensive(shoppingList));
        }

        [TestMethod]
        public void RemoveMostExpensiveTest()
        {
            var shoppingList = new Products[] { new Products("pizza", 7.24), new Products("water", 5.75), new Products("juice", 7.85),
            new Products ("coffee", 3.65), new Products ("cheese", 6.75)};
            RemoveMostExpensive(shoppingList);
            bool test = shoppingList[4].product != "juice";
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddNewProductTest()
        {
            var actual = new Products[] { new Products("pizza", 7.24), new Products("water", 5.75) };
            var expected = new Products[] { new Products("pizza", 7.24), new Products("water", 5.75), new Products("wine", 11.32) };
            CollectionAssert.AreEqual(expected, AddNewProduct(actual, new Products("wine", 11.32)));
        }

        [TestMethod]
        public void CalculateAveragePriceTest()
        {
            var shoppingList = new Products[] { new Products("chips", 7.00), new Products("soda", 8.50), new Products("juice", 3.00),
            new Products ("coffee", 2.50), new Products ("tea", 4.00)};
            Assert.AreEqual(5, CalculateAveragePrice(shoppingList));
        }

        double CalculateTotalPrice(Products[] products)
        {
            double totalPrice = 0;
            for (int i = 0; i < products.Length; i++)
            {
                totalPrice += products[i].price;
            }
            return totalPrice;
        }

        Products FindCheapest(Products[] shoppingList)
        {
            Products min = shoppingList[0];
            for (int i = 1; i < shoppingList.Length; i++)
            {
                if (shoppingList[i].price < min.price)
                    min = shoppingList[i];
            }
            return min;
        }
        int FindPositionOfMostExpensive(Products[] shoppingList)
        {
            int expensive = 0;
            for (int i = 1; i < shoppingList.Length; i++)
            {
                if (shoppingList[i].price > shoppingList[expensive].price)
                    expensive = i;
            }
            return expensive;
        }

        void RemoveMostExpensive(Products[] shoppingList)
        {
            int position = FindPositionOfMostExpensive(shoppingList);
            shoppingList[position] = shoppingList[position + 1];
            Array.Resize(ref shoppingList, shoppingList.Length - 1);

        }
        Products[] AddNewProduct(Products[] shoppingList, Products product)
        {
            Array.Resize(ref shoppingList, shoppingList.Length + 1);
            shoppingList[shoppingList.Length - 1] = product;
            return shoppingList;
        }

        double CalculateAveragePrice(Products[] shoppingList)
        {
            return CalculateTotalPrice(shoppingList) / shoppingList.Length;
        }
    }
}