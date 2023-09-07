using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class DemandForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public DemandForm()
        {
            InitializeComponent();
        }

        private void DemandForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            demandPanel.AutoScroll = true;

            UpdateDemandList();
        }

        public void UpdateDemandList()
        {
            demandPanel.Controls.Clear();

            int bottom = 0;

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateFilterSet_ApartmentFilter", connection);
            da.Fill(dt);

            RealEstateFilterApartment[] realEstateFilterApartments = new RealEstateFilterApartment[dt.Rows.Count];

            //Настройка списка кнопок (для квартир)
            for (int i = 0; i < realEstateFilterApartments.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where RealEstate_Type = 'Квартира' and RealEstateFilter_Id = {dt.Rows[i][6]}", connection);
                da1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    RealEstateFilterApartment realEstateFilterApartment = new RealEstateFilterApartment
                    {
                        MinArea = Convert.ToDouble(dt.Rows[i][0]),
                        MaxArea = Convert.ToInt32(dt.Rows[i][1]),
                        MinRooms = Convert.ToInt32(dt.Rows[i][2]),
                        MaxRooms = Convert.ToInt32(dt.Rows[i][3]),
                        MinFloor = Convert.ToInt32(dt.Rows[i][4]),
                        MaxFloor = Convert.ToInt32(dt.Rows[i][5]),
                        Id = Convert.ToInt32(dt1.Rows[0][0]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        MinPrice = Convert.ToInt32(dt1.Rows[0][5]),
                        MaxPrice = Convert.ToInt32(dt1.Rows[0][6]),
                        AgentId = Convert.ToInt32(dt1.Rows[0][7]),
                        ClientId = Convert.ToInt32(dt1.Rows[0][8]),
                        RealEstateFilterId = Convert.ToInt32(dt1.Rows[0][9])
                    };

                    Button button = new Button();

                    button.Name = "Apartment&" + realEstateFilterApartment.Id + "&" + realEstateFilterApartment.RealEstateFilterId;
                    button.Text = $"(Квартира) Мин площадь: {realEstateFilterApartment.MinArea} Макс площадь: {realEstateFilterApartment.MaxArea} ({realEstateFilterApartment.Id})";
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Color.FromArgb(255, 236, 239, 241);
                    button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Roboto", 10);
                    button.Size = new Size(demandPanel.Width, 50);
                    button.Location = new Point(0, bottom);
                    button.Click += Button_Click; ;

                    demandPanel.Controls.Add(button);

                    bottom += 50;
                }
            }

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateFilterSet_HouseFilter", connection);
            da.Fill(dt);

            RealEstateFilterHouse[] realEstateFilterHouses = new RealEstateFilterHouse[dt.Rows.Count];


            //Настройка списка кнопок (для домов)
            for (int i = 0; i < realEstateFilterHouses.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where RealEstate_Type = 'Дом' and RealEstateFilter_Id = {dt.Rows[i][6]}", connection);
                da1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    RealEstateFilterHouse realEstateFilterHouse = new RealEstateFilterHouse
                    {
                        MinFloors = Convert.ToInt32(dt.Rows[i][0]),
                        MaxFloors = Convert.ToInt32(dt.Rows[i][1]),
                        MinArea = Convert.ToDouble(dt.Rows[i][2]),
                        MaxArea = Convert.ToInt32(dt.Rows[i][3]),
                        MinRooms = Convert.ToInt32(dt.Rows[i][4]),
                        MaxRooms = Convert.ToInt32(dt.Rows[i][5]),
                        Id = Convert.ToInt32(dt1.Rows[0][0]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        MinPrice = Convert.ToInt32(dt1.Rows[0][5]),
                        MaxPrice = Convert.ToInt32(dt1.Rows[0][6]),
                        AgentId = Convert.ToInt32(dt1.Rows[0][7]),
                        ClientId = Convert.ToInt32(dt1.Rows[0][8]),
                        RealEstateFilterId = Convert.ToInt32(dt1.Rows[0][9])
                    };

                    Button button = new Button();

                    button.Name = "House&" + realEstateFilterHouse.Id + "&" + realEstateFilterHouse.RealEstateFilterId;
                    button.Text = $"(Дом) Мин площадь: {realEstateFilterHouse.MinArea} Макс площадь: {realEstateFilterHouse.MaxArea} ({realEstateFilterHouse.Id})";
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Color.FromArgb(255, 236, 239, 241);
                    button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Roboto", 10);
                    button.Size = new Size(demandPanel.Width, 50);
                    button.Location = new Point(0, bottom);
                    button.Click += Button_Click;

                    demandPanel.Controls.Add(button);

                    bottom += 50;
                }
            }

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateFilterSet_LandFilter", connection);
            da.Fill(dt);

            RealEstateFilterLand[] realEstateFilterLands = new RealEstateFilterLand[dt.Rows.Count];


            //Настройка списка кнопок (для земель)
            for (int i = 0; i < realEstateFilterLands.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where RealEstate_Type = 'Земля' and RealEstateFilter_Id = {dt.Rows[i][2]}", connection);
                da1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    RealEstateFilterLand realEstateFilterLand = new RealEstateFilterLand
                    {
                        MinArea = Convert.ToDouble(dt.Rows[i][0]),
                        MaxArea = Convert.ToInt32(dt.Rows[i][1]),
                        Id = Convert.ToInt32(dt1.Rows[0][0]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        MinPrice = Convert.ToInt32(dt1.Rows[0][5]),
                        MaxPrice = Convert.ToInt32(dt1.Rows[0][6]),
                        AgentId = Convert.ToInt32(dt1.Rows[0][7]),
                        ClientId = Convert.ToInt32(dt1.Rows[0][8]),
                        RealEstateFilterId = Convert.ToInt32(dt1.Rows[0][9])
                    };

                    Button button = new Button();

                    button.Name = "Land&" + realEstateFilterLand.Id + "&" + realEstateFilterLand.RealEstateFilterId;
                    button.Text = $"(Земля) Мин площадь: {realEstateFilterLand.MinArea} Макс площадь: {realEstateFilterLand.MaxArea} ({realEstateFilterLand.Id})";
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Color.FromArgb(255, 236, 239, 241);
                    button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Roboto", 10);
                    button.Size = new Size(demandPanel.Width, 50);
                    button.Location = new Point(0, bottom);
                    button.Click += Button_Click;

                    demandPanel.Controls.Add(button);

                    bottom += 50;
                }
            }
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            DemandInfoForm demandInfoForm = new DemandInfoForm(((Button)sender).Name, connection, false);
            demandInfoForm.Show();
        }

        //Нажатие на кнопку добавления
        private void addApartmentButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            DemandInfoForm demandInfoForm = new DemandInfoForm("", connection, true);
            demandInfoForm.Show();
        }

        private void DemandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
