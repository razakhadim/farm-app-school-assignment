using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
     class Cow :LiveStock
    {
        public static List<Cow> listOne = new List<Cow>();
        public double amountOfMilk;
        public string isJersy;

        public Cow(int id, double amountOfWater, double dailyCost, double weight, int age, string color, string category, double amountOfMilk, string isJersy) : base(id, amountOfWater, dailyCost, weight, age, color, category)
        {
            this.amountOfMilk = amountOfMilk;
            this.isJersy = isJersy;
        }

        public override double animalDailyCost(double amountOfWater, double waterPrice, double cowdailyCost, double cowDailyCost)
        {
            cowDailyCost = cowDailyCost + (amountOfWater * waterPrice) + cowDailyCost;
            return cowDailyCost;
        }

        //jersy cow has different taxprice
        public override double getAnimalDailyTax(double cowWeight, double cowTaxType, double cowDailyTax)
        {
            
            cowDailyTax = cowDailyTax + (cowWeight * cowTaxType);
            return cowDailyTax;
        }

    }
}
