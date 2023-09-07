namespace RealEstateApp
{
    partial class AgentInfoForm
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
            this.deleteAgentButton = new System.Windows.Forms.Button();
            this.addUpdateAgentButton = new System.Windows.Forms.Button();
            this.dealShareTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.middlenameTextBox = new System.Windows.Forms.TextBox();
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.demandRichTextBox = new System.Windows.Forms.RichTextBox();
            this.supplyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // deleteAgentButton
            // 
            this.deleteAgentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.deleteAgentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAgentButton.FlatAppearance.BorderSize = 0;
            this.deleteAgentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.deleteAgentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAgentButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteAgentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.deleteAgentButton.Location = new System.Drawing.Point(12, 406);
            this.deleteAgentButton.Name = "deleteAgentButton";
            this.deleteAgentButton.Size = new System.Drawing.Size(560, 42);
            this.deleteAgentButton.TabIndex = 14;
            this.deleteAgentButton.Text = "Удалить риэлтора";
            this.deleteAgentButton.UseVisualStyleBackColor = false;
            this.deleteAgentButton.Click += new System.EventHandler(this.deleteAgentButton_Click);
            // 
            // addUpdateAgentButton
            // 
            this.addUpdateAgentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addUpdateAgentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUpdateAgentButton.FlatAppearance.BorderSize = 0;
            this.addUpdateAgentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addUpdateAgentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addUpdateAgentButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addUpdateAgentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addUpdateAgentButton.Location = new System.Drawing.Point(12, 358);
            this.addUpdateAgentButton.Name = "addUpdateAgentButton";
            this.addUpdateAgentButton.Size = new System.Drawing.Size(560, 42);
            this.addUpdateAgentButton.TabIndex = 13;
            this.addUpdateAgentButton.Text = "Добавить/Обновить";
            this.addUpdateAgentButton.UseVisualStyleBackColor = false;
            this.addUpdateAgentButton.Click += new System.EventHandler(this.addUpdateAgentButton_Click);
            // 
            // dealShareTextBox
            // 
            this.dealShareTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dealShareTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.dealShareTextBox.Location = new System.Drawing.Point(12, 135);
            this.dealShareTextBox.MaxLength = 11;
            this.dealShareTextBox.Name = "dealShareTextBox";
            this.dealShareTextBox.Size = new System.Drawing.Size(560, 30);
            this.dealShareTextBox.TabIndex = 11;
            this.dealShareTextBox.Text = "0";
            this.dealShareTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dealShareTextBox_KeyPress);
            this.dealShareTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dealShareTextBox_KeyUp);
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastnameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.lastnameTextBox.Location = new System.Drawing.Point(12, 94);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(560, 30);
            this.lastnameTextBox.TabIndex = 10;
            this.lastnameTextBox.Text = "Отчество";
            this.lastnameTextBox.Enter += new System.EventHandler(this.lastnameTextBox_Enter);
            this.lastnameTextBox.Leave += new System.EventHandler(this.lastnameTextBox_Leave);
            // 
            // middlenameTextBox
            // 
            this.middlenameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.middlenameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.middlenameTextBox.Location = new System.Drawing.Point(12, 53);
            this.middlenameTextBox.Name = "middlenameTextBox";
            this.middlenameTextBox.Size = new System.Drawing.Size(560, 30);
            this.middlenameTextBox.TabIndex = 9;
            this.middlenameTextBox.Text = "Имя";
            this.middlenameTextBox.Enter += new System.EventHandler(this.middlenameTextBox_Enter);
            this.middlenameTextBox.Leave += new System.EventHandler(this.middlenameTextBox_Leave);
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstnameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.firstnameTextBox.Location = new System.Drawing.Point(12, 12);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(560, 30);
            this.firstnameTextBox.TabIndex = 8;
            this.firstnameTextBox.Text = "Фамилия";
            this.firstnameTextBox.Enter += new System.EventHandler(this.firstnameTextBox_Enter);
            this.firstnameTextBox.Leave += new System.EventHandler(this.firstnameTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(8, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Список предложений:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(8, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Список потребностей:";
            // 
            // demandRichTextBox
            // 
            this.demandRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.demandRichTextBox.Location = new System.Drawing.Point(12, 199);
            this.demandRichTextBox.Name = "demandRichTextBox";
            this.demandRichTextBox.ReadOnly = true;
            this.demandRichTextBox.Size = new System.Drawing.Size(560, 57);
            this.demandRichTextBox.TabIndex = 22;
            this.demandRichTextBox.Text = "";
            // 
            // supplyRichTextBox
            // 
            this.supplyRichTextBox.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplyRichTextBox.Location = new System.Drawing.Point(12, 290);
            this.supplyRichTextBox.Name = "supplyRichTextBox";
            this.supplyRichTextBox.ReadOnly = true;
            this.supplyRichTextBox.Size = new System.Drawing.Size(560, 57);
            this.supplyRichTextBox.TabIndex = 21;
            this.supplyRichTextBox.Text = "";
            // 
            // AgentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.demandRichTextBox);
            this.Controls.Add(this.supplyRichTextBox);
            this.Controls.Add(this.deleteAgentButton);
            this.Controls.Add(this.addUpdateAgentButton);
            this.Controls.Add(this.dealShareTextBox);
            this.Controls.Add(this.lastnameTextBox);
            this.Controls.Add(this.middlenameTextBox);
            this.Controls.Add(this.firstnameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgentInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о риэлторе";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgentInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.AgentInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteAgentButton;
        private System.Windows.Forms.Button addUpdateAgentButton;
        private System.Windows.Forms.TextBox dealShareTextBox;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox middlenameTextBox;
        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox demandRichTextBox;
        private System.Windows.Forms.RichTextBox supplyRichTextBox;
    }
}