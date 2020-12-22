namespace CourseworkOfTheThirdSemester
{
    partial class Form1
    {

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.tbGravitation = new System.Windows.Forms.TrackBar();
            this.lblGravitation = new System.Windows.Forms.Label();
            this.btnActivateRadar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(0, 457);
            this.tbDirection.Maximum = 357;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(143, 56);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(149, 468);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 17);
            this.lblDirection.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(275, 457);
            this.trackBar1.Maximum = 720;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(143, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(424, 468);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(0, 17);
            this.lblSpreading.TabIndex = 4;
            // 
            // tbGravitation
            // 
            this.tbGravitation.Location = new System.Drawing.Point(526, 457);
            this.tbGravitation.Maximum = 720;
            this.tbGravitation.Name = "tbGravitation";
            this.tbGravitation.Size = new System.Drawing.Size(143, 56);
            this.tbGravitation.TabIndex = 5;
           //this.tbGravitation.Scroll += new System.EventHandler(this.tbGravitation_Scroll);
            // 
            // lblGravitation
            // 
            this.lblGravitation.AutoSize = true;
            this.lblGravitation.Location = new System.Drawing.Point(700, 468);
            this.lblGravitation.Name = "lblGravitation";
            this.lblGravitation.Size = new System.Drawing.Size(0, 17);
            this.lblGravitation.TabIndex = 6;
            // 
            // btnActivateRadar
            // 
            this.btnActivateRadar.Location = new System.Drawing.Point(873, 457);
            this.btnActivateRadar.Name = "btnActivateRadar";
            this.btnActivateRadar.Size = new System.Drawing.Size(75, 23);
            this.btnActivateRadar.TabIndex = 7;
            this.btnActivateRadar.Text = "button1";
            this.btnActivateRadar.UseVisualStyleBackColor = true;
            this.btnActivateRadar.Click += new System.EventHandler(this.btnActivateRadar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 512);
            this.Controls.Add(this.btnActivateRadar);
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            this.Controls.Add(this.lblGravitation);
            this.Controls.Add(this.tbGravitation);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGravitation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.TrackBar tbGravitation;
        private System.Windows.Forms.Label lblGravitation;
        private System.Windows.Forms.Button btnActivateRadar;
    }
}

