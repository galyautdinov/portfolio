using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class DemandInfoForm : Form
    {
        string demandId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public DemandInfoForm(string DemandId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            demandId = DemandId;
            connection = Connection;
            fromAdd = FromAdd;
        }

        private void DemandInfoForm_Load(object sender, EventArgs e)
        {
            //Настройка размера списков
            agentComboBox.DropDownWidth = 400;
            clientComboBox.DropDownWidth = 400;

            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                RealEstateComboBox.Enabled = false;

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                da.Fill(dt);

                Demand demand = new Demand
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    AddressCity = dt.Rows[0][1].ToString(),
                    AddressStreet = dt.Rows[0][2].ToString(),
                    AddressHouse = dt.Rows[0][3].ToString(),
                    AddressNumber = dt.Rows[0][4].ToString(),
                    MinPrice = Convert.ToInt32(dt.Rows[0][5]),
                    MaxPrice = Convert.ToInt32(dt.Rows[0][6]),
                    AgentId = Convert.ToInt32(dt.Rows[0][7]),
                    ClientId = Convert.ToInt32(dt.Rows[0][8]),
                    RealEstateFilterId = Convert.ToInt32(dt.Rows[0][9]),
                    RealEstateType = dt.Rows[0][10].ToString()
                };

                //Заполнение списков и полей
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    agentComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {demand.AgentId}", connection);
                da.Fill(dt);

                agentComboBox.SelectedItem = $"{dt.Rows[0][1].ToString()} {dt.Rows[0][2].ToString()} {dt.Rows[0][3].ToString()} ({dt.Rows[0][0].ToString()})";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    clientComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");


                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {demand.ClientId}", connection);
                da.Fill(dt);

                clientComboBox.SelectedItem = $"{dt.Rows[0][1].ToString()} {dt.Rows[0][2].ToString()} {dt.Rows[0][3].ToString()} ({dt.Rows[0][0].ToString()})";

                if(demand.RealEstateType == "Квартира")
                    RealEstateComboBox.SelectedItem = "Квартира";
                else if (demand.RealEstateType == "Дом")
                    RealEstateComboBox.SelectedItem = "Дом";
                else if (demand.RealEstateType == "Земля")
                    RealEstateComboBox.SelectedItem = "Земля";

                //Заполнение списков и полей (для квартиры)
                if (demandId.Split('&')[0] == "Apartment")
                {
                    Text = "Информация о потребности в квартире";
                    addUpdateDemandButton.Text = "Обновить потребность в квартире";
                    deleteDemandButton.Text = "Удалить потребность в квартире";

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_ApartmentFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateFilterApartment realEstateFilterApartment = new RealEstateFilterApartment
                    {
                        MinArea = Convert.ToDouble(dt.Rows[0][0]),
                        MaxArea = Convert.ToInt32(dt.Rows[0][1]),
                        MinRooms = Convert.ToInt32(dt.Rows[0][2]),
                        MaxRooms = Convert.ToInt32(dt.Rows[0][3]),
                        MinFloor = Convert.ToInt32(dt.Rows[0][4]),
                        MaxFloor = Convert.ToInt32(dt.Rows[0][5]),
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

                    if (realEstateFilterApartment.AddressCity != "")
                        cityTextBox.Text = realEstateFilterApartment.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateFilterApartment.AddressStreet != "")
                        streetTextBox.Text = realEstateFilterApartment.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateFilterApartment.AddressHouse != "")
                        houseTextBox.Text = realEstateFilterApartment.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateFilterApartment.AddressNumber != "")
                        numberTextBox.Text = realEstateFilterApartment.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Квартира";
                    }
                    if (realEstateFilterApartment.MinPrice.ToString() != "")
                        minPriceTextBox.Text = realEstateFilterApartment.MinPrice.ToString();
                    else
                    {
                        minPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minPriceTextBox.Text = "Минимальная цена";
                    }
                    if (realEstateFilterApartment.MaxPrice.ToString() != "")
                        maxPriceTextBox.Text = realEstateFilterApartment.MaxPrice.ToString();
                    else
                    {
                        maxPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxPriceTextBox.Text = "Максимальная цена";
                    }
                    if (realEstateFilterApartment.MinArea.ToString() != "")
                        minAreaTextBox.Text = realEstateFilterApartment.MinArea.ToString();
                    else
                    {
                        minAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minAreaTextBox.Text = "Минимальная площаль";
                    }
                    if (realEstateFilterApartment.MaxArea.ToString() != "")
                        maxAreaTextBox.Text = realEstateFilterApartment.MaxArea.ToString();
                    else
                    {
                        maxAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxAreaTextBox.Text = "Максимальная площаль";
                    }
                    if (realEstateFilterApartment.MinRooms.ToString() != "")
                        minRoomsTextBox.Text = realEstateFilterApartment.MinRooms.ToString();
                    else
                    {
                        minRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minRoomsTextBox.Text = "Минимальное количество комнат";
                    }
                    if (realEstateFilterApartment.MaxRooms.ToString() != "")
                        maxRoomsTextBox.Text = realEstateFilterApartment.MaxRooms.ToString();
                    else
                    {
                        maxRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxRoomsTextBox.Text = "Максимальное количество комнат";
                    }
                    if (realEstateFilterApartment.MinFloor.ToString() != "")
                        minFloorsTextBox.Text = realEstateFilterApartment.MinFloor.ToString();
                    else
                    {
                        minFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minFloorsTextBox.Text = "Минимальный этаж";
                    }
                    if (realEstateFilterApartment.MaxFloor.ToString() != "")
                        maxFloorsTextBox.Text = realEstateFilterApartment.MaxFloor.ToString();
                    else
                    {
                        maxFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxFloorsTextBox.Text = "Максимальный этаж";
                    }
                }
                //Заполнение списков и полей (для дома)
                else if (demandId.Split('&')[0] == "House")
                {
                    Text = "Информация о потребности в доме";
                    addUpdateDemandButton.Text = "Обновить потребность в доме";
                    deleteDemandButton.Text = "Удалить потребность в доме";

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_HouseFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateFilterHouse realEstateFilterHouse = new RealEstateFilterHouse
                    {
                        MinFloors = Convert.ToInt32(dt.Rows[0][0]),
                        MaxFloors = Convert.ToInt32(dt.Rows[0][1]),
                        MinArea = Convert.ToDouble(dt.Rows[0][2]),
                        MaxArea = Convert.ToInt32(dt.Rows[0][3]),
                        MinRooms = Convert.ToInt32(dt.Rows[0][4]),
                        MaxRooms = Convert.ToInt32(dt.Rows[0][5]),
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

                    if (realEstateFilterHouse.AddressCity != "")
                        cityTextBox.Text = realEstateFilterHouse.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateFilterHouse.AddressStreet != "")
                        streetTextBox.Text = realEstateFilterHouse.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateFilterHouse.AddressHouse != "")
                        houseTextBox.Text = realEstateFilterHouse.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateFilterHouse.AddressNumber != "")
                        numberTextBox.Text = realEstateFilterHouse.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Квартира";
                    }
                    if (realEstateFilterHouse.MinPrice.ToString() != "")
                        minPriceTextBox.Text = realEstateFilterHouse.MinPrice.ToString();
                    else
                    {
                        minPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minPriceTextBox.Text = "Минимальная цена";
                    }
                    if (realEstateFilterHouse.MaxPrice.ToString() != "")
                        maxPriceTextBox.Text = realEstateFilterHouse.MaxPrice.ToString();
                    else
                    {
                        maxPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxPriceTextBox.Text = "Максимальная цена";
                    }
                    if (realEstateFilterHouse.MinArea.ToString() != "")
                        minAreaTextBox.Text = realEstateFilterHouse.MinArea.ToString();
                    else
                    {
                        minAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minAreaTextBox.Text = "Минимальная площаль";
                    }
                    if (realEstateFilterHouse.MaxArea.ToString() != "")
                        maxAreaTextBox.Text = realEstateFilterHouse.MaxArea.ToString();
                    else
                    {
                        maxAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxAreaTextBox.Text = "Максимальная площаль";
                    }
                    if (realEstateFilterHouse.MinRooms.ToString() != "")
                        minRoomsTextBox.Text = realEstateFilterHouse.MinRooms.ToString();
                    else
                    {
                        minRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minRoomsTextBox.Text = "Минимальное количество комнат";
                    }
                    if (realEstateFilterHouse.MaxRooms.ToString() != "")
                        maxRoomsTextBox.Text = realEstateFilterHouse.MaxRooms.ToString();
                    else
                    {
                        maxRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxRoomsTextBox.Text = "Максимальное количество комнат";
                    }
                    if (realEstateFilterHouse.MinFloors.ToString() != "")
                        minFloorsTextBox.Text = realEstateFilterHouse.MinFloors.ToString();
                    else
                    {
                        minFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minFloorsTextBox.Text = "Минимальное количество этажей";
                    }
                    if (realEstateFilterHouse.MaxFloors.ToString() != "")
                        maxFloorsTextBox.Text = realEstateFilterHouse.MaxFloors.ToString();
                    else
                    {
                        maxFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxFloorsTextBox.Text = "Максимальное количество этажей";
                    }
                }
                //Заполнение списков и полей (для земли)
                else if (demandId.Split('&')[0] == "Land")
                {
                    Text = "Информация о потребности в земле";
                    addUpdateDemandButton.Text = "Обновить потребность в земле";
                    deleteDemandButton.Text = "Удалить потребность в земле";
                    maxRoomsTextBox.Visible = false;
                    minRoomsTextBox.Visible = false;
                    maxFloorsTextBox.Visible = false;
                    minFloorsTextBox.Visible = false;

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_LandFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateFilterLand realEstateFilterLand = new RealEstateFilterLand
                    {
                        MinArea = Convert.ToDouble(dt.Rows[0][0]),
                        MaxArea = Convert.ToInt32(dt.Rows[0][1]),
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

                    if (realEstateFilterLand.AddressCity != "")
                        cityTextBox.Text = realEstateFilterLand.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateFilterLand.AddressStreet != "")
                        streetTextBox.Text = realEstateFilterLand.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateFilterLand.AddressHouse != "")
                        houseTextBox.Text = realEstateFilterLand.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateFilterLand.AddressNumber != "")
                        numberTextBox.Text = realEstateFilterLand.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Квартира";
                    }
                    if (realEstateFilterLand.MinPrice.ToString() != "")
                        minPriceTextBox.Text = realEstateFilterLand.MinPrice.ToString();
                    else
                    {
                        minPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minPriceTextBox.Text = "Минимальная цена";
                    }
                    if (realEstateFilterLand.MaxPrice.ToString() != "")
                        maxPriceTextBox.Text = realEstateFilterLand.MaxPrice.ToString();
                    else
                    {
                        maxPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxPriceTextBox.Text = "Максимальная цена";
                    }
                    if (realEstateFilterLand.MinArea.ToString() != "")
                        minAreaTextBox.Text = realEstateFilterLand.MinArea.ToString();
                    else
                    {
                        minAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        minAreaTextBox.Text = "Минимальная площаль";
                    }
                    if (realEstateFilterLand.MaxArea.ToString() != "")
                        maxAreaTextBox.Text = realEstateFilterLand.MaxArea.ToString();
                    else
                    {
                        maxAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        maxAreaTextBox.Text = "Максимальная площаль";
                    }
                }
            }
            //Если форма открыта с помощью кнопки добавения
            else
            {
                clientComboBox.SelectedItem = "";
                agentComboBox.SelectedItem = "";
                RealEstateComboBox.SelectedItem = "Квартира";

                //Заполнение списков
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    agentComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    clientComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");

                foreach (TextBox obj in Controls.OfType<TextBox>())
                    obj.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void addUpdateDemandButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                if (RealEstateComboBox.SelectedItem.ToString() == "Квартира")
                {
                    //Проверка незаполненных полей
                    if (clientComboBox.SelectedItem == null || agentComboBox.SelectedItem == null || RealEstateComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Есть незаполненные поля выбора");
                    }
                    else
                    {
                        nullTextBoxChange();

                        dt.Reset();
                        da.SelectCommand = new SqlCommand($"select max(Id)+1 from RealEstateFilterSet", connection);
                        da.Fill(dt);

                        int maxId = Convert.ToInt32(dt.Rows[0][0]);

                        //Добавление потребности в квартире
                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet values({maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into DemandSet(Address_City, Address_Street, Address_House, Address_Number, MinPrice, MaxPrice, AgentId, ClientId, RealEstateFilter_Id, RealEstate_Type) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {minPriceTextBox.Text}, {maxPriceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {maxId}, 'Квартира')", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet_ApartmentFilter values({minAreaTextBox.Text.Replace(',', '.')}, {maxAreaTextBox.Text.Replace(',', '.')}, {minRoomsTextBox.Text}, {maxRoomsTextBox.Text}, {minFloorsTextBox.Text}, {maxFloorsTextBox.Text}, {maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        MessageBox.Show("Потребность в квартире добавлена");
                        Close();
                    }
                }
                else if (RealEstateComboBox.SelectedItem.ToString() == "Дом")
                {
                    //Проверка незаполненных полей
                    if (clientComboBox.SelectedItem == null || agentComboBox.SelectedItem == null || RealEstateComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Есть незаполненные поля выбора");
                    }
                    else
                    {
                        nullTextBoxChange();

                        dt.Reset();
                        da.SelectCommand = new SqlCommand($"select max(Id)+1 from RealEstateFilterSet", connection);
                        da.Fill(dt);

                        int maxId = Convert.ToInt32(dt.Rows[0][0]);

                        //Добавление потребности в доме
                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet values({maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into DemandSet(Address_City, Address_Street, Address_House, Address_Number, MinPrice, MaxPrice, AgentId, ClientId, RealEstateFilter_Id, RealEstate_Type) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {minPriceTextBox.Text}, {maxPriceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {maxId}, 'Дом')", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet_HouseFilter values({minFloorsTextBox.Text}, {maxFloorsTextBox.Text}, {minAreaTextBox.Text.Replace(',', '.')}, {maxAreaTextBox.Text.Replace(',', '.')}, {minRoomsTextBox.Text}, {maxRoomsTextBox.Text}, {maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        MessageBox.Show("Потребность в доме добавлена");
                        Close();
                    }
                }
                else if (RealEstateComboBox.SelectedItem.ToString() == "Земля")
                {
                    //Проверка незаполненных полей
                    if (clientComboBox.SelectedItem == null || agentComboBox.SelectedItem == null || RealEstateComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Есть незаполненные поля выбора");
                    }
                    else
                    {
                        nullTextBoxChange();

                        dt.Reset();
                        da.SelectCommand = new SqlCommand($"select max(Id)+1 from RealEstateFilterSet", connection);
                        da.Fill(dt);

                        int maxId = Convert.ToInt32(dt.Rows[0][0]);

                        //Добавление потребности в земле
                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet values({maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into DemandSet(Address_City, Address_Street, Address_House, Address_Number, MinPrice, MaxPrice, AgentId, ClientId, RealEstateFilter_Id, RealEstate_Type) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {minPriceTextBox.Text}, {maxPriceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {maxId}, 'Земля')", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        da.InsertCommand = new SqlCommand($"insert into RealEstateFilterSet_LandFilter values({minAreaTextBox.Text.Replace(',', '.')}, {maxAreaTextBox.Text.Replace(',', '.')}, {maxId})", connection);
                        da.InsertCommand.ExecuteNonQuery();

                        MessageBox.Show("Потребность в земле добавлена");
                        Close();
                    }
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                if (RealEstateComboBox.SelectedItem.ToString() == "Квартира")
                {
                    nullTextBoxChange();

                    //Обновление квартирного предложения
                    da.UpdateCommand = new SqlCommand($"update DemandSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', MinPrice = {minPriceTextBox.Text}, MaxPrice = {maxPriceTextBox.Text}, AgentId = {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, ClientId = {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, RealEstate_Type = 'Квартира' where Id = {demandId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateFilterSet_ApartmentFilter set MinArea = {minAreaTextBox.Text.Replace(',', '.')}, MaxArea = {maxAreaTextBox.Text.Replace(',', '.')}, MinRooms = {minRoomsTextBox.Text}, MaxRooms = {maxRoomsTextBox.Text}, MinFloor = {minFloorsTextBox.Text}, MaxFloor = {maxFloorsTextBox.Text} where Id = {demandId.Split('&')[2]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в квартире обновлена");
                    Close();
                }
                else if (RealEstateComboBox.SelectedItem.ToString() == "Дом")
                {
                    nullTextBoxChange();

                    //Обновление домового предложения
                    da.UpdateCommand = new SqlCommand($"update DemandSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', MinPrice = {minPriceTextBox.Text}, MaxPrice = {maxPriceTextBox.Text}, AgentId = {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, ClientId = {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, RealEstate_Type = 'Дом' where Id = {demandId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateFilterSet_HouseFilter set MinArea = {minAreaTextBox.Text.Replace(',', '.')}, MaxArea = {maxAreaTextBox.Text.Replace(',', '.')}, MinRooms = {minRoomsTextBox.Text}, MaxRooms = {maxRoomsTextBox.Text}, MinFloors = {minFloorsTextBox.Text}, MaxFloors = {maxFloorsTextBox.Text} where Id = {demandId.Split('&')[2]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в доме обновлена");
                    Close();
                }
                else if (RealEstateComboBox.SelectedItem.ToString() == "Земля")
                {
                    nullTextBoxChange();

                    //Обновление земельного предложения
                    da.UpdateCommand = new SqlCommand($"update DemandSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', MinPrice = {minPriceTextBox.Text}, MaxPrice = {maxPriceTextBox.Text}, AgentId = {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, ClientId = {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, RealEstate_Type = 'Земля' where Id = {demandId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateFilterSet_LandFilter set MinArea = {minAreaTextBox.Text.Replace(',', '.')}, MaxArea = {maxAreaTextBox.Text.Replace(',', '.')} where Id = {demandId.Split('&')[2]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в земле обновлена");
                    Close();
                }
            }
        }

        private void nullTextBoxChange()
        {
            //Подготовка полей к запросу
            if (cityTextBox.Text == "Город")
                cityTextBox.Text = "";
            if (streetTextBox.Text == "Улица")
                streetTextBox.Text = "";
            if (houseTextBox.Text == "Дом")
                houseTextBox.Text = "";
            if (numberTextBox.Text == "Квартира")
                numberTextBox.Text = "";
            if (minPriceTextBox.Text == "Минимальная цена")
                minPriceTextBox.Text = "0";
            if (maxPriceTextBox.Text == "Максимальная цена")
                maxPriceTextBox.Text = "1000000000";
            if (minAreaTextBox.Text == "Минимальная площадь")
                minAreaTextBox.Text = "0";
            if (maxAreaTextBox.Text == "Максимальная площадь")
                maxAreaTextBox.Text = "1000000000";
            if (minFloorsTextBox.Text == "Минимальный этаж" || minFloorsTextBox.Text == "Минимальное количество этажей")
                minFloorsTextBox.Text = "0";
            if (maxFloorsTextBox.Text == "Максимальный этаж" || maxFloorsTextBox.Text == "Максимальное количество этажей")
                maxFloorsTextBox.Text = "1000";
            if (minRoomsTextBox.Text == "Минимальное количество комнат")
                minRoomsTextBox.Text = "0";
            if (maxRoomsTextBox.Text == "Максимальное количество комнат")
                maxRoomsTextBox.Text = "1000000000";
        }

        private void deleteDemandButton_Click(object sender, EventArgs e)
        {
            if (RealEstateComboBox.SelectedItem.ToString() == "Квартира")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DealSet where Demand_Id = {demandId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей со сделкой
                if (dt.Rows.Count == 0)
                {
                    //Удаление квартиры
                    da.DeleteCommand = new SqlCommand($"delete from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet_ApartmentFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в квартире удалена");
                    Close();
                }
                else
                {
                    MessageBox.Show("Потребность в квартире связана со сделкой. Удаление невозможно");
                }
            }
            else if (RealEstateComboBox.SelectedItem.ToString() == "Дом")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DealSet where Demand_Id = {demandId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей со сделкой
                if (dt.Rows.Count == 0)
                {
                    //Удаление дома
                    da.DeleteCommand = new SqlCommand($"delete from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet_HouseFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в доме удалена");
                    Close();
                }
                else
                {
                    MessageBox.Show("Потребность в доме связана со сделкой. Удаление невозможно");
                }
            }
            else if (RealEstateComboBox.SelectedItem.ToString() == "Земля")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DealSet where Demand_Id = {demandId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей со сделкой
                if (dt.Rows.Count == 0)
                {
                    //Удаление земли
                    da.DeleteCommand = new SqlCommand($"delete from DemandSet where Id = {demandId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateFilterSet_LandFilter where Id = {demandId.Split('&')[2]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Потребность в земле удалена");
                    Close();
                }
                else
                {
                    MessageBox.Show("Потребность в земле связана со сделкой. Удаление невозможно");
                }
            }
        }

        private void cityTextBox_Enter(object sender, EventArgs e)
        {
            if (cityTextBox.Text == "Город")
            {
                cityTextBox.Text = null;
                cityTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void cityTextBox_Leave(object sender, EventArgs e)
        {
            if (cityTextBox.Text == "")
            {
                cityTextBox.Text = "Город";
                cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void streetTextBox_Enter(object sender, EventArgs e)
        {
            if (streetTextBox.Text == "Улица")
            {
                streetTextBox.Text = null;
                streetTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void streetTextBox_Leave(object sender, EventArgs e)
        {
            if (streetTextBox.Text == "")
            {
                streetTextBox.Text = "Улица";
                streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void houseTextBox_Enter(object sender, EventArgs e)
        {
            if (houseTextBox.Text == "Дом")
            {
                houseTextBox.Text = null;
                houseTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void houseTextBox_Leave(object sender, EventArgs e)
        {
            if (houseTextBox.Text == "")
            {
                houseTextBox.Text = "Дом";
                houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void numberTextBox_Enter(object sender, EventArgs e)
        {
            if (numberTextBox.Text == "Квартира")
            {
                numberTextBox.Text = null;
                numberTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void numberTextBox_Leave(object sender, EventArgs e)
        {
            if (numberTextBox.Text == "")
            {
                numberTextBox.Text = "Квартира";
                numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void minPriceTextBox_Enter(object sender, EventArgs e)
        {
            if (minPriceTextBox.Text == "Минимальная цена")
            {
                minPriceTextBox.Text = null;
                minPriceTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void minPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (minPriceTextBox.Text == "")
            {
                minPriceTextBox.Text = "Минимальная цена";
                minPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void maxPriceTextBox_Enter(object sender, EventArgs e)
        {
            if (maxPriceTextBox.Text == "Максимальная цена")
            {
                maxPriceTextBox.Text = null;
                maxPriceTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void maxPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (maxPriceTextBox.Text == "")
            {
                maxPriceTextBox.Text = "Максимальная цена";
                maxPriceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void minAreaTextBox_Enter(object sender, EventArgs e)
        {
            if (minAreaTextBox.Text == "Минимальная площадь")
            {
                minAreaTextBox.Text = null;
                minAreaTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void minAreaTextBox_Leave(object sender, EventArgs e)
        {
            if (minAreaTextBox.Text == "")
            {
                minAreaTextBox.Text = "Минимальная площадь";
                minAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void maxAreaTextBox_Enter(object sender, EventArgs e)
        {
            if (maxAreaTextBox.Text == "Максимальная площадь")
            {
                maxAreaTextBox.Text = null;
                maxAreaTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void maxAreaTextBox_Leave(object sender, EventArgs e)
        {
            if (maxAreaTextBox.Text == "")
            {
                maxAreaTextBox.Text = "Максимальная площадь";
                maxAreaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void minRoomsTextBox_Enter(object sender, EventArgs e)
        {
            if (minRoomsTextBox.Text == "Минимальное количество комнат")
            {
                minRoomsTextBox.Text = null;
                minRoomsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void minRoomsTextBox_Leave(object sender, EventArgs e)
        {
            if (minRoomsTextBox.Text == "")
            {
                minRoomsTextBox.Text = "Минимальное количество комнат";
                minRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void maxRoomsTextBox_Enter(object sender, EventArgs e)
        {
            if (maxRoomsTextBox.Text == "Максимальное количество комнат")
            {
                maxRoomsTextBox.Text = null;
                maxRoomsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void maxRoomsTextBox_Leave(object sender, EventArgs e)
        {
            if (maxRoomsTextBox.Text == "")
            {
                maxRoomsTextBox.Text = "Максимальное количество комнат";
                maxRoomsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void minFloorsTextBox_Enter(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (minFloorsTextBox.Text == "Минимальное количество этажей")
                {
                    minFloorsTextBox.Text = null;
                    minFloorsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (minFloorsTextBox.Text == "Минимальный этаж")
                {
                    minFloorsTextBox.Text = null;
                    minFloorsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
        }

        private void minFloorsTextBox_Leave(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (minFloorsTextBox.Text == "")
                {
                    minFloorsTextBox.Text = "Минимальное количество этажей";
                    minFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (minFloorsTextBox.Text == "")
                {
                    minFloorsTextBox.Text = "Минимальный этаж";
                    minFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
        }

        private void maxFloorsTextBox_Enter(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (maxFloorsTextBox.Text == "Максимальное количество этажей")
                {
                    maxFloorsTextBox.Text = null;
                    maxFloorsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (maxFloorsTextBox.Text == "Максимальный этаж")
                {
                    maxFloorsTextBox.Text = null;
                    maxFloorsTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
        }

        private void maxFloorsTextBox_Leave(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (maxFloorsTextBox.Text == "")
                {
                    maxFloorsTextBox.Text = "Максимальное количество этажей";
                    maxFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (maxFloorsTextBox.Text == "")
                {
                    maxFloorsTextBox.Text = "Максимальный этаж";
                    maxFloorsTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
        }

        private void RealEstateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                //Изменение полей при выборе квартиры
                if (RealEstateComboBox.SelectedItem.ToString() == "Квартира")
                {
                    Text = "Информация о потребности в квартире";
                    addUpdateDemandButton.Text = "Обновить потребность в квартире";
                    deleteDemandButton.Text = "Удалить потребность в квартире";
                    minFloorsTextBox.Visible = true;
                    maxFloorsTextBox.Visible = true;
                    minRoomsTextBox.Visible = true;
                    maxRoomsTextBox.Visible = true;
                    if (minFloorsTextBox.Text == "Минимальное количество этажей")
                    {
                        minFloorsTextBox.Text = "Минимальный этаж";
                    }
                    if (maxFloorsTextBox.Text == "Максимальное количество этажей")
                    {
                        maxFloorsTextBox.Text = "Максимальный этаж";
                    }
                }
                //Изменение полей при выборе дома
                else if (RealEstateComboBox.SelectedItem.ToString() == "Дом")
                {
                    Text = "Информация о потребности в доме";
                    addUpdateDemandButton.Text = "Обновить потребность в доме";
                    deleteDemandButton.Text = "Удалить потребность в доме";
                    minFloorsTextBox.Visible = true;
                    maxFloorsTextBox.Visible = true;
                    minRoomsTextBox.Visible = true;
                    maxRoomsTextBox.Visible = true;
                    if (minFloorsTextBox.Text == "Минимальный этаж")
                    {
                        minFloorsTextBox.Text = "Минимальное количество этажей";
                    }
                    if (maxFloorsTextBox.Text == "Максимальный этаж")
                    {
                        maxFloorsTextBox.Text = "Максимальное количество этажей";
                    }
                }
                //Изменение полей при выборе земли
                else if (RealEstateComboBox.SelectedItem.ToString() == "Земля")
                {
                    Text = "Информация о потребности в земле";
                    addUpdateDemandButton.Text = "Обновить потребность в земле";
                    deleteDemandButton.Text = "Удалить потребность в земле";
                    minFloorsTextBox.Visible = false;
                    maxFloorsTextBox.Visible = false;
                    minRoomsTextBox.Visible = false;
                    maxRoomsTextBox.Visible = false;
                }
            }
            //Если форма открыта с помощью кнопки добавления
            else
            {
                //Изменение полей при выборе квартиры
                if (RealEstateComboBox.SelectedItem.ToString() == "Квартира")
                {
                    Text = "Добавление потребности в квартире";
                    addUpdateDemandButton.Text = "Добавить потребность в квартире";
                    deleteDemandButton.Visible = false;
                    minFloorsTextBox.Visible = true;
                    maxFloorsTextBox.Visible = true;
                    minRoomsTextBox.Visible = true;
                    maxRoomsTextBox.Visible = true;
                    if (minFloorsTextBox.Text == "Минимальное количество этажей")
                    {
                        minFloorsTextBox.Text = "Минимальный этаж";
                    }
                    if (maxFloorsTextBox.Text == "Максимальное количество этажей")
                    {
                        maxFloorsTextBox.Text = "Максимальный этаж";
                    }
                }
                //Изменение полей при выборе дома
                else if (RealEstateComboBox.SelectedItem.ToString() == "Дом")
                {
                    Text = "Добавление потребности в доме";
                    addUpdateDemandButton.Text = "Добавить потребность в доме";
                    deleteDemandButton.Visible = false;
                    minFloorsTextBox.Visible = true;
                    maxFloorsTextBox.Visible = true;
                    minRoomsTextBox.Visible = true;
                    maxRoomsTextBox.Visible = true;
                    if (minFloorsTextBox.Text == "Минимальный этаж")
                    {
                        minFloorsTextBox.Text = "Минимальное количество этажей";
                    }
                    if (maxFloorsTextBox.Text == "Максимальный этаж")
                    {
                        maxFloorsTextBox.Text = "Максимальное количество этажей";
                    }
                }
                //Изменение полей при выборе земли
                else if (RealEstateComboBox.SelectedItem.ToString() == "Земля")
                {
                    Text = "Добавление потребности в земле";
                    addUpdateDemandButton.Text = "Добавить потребность в земле";
                    deleteDemandButton.Visible = false;
                    minFloorsTextBox.Visible = false;
                    maxFloorsTextBox.Visible = false;
                    minRoomsTextBox.Visible = false;
                    maxRoomsTextBox.Visible = false;
                }
            }
        }

        private void minPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void maxPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void minAreaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            double doubleValue;

            //Ввод только вещественных чисел
            if (!double.TryParse(minAreaTextBox.Text, out doubleValue))
                minAreaTextBox.Text = "";
        }

        private void maxAreaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            double doubleValue;

            //Ввод только вещественных чисел
            if (!double.TryParse(maxAreaTextBox.Text, out doubleValue))
                maxAreaTextBox.Text = "";
        }

        private void minAreaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только вещественных чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void maxAreaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только вещественных чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void minRoomsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void maxRoomsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void minFloorsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void maxFloorsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void DemandInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((DemandForm)Application.OpenForms[1]).UpdateDemandList();
        }
    }
}
