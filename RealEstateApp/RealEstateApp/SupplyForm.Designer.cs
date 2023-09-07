namespace RealEstateApp
{
    partial class SupplyForm
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
            this.addSupplyButton = new System.Windows.Forms.Button();
            this.supplyPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // addSupplyButton
            // 
            this.addSupplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addSupplyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSupplyButton.FlatAppearance.BorderSize = 0;
            this.addSupplyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addSupplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSupplyButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addSupplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addSupplyButton.Location = new System.Drawing.Point(12, 399);
            this.addSupplyButton.Name = "addSupplyButton";
            this.addSupplyButton.Size = new System.Drawing.Size(658, 42);
            this.addSupplyButton.TabIndex = 7;
            this.addSupplyButton.Text = "Добавить предложение";
            this.addSupplyButton.UseVisualStyleBackColor = false;
            this.addSupplyButton.Click += new System.EventHandler(this.addSupplyButton_Click);
            // 
            // supplyPanel
            // 
            this.supplyPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.supplyPanel.Location = new System.Drawing.Point(12, 86);
            this.supplyPanel.Name = "supplyPanel";
            this.supplyPanel.Size = new System.Drawing.Size(658, 307);
            this.supplyPanel.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RealEstateApp.Properties.Resources.logoEsoft;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(453, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 68);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // SupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.addSupplyButton);
            this.Controls.Add(this.supplyPanel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SupplyForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Предложения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SupplyForm_FormClosing);
            this.Load += new System.EventHandler(this.SupplyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addSupplyButton;
        private System.Windows.Forms.Panel supplyPanel;
    }
}