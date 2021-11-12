using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Goat:LiveStock
    {
        public static List<Goat> listTwo = new List<Goat>();
        public double amountOfMilk;


        public Goat(int id, double amountOfWater, double dailyCost, double weight, int age, string color, string category, double amountOfMilk) 
            : base(id, amountOfWater, dailyCost, weight, age, color, category)
        {
            this.amountOfMilk = amountOfMilk;
        }

        public override double animalDailyCost(double amountOfWater, double waterPrice, double goatDailyCost, double goatTotalDailyCost)
        {
            goatTotalDailyCost = goatTotalDailyCost + (amountOfWater * waterPrice) + goatDailyCost;
            return goatTotalDailyCost;
        }

        public override double getAnimalDailyTax(double goatWeight, double goatTaxPrice, double goatTotalDailyTax)
        {
            goatTotalDailyTax = goatTotalDailyTax + (goatWeight * goatTaxPrice);
            return goatTotalDailyTax;
        }

    }
}
