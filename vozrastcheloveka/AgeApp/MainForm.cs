using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AgeCheak age = new AgeCheak();
            try
            {
                label2.Text = "";
                TimeSpan res = age.Cheak(dateTimePicker1.Value);
                int years = res.Days / 365;
                int mounth = (res.Days - (years * 365))/28;
                int days = res.Days - (years * 365) - (mounth * 28);
                label2.Text += "Ваш возраст ";
                if (years > 0)
                {
                    label2.Text += Convert.ToString(years);
                    if (years > 4)
                        label2.Text += " лет ";
                    else if (years > 1)
                        label2.Text += " года ";
                    else
                        label2.Text += " год ";
                }
                if (mounth > 0)
                {
                    label2.Text += Convert.ToString(mounth);
                    if (mounth > 4)
                        label2.Text += " месяцев ";
                    else if (mounth > 1)
                        label2.Text += " месяца ";
                    else
                        label2.Text += " месяц ";
                }
                if (days > 0)
                {
                    label2.Text += Convert.ToString(days);
                    if (days < 10)
                    {
                        if (days > 4)
                            label2.Text += " дней ";
                        else if (days > 1)
                            label2.Text += " дня ";
                        else
                            label2.Text += " день ";
                    }
                    else
                    {
                        if (days % 10 > 4)
                            label2.Text += " дней ";
                        else if (days % 10 > 1)
                            label2.Text += " дня ";
                        else
                            label2.Text += " день ";
                    }
                }

                
            }
            catch(ArgumentException t)
            {
                label2.Text = "";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

}
