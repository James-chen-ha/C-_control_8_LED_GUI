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
        Boolean on_off_status = false;  //True:on_time在跑, False:換off_time跑 //利用布林設定一開始的狀態
        int count_down_time = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void start_cycle_Click(object sender, EventArgs e)
        {
            start_cycle.Enabled = false;
            button_STOP.Enabled = true;
            count_down_time = Convert.ToInt32(set_on_time.Text);
            on_off_status = true;//為什麼要true呢?因為先給on_time跑完才給off_time跑
            timer_cycle.Start();
        }

        private void timer_cycle_Tick(object sender, EventArgs e)
        {
            count_down_time = count_down_time - 1;
            if (on_off_status == false)//off_time在跑
            {
                on_time.Text = "0";//on_time時間歸0
                off_time.Text = Convert.ToString(count_down_time);
            }
            else//on_time在跑
            {
                on_time.Text = Convert.ToString(count_down_time);
                off_time.Text = "0";//off_time時間歸0
            }
            ////
            if (count_down_time == 0)//如果倒數時間為0時
            {
                if (on_off_status == true)//檢查狀態:先讓on_time跑
                {
                    count_down_time = Convert.ToInt32(set_off_time.Text);//set_off_time可以輸入任意整數
                    on_off_status = false;//因為on_time = 0,所以換off_time跑
                    
                }
                else//on_off_status = false(因為這裡是off_time跑完且 = 0秒了!(count_down_time == 0)
                {
                    on_off_status = true;//因為上面是off_time = 0所以換on_time跑
                    running_cycle.Text = Convert.ToString(Convert.ToInt32(running_cycle.Text) + 1);//off_time跑完cycle就要+1了//running cycle +1//check cycle
                    count_down_time = Convert.ToInt32(set_on_time.Text);//顯示on_time的時間
                    
                    if (Convert.ToInt32(running_cycle.Text) == Convert.ToInt32(set_cycle.Text))//如果running_cycle = set_cycle的話就停止
                    {
                        timer_cycle.Stop();
                        MessageBox.Show("Completed");
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_STOP_Click(object sender, EventArgs e)
        {
            start_cycle.Enabled = true;
            button_STOP.Enabled = false;
            if(button_STOP.Enabled == false)
            {
                timer_cycle.Stop();
            }
        }
    }
}
