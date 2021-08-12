using System;
using System.Windows.Forms;

namespace Csharp_Arduino_Control_8_LEDs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_COM_port_setting = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.off_time = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.running_cycle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.on_time = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.set_cycle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.set_off_time = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.set_on_time = new System.Windows.Forms.TextBox();
            this.comboBox_baudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_comPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_STOP = new System.Windows.Forms.Button();
            this.start_cycle = new System.Windows.Forms.Button();
            this.groupBox_LED_control = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.animatedLED8 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED7 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED6 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED5 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED4 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED3 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED2 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.animatedLED1 = new Csharp_Arduino_Control_8_LEDs.AnimatedLED();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer_cycle = new System.Windows.Forms.Timer(this.components);
            this.prbTimeBar = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox_COM_port_setting.SuspendLayout();
            this.groupBox_LED_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_COM_port_setting
            // 
            this.groupBox_COM_port_setting.Controls.Add(this.label3);
            this.groupBox_COM_port_setting.Controls.Add(this.off_time);
            this.groupBox_COM_port_setting.Controls.Add(this.label13);
            this.groupBox_COM_port_setting.Controls.Add(this.running_cycle);
            this.groupBox_COM_port_setting.Controls.Add(this.label14);
            this.groupBox_COM_port_setting.Controls.Add(this.on_time);
            this.groupBox_COM_port_setting.Controls.Add(this.label15);
            this.groupBox_COM_port_setting.Controls.Add(this.set_cycle);
            this.groupBox_COM_port_setting.Controls.Add(this.label16);
            this.groupBox_COM_port_setting.Controls.Add(this.set_off_time);
            this.groupBox_COM_port_setting.Controls.Add(this.label17);
            this.groupBox_COM_port_setting.Controls.Add(this.set_on_time);
            this.groupBox_COM_port_setting.Controls.Add(this.comboBox_baudRate);
            this.groupBox_COM_port_setting.Controls.Add(this.label2);
            this.groupBox_COM_port_setting.Controls.Add(this.comboBox_comPort);
            this.groupBox_COM_port_setting.Controls.Add(this.label1);
            this.groupBox_COM_port_setting.Location = new System.Drawing.Point(8, 37);
            this.groupBox_COM_port_setting.Name = "groupBox_COM_port_setting";
            this.groupBox_COM_port_setting.Size = new System.Drawing.Size(222, 362);
            this.groupBox_COM_port_setting.TabIndex = 0;
            this.groupBox_COM_port_setting.TabStop = false;
            this.groupBox_COM_port_setting.Text = "COM PORT SETTINGS";
            this.groupBox_COM_port_setting.Enter += new System.EventHandler(this.groupBox_COM_port_setting_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Off Time(s) : ";
            // 
            // off_time
            // 
            this.off_time.Location = new System.Drawing.Point(111, 284);
            this.off_time.Name = "off_time";
            this.off_time.Size = new System.Drawing.Size(100, 23);
            this.off_time.TabIndex = 23;
            this.off_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.off_time_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 326);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Running cycle :";
            // 
            // running_cycle
            // 
            this.running_cycle.Location = new System.Drawing.Point(111, 323);
            this.running_cycle.Name = "running_cycle";
            this.running_cycle.Size = new System.Drawing.Size(100, 23);
            this.running_cycle.TabIndex = 21;
            this.running_cycle.Text = "0";
            this.running_cycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.running_cycle_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "On Time(s) :";
            // 
            // on_time
            // 
            this.on_time.Location = new System.Drawing.Point(111, 246);
            this.on_time.Name = "on_time";
            this.on_time.Size = new System.Drawing.Size(100, 23);
            this.on_time.TabIndex = 19;
            this.on_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.on_time_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "Set cycle : ";
            // 
            // set_cycle
            // 
            this.set_cycle.Location = new System.Drawing.Point(111, 206);
            this.set_cycle.Name = "set_cycle";
            this.set_cycle.Size = new System.Drawing.Size(100, 23);
            this.set_cycle.TabIndex = 17;
            this.set_cycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.set_cycle_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Set Off Time(s) :";
            // 
            // set_off_time
            // 
            this.set_off_time.Location = new System.Drawing.Point(111, 157);
            this.set_off_time.Name = "set_off_time";
            this.set_off_time.Size = new System.Drawing.Size(100, 23);
            this.set_off_time.TabIndex = 15;
            this.set_off_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.set_off_time_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 15);
            this.label17.TabIndex = 14;
            this.label17.Text = "Set On Time(s) :";
            // 
            // set_on_time
            // 
            this.set_on_time.Location = new System.Drawing.Point(111, 113);
            this.set_on_time.Name = "set_on_time";
            this.set_on_time.Size = new System.Drawing.Size(100, 23);
            this.set_on_time.TabIndex = 13;
            this.set_on_time.TextChanged += new System.EventHandler(this.set_on_time_TextChanged);
            this.set_on_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.set_on_time_KeyPress);
            // 
            // comboBox_baudRate
            // 
            this.comboBox_baudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_baudRate.FormattingEnabled = true;
            this.comboBox_baudRate.Items.AddRange(new object[] {
            "9600",
            "38400",
            "57600",
            "115200"});
            this.comboBox_baudRate.Location = new System.Drawing.Point(102, 70);
            this.comboBox_baudRate.Name = "comboBox_baudRate";
            this.comboBox_baudRate.Size = new System.Drawing.Size(109, 23);
            this.comboBox_baudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "BAUD RATE :";
            // 
            // comboBox_comPort
            // 
            this.comboBox_comPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_comPort.FormattingEnabled = true;
            this.comboBox_comPort.Location = new System.Drawing.Point(102, 31);
            this.comboBox_comPort.Name = "comboBox_comPort";
            this.comboBox_comPort.Size = new System.Drawing.Size(109, 23);
            this.comboBox_comPort.TabIndex = 1;
            this.comboBox_comPort.DropDown += new System.EventHandler(this.comboBox_comPort_DropDown);
            this.comboBox_comPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_comPort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM PORT :";
            // 
            // button_STOP
            // 
            this.button_STOP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_STOP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_STOP.Location = new System.Drawing.Point(120, 405);
            this.button_STOP.Name = "button_STOP";
            this.button_STOP.Size = new System.Drawing.Size(89, 45);
            this.button_STOP.TabIndex = 5;
            this.button_STOP.Text = "STOP";
            this.button_STOP.UseVisualStyleBackColor = false;
            this.button_STOP.Click += new System.EventHandler(this.button_STOP_Click);
            // 
            // start_cycle
            // 
            this.start_cycle.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.start_cycle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_cycle.Location = new System.Drawing.Point(9, 405);
            this.start_cycle.Name = "start_cycle";
            this.start_cycle.Size = new System.Drawing.Size(90, 45);
            this.start_cycle.TabIndex = 4;
            this.start_cycle.Text = "START";
            this.start_cycle.UseVisualStyleBackColor = false;
            this.start_cycle.Click += new System.EventHandler(this.start_cycle_Click);
            // 
            // groupBox_LED_control
            // 
            this.groupBox_LED_control.Controls.Add(this.label11);
            this.groupBox_LED_control.Controls.Add(this.label10);
            this.groupBox_LED_control.Controls.Add(this.label9);
            this.groupBox_LED_control.Controls.Add(this.label8);
            this.groupBox_LED_control.Controls.Add(this.label7);
            this.groupBox_LED_control.Controls.Add(this.label6);
            this.groupBox_LED_control.Controls.Add(this.label5);
            this.groupBox_LED_control.Controls.Add(this.label4);
            this.groupBox_LED_control.Controls.Add(this.checkBox8);
            this.groupBox_LED_control.Controls.Add(this.checkBox7);
            this.groupBox_LED_control.Controls.Add(this.checkBox6);
            this.groupBox_LED_control.Controls.Add(this.checkBox5);
            this.groupBox_LED_control.Controls.Add(this.checkBox4);
            this.groupBox_LED_control.Controls.Add(this.checkBox3);
            this.groupBox_LED_control.Controls.Add(this.checkBox2);
            this.groupBox_LED_control.Controls.Add(this.checkBox1);
            this.groupBox_LED_control.Controls.Add(this.animatedLED8);
            this.groupBox_LED_control.Controls.Add(this.animatedLED7);
            this.groupBox_LED_control.Controls.Add(this.animatedLED6);
            this.groupBox_LED_control.Controls.Add(this.animatedLED5);
            this.groupBox_LED_control.Controls.Add(this.animatedLED4);
            this.groupBox_LED_control.Controls.Add(this.animatedLED3);
            this.groupBox_LED_control.Controls.Add(this.animatedLED2);
            this.groupBox_LED_control.Controls.Add(this.animatedLED1);
            this.groupBox_LED_control.Location = new System.Drawing.Point(236, 37);
            this.groupBox_LED_control.Name = "groupBox_LED_control";
            this.groupBox_LED_control.Size = new System.Drawing.Size(345, 362);
            this.groupBox_LED_control.TabIndex = 2;
            this.groupBox_LED_control.TabStop = false;
            this.groupBox_LED_control.Text = "LED CONTROL";
            this.groupBox_LED_control.Enter += new System.EventHandler(this.groupBox_LED_control_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(115, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "LED2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(192, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "LED3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(272, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "LED4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "LED5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(113, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "LED6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(205, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "LED7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "LED8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "LED1";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(290, 246);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 29;
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(212, 246);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 28;
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(120, 246);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 27;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(32, 246);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 26;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(290, 125);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(210, 125);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 24;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(133, 125);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(43, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // animatedLED8
            // 
            this.animatedLED8.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED8.Location = new System.Drawing.Point(266, 174);
            this.animatedLED8.Name = "animatedLED8";
            this.animatedLED8.Size = new System.Drawing.Size(60, 57);
            this.animatedLED8.TabIndex = 21;
            this.animatedLED8.Text = "animatedLED5";
            this.animatedLED8.UseVisualStyleBackColor = false;
            // 
            // animatedLED7
            // 
            this.animatedLED7.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED7.Location = new System.Drawing.Point(185, 175);
            this.animatedLED7.Name = "animatedLED7";
            this.animatedLED7.Size = new System.Drawing.Size(60, 57);
            this.animatedLED7.TabIndex = 18;
            this.animatedLED7.Text = "animatedLED6";
            this.animatedLED7.UseVisualStyleBackColor = false;
            // 
            // animatedLED6
            // 
            this.animatedLED6.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED6.Location = new System.Drawing.Point(100, 176);
            this.animatedLED6.Name = "animatedLED6";
            this.animatedLED6.Size = new System.Drawing.Size(60, 57);
            this.animatedLED6.TabIndex = 15;
            this.animatedLED6.Text = "animatedLED7";
            this.animatedLED6.UseVisualStyleBackColor = false;
            // 
            // animatedLED5
            // 
            this.animatedLED5.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED5.Location = new System.Drawing.Point(14, 176);
            this.animatedLED5.Name = "animatedLED5";
            this.animatedLED5.Size = new System.Drawing.Size(60, 57);
            this.animatedLED5.TabIndex = 12;
            this.animatedLED5.Text = "animatedLED8";
            this.animatedLED5.UseVisualStyleBackColor = false;
            // 
            // animatedLED4
            // 
            this.animatedLED4.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED4.Location = new System.Drawing.Point(265, 55);
            this.animatedLED4.Name = "animatedLED4";
            this.animatedLED4.Size = new System.Drawing.Size(60, 57);
            this.animatedLED4.TabIndex = 9;
            this.animatedLED4.Text = "animatedLED3";
            this.animatedLED4.UseVisualStyleBackColor = false;
            // 
            // animatedLED3
            // 
            this.animatedLED3.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED3.Location = new System.Drawing.Point(182, 54);
            this.animatedLED3.Name = "animatedLED3";
            this.animatedLED3.Size = new System.Drawing.Size(60, 57);
            this.animatedLED3.TabIndex = 6;
            this.animatedLED3.Text = "animatedLED4";
            this.animatedLED3.UseVisualStyleBackColor = false;
            // 
            // animatedLED2
            // 
            this.animatedLED2.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED2.Location = new System.Drawing.Point(103, 54);
            this.animatedLED2.Name = "animatedLED2";
            this.animatedLED2.Size = new System.Drawing.Size(60, 57);
            this.animatedLED2.TabIndex = 3;
            this.animatedLED2.Text = "animatedLED2";
            this.animatedLED2.UseVisualStyleBackColor = false;
            // 
            // animatedLED1
            // 
            this.animatedLED1.BackColor = System.Drawing.Color.DarkRed;
            this.animatedLED1.Location = new System.Drawing.Point(23, 54);
            this.animatedLED1.Name = "animatedLED1";
            this.animatedLED1.Size = new System.Drawing.Size(60, 57);
            this.animatedLED1.TabIndex = 0;
            this.animatedLED1.Text = "animatedLED1";
            this.animatedLED1.UseVisualStyleBackColor = false;
            // 
            // timer_cycle
            // 
            this.timer_cycle.Tick += new System.EventHandler(this.timer_cycle_Tick);
            // 
            // prbTimeBar
            // 
            this.prbTimeBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.prbTimeBar.Location = new System.Drawing.Point(332, 421);
            this.prbTimeBar.Name = "prbTimeBar";
            this.prbTimeBar.Size = new System.Drawing.Size(184, 23);
            this.prbTimeBar.TabIndex = 15;
            this.prbTimeBar.Click += new System.EventHandler(this.prbTimeBar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(223, 421);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "PROGRESS_BAR :";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(523, 421);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 15);
            this.lblInfo.TabIndex = 41;
            this.lblInfo.Text = "RATE";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(261, 29);
            this.label18.TabIndex = 42;
            this.label18.Text = "Control 8 LED  GUI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(607, 452);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.prbTimeBar);
            this.Controls.Add(this.button_STOP);
            this.Controls.Add(this.groupBox_LED_control);
            this.Controls.Add(this.groupBox_COM_port_setting);
            this.Controls.Add(this.start_cycle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csharp Arduino Control 8 LEDs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_COM_port_setting.ResumeLayout(false);
            this.groupBox_COM_port_setting.PerformLayout();
            this.groupBox_LED_control.ResumeLayout(false);
            this.groupBox_LED_control.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.GroupBox groupBox_COM_port_setting;
        private System.Windows.Forms.Button button_STOP;
        private System.Windows.Forms.Button start_cycle;
        private System.Windows.Forms.ComboBox comboBox_baudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_comPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_LED_control;
        private AnimatedLED animatedLED8;
        private AnimatedLED animatedLED7;
        private AnimatedLED animatedLED6;
        private AnimatedLED animatedLED5;
        private AnimatedLED animatedLED4;
        private AnimatedLED animatedLED3;
        private AnimatedLED animatedLED2;
        private AnimatedLED animatedLED1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer_cycle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar prbTimeBar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox off_time;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox running_cycle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox on_time;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox set_cycle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox set_off_time;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox set_on_time;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label18;
    }
}

