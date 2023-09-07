namespace RealEstateApp
{
    partial class RealEstateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.addApartmentButton = new System.Windows.Forms.Button();
            this.realEstatePanel = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.addHouseButton = new System.Windows.Forms.Button();
            this.addLandButton = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Поиск:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.searchTextBox.Location = new System.Drawing.Point(84, 86);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(363, 30);
            this.searchTextBox.TabIndex = 10;
            this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
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
            this.addApartmentButton.Size = new System.Drawing.Size(214, 42);
            this.addApartmentButton.TabIndex = 9;
            this.addApartmentButton.Text = "Добавить квартиру";
            this.addApartmentButton.UseVisualStyleBackColor = false;
            this.addApartmentButton.Click += new System.EventHandler(this.addApartmentButton_Click);
            // 
            // realEstatePanel
            // 
            this.realEstatePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.realEstatePanel.Location = new System.Drawing.Point(12, 127);
            this.realEstatePanel.Name = "realEstatePanel";
            this.realEstatePanel.Size = new System.Drawing.Size(658, 266);
            this.realEstatePanel.TabIndex = 8;
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Все",
            "Квартиры",
            "Дома",
            "Земли"});
            this.comboBox.Location = new System.Drawing.Point(453, 86);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(217, 31);
            this.comboBox.TabIndex = 12;
            this.comboBox.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            // 
            // addHouseButton
            // 
            this.addHouseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addHouseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addHouseButton.FlatAppearance.BorderSize = 0;
            this.addHouseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addHouseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHouseButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addHouseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addHouseButton.Location = new System.Drawing.Point(234, 399);
            this.addHouseButton.Name = "addHouseButton";
            this.addHouseButton.Size = new System.Drawing.Size(214, 42);
            this.addHouseButton.TabIndex = 13;
            this.addHouseButton.Text = "Добавить дом";
            this.addHouseButton.UseVisualStyleBackColor = false;
            this.addHouseButton.Click += new System.EventHandler(this.addHouseButton_Click);
            // 
            // addLandButton
            // 
            this.addLandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addLandButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addLandButton.FlatAppearance.BorderSize = 0;
            this.addLandButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addLandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addLandButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addLandButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addLandButton.Location = new System.Drawing.Point(456, 399);
            this.addLandButton.Name = "addLandButton";
            this.addLandButton.Size = new System.Drawing.Size(214, 42);
            this.addLandButton.TabIndex = 14;
            this.addLandButton.Text = "Добавить землю";
            this.addLandButton.UseVisualStyleBackColor = false;
            this.addLandButton.Click += new System.EventHandler(this.addLandButton_Click);
            // 
            // RealEstateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.addLandButton);
            this.Controls.Add(this.addHouseButton);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.addApartmentButton);
            this.Controls.Add(this.realEstatePanel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RealEstateForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Объекты недвижимости";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RealEstateForm_FormClosing);
            this.Load += new System.EventHandler(this.RealEstateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button addApartmentButton;
        private System.Windows.Forms.Panel realEstatePanel;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button addHouseButton;
        private System.Windows.Forms.Button addLandButton;
    }
}