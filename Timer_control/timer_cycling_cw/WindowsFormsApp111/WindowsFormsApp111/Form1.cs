using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp111
{    
    public partial class Form1 : Form
    {
        Boolean on_off_status = false;  //True:on, False:off
        int count_down_time = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count_down_time = Convert.ToInt32(set_on_time.Text);
            on_off_status = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count_down_time = count_down_time - 1;
            if (on_off_status == false)
            {
                on_time.Text = "0";
                off_time.Text = Convert.ToString(count_down_time);
            }
            else
            {
                on_time.Text = Convert.ToString(count_down_time);
                off_time.Text = "0";
            }
            if (count_down_time == 0)
            {
                if (on_off_status == false)
                {
                    count_down_time = Convert.ToInt32(set_on_time.Text);
                    on_off_status = true;
                    
                }
                else
                {
                    on_off_status = false;
                    count_down_time = Convert.ToInt32(set_off_time.Text);
                    running_cycle.Text = Convert.ToString(Convert.ToInt32(running_cycle.Text) + 1);
                    if (Convert.ToInt32(running_cycle.Text) == Convert.ToInt32(set_cycle.Text))
                    {
                        timer1.Stop();
                        MessageBox.Show("Completed");
                    }

                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
