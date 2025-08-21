using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace XmlReportProcessor
{
    public partial class MainForm : Form
    {
        private string projectRoot;
        private DataTable dataTable;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private void InitializeComponent()
        {
            this.btnProcess = new Button();
            this.dataGridView = new DataGridView();
            this.cbDataFile = new ComboBox();
            this.label1 = new Label();
            this.btnAddData = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            
            // btnProcess
            this.btnProcess.Location = new System.Drawing.Point(12, 40);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(120, 30);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process Data";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            
            // dataGridView
            this.dataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 80);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(760, 380);
            this.dataGridView.TabIndex = 1;
            
            // cbDataFile
            this.cbDataFile.FormattingEnabled = true;
            this.cbDataFile.Items.AddRange(new object[] {
            "Data1.xml",
            "Data2.xml"});
            this.cbDataFile.Location = new System.Drawing.Point(100, 12);
            this.cbDataFile.Name = "cbDataFile";
            this.cbDataFile.Size = new System.Drawing.Size(120, 21);
            this.cbDataFile.TabIndex = 2;
            this.cbDataFile.SelectedIndex = 0;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Data File:";
            
            // btnAddData
            this.btnAddData.Location = new System.Drawing.Point(150, 40);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(120, 30);
            this.btnAddData.TabIndex = 4;
            this.btnAddData.Text = "Add Data";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            
            // MainForm
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDataFile);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnProcess);
            this.Name = "MainForm";
            this.Text = "XML Report Processor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Employee", typeof(string));
            dataTable.Columns.Add("January", typeof(decimal));
            dataTable.Columns.Add("February", typeof(decimal));
            dataTable.Columns.Add("March", typeof(decimal));
            dataTable.Columns.Add("Total", typeof(decimal));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\portfolio\\XmlReportProcessor\\";
            dataGridView.DataSource = dataTable;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string dataFileName = cbDataFile.SelectedItem.ToString();
                string dataPath = Path.Combine(projectRoot, "Data", dataFileName);
                string xsltPath = Path.Combine(projectRoot, "Resources", "TransformToEmployees.xslt");
                string employeesPath = Path.Combine(projectRoot, "Data", "Employees.xml");

                // 1. Запускаем XSLT-преобразование
                RunXsltTransformation(dataPath, xsltPath, employeesPath);
                
                // 2. Добавляем атрибут с суммой salary для каждого Employee
                AddSalarySumAttribute(employeesPath);
                
                // 3. Добавляем атрибут с общей суммой только для Data1.xml
                if (dataFileName == "Data1.xml")
                {
                    AddTotalSumAttribute(dataPath);
                }
                
                // 4. Обновляем DataGridView
                UpdateDataGridView(employeesPath);
                
                MessageBox.Show("Processing completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunXsltTransformation(string xmlPath, string xsltPath, string outputPath)
        {
            var xslt = new XslCompiledTransform();
            xslt.Load(xsltPath);
            xslt.Transform(xmlPath, outputPath);
        }

        private void AddSalarySumAttribute(string xmlPath)
        {
            var doc = new XmlDocument();
            doc.Load(xmlPath);

            var employees = doc.SelectNodes("/Employees/Employee");
            foreach (XmlElement employee in employees)
            {
                decimal totalSalary = 0;
                var salaries = employee.SelectNodes("salary");
                
                foreach (XmlElement salary in salaries)
                {
                    string amountValue = salary.GetAttribute("amount");
                    if (decimal.TryParse(amountValue.Replace(',', '.'), 
                                        NumberStyles.Any, 
                                        CultureInfo.InvariantCulture, 
                                        out decimal amount))
                    {
                        totalSalary += amount;
                    }
                }
                
                employee.SetAttribute("total-salary", totalSalary.ToString("F2", CultureInfo.InvariantCulture));
            }

            doc.Save(xmlPath);
        }

        private void AddTotalSumAttribute(string xmlPath)
        {
            var doc = new XmlDocument();
            doc.Load(xmlPath);

            decimal totalAmount = 0;
            var items = doc.SelectNodes("//item");
            
            foreach (XmlElement item in items)
            {
                string amountValue = item.GetAttribute("amount");
                if (decimal.TryParse(amountValue.Replace(',', '.'), 
                                    NumberStyles.Any, 
                                    CultureInfo.InvariantCulture, 
                                    out decimal amount))
                {
                    totalAmount += amount;
                }
            }

            var payElement = doc.DocumentElement;
            payElement.SetAttribute("total", totalAmount.ToString("F2", CultureInfo.InvariantCulture));
            
            doc.Save(xmlPath);
        }

        private void UpdateDataGridView(string xmlPath)
        {
            dataTable.Rows.Clear();

            var doc = new XmlDocument();
            doc.Load(xmlPath);

            var employees = doc.SelectNodes("/Employees/Employee");
            foreach (XmlElement employee in employees)
            {
                string employeeName = $"{employee.GetAttribute("name")} {employee.GetAttribute("surname")}";
                decimal totalSalary = decimal.Parse(employee.GetAttribute("total-salary"), CultureInfo.InvariantCulture);
                
                DataRow row = dataTable.NewRow();
                row["Employee"] = employeeName;
                row["Total"] = totalSalary;

                var salaries = employee.SelectNodes("salary");
                foreach (XmlElement salary in salaries)
                {
                    string mount = salary.GetAttribute("mount");
                    decimal amount = decimal.Parse(salary.GetAttribute("amount").Replace(',', '.'), CultureInfo.InvariantCulture);
                    
                    switch (mount.ToLower())
                    {
                        case "january": row["January"] = amount; break;
                        case "february": row["February"] = amount; break;
                        case "march": row["March"] = amount; break;
                    }
                }

                dataTable.Rows.Add(row);
            }
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            // Реализация добавления данных будет в следующем шаге
            MessageBox.Show("This feature will be implemented in the next step", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Button btnProcess;
        private DataGridView dataGridView;
        private ComboBox cbDataFile;
        private Label label1;
        private Button btnAddData;
    }
}