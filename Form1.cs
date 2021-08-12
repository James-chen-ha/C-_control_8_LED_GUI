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
using System.Management;

namespace Csharp_Arduino_Control_8_LEDs
{
    public partial class Form1 : Form
    {
        Boolean on_off_status = false;  //True:on_time在跑, False:換off_time跑 //利用布林設定一開始的狀態
        int count_down_time = 0;
        
        byte[] sendByteArray = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A };//給定一個sendByteArray陣列[0,0,0,0,0,0,0,0,換行] //初始都是暗的，0x0A代表換行
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prbTimeBar.Value = 0;
            comboBox_baudRate.Text = "115200";
            checkBoxControl_Initialization(true);  //checkBox一開始是勾的
            AnimatedLED_Initialization();
        }
        private void AnimatedLED_Initialization()
        {
            animatedLED1.BackColor = Color.Gray;
            animatedLED2.BackColor = Color.Gray;
            animatedLED3.BackColor = Color.Gray;
            animatedLED4.BackColor = Color.Gray;
            animatedLED5.BackColor = Color.Gray;
            animatedLED6.BackColor = Color.Gray;
            animatedLED7.BackColor = Color.Gray;
            animatedLED8.BackColor = Color.Gray;
        }

        private void start_cycle_Click(object sender, EventArgs e)
        {
            start_cycle.Enabled = false;
            button_STOP.Enabled = true;
            count_down_time = Convert.ToInt32(set_on_time.Text);
            on_off_status = true;//為什麼要true呢?因為先給on_time跑完才給off_time跑
            prbTimeBar.Maximum = Convert.ToInt32(set_cycle.Text);//BAR滿了時候相當於set_cycle的設定值
            timer_cycle.Start();
            try
            {
                serialPort1.PortName = comboBox_comPort.Text;//assign進來start，才會抓到combo_box所選擇的COM_PORT
                serialPort1.BaudRate = Convert.ToInt32(comboBox_baudRate.Text);
                serialPort1.Open();//start時就打開
                //serialPort1.Open();
                if (checkBox1.Checked)
                {
                    sendByteArray[0] = 0x01;//陣列中第0個元素為:亮 (0 ~ 7 LED)
                }
                else//(checkBox1.unChecked)
                {
                    sendByteArray[0] = 0x00;
                }
                if (checkBox2.Checked)
                {
                    sendByteArray[1] = 0x01;//陣列中第1個元素為:亮
                }
                else
                {
                    sendByteArray[1] = 0x00;
                }
                if (checkBox3.Checked)
                {
                    sendByteArray[2] = 0x01;//陣列中第2個元素為:亮
                }
                else
                {
                    sendByteArray[2] = 0x00;
                }
                if (checkBox4.Checked)
                {
                    sendByteArray[3] = 0x01;//陣列中第3個元素為:亮
                }
                else
                {
                    sendByteArray[3] = 0x00;
                }
                if (checkBox5.Checked)
                {
                    sendByteArray[4] = 0x01;//陣列中第4個元素為:亮
                }
                else
                {
                    sendByteArray[4] = 0x00;
                }
                if (checkBox6.Checked)
                {
                    sendByteArray[5] = 0x01;//陣列中第5個元素為:亮
                }
                else
                {
                    sendByteArray[5] = 0x00;
                }
                if (checkBox7.Checked)
                {
                    sendByteArray[6] = 0x01;//陣列中第6個元素為:亮
                }
                else
                {
                    sendByteArray[6] = 0x00;
                }
                if (checkBox8.Checked)
                {
                    sendByteArray[7] = 0x01;//陣列中第7個元素為:亮
                }
                else
                {
                    sendByteArray[7] = 0x00;
                }
                start_cycle.Enabled = false;
                button_STOP.Enabled = true;
                //prbTimeBar.Value = 100;
                checkBoxControl_Initialization(true);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //
        private void timer_cycle_Tick(object sender, EventArgs e)
        {
            count_down_time = count_down_time - 1;
            if (on_off_status == false)
            {
                serialPort1.Write(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A }, 0, 9);//送一次資料
                if (checkBox1.Checked == true && on_off_status == false)
                {
                    animatedLED1.BackColor = Color.Gray;
                    
                }
                if (checkBox2.Checked == true && on_off_status == false)
                {
                    animatedLED2.BackColor = Color.Gray;
                    
                }
                if (checkBox3.Checked == true && on_off_status == false)
                {
                    animatedLED3.BackColor = Color.Gray;
                   
                }
                if (checkBox4.Checked == true && on_off_status == false)
                {
                    animatedLED4.BackColor = Color.Gray;
                    
                }
                if (checkBox5.Checked == true && on_off_status == false)
                {
                    animatedLED5.BackColor = Color.Gray;
                   
                }
                if (checkBox6.Checked == true && on_off_status == false)
                {
                    animatedLED6.BackColor = Color.Gray;
                    
                }
                if (checkBox7.Checked == true && on_off_status == false)
                {
                    animatedLED7.BackColor = Color.Gray;
                    
                }
                if (checkBox8.Checked == true && on_off_status == false)
                {
                    animatedLED8.BackColor = Color.Gray;
                    
                }
                on_time.Text = "0";//on_time時間歸0
                off_time.Text = Convert.ToString(count_down_time);
            }
            else//on_time在跑//on_off_status = true
            {
                serialPort1.Write(sendByteArray, 0, 9);//上面已經寫好了
                //LED燈開始亮
                if (checkBox1.Checked == true /*&& on_off_status == true*/)
                {
                    animatedLED1.BackColor = Color.Green;
                }
                
                if (checkBox2.Checked == true && on_off_status == true)
                {
                    animatedLED2.BackColor = Color.Green;
                  
                }
                if (checkBox3.Checked == true && on_off_status == true)
                {
                    animatedLED3.BackColor = Color.Green;
                    
                }
                
                if (checkBox4.Checked == true && on_off_status == true)
                {
                    animatedLED4.BackColor = Color.Green;
                    
                }
                if (checkBox5.Checked == true && on_off_status == true)
                {
                    animatedLED5.BackColor = Color.Green;
                   
                }
                if (checkBox6.Checked == true && on_off_status == true)
                {
                    animatedLED6.BackColor = Color.Green;
                    
                }
                if (checkBox7.Checked == true && on_off_status == true)
                {
                    animatedLED7.BackColor = Color.Green;
                    
                }
                if (checkBox8.Checked == true && on_off_status == true)
                {
                    animatedLED8.BackColor = Color.Green;
                    
                }
                
                on_time.Text = Convert.ToString(count_down_time);
                off_time.Text = "0";//off_time時間歸0
            }
            
            if (count_down_time == 0)//如果倒數時間為0時
            {
                if (on_off_status == true)//檢查狀態:先讓on_time跑
                {
                    count_down_time = Convert.ToInt32(set_off_time.Text);//set_off_time可以輸入任意整數
                    on_off_status = false;//因為on_time = 0,所以換off_time跑
                }
                else//on_off_status = false(因為這裡是off_time跑完且 = 0秒了!(上面的 if(count_down_time == 0))
                {
                    on_off_status = true;//因為上面是off_time = 0所以換on_time跑
                    running_cycle.Text = Convert.ToString(Convert.ToInt32(running_cycle.Text) + 1);//off_time跑完cycle就要+1了//running cycle +1//check cycle
                    //BAR
                    prbTimeBar.Increment(1);
                    lblInfo.Text = String.Format($"{Convert.ToDouble(running_cycle.Text)/Convert.ToDouble(set_cycle.Text) * 100}% already");//串連進度列以文字顯示
                    count_down_time = Convert.ToInt32(set_on_time.Text);//顯示on_time的時間
                    //BAR

                    if (Convert.ToInt32(running_cycle.Text) == Convert.ToInt32(set_cycle.Text))//如果running_cycle = set_cycle的話就停止
                    {
                        //lblInfo.Text = String.Format($"{prbTimeBar.Value}% 已經完成");//串連進度列以文字顯示
                        timer_cycle.Stop();
                        MessageBox.Show("Completed!!");
                        serialPort1.Close();
                    }
                }
            }
        }
        //
        private void button_STOP_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            start_cycle.Enabled = true;
            button_STOP.Enabled = false;
            
            if (button_STOP.Enabled == false && (set_cycle.Text == running_cycle.Text))
            {
                timer_cycle.Stop();
                running_cycle.Text = ("0");
            }
            try
                {
                    //serialPort1.Close();
                    start_cycle.Enabled = true;
                    button_STOP.Enabled = false;
                    //power_off_control.Enabled = true;
                    prbTimeBar.Value = 0;
                    checkBoxControl_Initialization(true);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
           
        }

        private void comboBox_comPort_DropDown(object sender, EventArgs e)
        {
            string[] portLists = SerialPort.GetPortNames();
            comboBox_comPort.Items.Clear();
            comboBox_comPort.Items.AddRange(portLists);
            var searcher = new ManagementObjectSearcher("SELECT DeviceID,Caption FROM WIN32_SerialPort");
            foreach (ManagementObject port in searcher.Get())
            {
                string name = port.GetPropertyValue("DeviceID").ToString();//DeviceID是之後要連serial port時可以識別的字串
            }
        }

        private void groupBox_LED_control_Enter(object sender, EventArgs e)
        {
            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            //if (checkBox1.Checked == true)//第一個LED//只留這個
            //{
                //animatedLED1.BackColor = Color.Green;//跟這個 ，只留這個
                //serialPort1.Write("1");//==============就會亮
                /*if(animatedLED1.BackColor == Color.Green /*&& on_off_status == true)*/
            //{
            //serialPort1.Write("1");
            //}
            //animatedLED1.BackColor = Color.Green;
            //serialPort1.Write("1");


            /*else if (checkBox1.Checked == false)//只留這個
            {
                animatedLED1.BackColor = Color.Gray;//跟這個
                serialPort1.Write("0");//==============就會暗
                /*if (animatedLED1.BackColor == Color.Gray /*&& on_off_status == false)
                {
                    serialPort1.Write("0");
                }*/
            //}
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox2.Checked == true)//第二個LED
            {
                if (animatedLED2.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("2");
                }
            }
            else if (checkBox2.Checked == false)
            {
                if (animatedLED2.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox3.Checked == true)//第三個LED
            {
                if (animatedLED3.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("3");
                }
            }
            else if (checkBox3.Checked == false)
            {
                if (animatedLED3.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox4.Checked == true)//第四個LED
            {
                if (animatedLED4.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("4");
                }
            }
            else if (checkBox4.Checked == false)
            {
                if (animatedLED4.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox5.Checked == true)//第五個LED
            {
                if (animatedLED5.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("5");
                }
            }
            else if (checkBox5.Checked == false)
            {
                if (animatedLED5.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox6.Checked == true)//第六個LED
            {
                if (animatedLED6.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("6");
                }
            }
            else if (checkBox6.Checked == false)
            {
                if (animatedLED6.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox7.Checked == true)//第七個LED
            {
                if (animatedLED7.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("7");
                }

            }
            else if (checkBox7.Checked == false)
            {
                if (animatedLED7.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }
            }*/
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox8.Checked == true)//第八個LED
            {
                if (animatedLED8.BackColor == Color.Green && on_off_status == true)
                {
                    serialPort1.Write("8");
                }

            }
            else if (checkBox8.Checked == false)
            {
                if (animatedLED8.BackColor == Color.Gray && on_off_status == false)
                {
                    serialPort1.Write("0");
                }

            }*/
        }
        
        private void checkBoxControl_Initialization(bool state)
        {
            //button_1turnON.Enabled = state;
            //button_1turnOFF.Enabled = state;
            checkBox1.Enabled = state;
            //button_2turnON.Enabled = state;
            //button_2turnOFF.Enabled = state;
            checkBox2.Enabled = state;
            //button_3turnON.Enabled = state;
            //button_3turnOFF.Enabled = state;
            checkBox3.Enabled = state;
            //button_4turnON.Enabled = state;
            //button_4turnOFF.Enabled = state;
            checkBox4.Enabled = state;
            //button_5turnON.Enabled = state;
            //button_5turnOFF.Enabled = state;
            checkBox5.Enabled = state;
            //button_6turnON.Enabled = state;
            //button_6turnOFF.Enabled = state;
            checkBox6.Enabled = state;
            //button_7turnON.Enabled = state;
            //button_7turnOFF.Enabled = state;
            checkBox7.Enabled = state;
            //button_8turnON.Enabled = state;
            //button_8turnOFF.Enabled = state;
            checkBox8.Enabled = state;
        }
        private void groupBox_COM_port_setting_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox_comPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*private void COM_PORT_ON_Click(object sender, EventArgs e)
        {
            PORT_ON.Enabled = false;
            PORT_OFF.Enabled = true;
            if(PORT_ON.Enabled == false)
            {
                serialPort1.Open();
            }
        }
        private void PORT_OFF_Click(object sender, EventArgs e)
        {
            PORT_ON.Enabled = true;
            PORT_OFF.Enabled = false;
            if (PORT_OFF.Enabled == false)
            {
                serialPort1.Close();
            }
        }*/
        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void set_on_time_TextChanged(object sender, EventArgs e)
        {

        }

        private void set_on_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0'))//这是允许输入0-9数字//強制讓set_on_time.Text=0
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter a positive integer ! ");
                }
                
                if(set_on_time.Text == "0")
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter a positive integer ! ");
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void set_off_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;//lock
                    MessageBox.Show("Please enter a positive integer ! ");
                }
            }
        }

        private void set_cycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter a positive integer ! ");
                }
            }
        }

        private void on_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0')
            {
                e.Handled = true;
                MessageBox.Show("No need to enter any numbers ! ");
            }
        }

        private void off_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0')
            {
                e.Handled = true;
                MessageBox.Show("No need to enter any numbers ! ");
            }
        }

        private void running_cycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' || e.KeyChar =='\b')
            {
                e.Handled = true;
                MessageBox.Show("No need to enter any numbers ! ");
            }
        }

        private void prbTimeBar_Click(object sender, EventArgs e)
        {

        }
    }

    
}
