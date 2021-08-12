using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;

namespace times_for_loop_experiment
{
    public partial class Form1 : Form
    {
        int N;
        int F;
        int C;
        int a;
        int timeLeft_1;
        int timeLeft_2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ON_sec.TabIndex = 0;
            OFF_sec.TabIndex = 0;
            //for(C = 1; C <=5; C++)
            //{
            //if(Button_Cycle_Start.Enabled == false)
            timer_ON.Start();

            //}
            //timer_ON.Start(); //代表計時開始，且如果沒有設定stop的話會不斷執行
            timer_OFF.Start();
            Button_Cycle_Start.Enabled = true;
            Button_Stop.Enabled = false;
        }
        private void Button_Cycle_Start_Click(object sender, EventArgs e)
        {
            Button_Cycle_Start.Enabled = false;
            Button_Stop.Enabled = true;

            //do
            //{

            //} while (C>=3);


            //Button_Cycle_Start.Enabled = false;
            //Button_Stop.Enabled = true;
        }

        private void timer_ON_Tick(object sender, EventArgs e)
        {

            if (Button_Cycle_Start.Enabled == false)
            {
                ON_sec.MaxLength = 3;//最大輸入位數

                try
                {
                    N = Convert.ToInt32(ON_sec.Text); //string to int  //N為存取下來的任意輸入的數
                }
                catch
                {
                    ON_sec.Clear();
                }

                try
                {
                    timeLeft_1 = Convert.ToInt32(ON_sec.Text);//轉換成整數(可能發生錯誤的程式碼放在try區域)
                }
                catch
                {
                    ON_sec.Clear();//清空錯誤資料(例外狀況處理)
                }

                //}

                if (timeLeft_1 > 0)
                {
                    ON_sec.Text = timeLeft_1 + "seconds";
                    timeLeft_1 = timeLeft_1 - 1;
                }
                else
                {
                    //for (C = 1; C <= 5; C++)
                    //{
                        try
                        {
                            timeLeft_1 = Convert.ToInt32(ON_sec.Text); //string to int
                        }
                        catch
                        {
                            ON_sec.Text = Convert.ToString(N);
                        }
                        timer_ON.Stop();                   //停止計時
                        timer_OFF.Start();
                    //}
                    //timer_ON.Start();

                }
            }
        }

        private void timer_OFF_Tick(object sender, EventArgs e)
        {
           
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            Button_Cycle_Start.Enabled = true;
            Button_Stop.Enabled = false;

        }

        private void cycle_textBox_TextChanged(object sender, EventArgs e)
        {
            C = Convert.ToInt32(cycle_textBox.Text);
            a = Convert.ToInt32(cycle_textBox.Text);
        }

        private void timer_OFF_Tick_1(object sender, EventArgs e)
        {
            if (Button_Cycle_Start.Enabled == false && timeLeft_1 == 0)   //timeLeft_1=0的話，POWER_ON_TIMES會倒數到0秒後POWER_OFF_TIMES才會開始倒數
            {
                OFF_sec.MaxLength = 3;//最大輸入位數

                try
                {
                    F = Convert.ToInt32(OFF_sec.Text); //string to int
                }
                catch
                {
                    OFF_sec.Clear();
                }
                try
                {
                    timeLeft_2 = Convert.ToInt32(OFF_sec.Text);//可以輸入任意整數
                }
                catch
                {
                    OFF_sec.Clear();
                }
                if (timeLeft_2 > 0)
                {
                    timeLeft_2 = timeLeft_2 - 1;
                    OFF_sec.Text = timeLeft_2 + 1 + "seconds";
                }
                else
                {
                    //倒數時間到執行
                    try
                    {
                        timeLeft_2 = Convert.ToInt32(OFF_sec.Text); //string to int
                    }
                    catch
                    {
                        OFF_sec.Text = Convert.ToString(F);
                    }

                    timer_OFF.Stop();//停止計時           
                }
            }
        }
    }
}