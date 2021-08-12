namespace WindowsFormsApp111
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
            this.set_on_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.set_off_time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.set_cycle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.running_cycle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.on_time = new System.Windows.Forms.TextBox();
            this.timer_cycle = new System.Windows.Forms.Timer(this.components);
            this.start_cycle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.off_time = new System.Windows.Forms.TextBox();
            this.button_STOP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // set_on_time
            // 
            this.set_on_time.Location = new System.Drawing.Point(96, 16);
            this.set_on_time.Name = "set_on_time";
            this.set_on_time.Size = new System.Drawing.Size(100, 22);
            this.set_on_time.TabIndex = 0;
            this.set_on_time.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set On Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Off Time";
            // 
            // set_off_time
            // 
            this.set_off_time.Location = new System.Drawing.Point(96, 60);
            this.set_off_time.Name = "set_off_time";
            this.set_off_time.Size = new System.Drawing.Size(100, 22);
            this.set_off_time.TabIndex = 2;
            this.set_off_time.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Set cycle";
            // 
            // set_cycle
            // 
            this.set_cycle.Location = new System.Drawing.Point(96, 109);
            this.set_cycle.Name = "set_cycle";
            this.set_cycle.Size = new System.Drawing.Size(100, 22);
            this.set_cycle.TabIndex = 4;
            this.set_cycle.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Running cycle";
            // 
            // running_cycle
            // 
            this.running_cycle.Location = new System.Drawing.Point(96, 246);
            this.running_cycle.Name = "running_cycle";
            this.running_cycle.Size = new System.Drawing.Size(100, 22);
            this.running_cycle.TabIndex = 8;
            this.running_cycle.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "On Time";
            // 
            // on_time
            // 
            this.on_time.Location = new System.Drawing.Point(96, 166);
            this.on_time.Name = "on_time";
            this.on_time.Size = new System.Drawing.Size(100, 22);
            this.on_time.TabIndex = 6;
            this.on_time.Text = "0";
            // 
            // timer_cycle
            // 
            this.timer_cycle.Interval = 500;
            this.timer_cycle.Tick += new System.EventHandler(this.timer_cycle_Tick);
            // 
            // start_cycle
            // 
            this.start_cycle.Location = new System.Drawing.Point(14, 298);
            this.start_cycle.Name = "start_cycle";
            this.start_cycle.Size = new System.Drawing.Size(75, 23);
            this.start_cycle.TabIndex = 10;
            this.start_cycle.Text = "START";
            this.start_cycle.UseVisualStyleBackColor = true;
            this.start_cycle.Click += new System.EventHandler(this.start_cycle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Off Time";
            // 
            // off_time
            // 
            this.off_time.Location = new System.Drawing.Point(96, 204);
            this.off_time.Name = "off_time";
            this.off_time.Size = new System.Drawing.Size(100, 22);
            this.off_time.TabIndex = 11;
            this.off_time.Text = "0";
            // 
            // button_STOP
            // 
            this.button_STOP.Location = new System.Drawing.Point(121, 298);
            this.button_STOP.Name = "button_STOP";
            this.button_STOP.Size = new System.Drawing.Size(75, 23);
            this.button_STOP.TabIndex = 13;
            this.button_STOP.Text = "STOP";
            this.button_STOP.UseVisualStyleBackColor = true;
            this.button_STOP.Click += new System.EventHandler(this.button_STOP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 333);
            this.Controls.Add(this.button_STOP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.off_time);
            this.Controls.Add(this.start_cycle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.running_cycle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.on_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.set_cycle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.set_off_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.set_on_time);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox set_on_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox set_off_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox set_cycle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox running_cycle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox on_time;
        private System.Windows.Forms.Timer timer_cycle;
        private System.Windows.Forms.Button start_cycle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox off_time;
        private System.Windows.Forms.Button button_STOP;
    }
}

