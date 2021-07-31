namespace TCalc_004
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
            this.textBox_latitude = new System.Windows.Forms.TextBox();
            this.textBox_longitude = new System.Windows.Forms.TextBox();
            this.textBox_trueheading = new System.Windows.Forms.TextBox();
            this.label_longitude = new System.Windows.Forms.Label();
            this.label_trueheading = new System.Windows.Forms.Label();
            this.label_groundaltitude = new System.Windows.Forms.Label();
            this.textBox_groundaltitude = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label_latitude = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_latitude
            // 
            this.textBox_latitude.Location = new System.Drawing.Point(63, 62);
            this.textBox_latitude.Name = "textBox_latitude";
            this.textBox_latitude.ReadOnly = true;
            this.textBox_latitude.Size = new System.Drawing.Size(140, 20);
            this.textBox_latitude.TabIndex = 0;
            // 
            // textBox_longitude
            // 
            this.textBox_longitude.Location = new System.Drawing.Point(63, 88);
            this.textBox_longitude.Name = "textBox_longitude";
            this.textBox_longitude.ReadOnly = true;
            this.textBox_longitude.Size = new System.Drawing.Size(140, 20);
            this.textBox_longitude.TabIndex = 1;
            // 
            // textBox_trueheading
            // 
            this.textBox_trueheading.Location = new System.Drawing.Point(290, 59);
            this.textBox_trueheading.Name = "textBox_trueheading";
            this.textBox_trueheading.ReadOnly = true;
            this.textBox_trueheading.Size = new System.Drawing.Size(140, 20);
            this.textBox_trueheading.TabIndex = 2;
            // 
            // label_longitude
            // 
            this.label_longitude.AutoSize = true;
            this.label_longitude.Location = new System.Drawing.Point(7, 91);
            this.label_longitude.Name = "label_longitude";
            this.label_longitude.Size = new System.Drawing.Size(50, 13);
            this.label_longitude.TabIndex = 4;
            this.label_longitude.Text = "longitude";
            // 
            // label_trueheading
            // 
            this.label_trueheading.AutoSize = true;
            this.label_trueheading.Location = new System.Drawing.Point(218, 62);
            this.label_trueheading.Name = "label_trueheading";
            this.label_trueheading.Size = new System.Drawing.Size(66, 13);
            this.label_trueheading.TabIndex = 5;
            this.label_trueheading.Text = "true heading";
            // 
            // label_groundaltitude
            // 
            this.label_groundaltitude.AutoSize = true;
            this.label_groundaltitude.Location = new System.Drawing.Point(209, 88);
            this.label_groundaltitude.Name = "label_groundaltitude";
            this.label_groundaltitude.Size = new System.Drawing.Size(77, 13);
            this.label_groundaltitude.TabIndex = 7;
            this.label_groundaltitude.Text = "ground altitude";
            // 
            // textBox_groundaltitude
            // 
            this.textBox_groundaltitude.Location = new System.Drawing.Point(290, 85);
            this.textBox_groundaltitude.Name = "textBox_groundaltitude";
            this.textBox_groundaltitude.ReadOnly = true;
            this.textBox_groundaltitude.Size = new System.Drawing.Size(140, 20);
            this.textBox_groundaltitude.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.Simconnect_Connect);
            // 
            // label_latitude
            // 
            this.label_latitude.AutoSize = true;
            this.label_latitude.Location = new System.Drawing.Point(16, 65);
            this.label_latitude.Name = "label_latitude";
            this.label_latitude.Size = new System.Drawing.Size(41, 13);
            this.label_latitude.TabIndex = 3;
            this.label_latitude.Text = "latitude";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 627);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.textBox_groundaltitude);
            this.Controls.Add(this.label_groundaltitude);
            this.Controls.Add(this.label_trueheading);
            this.Controls.Add(this.label_longitude);
            this.Controls.Add(this.label_latitude);
            this.Controls.Add(this.textBox_trueheading);
            this.Controls.Add(this.textBox_longitude);
            this.Controls.Add(this.textBox_latitude);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "TCalc_004";
            this.TopMost = true;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_latitude;
        private System.Windows.Forms.TextBox textBox_longitude;
        private System.Windows.Forms.TextBox textBox_trueheading;
        private System.Windows.Forms.Label label_longitude;
        private System.Windows.Forms.Label label_trueheading;
        private System.Windows.Forms.Label label_groundaltitude;
        private System.Windows.Forms.TextBox textBox_groundaltitude;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label_latitude;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

