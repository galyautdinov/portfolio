using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class SupplyForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public SupplyForm()
        {
            InitializeComponent();
        }

        private void SupplyForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            supplyPanel.AutoScroll = true;

            UpdateSupplyList();
        }

        public void UpdateSupplyList()
        {
            supplyPanel.Controls.Clear();

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from SupplySet", connection);
            da.Fill(dt);

            //Настройка списка кнопок
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button button = new Button();

                button.Name = dt.Rows[i][0].ToString();

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[i][2]}", connection);
                da1.Fill(dt1);

                string agentName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString()} {dt1.Rows[0][3].ToString()}";

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[i][3]}", connection);
                da1.Fill(dt1);

                string clientName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString()} {dt1.Rows[0][3].ToString()}";

                button.Text = $"Клиент: {clientName} --- Риэлтор: {agentName}";
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(supplyPanel.Width, 50);
                button.Location = new Point(0, i * 50);
                button.Click += Button_Click; ;

                supplyPanel.Controls.Add(button);
            }
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            SupplyInfoForm supplyInfoForm = new SupplyInfoForm(((Button)sender).Name, connection, false);
            supplyInfoForm.Show();
        }

        //Нажатие на кнопку добавления
        private void addSupplyButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            SupplyInfoForm supplyInfoForm = new SupplyInfoForm("", connection, true);
            supplyInfoForm.Show();
        }

        private void SupplyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
