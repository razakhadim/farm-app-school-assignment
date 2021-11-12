using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Dog:LiveStock
    {
        public static List<Dog> listFour = new List<Dog>();

        public Dog(int id, double amountOfWater, double dailyCost, double weight, int age, string color, string category)
          : base(id, amountOfWater, dailyCost, weight, age, color, category)
        {

        }

        public override double animalDailyCost(double amountOfWater, double waterPrice, double dogDailyCost, double totalDogDailyCost)
        {
            totalDogDailyCost = totalDogDailyCost + (amountOfWater * waterPrice) + dogDailyCost;
            return totalDogDailyCost;
        }

        public override double getAnimalDailyTax(double dogWeight, double dogTaxPrice, double dogTotalDailyTax)
        {
            dogTotalDailyTax = dogTotalDailyTax + (dogWeight * dogTaxPrice);
            return dogTotalDailyTax;
        }

    }
}
