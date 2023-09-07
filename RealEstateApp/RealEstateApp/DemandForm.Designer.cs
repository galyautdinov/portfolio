namespace RealEstateApp
{
    partial class DemandForm
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
            this.addApartmentButton = new System.Windows.Forms.Button();
            this.demandPanel = new System.Windows.Forms.Panel();
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
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // addApartmentButton
            // 
            this.addApartmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addApartmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addApartmentButton.FlatAppearance.BorderSize = 0;
            this.addApartmentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addApartmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addApartmentButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addApartmentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addApartmentButton.Location = new System.Drawing.Point(12, 399);
            this.addApartmentButton.Name = "addApartmentButton";
            this.addApartmentButton.Size = new System.Drawing.Size(658, 42);
            this.addApartmentButton.TabIndex = 16;
            this.addApartmentButton.Text = "Добавить потребность";
            this.addApartmentButton.UseVisualStyleBackColor = false;
            this.addApartmentButton.Click += new System.EventHandler(this.addApartmentButton_Click);
            // 
            // demandPanel
            // 
            this.demandPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.demandPanel.Location = new System.Drawing.Point(12, 86);
            this.demandPanel.Name = "demandPanel";
            this.demandPanel.Size = new System.Drawing.Size(658, 307);
            this.demandPanel.TabIndex = 15;
            // 
            // DemandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.addApartmentButton);
            this.Controls.Add(this.demandPanel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DemandForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Потребности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemandForm_FormClosing);
            this.Load += new System.EventHandler(this.DemandForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addApartmentButton;
        private System.Windows.Forms.Panel demandPanel;
    }
}