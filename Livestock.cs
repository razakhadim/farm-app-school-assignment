using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    abstract public class LiveStock
    {
        public int id;
        public double amountOfWater;
        public double dailyCost;
        public double weight;
        public int age;
        public string color;
        public string category;
        public static int animals;
        public static List<int> ages = new List<int>();


        public LiveStock(int id, double amountOfWater, double dailyCost, double weight, int age, string color, string category)
        {
            this.id = id;
            this.amountOfWater = amountOfWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.category = category;

        }


        public abstract double animalDailyCost(double amountOfWater, double waterPrice, double dailyCost, double animalDailyCost);

        public double getDailySale(double amountOfProduct, double productPrice, double dailySale)
        {
            dailySale = dailySale + (amountOfProduct * productPrice);
            return dailySale;
        }

        public abstract double getAnimalDailyTax(double animalWeight, double animalTaxPrice, double animalDailyTax);

   


    }


}
