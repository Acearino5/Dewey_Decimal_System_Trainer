namespace DeweyDecimalSystemTrainer
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.findingCallNumButton1 = new DeweyDecimalSystemTrainer.Controls.Buttons();
            this.identifyAreaButton1 = new DeweyDecimalSystemTrainer.Controls.Buttons();
            this.replacingBookBtn = new DeweyDecimalSystemTrainer.Controls.Buttons();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(238, 127);
            this.usernameTextBox.MaxLength = 8;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(256, 22);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter a username before starting!";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(681, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "NB* Username system is like old school arcade games. Use the same username to con" +
    "tinue your progress!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(704, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(941, 616);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(839, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(674, 452);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // findingCallNumButton1
            // 
            this.findingCallNumButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.findingCallNumButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.findingCallNumButton1.BorderColor = System.Drawing.Color.Black;
            this.findingCallNumButton1.BorderRadius = 40;
            this.findingCallNumButton1.BorderSize = 0;
            this.findingCallNumButton1.FlatAppearance.BorderSize = 0;
            this.findingCallNumButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findingCallNumButton1.ForeColor = System.Drawing.Color.White;
            this.findingCallNumButton1.Location = new System.Drawing.Point(238, 454);
            this.findingCallNumButton1.Name = "findingCallNumButton1";
            this.findingCallNumButton1.Size = new System.Drawing.Size(256, 48);
            this.findingCallNumButton1.TabIndex = 7;
            this.findingCallNumButton1.Text = "Finding Call Numbers";
            this.findingCallNumButton1.TextColor = System.Drawing.Color.White;
            this.findingCallNumButton1.UseVisualStyleBackColor = false;
            this.findingCallNumButton1.Click += new System.EventHandler(this.findingCallNumButton1_Click);
            // 
            // identifyAreaButton1
            // 
            this.identifyAreaButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.identifyAreaButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.identifyAreaButton1.BorderColor = System.Drawing.Color.Black;
            this.identifyAreaButton1.BorderRadius = 40;
            this.identifyAreaButton1.BorderSize = 0;
            this.identifyAreaButton1.FlatAppearance.BorderSize = 0;
            this.identifyAreaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.identifyAreaButton1.ForeColor = System.Drawing.Color.White;
            this.identifyAreaButton1.Location = new System.Drawing.Point(238, 352);
            this.identifyAreaButton1.Name = "identifyAreaButton1";
            this.identifyAreaButton1.Size = new System.Drawing.Size(256, 48);
            this.identifyAreaButton1.TabIndex = 6;
            this.identifyAreaButton1.Text = "Identifying Areas";
            this.identifyAreaButton1.TextColor = System.Drawing.Color.White;
            this.identifyAreaButton1.UseVisualStyleBackColor = false;
            this.identifyAreaButton1.Click += new System.EventHandler(this.identifyAreaButton1_Click);
            // 
            // replacingBookBtn
            // 
            this.replacingBookBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.replacingBookBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.replacingBookBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.replacingBookBtn.BorderRadius = 40;
            this.replacingBookBtn.BorderSize = 0;
            this.replacingBookBtn.FlatAppearance.BorderSize = 0;
            this.replacingBookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replacingBookBtn.ForeColor = System.Drawing.Color.White;
            this.replacingBookBtn.Location = new System.Drawing.Point(238, 259);
            this.replacingBookBtn.Name = "replacingBookBtn";
            this.replacingBookBtn.Size = new System.Drawing.Size(256, 48);
            this.replacingBookBtn.TabIndex = 5;
            this.replacingBookBtn.Text = "Replacing Books";
            this.replacingBookBtn.TextColor = System.Drawing.Color.White;
            this.replacingBookBtn.UseVisualStyleBackColor = false;
            this.replacingBookBtn.Click += new System.EventHandler(this.replacingBookBtn_Click_1);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1571, 640);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.findingCallNumButton1);
            this.Controls.Add(this.identifyAreaButton1);
            this.Controls.Add(this.replacingBookBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Controls.Buttons replacingBookBtn;
        private Controls.Buttons findingCallNumButton1;
        private Controls.Buttons identifyAreaButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

