using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer_byyt
{
    public partial class Form1 : Form
    {

        int i;
        int a;
        int c_on;
        int c_off;
        
        //int on_seconds;
        //int off_seconds;
        private int totalSeconds_on;
        private int totalSeconds_off;

        public Form1()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//for迴圈放在這裡，沒放不能動
        {
            
            for(c_on = 0; c_on <= 5; c_on++)
            {
               
                
                for (i = 60; i > 0; i--)
                { 
                 this.on_times.Items.Add(i.ToString());      //this用法:把当前的对象作为参数传给另一个方法
                 //int.Parse("on_sec.Text") = this.on_sec.Text.Add(i.ToString());
                }
                this.on_times.SelectedIndex = 20;//一開始顯示的秒數位置
                i = 0;
            }
              
            /////////////////////////////////
           
            for(c_off = 0; c_off <=5; c_off++)
            {
                for (a = 60; a > 0; a--)
                {
                    this.off_times.Items.Add(a.ToString());
                    //this.off_sec.Text.Add(a.ToString());
                }
                this.off_times.SelectedIndex = 20;//一開始顯示的秒數位置
                a = 0;
            }
               
            this.Button_stop.Enabled = false;
        }

        private void Button_on_start_Click(object sender, EventArgs e)
        {
            this.Button_on_start.Enabled = false;
            this.Button_stop.Enabled = true;

            int on_seconds = int.Parse(this.on_times.SelectedItem.ToString()); //Parse(強制轉型)
            int off_seconds = int.Parse(this.off_times.SelectedItem.ToString()); //Parse(強制轉型)

            totalSeconds_on = on_seconds;
            //totalSeconds_off = off_seconds;

            this.timer_ON.Enabled = true;
            this.timer_OFF.Enabled = false;
        }
        private void Button_off_start_Click(object sender, EventArgs e)
        {
            this.Button_off_start.Enabled = false;
            this.Button_stop.Enabled = true;

            int on_seconds = int.Parse(this.on_times.SelectedItem.ToString()); //Parse(強制轉型)
            int off_seconds = int.Parse(this.off_times.SelectedItem.ToString()); //Parse(強制轉型)

            //totalSeconds_on = on_seconds;
            totalSeconds_off = off_seconds;

            this.timer_ON.Enabled = false;
            this.timer_OFF.Enabled = true;
        }

        private void Button_stop_Click(object sender, EventArgs e)
        {
            this.Button_stop.Enabled = false;
            this.Button_on_start.Enabled = true;
            this.Button_off_start.Enabled = true;
            totalSeconds_on = 0;
            totalSeconds_off = 0;
            this.timer_ON.Enabled = false;
            this.timer_OFF.Enabled = false;
        }

        private void timer_ON_Tick(object sender, EventArgs e)//只能放顯示時間或控制停、開始
        {
                if (totalSeconds_on > 0)
                {
                    totalSeconds_on--;
                    int on_seconds = totalSeconds_on;
                    this.on_sec.Text = on_seconds.ToString();//顯示計時
                    //this.on_sec_label.Text = on_seconds.ToString();//顯示計時
                }
                else
                {
                    this.timer_ON.Stop();
                    //MessageBox.Show("time's up!!");
                }
            //}
        }

        private void timer_OFF_Tick(object sender, EventArgs e)//只能放顯示時間或控制停、開始
        {
            
                if (totalSeconds_off > 0)
                {
                    totalSeconds_off--;
                    int off_seconds = totalSeconds_off;
                    this.off_sec.Text = off_seconds.ToString();//顯示計時
                    //this.off_sec_label.Text = off_seconds.ToString();//顯示計時
                }
                else
                {
                    this.timer_OFF.Stop();
                    //MessageBox.Show("time's up!!");
                }
            //}
        }

        private void on_sec_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void off_sec_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cycle_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int c_on = Int32.Parse(cycle_textBox.Text);
            }
            catch
            {
                this.cycle_textBox.Text = cycle_textBox.ToString();
            }

            try
            {
                int c_off = Int32.Parse(cycle_textBox.Text);
            }
            catch
            {
                this.cycle_textBox.Text = cycle_textBox.ToString();
            }
        }
    }
}
