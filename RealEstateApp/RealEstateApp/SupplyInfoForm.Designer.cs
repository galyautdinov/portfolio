namespace RealEstateApp
{
    partial class SupplyInfoForm
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
            this.deleteSupplyButton = new System.Windows.Forms.Button();
            this.addUpdateSupplyButton = new System.Windows.Forms.Button();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.agentComboBox = new System.Windows.Forms.ComboBox();
            this.RealEstateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteSupplyButton
            // 
            this.deleteSupplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.deleteSupplyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteSupplyButton.FlatAppearance.BorderSize = 0;
            this.deleteSupplyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.deleteSupplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSupplyButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteSupplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.deleteSupplyButton.Location = new System.Drawing.Point(12, 305);
            this.deleteSupplyButton.Name = "deleteSupplyButton";
            this.deleteSupplyButton.Size = new System.Drawing.Size(358, 42);
            this.deleteSupplyButton.TabIndex = 14;
            this.deleteSupplyButton.Text = "Удалить предложение";
            this.deleteSupplyButton.UseVisualStyleBackColor = false;
            this.deleteSupplyButton.Click += new System.EventHandler(this.deleteSupplyButton_Click);
            // 
            // addUpdateSupplyButton
            // 
            this.addUpdateSupplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addUpdateSupplyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUpdateSupplyButton.FlatAppearance.BorderSize = 0;
            this.addUpdateSupplyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addUpdateSupplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUpdateSupplyButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUpdateSupplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addUpdateSupplyButton.Location = new System.Drawing.Point(12, 257);
            this.addUpdateSupplyButton.Name = "addUpdateSupplyButton";
            this.addUpdateSupplyButton.Size = new System.Drawing.Size(358, 42);
            this.addUpdateSupplyButton.TabIndex = 13;
            this.addUpdateSupplyButton.Text = "Добавить/Обновить";
            this.addUpdateSupplyButton.UseVisualStyleBackColor = false;
            this.addUpdateSupplyButton.Click += new System.EventHandler(this.addUpdateSupplyButton_Click);
            // 
            // priceTextBox
            // 
            this.priceTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.priceTextBox.Location = new System.Drawing.Point(12, 212);
            this.priceTextBox.MaxLength = 11;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(358, 30);
            this.priceTextBox.TabIndex = 11;
            this.priceTextBox.Text = "0";
            this.priceTextBox.Enter += new System.EventHandler(this.priceTextBox_Enter);
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            this.priceTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.priceTextBox_KeyUp);
            this.priceTextBox.Leave += new System.EventHandler(this.priceTextBox_Leave);
            // 
            // clientComboBox
            // 
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(12, 35);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(358, 31);
            this.clientComboBox.TabIndex = 15;
            // 
            // agentComboBox
            // 
            this.agentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agentComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.agentComboBox.FormattingEnabled = true;
            this.agentComboBox.Location = new System.Drawing.Point(12, 100);
            this.agentComboBox.Name = "agentComboBox";
            this.agentComboBox.Size = new System.Drawing.Size(358, 31);
            this.agentComboBox.TabIndex = 16;
            // 
            // RealEstateComboBox
            // 
            this.RealEstateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RealEstateComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RealEstateComboBox.FormattingEnabled = true;
            this.RealEstateComboBox.Location = new System.Drawing.Point(12, 166);
            this.RealEstateComboBox.Name = "RealEstateComboBox";
            this.RealEstateComboBox.Size = new System.Drawing.Size(358, 31);
            this.RealEstateComboBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Клиент:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Риэлтор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(8, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Недвижимость:";
            // 
            // SupplyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 359);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RealEstateComboBox);
            this.Controls.Add(this.agentComboBox);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.deleteSupplyButton);
            this.Controls.Add(this.addUpdateSupplyButton);
            this.Controls.Add(this.priceTextBox);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о предложении";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SupplyInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.SupplyInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteSupplyButton;
        private System.Windows.Forms.Button addUpdateSupplyButton;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.ComboBox agentComboBox;
        private System.Windows.Forms.ComboBox RealEstateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}