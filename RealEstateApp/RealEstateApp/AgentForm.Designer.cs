namespace RealEstateApp
{
    partial class AgentForm
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
            this.agentPanel = new System.Windows.Forms.Panel();
            this.addAgentButton = new System.Windows.Forms.Button();
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
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Поиск:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(59)))));
            this.searchTextBox.Location = new System.Drawing.Point(84, 86);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(586, 30);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
            // 
            // agentPanel
            // 
            this.agentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.agentPanel.Location = new System.Drawing.Point(12, 127);
            this.agentPanel.Name = "agentPanel";
            this.agentPanel.Size = new System.Drawing.Size(658, 266);
            this.agentPanel.TabIndex = 10;
            // 
            // addAgentButton
            // 
            this.addAgentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.addAgentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addAgentButton.FlatAppearance.BorderSize = 0;
            this.addAgentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.addAgentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAgentButton.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addAgentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.addAgentButton.Location = new System.Drawing.Point(12, 399);
            this.addAgentButton.Name = "addAgentButton";
            this.addAgentButton.Size = new System.Drawing.Size(658, 42);
            this.addAgentButton.TabIndex = 6;
            this.addAgentButton.Text = "Добавить риэлтора";
            this.addAgentButton.UseVisualStyleBackColor = false;
            this.addAgentButton.Click += new System.EventHandler(this.addAgentButton_Click);
            // 
            // AgentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.addAgentButton);
            this.Controls.Add(this.agentPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AgentForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Риэлторы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgentForm_FormClosing);
            this.Load += new System.EventHandler(this.AgentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel agentPanel;
        private System.Windows.Forms.Button addAgentButton;
    }
}