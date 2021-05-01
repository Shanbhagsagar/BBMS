namespace BBMS
{
    partial class Blink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blink));
            this.label1 = new System.Windows.Forms.Label();
            this.pb = new CircularProgressBar.CircularProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Fugaz One", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "BLOOD BANK MANAGEMENT SYSTEM";
            // 
            // pb
            // 
            this.pb.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.pb.AnimationSpeed = 500;
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.pb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pb.InnerColor = System.Drawing.Color.Transparent;
            this.pb.InnerMargin = 2;
            this.pb.InnerWidth = -1;
            this.pb.Location = new System.Drawing.Point(168, 67);
            this.pb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pb.MarqueeAnimationSpeed = 2000;
            this.pb.Name = "pb";
            this.pb.OuterColor = System.Drawing.Color.LightGray;
            this.pb.OuterMargin = -25;
            this.pb.OuterWidth = 23;
            this.pb.ProgressColor = System.Drawing.Color.Red;
            this.pb.ProgressWidth = 10;
            this.pb.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.pb.Size = new System.Drawing.Size(176, 186);
            this.pb.StartAngle = 270;
            this.pb.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pb.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.pb.SubscriptText = ".23";
            this.pb.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pb.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.pb.SuperscriptText = "°C";
            this.pb.TabIndex = 1;
            this.pb.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(196, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Blink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 273);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Blink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Blink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CircularProgressBar.CircularProgressBar pb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

