namespace RubiksCubeDemo
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_FrontClockwise = new System.Windows.Forms.Button();
            this.btn_RightClockwise = new System.Windows.Forms.Button();
            this.btn_BackClockwise = new System.Windows.Forms.Button();
            this.btn_UpClockwise = new System.Windows.Forms.Button();
            this.btn_DownClockwise = new System.Windows.Forms.Button();
            this.btn_LeftClockwise = new System.Windows.Forms.Button();
            this.btn_DownAntiClockwise = new System.Windows.Forms.Button();
            this.btn_LeftAntiClockwise = new System.Windows.Forms.Button();
            this.btn_BackAntiClockwise = new System.Windows.Forms.Button();
            this.btn_UpAntiClockwise = new System.Windows.Forms.Button();
            this.btn_RightAntiClockwise = new System.Windows.Forms.Button();
            this.btn_FrontAntiClockwise = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(12, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 539);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_FrontClockwise
            // 
            this.btn_FrontClockwise.Location = new System.Drawing.Point(26, 81);
            this.btn_FrontClockwise.Name = "btn_FrontClockwise";
            this.btn_FrontClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_FrontClockwise.TabIndex = 1;
            this.btn_FrontClockwise.Text = "F";
            this.btn_FrontClockwise.UseVisualStyleBackColor = true;
            this.btn_FrontClockwise.Click += new System.EventHandler(this.btn_FrontClockwise_Click);
            // 
            // btn_RightClockwise
            // 
            this.btn_RightClockwise.Location = new System.Drawing.Point(78, 81);
            this.btn_RightClockwise.Name = "btn_RightClockwise";
            this.btn_RightClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_RightClockwise.TabIndex = 2;
            this.btn_RightClockwise.Text = "R";
            this.btn_RightClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_BackClockwise
            // 
            this.btn_BackClockwise.Location = new System.Drawing.Point(182, 81);
            this.btn_BackClockwise.Name = "btn_BackClockwise";
            this.btn_BackClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_BackClockwise.TabIndex = 4;
            this.btn_BackClockwise.Text = "B";
            this.btn_BackClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_UpClockwise
            // 
            this.btn_UpClockwise.Location = new System.Drawing.Point(130, 81);
            this.btn_UpClockwise.Name = "btn_UpClockwise";
            this.btn_UpClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_UpClockwise.TabIndex = 3;
            this.btn_UpClockwise.Text = "U";
            this.btn_UpClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_DownClockwise
            // 
            this.btn_DownClockwise.Location = new System.Drawing.Point(286, 81);
            this.btn_DownClockwise.Name = "btn_DownClockwise";
            this.btn_DownClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_DownClockwise.TabIndex = 6;
            this.btn_DownClockwise.Text = "D";
            this.btn_DownClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_LeftClockwise
            // 
            this.btn_LeftClockwise.Location = new System.Drawing.Point(234, 81);
            this.btn_LeftClockwise.Name = "btn_LeftClockwise";
            this.btn_LeftClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_LeftClockwise.TabIndex = 5;
            this.btn_LeftClockwise.Text = "L";
            this.btn_LeftClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_DownAntiClockwise
            // 
            this.btn_DownAntiClockwise.Location = new System.Drawing.Point(286, 123);
            this.btn_DownAntiClockwise.Name = "btn_DownAntiClockwise";
            this.btn_DownAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_DownAntiClockwise.TabIndex = 12;
            this.btn_DownAntiClockwise.Text = "D\'";
            this.btn_DownAntiClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_LeftAntiClockwise
            // 
            this.btn_LeftAntiClockwise.Location = new System.Drawing.Point(234, 123);
            this.btn_LeftAntiClockwise.Name = "btn_LeftAntiClockwise";
            this.btn_LeftAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_LeftAntiClockwise.TabIndex = 11;
            this.btn_LeftAntiClockwise.Text = "L\'";
            this.btn_LeftAntiClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_BackAntiClockwise
            // 
            this.btn_BackAntiClockwise.Location = new System.Drawing.Point(182, 123);
            this.btn_BackAntiClockwise.Name = "btn_BackAntiClockwise";
            this.btn_BackAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_BackAntiClockwise.TabIndex = 10;
            this.btn_BackAntiClockwise.Text = "B\'";
            this.btn_BackAntiClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_UpAntiClockwise
            // 
            this.btn_UpAntiClockwise.Location = new System.Drawing.Point(130, 123);
            this.btn_UpAntiClockwise.Name = "btn_UpAntiClockwise";
            this.btn_UpAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_UpAntiClockwise.TabIndex = 9;
            this.btn_UpAntiClockwise.Text = "U\'";
            this.btn_UpAntiClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_RightAntiClockwise
            // 
            this.btn_RightAntiClockwise.Location = new System.Drawing.Point(78, 123);
            this.btn_RightAntiClockwise.Name = "btn_RightAntiClockwise";
            this.btn_RightAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_RightAntiClockwise.TabIndex = 8;
            this.btn_RightAntiClockwise.Text = "R\'";
            this.btn_RightAntiClockwise.UseVisualStyleBackColor = true;
            // 
            // btn_FrontAntiClockwise
            // 
            this.btn_FrontAntiClockwise.Location = new System.Drawing.Point(26, 123);
            this.btn_FrontAntiClockwise.Name = "btn_FrontAntiClockwise";
            this.btn_FrontAntiClockwise.Size = new System.Drawing.Size(46, 23);
            this.btn_FrontAntiClockwise.TabIndex = 7;
            this.btn_FrontAntiClockwise.Text = "F\'";
            this.btn_FrontAntiClockwise.UseVisualStyleBackColor = true;
            this.btn_FrontAntiClockwise.Click += new System.EventHandler(this.btn_FrontAntiClockwise_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(425, 81);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 23);
            this.btn_Reset.TabIndex = 13;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_DownAntiClockwise);
            this.Controls.Add(this.btn_LeftAntiClockwise);
            this.Controls.Add(this.btn_BackAntiClockwise);
            this.Controls.Add(this.btn_UpAntiClockwise);
            this.Controls.Add(this.btn_RightAntiClockwise);
            this.Controls.Add(this.btn_FrontAntiClockwise);
            this.Controls.Add(this.btn_DownClockwise);
            this.Controls.Add(this.btn_LeftClockwise);
            this.Controls.Add(this.btn_BackClockwise);
            this.Controls.Add(this.btn_UpClockwise);
            this.Controls.Add(this.btn_RightClockwise);
            this.Controls.Add(this.btn_FrontClockwise);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btn_FrontClockwise;
        private Button btn_RightClockwise;
        private Button btn_BackClockwise;
        private Button btn_UpClockwise;
        private Button btn_DownClockwise;
        private Button btn_LeftClockwise;
        private Button btn_DownAntiClockwise;
        private Button btn_LeftAntiClockwise;
        private Button btn_BackAntiClockwise;
        private Button btn_UpAntiClockwise;
        private Button btn_RightAntiClockwise;
        private Button btn_FrontAntiClockwise;
        private Button btn_Reset;
    }
}