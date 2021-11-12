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
    public partial class SheepCategory : Form
    {
        public SheepCategory()
        {
            InitializeComponent();
            int count = Sheep.listThree.Count();
            t1.Text = Sheep.listThree[count - 1].amountOfWater.ToString();
            t2.Text = Sheep.listThree[count - 1].dailyCost.ToString();
            t3.Text = Sheep.listThree[count - 1].weight.ToString();
            t4.Text = Sheep.listThree[count - 1].age.ToString();
            t5.Text = Sheep.listThree[count - 1].color.ToString();
            t6.Text = Sheep.listThree[count - 1].amountOfWool.ToString();

        }

     
    }
}
