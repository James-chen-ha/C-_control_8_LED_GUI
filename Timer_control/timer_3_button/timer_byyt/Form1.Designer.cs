using System.Collections.Generic;

namespace timer_byyt
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_on_start = new System.Windows.Forms.Button();
            this.on_times = new System.Windows.Forms.ComboBox();
            this.sec = new System.Windows.Forms.Label();
            this.Button_stop = new System.Windows.Forms.Button();
            this.on_sec = new System.Windows.Forms.TextBox();
            this.timer_ON = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.off_times = new System.Windows.Forms.ComboBox();
            this.off_sec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cycle_textBox = new System.Windows.Forms.TextBox();
            this.timer_OFF = new System.Windows.Forms.Timer(this.components);
            this.Button_off_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_on_start
            // 
            this.Button_on_start.Location = new System.Drawing.Point(35, 270);
            this.Button_on_start.Name = "Button_on_start";
            this.Button_on_start.Size = new System.Drawing.Size(135, 42);
            this.Button_on_start.TabIndex = 0;
            this.Button_on_start.Text = "0N_START";
            this.Button_on_start.UseVisualStyleBackColor = true;
            this.Button_on_start.Click += new System.EventHandler(this.Button_on_start_Click);
            // 
            // on_times
            // 
            this.on_times.FormattingEnabled = true;
            this.on_times.Location = new System.Drawing.Point(70, 59);
            this.on_times.Name = "on_times";
            this.on_times.Size = new System.Drawing.Size(121, 20);
            this.on_times.TabIndex = 1;
            // 
            // sec
            // 
            this.sec.AutoSize = true;
            this.sec.Font = new System.Drawing.Font("新細明體", 16F);
            this.sec.Location = new System.Drawing.Point(19, 9);
            this.sec.Name = "sec";
            this.sec.Size = new System.Drawing.Size(234, 22);
            this.sec.TabIndex = 4;
            this.sec.Text = "power_on_times seconds : ";
            // 
            // Button_stop
            // 
            this.Button_stop.Location = new System.Drawing.Point(371, 270);
            this.Button_stop.Name = "Button_stop";
            this.Button_stop.Size = new System.Drawing.Size(138, 42);
            this.Button_stop.TabIndex = 5;
            this.Button_stop.Text = "STOP";
            this.Button_stop.UseVisualStyleBackColor = true;
            this.Button_stop.Click += new System.EventHandler(this.Button_stop_Click);
            // 
            // on_sec
            // 
            this.on_sec.Location = new System.Drawing.Point(70, 105);
            this.on_sec.Name = "on_sec";
            this.on_sec.Size = new System.Drawing.Size(121, 22);
            this.on_sec.TabIndex = 6;
            this.on_sec.TextChanged += new System.EventHandler(this.on_sec_TextChanged);
            // 
            // timer_ON
            // 
            this.timer_ON.Interval = 1000;
            this.timer_ON.Tick += new System.EventHandler(this.timer_ON_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F);
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "power_off_times seconds : ";
            // 
            // off_times
            // 
            this.off_times.FormattingEnabled = true;
            this.off_times.Location = new System.Drawing.Point(348, 59);
            this.off_times.Name = "off_times";
            this.off_times.Size = new System.Drawing.Size(121, 20);
            this.off_times.TabIndex = 9;
            // 
            // off_sec
            // 
            this.off_sec.Location = new System.Drawing.Point(348, 105);
            this.off_sec.Name = "off_sec";
            this.off_sec.Size = new System.Drawing.Size(121, 22);
            this.off_sec.TabIndex = 10;
            this.off_sec.TextChanged += new System.EventHandler(this.off_sec_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(221, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "cycle : ";
            // 
            // cycle_textBox
            // 
            this.cycle_textBox.Location = new System.Drawing.Point(225, 173);
            this.cycle_textBox.Name = "cycle_textBox";
            this.cycle_textBox.Size = new System.Drawing.Size(75, 22);
            this.cycle_textBox.TabIndex = 13;
            this.cycle_textBox.TextChanged += new System.EventHandler(this.cycle_textBox_TextChanged);
            // 
            // timer_OFF
            // 
            this.timer_OFF.Interval = 1000;
            this.timer_OFF.Tick += new System.EventHandler(this.timer_OFF_Tick);
            // 
            // Button_off_start
            // 
            this.Button_off_start.Location = new System.Drawing.Point(200, 270);
            this.Button_off_start.Name = "Button_off_start";
            this.Button_off_start.Size = new System.Drawing.Size(135, 42);
            this.Button_off_start.TabIndex = 14;
            this.Button_off_start.Text = "0FF_START";
            this.Button_off_start.UseVisualStyleBackColor = true;
            this.Button_off_start.Click += new System.EventHandler(this.Button_off_start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 324);
            this.Controls.Add(this.Button_off_start);
            this.Controls.Add(this.cycle_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.off_sec);
            this.Controls.Add(this.off_times);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.on_sec);
            this.Controls.Add(this.Button_stop);
            this.Controls.Add(this.sec);
            this.Controls.Add(this.on_times);
            this.Controls.Add(this.Button_on_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_on_start;
        private System.Windows.Forms.ComboBox on_times;
        private System.Windows.Forms.Label sec;
        private System.Windows.Forms.Button Button_stop;
        private System.Windows.Forms.TextBox on_sec;
        private System.Windows.Forms.Timer timer_ON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox off_times;
        private System.Windows.Forms.TextBox off_sec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cycle_textBox;
        private System.Windows.Forms.Timer timer_OFF;
        private System.Windows.Forms.Button Button_off_start;
    }
}

