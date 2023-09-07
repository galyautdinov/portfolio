namespace RealEstateApp
{
    partial class DealInfoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.supplyComboBox = new System.Windows.Forms.ComboBox();
            this.demandComboBox = new System.Windows.Forms.ComboBox();
            this.addUpdateClientButton = new System.Windows.Forms.Button();
            this.supplyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.demandRichTextBox = new System.Windows.Forms.RichTextBox();
            this.priceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Предложение:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Потребность:";
            // 
            // supplyComboBox
            // 
            this.supplyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplyComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplyComboBox.FormattingEnabled = true;
            this.supplyComboBox.Location = new System.Drawing.Point(12, 98);
            this.supplyComboBox.Name = "supplyComboBox";
            this.supplyComboBox.Size = new System.Drawing.Size(660, 31);
            this.supplyComboBox.TabIndex = 21;
            this.supplyComboBox.SelectedIndexChanged += new System.EventHandler(this.supplyComboBox_SelectedIndexChanged);
            // 
            // demandComboBox
            // 
            this.demandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.demandComboBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.demandComboBox.FormattingEnabled = true;
            this.demandComboBox.Location = new System.Drawing.Point(12, 33);
            this.demandComboBox.Name = "demandComboBox";
            this.demandComboBox.Size = new System.Drawing.Size(660, 31);
            this.demandComboBox.TabIndex = 20;
            this.demandComboBox.SelectedIndexChanged += new System.EventHandler(this.demandComboBox_SelectedIndexChanged);
            // 
            // addUpdateClientButton
            // 
            this.addUpdateClientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addUpdateClientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUpdateClientButton.FlatAppearance.BorderSize = 0;
            this.addUpdateClientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addUpdateClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUpdateClientButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUpdateClientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addUpdateClientButton.Location = new System.Drawing.Point(12, 522);
            this.addUpdateClientButton.Name = "addUpdateClientButton";
            this.addUpdateClientButton.Size = new System.Drawing.Size(660, 42);
            this.addUpdateClientButton.TabIndex = 24;
            this.addUpdateClientButton.Text = "Оформить сделку";
            this.addUpdateClientButton.UseVisualStyleBackColor = false;
            this.addUpdateClientButton.Click += new System.EventHandler(this.addUpdateClientButton_Click);
            // 
            // supplyRichTextBox
            // 
            this.supplyRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplyRichTextBox.Location = new System.Drawing.Point(347, 145);
            this.supplyRichTextBox.Name = "supplyRichTextBox";
            this.supplyRichTextBox.ReadOnly = true;
            this.supplyRichTextBox.Size = new System.Drawing.Size(325, 246);
            this.supplyRichTextBox.TabIndex = 25;
            this.supplyRichTextBox.Text = "";
            // 
            // demandRichTextBox
            // 
            this.demandRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.demandRichTextBox.Location = new System.Drawing.Point(12, 145);
            this.demandRichTextBox.Name = "demandRichTextBox";
            this.demandRichTextBox.ReadOnly = true;
            this.demandRichTextBox.Size = new System.Drawing.Size(325, 246);
            this.demandRichTextBox.TabIndex = 26;
            this.demandRichTextBox.Text = "";
            // 
            // priceRichTextBox
            // 
            this.priceRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceRichTextBox.Location = new System.Drawing.Point(12, 405);
            this.priceRichTextBox.Name = "priceRichTextBox";
            this.priceRichTextBox.ReadOnly = true;
            this.priceRichTextBox.Size = new System.Drawing.Size(660, 103);
            this.priceRichTextBox.TabIndex = 28;
            this.priceRichTextBox.Text = "";
            // 
            // DealInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 578);
            this.Controls.Add(this.priceRichTextBox);
            this.Controls.Add(this.demandRichTextBox);
            this.Controls.Add(this.supplyRichTextBox);
            this.Controls.Add(this.addUpdateClientButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplyComboBox);
            this.Controls.Add(this.demandComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DealInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание сделки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DealInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.DealInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox supplyComboBox;
        private System.Windows.Forms.ComboBox demandComboBox;
        private System.Windows.Forms.Button addUpdateClientButton;
        private System.Windows.Forms.RichTextBox supplyRichTextBox;
        private System.Windows.Forms.RichTextBox demandRichTextBox;
        private System.Windows.Forms.RichTextBox priceRichTextBox;
    }
}