namespace RealEstateApp
{
    partial class ClientInfoForm
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
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.middlenameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addUpdateClientButton = new System.Windows.Forms.Button();
            this.deleteClientButton = new System.Windows.Forms.Button();
            this.supplyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.demandRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstnameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.firstnameTextBox.Location = new System.Drawing.Point(12, 12);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(560, 30);
            this.firstnameTextBox.TabIndex = 0;
            this.firstnameTextBox.Text = "Фамилия";
            this.firstnameTextBox.Enter += new System.EventHandler(this.firstnameTextBox_Enter);
            this.firstnameTextBox.Leave += new System.EventHandler(this.firstnameTextBox_Leave);
            // 
            // middlenameTextBox
            // 
            this.middlenameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.middlenameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.middlenameTextBox.Location = new System.Drawing.Point(12, 53);
            this.middlenameTextBox.Name = "middlenameTextBox";
            this.middlenameTextBox.Size = new System.Drawing.Size(560, 30);
            this.middlenameTextBox.TabIndex = 1;
            this.middlenameTextBox.Text = "Имя";
            this.middlenameTextBox.Enter += new System.EventHandler(this.middlenameTextBox_Enter);
            this.middlenameTextBox.Leave += new System.EventHandler(this.middlenameTextBox_Leave);
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastnameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.lastnameTextBox.Location = new System.Drawing.Point(12, 94);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(560, 30);
            this.lastnameTextBox.TabIndex = 2;
            this.lastnameTextBox.Text = "Отчество";
            this.lastnameTextBox.Enter += new System.EventHandler(this.lastnameTextBox_Enter);
            this.lastnameTextBox.Leave += new System.EventHandler(this.lastnameTextBox_Leave);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.phoneTextBox.Location = new System.Drawing.Point(12, 135);
            this.phoneTextBox.MaxLength = 11;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(560, 30);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.Text = "Телефон";
            this.phoneTextBox.Enter += new System.EventHandler(this.phoneTextBox_Enter);
            this.phoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneTextBox_KeyPress);
            this.phoneTextBox.Leave += new System.EventHandler(this.phoneTextBox_Leave);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.emailTextBox.Location = new System.Drawing.Point(12, 176);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(560, 30);
            this.emailTextBox.TabIndex = 4;
            this.emailTextBox.Text = "Почта";
            this.emailTextBox.Enter += new System.EventHandler(this.emailTextBox_Enter);
            this.emailTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emailTextBox_KeyUp);
            this.emailTextBox.Leave += new System.EventHandler(this.emailTextBox_Leave);
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
            this.addUpdateClientButton.Location = new System.Drawing.Point(12, 407);
            this.addUpdateClientButton.Name = "addUpdateClientButton";
            this.addUpdateClientButton.Size = new System.Drawing.Size(560, 42);
            this.addUpdateClientButton.TabIndex = 6;
            this.addUpdateClientButton.Text = "Добавить/Обновить";
            this.addUpdateClientButton.UseVisualStyleBackColor = false;
            this.addUpdateClientButton.Click += new System.EventHandler(this.addUpdateClientButton_Click);
            // 
            // deleteClientButton
            // 
            this.deleteClientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.deleteClientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteClientButton.FlatAppearance.BorderSize = 0;
            this.deleteClientButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.deleteClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteClientButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteClientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.deleteClientButton.Location = new System.Drawing.Point(12, 455);
            this.deleteClientButton.Name = "deleteClientButton";
            this.deleteClientButton.Size = new System.Drawing.Size(560, 42);
            this.deleteClientButton.TabIndex = 7;
            this.deleteClientButton.Text = "Удалить клиента";
            this.deleteClientButton.UseVisualStyleBackColor = false;
            this.deleteClientButton.Click += new System.EventHandler(this.deleteClientButton_Click);
            // 
            // supplyRichTextBox
            // 
            this.supplyRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplyRichTextBox.Location = new System.Drawing.Point(12, 337);
            this.supplyRichTextBox.Name = "supplyRichTextBox";
            this.supplyRichTextBox.ReadOnly = true;
            this.supplyRichTextBox.Size = new System.Drawing.Size(560, 57);
            this.supplyRichTextBox.TabIndex = 8;
            this.supplyRichTextBox.Text = "";
            // 
            // demandRichTextBox
            // 
            this.demandRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.demandRichTextBox.Location = new System.Drawing.Point(12, 244);
            this.demandRichTextBox.Name = "demandRichTextBox";
            this.demandRichTextBox.ReadOnly = true;
            this.demandRichTextBox.Size = new System.Drawing.Size(560, 57);
            this.demandRichTextBox.TabIndex = 9;
            this.demandRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Список потребностей:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Список предложений:";
            // 
            // ClientInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.demandRichTextBox);
            this.Controls.Add(this.supplyRichTextBox);
            this.Controls.Add(this.deleteClientButton);
            this.Controls.Add(this.addUpdateClientButton);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.lastnameTextBox);
            this.Controls.Add(this.middlenameTextBox);
            this.Controls.Add(this.firstnameTextBox);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о клиенте";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.TextBox middlenameTextBox;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button addUpdateClientButton;
        private System.Windows.Forms.Button deleteClientButton;
        private System.Windows.Forms.RichTextBox supplyRichTextBox;
        private System.Windows.Forms.RichTextBox demandRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}