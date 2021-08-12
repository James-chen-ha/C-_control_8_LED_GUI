
namespace times_for_loop_experiment
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
            this.Button_Stop = new System.Windows.Forms.Button();
            this.Button_Cycle_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OFF_sec = new System.Windows.Forms.TextBox();
            this.timer_ON = new System.Windows.Forms.Timer(this.components);
            this.timer_OFF = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ON_sec = new System.Windows.Forms.TextBox();
            this.cycle_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_Stop
            // 
            this.Button_Stop.Location = new System.Drawing.Point(183, 265);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(114, 43);
            this.Button_Stop.TabIndex = 0;
            this.Button_Stop.Text = "STOP";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Button_Cycle_Start
            // 
            this.Button_Cycle_Start.Location = new System.Drawing.Point(21, 265);
            this.Button_Cycle_Start.Name = "Button_Cycle_Start";
            this.Button_Cycle_Start.Size = new System.Drawing.Size(114, 43);
            this.Button_Cycle_Start.TabIndex = 1;
            this.Button_Cycle_Start.Text = "START";
            this.Button_Cycle_Start.UseVisualStyleBackColor = true;
            this.Button_Cycle_Start.Click += new System.EventHandler(this.Button_Cycle_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F);
            this.label1.Location = new System.Drawing.Point(17, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "power_on_times : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F);
            this.label2.Location = new System.Drawing.Point(17, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "power_off_times : ";
            // 
            // OFF_sec
            // 
            this.OFF_sec.Location = new System.Drawing.Point(183, 201);
            this.OFF_sec.Name = "OFF_sec";
            this.OFF_sec.Size = new System.Drawing.Size(86, 22);
            this.OFF_sec.TabIndex = 5;
            // 
            // timer_ON
            // 
            this.timer_ON.Interval = 1000;
            this.timer_ON.Tick += new System.EventHandler(this.timer_ON_Tick);
            // 
            // timer_OFF
            // 
            this.timer_OFF.Interval = 1000;
            this.timer_OFF.Tick += new System.EventHandler(this.timer_OFF_Tick_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(113, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "cycle : ";
            // 
            // ON_sec
            // 
            this.ON_sec.Location = new System.Drawing.Point(183, 134);
            this.ON_sec.Name = "ON_sec";
            this.ON_sec.Size = new System.Drawing.Size(86, 22);
            this.ON_sec.TabIndex = 7;
            // 
            // cycle_textBox
            // 
            this.cycle_textBox.Location = new System.Drawing.Point(183, 65);
            this.cycle_textBox.Name = "cycle_textBox";
            this.cycle_textBox.Size = new System.Drawing.Size(86, 22);
            this.cycle_textBox.TabIndex = 8;
            this.cycle_textBox.TextChanged += new System.EventHandler(this.cycle_textBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 348);
            this.Controls.Add(this.cycle_textBox);
            this.Controls.Add(this.ON_sec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OFF_sec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Cycle_Start);
            this.Controls.Add(this.Button_Stop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Stop;
        private System.Windows.Forms.Button Button_Cycle_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OFF_sec;
        private System.Windows.Forms.Timer timer_ON;
        private System.Windows.Forms.Timer timer_OFF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ON_sec;
        private System.Windows.Forms.TextBox cycle_textBox;
    }
}

