using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FieldOfFarmer
{
    [TestClass]
    public class FieldOfFarmerTest
    {

        [TestMethod]
        public void IntialValuesOfTheField()
        {
            Array expected = new[] { 2, -5 }; /*tinand cont ca aceasta problema se refera 
                                               la un teren, solutia negativa nu poate fi 
                                               luata in calcul, dar am luat-o in 
                                               considerare ca exercitiu;*/
            CollectionAssert.AreEqual(expected, CalculateInitialLengthOfField(10, 3));
        }
        Array CalculateInitialLengthOfField(int actualArea, int widthOfTheBoughtField)

          {
           int delta = (widthOfTheBoughtField * widthOfTheBoughtField) - 4 *(-actualArea);
        //    if (delta > 0)
        //    {
                int initialLengthOfField = (int)(-widthOfTheBoughtField + Math.Sqrt(delta)) / 2;
                int secondSolution = (int)(-widthOfTheBoughtField - Math.Sqrt(delta)) / 2;
                return new int[] { initialLengthOfField, secondSolution };
         //   }
         //   return new int[] {0, 0}; 
        }
    }
}
    

