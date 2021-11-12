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
    public partial class DogCategory : Form
    {
        public DogCategory()
        {
            InitializeComponent();
            int count = Dog.listFour.Count();
            t1.Text = Dog.listFour[count - 1].amountOfWater.ToString();
            t2.Text = Dog.listFour[count - 1].dailyCost.ToString();
            t3.Text = Dog.listFour[count - 1].weight.ToString();
            t4.Text = Dog.listFour[count - 1].age.ToString();
            t5.Text = Dog.listFour[count - 1].color.ToString();

        }
    }
}
