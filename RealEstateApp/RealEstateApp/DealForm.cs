using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class DealForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        int dealId;

        public DealForm()
        {
            InitializeComponent();
        }

        private void DealForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            dealPanel.AutoScroll = true;

            UpdateDealList();
        }

        public void UpdateDealList()
        {
            dealPanel.Controls.Clear();

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from DealSet", connection);
            da.Fill(dt);

            //Настройка списка кнопок
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {dt.Rows[i][1]}", connection);
                da1.Fill(dt1);

                Demand Demand = new Demand
                {
                    Id = Convert.ToInt32(dt1.Rows[0][0]),
                    AgentId = Convert.ToInt32(dt1.Rows[0][7]),
                    ClientId = Convert.ToInt32(dt1.Rows[0][8]),
                    RealEstateType = dt1.Rows[0][10].ToString()
                };

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from SupplySet where Id = {dt.Rows[i][2]}", connection);
                da1.Fill(dt1);

                Supply Supply = new Supply
                {
                    Id = Convert.ToInt32(dt1.Rows[0][0]),
                    RealEstateId = Convert.ToInt32(dt1.Rows[0][4])
                };

                Deal deal = new Deal
                {
                    Id = Convert.ToInt32(dt.Rows[i][1]),
                    Demand = Demand,
                    Supply = Supply,
                };

                dealId = Convert.ToInt32(dt.Rows[i][1]);

                Button button = new Button();

                button.Name = dt.Rows[i][0].ToString();
                button.Text = $"({deal.Demand.RealEstateType}) Потребность ({deal.Demand.Id}) --- Предложение ({deal.Supply.Id})";
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(dealPanel.Width, 50);
                button.Location = new Point(0, i * 50);
                button.Click += Button_Click;

                dealPanel.Controls.Add(button);
            }
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            DealInfoForm dealInfoForm = new DealInfoForm(((Button)sender).Name, ((Button)sender).Text.Split('(')[2].Split(')')[0], ((Button)sender).Text.Split('(')[3].Split(')')[0],  connection, false);
            dealInfoForm.Show();
        }

        //Нажатие на кнопку добавления
        private void addDealButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            DealInfoForm dealInfoForm = new DealInfoForm("", "", "", connection, true);
            dealInfoForm.Show();
        }

        private void DealForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
