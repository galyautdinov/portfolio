namespace RealEstateApp
{
    partial class ClientForm
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
            this.clientPanel = new System.Windows.Forms.Panel();
            this.addClientButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.clientPanel.Location = new System.Drawing.Point(12, 127);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(658, 266);
            this.clientPanel.TabIndex = 4;
            // 
            // addClientButton
            // 
            this.addClientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addClientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addClientButton.FlatAppearance.BorderSize = 0;
            this.addClientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addClientButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addClientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addClientButton.Location = new System.Drawing.Point(12, 399);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(658, 42);
            this.addClientButton.TabIndex = 5;
            this.addClientButton.Text = "Добавить клиента";
            this.addClientButton.UseVisualStyleBackColor = false;
            this.addClientButton.Click += new System.EventHandler(this.addClientButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.searchTextBox.Location = new System.Drawing.Point(84, 86);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(586, 30);
            this.searchTextBox.TabIndex = 6;
            this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Поиск:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RealEstateApp.Properties.Resources.logoEsoft;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(453, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 68);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.addClientButton);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel clientPanel;
        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
    }
}