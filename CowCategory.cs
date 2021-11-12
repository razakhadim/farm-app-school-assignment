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
    public partial class CowCategory : Form
    {
        public CowCategory()
        {
            InitializeComponent();
            int count = Cow.listOne.Count();
            count = count - 1;

            t1.Text = Cow.listOne[count].amountOfWater.ToString();
            t2.Text = Cow.listOne[count].dailyCost.ToString();
            t3.Text = Cow.listOne[count].weight.ToString();
            t4.Text = Cow.listOne[count].age.ToString();
            t5.Text = Cow.listOne[count].color.ToString();
            t6.Text = Cow.listOne[count].amountOfMilk.ToString();
            t7.Text = Cow.listOne[count].isJersy.ToString();

        }

        private void Back_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
