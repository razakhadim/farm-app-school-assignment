using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Sheep : LiveStock
    {
        public static List<Sheep> listThree = new List<Sheep>();
        public double amountOfWool;

        public Sheep(int id, double amountOfWater, double dailyCost, double weight, int age, string color, string category, double amountOfWool)
                : base(id, amountOfWater, dailyCost, weight, age, color, category)
        {
            this.amountOfWool = amountOfWool;
        }

        public override double animalDailyCost(double amountOfWater, double waterPrice, double sheepDailyCost, double totalSheepDailyCost)
        {
            totalSheepDailyCost = totalSheepDailyCost + (amountOfWater * waterPrice) + sheepDailyCost;
            return totalSheepDailyCost;
        }

        public override double getAnimalDailyTax(double sheepWeight, double sheepTaxPrice, double sheepTotalDailyTax)
        {
            sheepTotalDailyTax = sheepTotalDailyTax + (sheepWeight * sheepTaxPrice);
            return sheepTotalDailyTax;
        }


    }
}