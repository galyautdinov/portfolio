namespace RealEstateApp
{
    partial class DealForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addDealButton = new System.Windows.Forms.Button();
            this.dealPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RealEstateApp.Properties.Resources.logoEsoft;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(453, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 68);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // addDealButton
            // 
            this.addDealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addDealButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDealButton.FlatAppearance.BorderSize = 0;
            this.addDealButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addDealButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDealButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDealButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addDealButton.Location = new System.Drawing.Point(12, 399);
            this.addDealButton.Name = "addDealButton";
            this.addDealButton.Size = new System.Drawing.Size(658, 42);
            this.addDealButton.TabIndex = 7;
            this.addDealButton.Text = "Добавить сделку";
            this.addDealButton.UseVisualStyleBackColor = false;
            this.addDealButton.Click += new System.EventHandler(this.addDealButton_Click);
            // 
            // dealPanel
            // 
            this.dealPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dealPanel.Location = new System.Drawing.Point(12, 86);
            this.dealPanel.Name = "dealPanel";
            this.dealPanel.Size = new System.Drawing.Size(658, 307);
            this.dealPanel.TabIndex = 6;
            // 
            // DealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.addDealButton);
            this.Controls.Add(this.dealPanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DealForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сделки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DealForm_FormClosing);
            this.Load += new System.EventHandler(this.DealForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addDealButton;
        private System.Windows.Forms.Panel dealPanel;
    }
}