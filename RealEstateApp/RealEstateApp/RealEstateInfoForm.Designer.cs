namespace RealEstateApp
{
    partial class RealEstateInfoForm
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
            this.deleteRealEstateButton = new System.Windows.Forms.Button();
            this.addUpdateRealEstateButton = new System.Windows.Forms.Button();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.houseTextBox = new System.Windows.Forms.TextBox();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.roomTextBox = new System.Windows.Forms.TextBox();
            this.floorTextBox = new System.Windows.Forms.TextBox();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteRealEstateButton
            // 
            this.deleteRealEstateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.deleteRealEstateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteRealEstateButton.FlatAppearance.BorderSize = 0;
            this.deleteRealEstateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.deleteRealEstateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteRealEstateButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteRealEstateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.deleteRealEstateButton.Location = new System.Drawing.Point(12, 538);
            this.deleteRealEstateButton.Name = "deleteRealEstateButton";
            this.deleteRealEstateButton.Size = new System.Drawing.Size(358, 42);
            this.deleteRealEstateButton.TabIndex = 14;
            this.deleteRealEstateButton.Text = "Удалить недвижимость";
            this.deleteRealEstateButton.UseVisualStyleBackColor = false;
            this.deleteRealEstateButton.Click += new System.EventHandler(this.deleteRealEstateButton_Click);
            // 
            // addUpdateRealEstateButton
            // 
            this.addUpdateRealEstateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addUpdateRealEstateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUpdateRealEstateButton.FlatAppearance.BorderSize = 0;
            this.addUpdateRealEstateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addUpdateRealEstateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUpdateRealEstateButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUpdateRealEstateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addUpdateRealEstateButton.Location = new System.Drawing.Point(12, 490);
            this.addUpdateRealEstateButton.Name = "addUpdateRealEstateButton";
            this.addUpdateRealEstateButton.Size = new System.Drawing.Size(358, 42);
            this.addUpdateRealEstateButton.TabIndex = 13;
            this.addUpdateRealEstateButton.Text = "Добавить/Обновить";
            this.addUpdateRealEstateButton.UseVisualStyleBackColor = false;
            this.addUpdateRealEstateButton.Click += new System.EventHandler(this.addUpdateRealEstateButton_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.numberTextBox.Location = new System.Drawing.Point(12, 164);
            this.numberTextBox.MaxLength = 11;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(358, 30);
            this.numberTextBox.TabIndex = 11;
            this.numberTextBox.Text = "Квартира";
            this.numberTextBox.Enter += new System.EventHandler(this.numberTextBox_Enter);
            this.numberTextBox.Leave += new System.EventHandler(this.numberTextBox_Leave);
            // 
            // houseTextBox
            // 
            this.houseTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.houseTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.houseTextBox.Location = new System.Drawing.Point(12, 123);
            this.houseTextBox.Name = "houseTextBox";
            this.houseTextBox.Size = new System.Drawing.Size(358, 30);
            this.houseTextBox.TabIndex = 10;
            this.houseTextBox.Text = "Дом";
            this.houseTextBox.Enter += new System.EventHandler(this.houseTextBox_Enter);
            this.houseTextBox.Leave += new System.EventHandler(this.houseTextBox_Leave);
            // 
            // streetTextBox
            // 
            this.streetTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.streetTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.streetTextBox.Location = new System.Drawing.Point(12, 82);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(358, 30);
            this.streetTextBox.TabIndex = 9;
            this.streetTextBox.Text = "Улица";
            this.streetTextBox.Enter += new System.EventHandler(this.streetTextBox_Enter);
            this.streetTextBox.Leave += new System.EventHandler(this.streetTextBox_Leave);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cityTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.cityTextBox.Location = new System.Drawing.Point(12, 41);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(358, 30);
            this.cityTextBox.TabIndex = 8;
            this.cityTextBox.Text = "Город";
            this.cityTextBox.Enter += new System.EventHandler(this.cityTextBox_Enter);
            this.cityTextBox.Leave += new System.EventHandler(this.cityTextBox_Leave);
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.longitudeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.longitudeTextBox.Location = new System.Drawing.Point(12, 282);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.Size = new System.Drawing.Size(358, 30);
            this.longitudeTextBox.TabIndex = 16;
            this.longitudeTextBox.Text = "Долгота";
            this.longitudeTextBox.Enter += new System.EventHandler(this.longitudeTextBox_Enter);
            this.longitudeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.longitudeTextBox_KeyPress);
            this.longitudeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.longitudeTextBox_KeyUp);
            this.longitudeTextBox.Leave += new System.EventHandler(this.longitudeTextBox_Leave);
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.latitudeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.latitudeTextBox.Location = new System.Drawing.Point(12, 241);
            this.latitudeTextBox.MaxLength = 11;
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.Size = new System.Drawing.Size(358, 30);
            this.latitudeTextBox.TabIndex = 15;
            this.latitudeTextBox.Text = "Широта";
            this.latitudeTextBox.Enter += new System.EventHandler(this.latitudeTextBox_Enter);
            this.latitudeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.latitudeTextBox_KeyPress);
            this.latitudeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.latitudeTextBox_KeyUp);
            this.latitudeTextBox.Leave += new System.EventHandler(this.latitudeTextBox_Leave);
            // 
            // roomTextBox
            // 
            this.roomTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roomTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.roomTextBox.Location = new System.Drawing.Point(12, 441);
            this.roomTextBox.MaxLength = 11;
            this.roomTextBox.Name = "roomTextBox";
            this.roomTextBox.Size = new System.Drawing.Size(358, 30);
            this.roomTextBox.TabIndex = 19;
            this.roomTextBox.Text = "Количество комнат";
            this.roomTextBox.Enter += new System.EventHandler(this.roomTextBox_Enter);
            this.roomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomTextBox_KeyPress);
            this.roomTextBox.Leave += new System.EventHandler(this.roomTextBox_Leave);
            // 
            // floorTextBox
            // 
            this.floorTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.floorTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.floorTextBox.Location = new System.Drawing.Point(12, 400);
            this.floorTextBox.Name = "floorTextBox";
            this.floorTextBox.Size = new System.Drawing.Size(358, 30);
            this.floorTextBox.TabIndex = 18;
            this.floorTextBox.Text = "Этаж";
            this.floorTextBox.Enter += new System.EventHandler(this.floorTextBox_Enter);
            this.floorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.floorTextBox_KeyPress);
            this.floorTextBox.Leave += new System.EventHandler(this.floorTextBox_Leave);
            // 
            // areaTextBox
            // 
            this.areaTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.areaTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.areaTextBox.Location = new System.Drawing.Point(12, 359);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(358, 30);
            this.areaTextBox.TabIndex = 17;
            this.areaTextBox.Text = "Площадь";
            this.areaTextBox.Enter += new System.EventHandler(this.areaTextBox_Enter);
            this.areaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaTextBox_KeyPress);
            this.areaTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.areaTextBox_KeyUp);
            this.areaTextBox.Leave += new System.EventHandler(this.areaTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Координаты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(8, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Дополнительно";
            // 
            // RealEstateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 591);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomTextBox);
            this.Controls.Add(this.floorTextBox);
            this.Controls.Add(this.areaTextBox);
            this.Controls.Add(this.longitudeTextBox);
            this.Controls.Add(this.latitudeTextBox);
            this.Controls.Add(this.deleteRealEstateButton);
            this.Controls.Add(this.addUpdateRealEstateButton);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.houseTextBox);
            this.Controls.Add(this.streetTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RealEstateInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об объекте недвижимости";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RealEstateInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.RealEstateInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteRealEstateButton;
        private System.Windows.Forms.Button addUpdateRealEstateButton;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox houseTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.TextBox roomTextBox;
        private System.Windows.Forms.TextBox floorTextBox;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}