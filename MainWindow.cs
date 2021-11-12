using Farm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace OverAllApp
{
    public partial class MainWindow : Form
    {

        //global variables
        public int countRed;


        //Create connection with database 
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\OEM\OneDrive\Desktop\AnimalApplication_Submitted\OverAllApp\OverAllApp_Final_BugFixes\OverAllApp\Database1BKP.accdb");

        //Create hashTable
        Hashtable hashTable = new Hashtable();
      
        public int counterRed;
        public MainWindow()
        {
            InitializeComponent();
            //loadData from database
            loadData();
            cost();
        }


        //This fuction loads data from access database and stores in hashTable
        public void loadData()
        {


            int id;
            double amountOfWater;
            double dailyCost;
            double weight;
            int age;
            double amountOfMilk;
            string isJersy;
            string color = "";
            string category; //this is categorise the animals
            double amountOfWool;


            try
            {
                //Open the database
                con.Open();

                // get the names of the tables minus system tables.
                string[] restrictions = new string[4];
                restrictions[3] = "Table";

                DataTable schema = con.GetSchema("Tables", restrictions);
                List<string> tableNames = new List<string>();
                for (int i = 0; i < schema.Rows.Count; i++)
                {
                    tableNames.Add(schema.Rows[i][2].ToString().ToLower());
                    Console.WriteLine(tableNames[i]);

                }

                foreach (var table in tableNames)
                {

                    String dbQuery = "Select * from " + table + ";";
                    OleDbCommand cmd = new OleDbCommand(dbQuery, con);

                    //DB reader
                    OleDbDataReader reader;
                    reader = cmd.ExecuteReader();

                    //Read data from cow table and store in hashTable

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            if (table == "cows")
                            {

                                Cow cow = new Cow(
                                    id = Convert.ToInt32(reader["ID"].ToString()),
                                  amountOfWater = Convert.ToDouble(reader["Amount of water"].ToString()),
                                  dailyCost = Convert.ToDouble(reader["Daily cost"].ToString()),
                                  weight = Convert.ToDouble(reader["Weight"].ToString()),
                                  age = Convert.ToInt32(reader["Age"].ToString()),
                                  color = reader["Color"].ToString().ToLower(),
                                  category = "Cow",
                                  amountOfMilk = Convert.ToDouble(reader["Amount of milk"].ToString()),
                                  isJersy = reader["Is jersy"].ToString()

                                   );
                                hashTable.Add(id, cow);


                                //    }
                            }
                            else if (table == "goats")
                            {

                                Goat goat = new Goat(
                                  id = Convert.ToInt32(reader["ID"].ToString()),
                                  amountOfWater = Convert.ToDouble(reader["Amount of water"].ToString()),
                                dailyCost = Convert.ToDouble(reader["Daily cost"].ToString()),
                                 weight = Convert.ToDouble(reader["Weight"].ToString()),
                                 age = Convert.ToInt32(reader["Age"].ToString()),
                                 color = reader["Color"].ToString().ToLower(),
                                 category = "Goat",
                                 amountOfMilk = Convert.ToDouble(reader["Amount of milk"].ToString())
                                  );

                                //Add data of goat into hashtable
                                hashTable.Add(id, goat);


                            }
                            else if (table == "sheep")
                            {

                                Sheep sheep = new Sheep(
                                id = Convert.ToInt32(reader["ID"].ToString()),
                                amountOfWater = Convert.ToDouble(reader["Amount of water"].ToString()),
                                dailyCost = Convert.ToDouble(reader["Daily cost"].ToString()),
                                weight = Convert.ToDouble(reader["Weight"].ToString()),
                                age = Convert.ToInt32(reader["Age"].ToString()),
                                color = reader["Color"].ToString().ToLower(),
                                category = "Sheep",
                                amountOfWool = Convert.ToDouble(reader["Amount of wool"].ToString())

                                 );

                                hashTable.Add(id, sheep);


                            }
                            else if (table == "dogs")
                            {

                                Dog dog = new Dog(
                                id = Convert.ToInt32(reader["ID"].ToString()),
                                amountOfWater = Convert.ToDouble(reader["Amount of water"].ToString()),
                               dailyCost = Convert.ToDouble(reader["Daily cost"].ToString()),
                               weight = Convert.ToDouble(reader["Weight"].ToString()),
                               age = Convert.ToInt32(reader["Age"].ToString()),
                               color = reader["Color"].ToString().ToLower(),
                               category = "Dog"
                                );
                                //Add dog data into hashtable
                                hashTable.Add(id, dog);

                            }

                        }
                        else
                        {
                            Console.WriteLine("No Rows Found");
                        }


                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("DataBase Error");
            }
            con.Close();

        }


        //get animal color if red
        public void getColor(string color)
        {
            if (color.Equals("red"))
            {
                countRed++;
            }
        }


        //Get prices from price table

        double goatMilkPrice = 0;
        double cowMilkPrice = 0;
        double sheepWoolPrice = 0;
        double waterPrice = 0;
        double tax = 0;
        double jersyTax = 0;
        public void readPriceTable()
        {
            con.Open();
            //Get price from price table
            OleDbCommand cmd = new OleDbCommand("Select * from price", con);

            OleDbDataReader readerOne;
            readerOne = cmd.ExecuteReader();

            if (readerOne.Read())
            {
                //Store different prices

                goatMilkPrice = Convert.ToDouble(readerOne["Goat milk price"].ToString());
                cowMilkPrice = Convert.ToDouble(readerOne["Cow milk price"].ToString());
                sheepWoolPrice = Convert.ToDouble(readerOne["Sheep wool price"].ToString());
                waterPrice = Convert.ToDouble(readerOne["Water price"].ToString());
                tax = Convert.ToDouble(readerOne["Tax"].ToString());
                jersyTax = Convert.ToDouble(readerOne["Jersy cow tax"].ToString());
            }

            con.Close();
        }


        double cowTotalDailyCost = 0;
        double cowDailySale = 0;
    //    double totalCow = 0;
        double jersyCowDailySale = 0;

        double goatTotalTax = 0;
        double cowTotalTax = 0;
        double sheepTotalTax = 0;
        double jersyTotalTax = 0;

        double goatTotalDailyCost = 0;
   //     double totalGoat = 0;

        double goatTotalMilk = 0;

        double sheepTotalDailyCost = 0;
        double sheepDailySale = 0;
  //      double totalSheep = 0;

        double dogTotalDailyCost = 0;

        double cowTotalMilk = 0;
        double goatDailySale = 0;

        int cowAge = 0;
        int sheepAge = 0;
        int goatAge = 0;
        int countAnimals = 0; // for age average, not incremented on dogs

        //get average of cow and goat milk per day
        int counterForAvereageProfit = 0;
        int counterForSheepAverage = 0;
        int animals = 0;
     
        double totalProfitJersyCow = 0;
        double jersyCowDailyCost = 0;



        //This function will calculate cost, ratio functionalities
        public void cost()
        {
            readPriceTable();

              int countRed = 0;



            //Get data from hashtable and apply calculation
            foreach (DictionaryEntry element in hashTable)
            {

                LiveStock cowObject = (LiveStock)element.Value;
                string category = cowObject.category;

                if (category.Equals("Cow"))
                {
                    //Get data of cow and perform calculation

                    Cow cowInstance = (Cow)element.Value;
                    double amountOfWater = cowInstance.amountOfWater;
                    double dailyCost = cowInstance.dailyCost;
                    double amountOfMilk = cowInstance.amountOfMilk;
                    double weight = cowInstance.weight;
                    string check = cowInstance.isJersy;
                    string color = cowInstance.color;
                    LiveStock.ages.Add(cowInstance.age);

                    Profitability objProfit = new Profitability();
                    objProfit.id = cowInstance.id;

                    getColor(color);


                    animals++;
                    cowAge = cowAge + cowInstance.age;
                    countAnimals++; //count the animals to calculate average age
                    counterForAvereageProfit++;

                    if (check == "True")
                    {

                        jersyTotalTax = cowInstance.getAnimalDailyTax(weight, jersyTax, jersyTotalTax);
                        jersyCowDailyCost = cowInstance.animalDailyCost(amountOfWater, waterPrice, dailyCost, jersyCowDailyCost);
                        jersyCowDailySale = cowInstance.getDailySale(amountOfMilk, cowMilkPrice, jersyCowDailySale);

                        
                    }
                    else
                    {
                        //If cow is not jersy

                        cowTotalDailyCost = cowInstance.animalDailyCost(amountOfWater, waterPrice, dailyCost, cowTotalDailyCost);
                        cowDailySale = cowInstance.getDailySale(amountOfMilk, cowMilkPrice, cowDailySale);
                        cowTotalTax = cowInstance.getAnimalDailyTax(weight, tax, cowTotalTax);

                    }

                    cowTotalMilk = cowTotalMilk + amountOfMilk;


                    //get cows profitibility for generating file

                    if (check == "True")
                    {
                        objProfit.profit = jersyCowDailySale - jersyCowDailyCost - jersyTotalTax;
                        Profitability.list.Add(objProfit);
                    }
                    else
                    {
                        objProfit.profit = cowDailySale - cowTotalDailyCost - cowTotalTax;
                        Profitability.list.Add(objProfit);

                    }

                }


                if (category.Equals("Goat"))
                {
                    //Get data of Goat

                    Goat goatObject = (Goat)element.Value;
                    double amountOfWater = goatObject.amountOfWater;
                    double dailyCost = goatObject.dailyCost;
                    double amountOfMilk = goatObject.amountOfMilk;
                    double weight = goatObject.weight;
                    goatAge = goatAge + goatObject.age;
                    string color = goatObject.color;
                    LiveStock.ages.Add(goatObject.age);

                    Profitability objProfit = new Profitability();
                    objProfit.id = goatObject.id;


                    getColor(color);
                    animals++;


                    countAnimals++;
                    counterForAvereageProfit++;

                    //get goat daily sale
                    goatDailySale = goatObject.getDailySale(amountOfMilk, goatMilkPrice, goatDailySale);

                    //get goat daily total costs
                    goatTotalDailyCost = goatObject.animalDailyCost(amountOfWater, waterPrice, dailyCost, goatTotalDailyCost);

                    goatTotalTax = goatObject.getAnimalDailyTax(weight, tax, goatTotalTax);

                    goatTotalMilk = goatTotalMilk + amountOfMilk; //get total milk for comparison later

                    objProfit.profit = goatDailySale - goatTotalDailyCost - goatTotalTax;
                    Profitability.list.Add(objProfit);

                }


                if (category.Equals("Sheep"))
                {
                    // Get data of sheep

                    Sheep sheepObject = (Sheep)element.Value;
                    double amountOfWater = sheepObject.amountOfWater;
                    double dailyCost = sheepObject.dailyCost;
                    double amountOfWool = sheepObject.amountOfWool;
                    double weight = sheepObject.weight;
                    sheepAge = sheepAge + sheepObject.age;
                    string color = sheepObject.color;
                    Profitability objProfit = new Profitability();
                    objProfit.id = sheepObject.id;

                    LiveStock.ages.Add(sheepObject.age);
                    getColor(color);
                    animals++;
                    countAnimals++;
                    counterForSheepAverage++;

                    //get sheep daily total cost
                    sheepTotalDailyCost = sheepObject.animalDailyCost(amountOfWater, waterPrice, dailyCost, sheepTotalDailyCost);
                    sheepTotalTax = sheepObject.getAnimalDailyTax(weight, tax, sheepTotalTax);


                    sheepDailySale = sheepObject.getDailySale(amountOfWool, sheepWoolPrice, sheepDailySale);

                    objProfit.profit = sheepDailySale - sheepTotalDailyCost - sheepTotalTax;
                    Profitability.list.Add(objProfit);

                }


                if (category.Equals("Dog"))
                {

                    Dog dogObject = (Dog)element.Value;
                    double amountOfWater = dogObject.amountOfWater;
                    double dailyCost = dogObject.dailyCost;
                    double weight = dogObject.weight;
                    string color = dogObject.color;
                    LiveStock.ages.Add(dogObject.age);
                    getColor(color);
                    animals++;

                    dogTotalDailyCost = dogObject.animalDailyCost(amountOfWater, waterPrice, dailyCost, dogTotalDailyCost);

                }


            }



            //Perform total Calculation


            double totalMilkAmountCowAndGoat = goatTotalMilk + cowTotalMilk;
            double totalTaxPerMonth = 30 * (jersyTotalTax + cowTotalTax + goatTotalTax + sheepTotalTax);


            //Total Profitablity 

            double totalProfitCow = getTotalProfit(cowDailySale, cowTotalDailyCost, cowTotalTax);
            double totalProfitGoat = getTotalProfit(goatDailySale, goatTotalDailyCost, goatTotalTax);
            double totalProfitSheep = getTotalProfit(sheepDailySale, sheepTotalDailyCost, sheepTotalTax);

            totalProfitJersyCow = getTotalProfit(jersyCowDailySale, jersyCowDailyCost, jersyTotalTax);

            double grandTotalProfit = (totalProfitCow + totalProfitJersyCow + totalProfitGoat + totalProfitSheep) - dogTotalDailyCost;


            //get average ages minus the dog

            double totalAge = cowAge + sheepAge + goatAge;
            double averageAnimalAge = totalAge / countAnimals;


            //average profit
            int averageProfitCowAndGoat = (Convert.ToInt32(totalProfitCow + totalProfitGoat)) / counterForAvereageProfit;
            int averageProfitSheep = Convert.ToInt32(totalProfitSheep / counterForSheepAverage);

            //Console.WriteLine(averageProfitCowAndGoat);
            //Console.WriteLine(averageProfitSheep);

            double allAnimalsTotalDailyCost = goatTotalDailyCost + cowTotalDailyCost + dogTotalDailyCost + sheepTotalDailyCost;
            var gcd = GCD(Convert.ToInt32(dogTotalDailyCost), Convert.ToInt32(allAnimalsTotalDailyCost));


            var gcdRedAnimal = GCD(Convert.ToInt32(countRed), Convert.ToInt32(animals));


         //   double total = totalGoat + totalCow + totalSheep + dogTotalDailyCost;

            LiveStock.animals = animals;

            //Display the result
            totalProfitTextBox.Text = grandTotalProfit.ToString();
            totalTaxPerMonthTextBox.Text = totalTaxPerMonth.ToString();
            totalMilkAmountTextBox.Text = totalMilkAmountCowAndGoat.ToString();
            averageAgeTextBox.Text = averageAnimalAge.ToString();
            averageProfitCowGoatSheepTextBox.Text = averageProfitCowAndGoat.ToString() + " VS " + averageProfitSheep.ToString();
            ratioDogCostTextBox.Text = string.Format("{0}:{1}", (dogTotalDailyCost) / gcd, allAnimalsTotalDailyCost / gcd);
            userInputThresholdTextBox.Text = string.Format("{0}:{1}", (countRed) / gcdRedAnimal, animals / gcdRedAnimal);
            jersyCowTotalTaxTextBox.Text = jersyTotalTax.ToString();
            jersyCowTotalProfitText.Text = totalProfitJersyCow.ToString();

            
        }

        //public static displayResult()
        //{
            
        

        
        //}
           

        // This function is to calculate ratio greatest common denominatr
        static int GCD(int a, int b)
        {
            return (b == 0 ? Math.Abs(a) : GCD(b, a % b));
        }

        //get total profit method
        double getTotalProfit(double animalDailySale, double animalTotalDailyCost, double animalTax)
        {
            return animalDailySale - (animalTotalDailyCost + animalTax);

        }

        //Search animal by id
        private void search(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(searchInputTextBox.Text);
            searchInputTextBox.Text = "";
            int count = 0;

            //Open haahstable and get the animal in window form

            foreach (DictionaryEntry element in hashTable)
            {
                if (id == Convert.ToInt32(element.Key))
                {
                    LiveStock liveStock = (LiveStock)element.Value;
                    string category = liveStock.category;

                    if (category.Equals("Cow"))
                    {

                        //Display detail of cow in form popup

                        Cow cowObject = (Cow)element.Value;
                        Cow.listOne.Add(cowObject);
                        CowCategory cowInstance = new CowCategory();
                        cowInstance.Show();
                        count = 1;
                        break;

                    }
                    else if (category.Equals("Sheep"))
                    {
                        //Display details of sheep


                        Sheep sheepObject = (Sheep)element.Value;
                        Sheep.listThree.Add(sheepObject);
                        SheepCategory sheepInstance = new SheepCategory();
                        sheepInstance.Show();
                        count = 1;
                        break;

                    }
                    else if (category.Equals("Goat"))
                    {
                        //Display details of Goat

                        Goat goatObject = (Goat)element.Value;
                        Goat.listTwo.Add(goatObject);
                        GoatCategory goatInstance = new GoatCategory();
                        goatInstance.Show();
                        count = 1;
                        break;
                    }
                    else if (category.Equals("Dog"))
                    {
                        //Display details of Dog

                        Dog dogObject = (Dog)element.Value;
                        Dog.listFour.Add(dogObject);
                        DogCategory dogInstance = new DogCategory();
                        dogInstance.Show();
                        count = 1;
                        break;
                    }

                }

            }
            if (count == 0)
            {
                //If id don't match

                MessageBox.Show("Invalid ID");
                searchInputTextBox.Text = "";
            }


        }

        //Function to calculate ratio when age is greater than thresold

        private void threshold(object sender, EventArgs e)
        {
            int count = LiveStock.ages.Count();
            int value = Convert.ToInt32(t11.Text);
            int counter = 0;
            for (int i = 0; i < count; i++)
            {
                if (value < LiveStock.ages[i])
                {
                    counter++;
                }
            }

            var gcd = GCD(Convert.ToInt32(counter), Convert.ToInt32(count));
            userInputForThesholdTextBox.Text = string.Format("{0}:{1}", (counter) / gcd, count / gcd);

        }

        //Apply bubble sort for sorting
        public static void BubbleSort(double[] input)
        {
            var itemMoved = false;
            do
            {
                itemMoved = false;
                for (int i = 0; i < input.Count() - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        var lowerValue = input[i + 1];
                        input[i + 1] = input[i];
                        input[i] = lowerValue;
                        itemMoved = true;
                    }
                }
            } while (itemMoved);


            // file out put destination, when generating please assign a new name. It will not replace existing file
            string filePath = @"C:\Users\OEM\OneDrive\Desktop\fileNewCow4.txt";
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);


                for (int i = 0; i < input.Count(); i++)
                {
                  //  Console.WriteLine(i);
                    for (int j = 0; j < input.Count(); j++)
                    {
                        if (input[i] == Profitability.list[j].profit)
                        {
                          //  Console.WriteLine(input[i]);
                            sw.Write("Id: " + Profitability.list[j].id);

                          //  Console.WriteLine(Profitability.list[j].id);
                            sw.WriteLine("    Profibility: " + input[i]);

                           // Console.WriteLine(input[i]);

                        }
                    }

                }
                sw.Close();
              //  file.Close();
                MessageBox.Show("Succesfully File Generated");

            }
            catch (Exception e)
            {
                MessageBox.Show("Wrong File Path");

            }

        }

        //Generate file 
        private void generate(object sender, EventArgs e)
        {
            int count = Profitability.list.Count();
            double[] profit = new double[count];
            double[] distinctProfit = new double[count];

            List<Profitability> distinct = Profitability.list.Distinct().ToList();

            for (int i = 0; i < count; i++)
            {
                profit[i] = distinct[i].profit;
            }
            distinctProfit = profit.Distinct().ToArray();
            
            //reads the array fine
            //foreach (var item in distinctProfit)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            BubbleSort(distinctProfit);

        }

        private void totalProfitTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
