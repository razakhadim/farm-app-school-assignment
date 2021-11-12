using Farm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverAllApp
{
    public partial class GoatCategory : Form
    {
        public GoatCategory()
        {
            InitializeComponent();
            int count = Goat.listTwo.Count();
            t1.Text = Goat.listTwo[count - 1].amountOfWater.ToString();
            t2.Text = Goat.listTwo[count - 1].dailyCost.ToString();
            t3.Text = Goat.listTwo[count - 1].weight.ToString();
            t4.Text = Goat.listTwo[count - 1].age.ToString();
            t5.Text = Goat.listTwo[count - 1].color.ToString();
            t6.Text = Goat.listTwo[count - 1].amountOfMilk.ToString();

        }

     
    }
}
