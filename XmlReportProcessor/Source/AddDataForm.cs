using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace XmlReportProcessor
{
    public partial class AddDataForm : Form
    {
        private string dataFilePath;

        public AddDataForm(string dataFilePath)
        {
            InitializeComponent();
            this.dataFilePath = dataFilePath;
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.txtName = new TextBox();
            this.label2 = new Label();
            this.txtSurname = new TextBox();
            this.label3 = new Label();
            this.txtAmount = new TextBox();
            this.label4 = new Label();
            this.cbMount = new ComboBox();
            this.btnAdd = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            
            // txtName
            this.txtName.Location = new System.Drawing.Point(80, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;
            
            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname:";
            
            // txtSurname
            this.txtSurname.Location = new System.Drawing.Point(80, 42);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 20);
            this.txtSurname.TabIndex = 3;
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount:";
            
            // txtAmount
            this.txtAmount.Location = new System.Drawing.Point(80, 72);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.txtAmount.TabIndex = 5;
            
            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Month:";
            
            // cbMount
            this.cbMount.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbMount.FormattingEnabled = true;
			this.cbMount.Items.AddRange(new object[] {
				"january", "february", "march", "april", "may", "june",
				"july", "august", "september", "october", "november", "december"});
			this.cbMount.Location = new System.Drawing.Point(80, 102);
			this.cbMount.Name = "cbMount";
			this.cbMount.Size = new System.Drawing.Size(150, 21);
			this.cbMount.TabIndex = 7;
			this.cbMount.SelectedIndex = 0;
            
            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            // btnCancel
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // AddDataForm
            this.AcceptButton = this.btnAdd;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(244, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbMount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDataForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add New Data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtName.Text) ||
				string.IsNullOrWhiteSpace(txtSurname.Text) ||
				string.IsNullOrWhiteSpace(txtAmount.Text) ||
				cbMount.SelectedItem == null)
			{
				MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!decimal.TryParse(txtAmount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
			{
				MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				// Загружаем XML-документ
				XmlDocument doc = new XmlDocument();
				doc.Load(dataFilePath);

				// Проверяем, существует ли уже запись для этого сотрудника и месяца
				string xpath = $"/Pay/item[@name='{txtName.Text}' and @surname='{txtSurname.Text}' and @mount='{cbMount.SelectedItem}']";
				XmlNode existingItem = doc.SelectSingleNode(xpath);

				if (existingItem != null)
				{
					// Обновляем существующую запись
					XmlElement itemElement = (XmlElement)existingItem;
					itemElement.SetAttribute("amount", amount.ToString(CultureInfo.InvariantCulture));
					
					MessageBox.Show("Existing record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					// Создаем новый элемент item
					XmlElement newItem = doc.CreateElement("item");
					newItem.SetAttribute("name", txtName.Text);
					newItem.SetAttribute("surname", txtSurname.Text);
					newItem.SetAttribute("amount", amount.ToString(CultureInfo.InvariantCulture));
					newItem.SetAttribute("mount", cbMount.SelectedItem.ToString());

					// Добавляем в корневой элемент Pay
					doc.DocumentElement.AppendChild(newItem);
					
					MessageBox.Show("New record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// Сохраняем изменения
				doc.Save(dataFilePath);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtSurname;
        private Label label3;
        private TextBox txtAmount;
        private Label label4;
        private ComboBox cbMount;
        private Button btnAdd;
        private Button btnCancel;
    }
}