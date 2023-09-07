namespace RealEstateApp
{
    partial class DemandInfoForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RealEstateComboBox = new System.Windows.Forms.ComboBox();
            this.agentComboBox = new System.Windows.Forms.ComboBox();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.houseTextBox = new System.Windows.Forms.TextBox();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxFloorsTextBox = new System.Windows.Forms.TextBox();
            this.minFloorsTextBox = new System.Windows.Forms.TextBox();
            this.maxRoomsTextBox = new System.Windows.Forms.TextBox();
            this.minRoomsTextBox = new System.Windows.Forms.TextBox();
            this.maxAreaTextBox = new System.Windows.Forms.TextBox();
            this.minAreaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deleteDemandButton = new System.Windows.Forms.Button();
            this.addUpdateDemandButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(8, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Тип недвижимости:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Риэлтор:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Клиент:";
            // 
            // RealEstateComboBox
            // 
            this.RealEstateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RealEstateComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RealEstateComboBox.FormattingEnabled = true;
            this.RealEstateComboBox.Items.AddRange(new object[] {
            "Квартира",
            "Дом",
            "Земля"});
            this.RealEstateComboBox.Location = new System.Drawing.Point(12, 158);
            this.RealEstateComboBox.Name = "RealEstateComboBox";
            this.RealEstateComboBox.Size = new System.Drawing.Size(360, 31);
            this.RealEstateComboBox.TabIndex = 23;
            this.RealEstateComboBox.SelectedIndexChanged += new System.EventHandler(this.RealEstateComboBox_SelectedIndexChanged);
            // 
            // agentComboBox
            // 
            this.agentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agentComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.agentComboBox.FormattingEnabled = true;
            this.agentComboBox.Location = new System.Drawing.Point(12, 95);
            this.agentComboBox.Name = "agentComboBox";
            this.agentComboBox.Size = new System.Drawing.Size(360, 31);
            this.agentComboBox.TabIndex = 22;
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(12, 33);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(360, 31);
            this.clientComboBox.TabIndex = 21;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.numberTextBox.Location = new System.Drawing.Point(12, 364);
            this.numberTextBox.MaxLength = 11;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(360, 30);
            this.numberTextBox.TabIndex = 30;
            this.numberTextBox.Text = "Квартира";
            this.numberTextBox.Enter += new System.EventHandler(this.numberTextBox_Enter);
            this.numberTextBox.Leave += new System.EventHandler(this.numberTextBox_Leave);
            // 
            // houseTextBox
            // 
            this.houseTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.houseTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.houseTextBox.Location = new System.Drawing.Point(12, 323);
            this.houseTextBox.Name = "houseTextBox";
            this.houseTextBox.Size = new System.Drawing.Size(360, 30);
            this.houseTextBox.TabIndex = 29;
            this.houseTextBox.Text = "Дом";
            this.houseTextBox.Enter += new System.EventHandler(this.houseTextBox_Enter);
            this.houseTextBox.Leave += new System.EventHandler(this.houseTextBox_Leave);
            // 
            // streetTextBox
            // 
            this.streetTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.streetTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.streetTextBox.Location = new System.Drawing.Point(12, 282);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(360, 30);
            this.streetTextBox.TabIndex = 28;
            this.streetTextBox.Text = "Улица";
            this.streetTextBox.Enter += new System.EventHandler(this.streetTextBox_Enter);
            this.streetTextBox.Leave += new System.EventHandler(this.streetTextBox_Leave);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cityTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.cityTextBox.Location = new System.Drawing.Point(12, 241);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(360, 30);
            this.cityTextBox.TabIndex = 27;
            this.cityTextBox.Text = "Город";
            this.cityTextBox.Enter += new System.EventHandler(this.cityTextBox_Enter);
            this.cityTextBox.Leave += new System.EventHandler(this.cityTextBox_Leave);
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxPriceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.maxPriceTextBox.Location = new System.Drawing.Point(12, 489);
            this.maxPriceTextBox.MaxLength = 11;
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(360, 30);
            this.maxPriceTextBox.TabIndex = 33;
            this.maxPriceTextBox.Text = "Максимальная цена";
            this.maxPriceTextBox.Enter += new System.EventHandler(this.maxPriceTextBox_Enter);
            this.maxPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxPriceTextBox_KeyPress);
            this.maxPriceTextBox.Leave += new System.EventHandler(this.maxPriceTextBox_Leave);
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minPriceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.minPriceTextBox.Location = new System.Drawing.Point(12, 447);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(360, 30);
            this.minPriceTextBox.TabIndex = 32;
            this.minPriceTextBox.Text = "Минимальная цена";
            this.minPriceTextBox.Enter += new System.EventHandler(this.minPriceTextBox_Enter);
            this.minPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minPriceTextBox_KeyPress);
            this.minPriceTextBox.Leave += new System.EventHandler(this.minPriceTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label4.Location = new System.Drawing.Point(384, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Дополнительно";
            // 
            // maxFloorsTextBox
            // 
            this.maxFloorsTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxFloorsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.maxFloorsTextBox.Location = new System.Drawing.Point(388, 241);
            this.maxFloorsTextBox.MaxLength = 11;
            this.maxFloorsTextBox.Name = "maxFloorsTextBox";
            this.maxFloorsTextBox.Size = new System.Drawing.Size(360, 30);
            this.maxFloorsTextBox.TabIndex = 40;
            this.maxFloorsTextBox.Text = "Максимальный этаж";
            this.maxFloorsTextBox.Enter += new System.EventHandler(this.maxFloorsTextBox_Enter);
            this.maxFloorsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxFloorsTextBox_KeyPress);
            this.maxFloorsTextBox.Leave += new System.EventHandler(this.maxFloorsTextBox_Leave);
            // 
            // minFloorsTextBox
            // 
            this.minFloorsTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minFloorsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.minFloorsTextBox.Location = new System.Drawing.Point(388, 199);
            this.minFloorsTextBox.Name = "minFloorsTextBox";
            this.minFloorsTextBox.Size = new System.Drawing.Size(360, 30);
            this.minFloorsTextBox.TabIndex = 39;
            this.minFloorsTextBox.Text = "Минимальный этаж";
            this.minFloorsTextBox.Enter += new System.EventHandler(this.minFloorsTextBox_Enter);
            this.minFloorsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minFloorsTextBox_KeyPress);
            this.minFloorsTextBox.Leave += new System.EventHandler(this.minFloorsTextBox_Leave);
            // 
            // maxRoomsTextBox
            // 
            this.maxRoomsTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxRoomsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.maxRoomsTextBox.Location = new System.Drawing.Point(388, 157);
            this.maxRoomsTextBox.MaxLength = 11;
            this.maxRoomsTextBox.Name = "maxRoomsTextBox";
            this.maxRoomsTextBox.Size = new System.Drawing.Size(360, 30);
            this.maxRoomsTextBox.TabIndex = 38;
            this.maxRoomsTextBox.Text = "Максимальное количество комнат";
            this.maxRoomsTextBox.Enter += new System.EventHandler(this.maxRoomsTextBox_Enter);
            this.maxRoomsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxRoomsTextBox_KeyPress);
            this.maxRoomsTextBox.Leave += new System.EventHandler(this.maxRoomsTextBox_Leave);
            // 
            // minRoomsTextBox
            // 
            this.minRoomsTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minRoomsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.minRoomsTextBox.Location = new System.Drawing.Point(388, 116);
            this.minRoomsTextBox.Name = "minRoomsTextBox";
            this.minRoomsTextBox.Size = new System.Drawing.Size(360, 30);
            this.minRoomsTextBox.TabIndex = 37;
            this.minRoomsTextBox.Text = "Минимальное количество комнат";
            this.minRoomsTextBox.Enter += new System.EventHandler(this.minRoomsTextBox_Enter);
            this.minRoomsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minRoomsTextBox_KeyPress);
            this.minRoomsTextBox.Leave += new System.EventHandler(this.minRoomsTextBox_Leave);
            // 
            // maxAreaTextBox
            // 
            this.maxAreaTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxAreaTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.maxAreaTextBox.Location = new System.Drawing.Point(388, 75);
            this.maxAreaTextBox.Name = "maxAreaTextBox";
            this.maxAreaTextBox.Size = new System.Drawing.Size(360, 30);
            this.maxAreaTextBox.TabIndex = 36;
            this.maxAreaTextBox.Text = "Максимальная площадь";
            this.maxAreaTextBox.Enter += new System.EventHandler(this.maxAreaTextBox_Enter);
            this.maxAreaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxAreaTextBox_KeyPress);
            this.maxAreaTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maxAreaTextBox_KeyUp);
            this.maxAreaTextBox.Leave += new System.EventHandler(this.maxAreaTextBox_Leave);
            // 
            // minAreaTextBox
            // 
            this.minAreaTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minAreaTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.minAreaTextBox.Location = new System.Drawing.Point(388, 34);
            this.minAreaTextBox.Name = "minAreaTextBox";
            this.minAreaTextBox.Size = new System.Drawing.Size(360, 30);
            this.minAreaTextBox.TabIndex = 35;
            this.minAreaTextBox.Text = "Минимальная площадь";
            this.minAreaTextBox.Enter += new System.EventHandler(this.minAreaTextBox_Enter);
            this.minAreaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minAreaTextBox_KeyPress);
            this.minAreaTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.minAreaTextBox_KeyUp);
            this.minAreaTextBox.Leave += new System.EventHandler(this.minAreaTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label5.Location = new System.Drawing.Point(8, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "Адрес:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label6.Location = new System.Drawing.Point(8, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 42;
            this.label6.Text = "Цена:";
            // 
            // deleteDemandButton
            // 
            this.deleteDemandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.deleteDemandButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteDemandButton.FlatAppearance.BorderSize = 0;
            this.deleteDemandButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.deleteDemandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteDemandButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteDemandButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.deleteDemandButton.Location = new System.Drawing.Point(388, 352);
            this.deleteDemandButton.Name = "deleteDemandButton";
            this.deleteDemandButton.Size = new System.Drawing.Size(360, 42);
            this.deleteDemandButton.TabIndex = 44;
            this.deleteDemandButton.Text = "Удалить недвижимость";
            this.deleteDemandButton.UseVisualStyleBackColor = false;
            this.deleteDemandButton.Click += new System.EventHandler(this.deleteDemandButton_Click);
            // 
            // addUpdateDemandButton
            // 
            this.addUpdateDemandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addUpdateDemandButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUpdateDemandButton.FlatAppearance.BorderSize = 0;
            this.addUpdateDemandButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addUpdateDemandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUpdateDemandButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUpdateDemandButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addUpdateDemandButton.Location = new System.Drawing.Point(388, 296);
            this.addUpdateDemandButton.Name = "addUpdateDemandButton";
            this.addUpdateDemandButton.Size = new System.Drawing.Size(360, 42);
            this.addUpdateDemandButton.TabIndex = 43;
            this.addUpdateDemandButton.Text = "Добавить/Обновить";
            this.addUpdateDemandButton.UseVisualStyleBackColor = false;
            this.addUpdateDemandButton.Click += new System.EventHandler(this.addUpdateDemandButton_Click);
            // 
            // DemandInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(759, 531);
            this.Controls.Add(this.deleteDemandButton);
            this.Controls.Add(this.addUpdateDemandButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxFloorsTextBox);
            this.Controls.Add(this.minFloorsTextBox);
            this.Controls.Add(this.maxRoomsTextBox);
            this.Controls.Add(this.minRoomsTextBox);
            this.Controls.Add(this.maxAreaTextBox);
            this.Controls.Add(this.minAreaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxPriceTextBox);
            this.Controls.Add(this.minPriceTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.houseTextBox);
            this.Controls.Add(this.streetTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RealEstateComboBox);
            this.Controls.Add(this.agentComboBox);
            this.Controls.Add(this.clientComboBox);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DemandInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о потребности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemandInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.DemandInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RealEstateComboBox;
        private System.Windows.Forms.ComboBox agentComboBox;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox houseTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox maxPriceTextBox;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxFloorsTextBox;
        private System.Windows.Forms.TextBox minFloorsTextBox;
        private System.Windows.Forms.TextBox maxRoomsTextBox;
        private System.Windows.Forms.TextBox minRoomsTextBox;
        private System.Windows.Forms.TextBox maxAreaTextBox;
        private System.Windows.Forms.TextBox minAreaTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deleteDemandButton;
        private System.Windows.Forms.Button addUpdateDemandButton;
    }
}