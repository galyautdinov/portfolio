using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class RealEstateInfoForm : Form
    {
        string realEstateId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public RealEstateInfoForm(string RealEstateId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            realEstateId = RealEstateId;
            connection = Connection;
            fromAdd = FromAdd;
        }

        private void RealEstateInfoForm_Load(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                //Для квартиры
                if (realEstateId.Split('&')[0] == "Apartment")
                {
                    Text = "Информация о квартире";
                    addUpdateRealEstateButton.Text = "Обновить квартиру";
                    deleteRealEstateButton.Text = "Удалить квартиру";

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_Apartment where Id = {realEstateId.Split('&')[1]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateApartment realEstateApartment = new RealEstateApartment
                    {
                        TotalArea = Convert.ToDouble(dt.Rows[0][0]),
                        Rooms = Convert.ToInt32(dt.Rows[0][1]),
                        Floor = Convert.ToInt32(dt.Rows[0][2]),
                        Id = Convert.ToInt32(dt.Rows[0][3]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                        Longitude = Convert.ToDouble(dt1.Rows[0][6])
                    };

                    //Заполнение полей
                    if (realEstateApartment.AddressCity != "")
                        cityTextBox.Text = realEstateApartment.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateApartment.AddressStreet != "")
                        streetTextBox.Text = realEstateApartment.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateApartment.AddressHouse != "")
                        houseTextBox.Text = realEstateApartment.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateApartment.AddressNumber != "")
                        numberTextBox.Text = realEstateApartment.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Номер";
                    }
                    if (realEstateApartment.Latitude.ToString() != "")
                        latitudeTextBox.Text = realEstateApartment.Latitude.ToString();
                    else
                    {
                        latitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        latitudeTextBox.Text = "Широта";
                    }
                    if (realEstateApartment.Longitude.ToString() != "")
                        longitudeTextBox.Text = realEstateApartment.Longitude.ToString();
                    else
                    {
                        longitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        longitudeTextBox.Text = "Долгота";
                    }
                    if (realEstateApartment.TotalArea.ToString() != "")
                        areaTextBox.Text = realEstateApartment.TotalArea.ToString();
                    else
                    {
                        areaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        areaTextBox.Text = "Площадь";
                    }
                    if (realEstateApartment.Rooms.ToString() != "")
                        roomTextBox.Text = realEstateApartment.Rooms.ToString();
                    else
                    {
                        roomTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        roomTextBox.Text = "Количество комнат";
                    }
                    if (realEstateApartment.Floor.ToString() != "")
                        floorTextBox.Text = realEstateApartment.Floor.ToString();
                    else
                    {
                        floorTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        floorTextBox.Text = "Этаж";
                    }
                }
                //Для дома
                else if (realEstateId.Split('&')[0] == "House")
                {
                    Text = "Информация о доме";
                    addUpdateRealEstateButton.Text = "Обновить дом";
                    deleteRealEstateButton.Text = "Удалить дом";
                    roomTextBox.Visible = false;

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_House where Id = {realEstateId.Split('&')[1]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateHouse realEstateHouse = new RealEstateHouse
                    {
                        TotalArea = Convert.ToDouble(dt.Rows[0][1]),
                        TotalFloors = Convert.ToInt32(dt.Rows[0][0]),
                        Id = Convert.ToInt32(dt.Rows[0][2]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                        Longitude = Convert.ToDouble(dt1.Rows[0][6])
                    };

                    //Заполнение полей
                    if (realEstateHouse.AddressCity != "")
                        cityTextBox.Text = realEstateHouse.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateHouse.AddressStreet != "")
                        streetTextBox.Text = realEstateHouse.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateHouse.AddressHouse != "")
                        houseTextBox.Text = realEstateHouse.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateHouse.AddressNumber != "")
                        numberTextBox.Text = realEstateHouse.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Номер";
                    }
                    if (realEstateHouse.Latitude.ToString() != "")
                        latitudeTextBox.Text = realEstateHouse.Latitude.ToString();
                    else
                    {
                        latitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        latitudeTextBox.Text = "Широта";
                    }
                    if (realEstateHouse.Longitude.ToString() != "")
                        longitudeTextBox.Text = realEstateHouse.Longitude.ToString();
                    else
                    {
                        longitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        longitudeTextBox.Text = "Долгота";
                    }
                    if (realEstateHouse.TotalArea.ToString() != "")
                        areaTextBox.Text = realEstateHouse.TotalArea.ToString();
                    else
                    {
                        areaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        areaTextBox.Text = "Площадь";
                    }
                    if (realEstateHouse.TotalFloors.ToString() != "")
                        floorTextBox.Text = realEstateHouse.TotalFloors.ToString();
                    else
                    {
                        floorTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        floorTextBox.Text = "Этажность";
                    }
                }
                //Для земли
                else if (realEstateId.Split('&')[0] == "Land")
                {
                    Text = "Информация о земле";
                    addUpdateRealEstateButton.Text = "Обновить землю";
                    deleteRealEstateButton.Text = "Удалить землю";
                    roomTextBox.Visible = false;
                    floorTextBox.Visible = false;

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_Land where Id = {realEstateId.Split('&')[1]}", connection);
                    da.Fill(dt);

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da1.Fill(dt1);

                    RealEstateLand realEstateLand = new RealEstateLand
                    {
                        TotalArea = Convert.ToDouble(dt.Rows[0][0]),
                        Id = Convert.ToInt32(dt.Rows[0][1]),
                        AddressCity = dt1.Rows[0][1].ToString(),
                        AddressStreet = dt1.Rows[0][2].ToString(),
                        AddressHouse = dt1.Rows[0][3].ToString(),
                        AddressNumber = dt1.Rows[0][4].ToString(),
                        Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                        Longitude = Convert.ToDouble(dt1.Rows[0][6])
                    };

                    //Заполнение полей
                    if (realEstateLand.AddressCity != "")
                        cityTextBox.Text = realEstateLand.AddressCity;
                    else
                    {
                        cityTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        cityTextBox.Text = "Город";
                    }
                    if (realEstateLand.AddressStreet != "")
                        streetTextBox.Text = realEstateLand.AddressStreet;
                    else
                    {
                        streetTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        streetTextBox.Text = "Улица";
                    }
                    if (realEstateLand.AddressHouse != "")
                        houseTextBox.Text = realEstateLand.AddressHouse;
                    else
                    {
                        houseTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        houseTextBox.Text = "Дом";
                    }
                    if (realEstateLand.AddressNumber != "")
                        numberTextBox.Text = realEstateLand.AddressNumber;
                    else
                    {
                        numberTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        numberTextBox.Text = "Номер";
                    }
                    if (realEstateLand.Latitude.ToString() != "")
                        latitudeTextBox.Text = realEstateLand.Latitude.ToString();
                    else
                    {
                        latitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        latitudeTextBox.Text = "Широта";
                    }
                    if (realEstateLand.Longitude.ToString() != "")
                        longitudeTextBox.Text = realEstateLand.Longitude.ToString();
                    else
                    {
                        longitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        longitudeTextBox.Text = "Долгота";
                    }
                    if (realEstateLand.TotalArea.ToString() != "")
                        areaTextBox.Text = realEstateLand.TotalArea.ToString();
                    else
                    {
                        areaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                        areaTextBox.Text = "Площадь";
                    }
                }
            }
            //Если форма открыта с помощью кнопки добавения
            else
            {
                if (realEstateId.Split('&')[0] == "Apartment")
                {
                    Text = "Информация о квартире";
                    addUpdateRealEstateButton.Text = "Добавить квартиру";
                }
                else if (realEstateId.Split('&')[0] == "House")
                {
                    Text = "Информация о доме";
                    addUpdateRealEstateButton.Text = "Добавить дом";
                    roomTextBox.Visible = false;
                    floorTextBox.Text = "Этажность";
                }
                else if (realEstateId.Split('&')[0] == "Land")
                {
                    Text = "Информация о земле";
                    addUpdateRealEstateButton.Text = "Добавить землю";
                    roomTextBox.Visible = false;
                    floorTextBox.Visible = false;
                }

                deleteRealEstateButton.Visible = false;

                foreach (TextBox obj in Controls.OfType<TextBox>())
                    obj.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void addUpdateRealEstateButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                if (realEstateId.Split('&')[0] == "Apartment")
                {
                    nullTextBoxChange();

                    //Добавление квартиры
                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet(Address_City, Address_Street, Address_House, Address_Number, Coordinate_latitude, Coordinate_longitude) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {latitudeTextBox.Text.Replace(',', '.')}, {longitudeTextBox.Text.Replace(',', '.')})", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet_Apartment values({areaTextBox.Text.Replace(',', '.')}, {roomTextBox.Text}, {floorTextBox.Text}, (select max(Id) from RealEstateSet))", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Квартира добавлена");
                    Close();
                }
                else if (realEstateId.Split('&')[0] == "House")
                {
                    nullTextBoxChange();

                    //Добавление дома
                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet(Address_City, Address_Street, Address_House, Address_Number, Coordinate_latitude, Coordinate_longitude) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {latitudeTextBox.Text.Replace(',', '.')}, {longitudeTextBox.Text.Replace(',', '.')})", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet_House values({floorTextBox.Text}, {areaTextBox.Text.Replace(',', '.')}, (select max(Id) from RealEstateSet))", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Дом добавлен");
                    Close();
                }
                else if (realEstateId.Split('&')[0] == "Land")
                {
                    nullTextBoxChange();

                    //Добавление земли
                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet(Address_City, Address_Street, Address_House, Address_Number, Coordinate_latitude, Coordinate_longitude) values('{cityTextBox.Text}', '{streetTextBox.Text}', '{houseTextBox.Text}', '{numberTextBox.Text}', {latitudeTextBox.Text.Replace(',', '.')}, {longitudeTextBox.Text.Replace(',', '.')})", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    da.InsertCommand = new SqlCommand($"insert into RealEstateSet_Land values({areaTextBox.Text.Replace(',', '.')}, (select max(Id) from RealEstateSet))", connection);
                    da.InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Земля добавлена");
                    Close();
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                if (realEstateId.Split('&')[0] == "Apartment")
                {
                    nullTextBoxChange();

                    //Обновление квартиры
                    da.UpdateCommand = new SqlCommand($"update RealEstateSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', Coordinate_latitude = {latitudeTextBox.Text.Replace(',', '.')}, Coordinate_longitude = {longitudeTextBox.Text.Replace(',', '.')} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateSet_Apartment set TotalArea = {areaTextBox.Text.Replace(',', '.')}, Rooms = {roomTextBox.Text}, Floor = {floorTextBox.Text} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Квартира обновлена");
                    Close();
                }
                else if (realEstateId.Split('&')[0] == "House")
                {
                    nullTextBoxChange();

                    //Обновление дома
                    da.UpdateCommand = new SqlCommand($"update RealEstateSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', Coordinate_latitude = {latitudeTextBox.Text.Replace(',', '.')}, Coordinate_longitude = {longitudeTextBox.Text.Replace(',', '.')} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateSet_House set TotalFloors = {floorTextBox.Text}, TotalArea = {areaTextBox.Text.Replace(',', '.')} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Дом обновлен");
                    Close();
                }
                else if (realEstateId.Split('&')[0] == "Land")
                {
                    nullTextBoxChange();

                    //Обновление земли
                    da.UpdateCommand = new SqlCommand($"update RealEstateSet set Address_City = '{cityTextBox.Text}',  Address_Street = '{streetTextBox.Text}', Address_House = '{houseTextBox.Text}', Address_Number = '{numberTextBox.Text}', Coordinate_latitude = {latitudeTextBox.Text.Replace(',', '.')}, Coordinate_longitude = {longitudeTextBox.Text.Replace(',', '.')} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    da.UpdateCommand = new SqlCommand($"update RealEstateSet_Land set TotalArea = {areaTextBox.Text.Replace(',', '.')} where Id = {realEstateId.Split('&')[1]}", connection);
                    da.UpdateCommand.ExecuteNonQuery();

                    MessageBox.Show("Земля обновлена");
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
            if (latitudeTextBox.Text == "Широта")
                latitudeTextBox.Text = "0";
            if (longitudeTextBox.Text == "Долгота")
                longitudeTextBox.Text = "0";
            if (areaTextBox.Text == "Площадь")
                areaTextBox.Text = "0";
            if (floorTextBox.Text == "Этаж" || floorTextBox.Text == "Этажность")
                floorTextBox.Text = "1";
            if (roomTextBox.Text == "Количество комнат")
                roomTextBox.Text = "1";
        }

        private void deleteRealEstateButton_Click(object sender, EventArgs e)
        {
            if (realEstateId.Split('&')[0] == "Apartment")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where RealEstateId = {realEstateId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей с предложением
                if (dt.Rows.Count == 0)
                {
                    //Удаление квартиры
                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet_Apartment where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Квартира удалена");
                    Close();
                }
                else
                {
                    MessageBox.Show("Квартира связана с предложением. Удаление невозможно");
                }
            }
            else if (realEstateId.Split('&')[0] == "House")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where RealEstateId = {realEstateId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей с предложением
                if (dt.Rows.Count == 0)
                {
                    //Удаление дома
                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet_House where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Дом удален");
                    Close();
                }
                else
                {
                    MessageBox.Show("Дом связан с предложением. Удаление невозможно");
                }
            }
            else if (realEstateId.Split('&')[0] == "Land")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where RealEstateId = {realEstateId.Split('&')[1]}", connection);
                da.Fill(dt);

                //Проверка на наличие связей с предложением
                if (dt.Rows.Count == 0)
                {
                    //Удаление земли
                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    da.DeleteCommand = new SqlCommand($"delete from RealEstateSet_Land where Id = {realEstateId.Split('&')[1]}", connection);
                    da.DeleteCommand.ExecuteNonQuery();

                    MessageBox.Show("Земля удалена");
                    Close();
                }
                else
                {
                    MessageBox.Show("Земля связана с предложением. Удаление невозможно");
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

        private void latitudeTextBox_Enter(object sender, EventArgs e)
        {
            if (latitudeTextBox.Text == "Широта")
            {
                latitudeTextBox.Text = null;
                latitudeTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void latitudeTextBox_Leave(object sender, EventArgs e)
        {
            if (latitudeTextBox.Text == "")
            {
                latitudeTextBox.Text = "Широта";
                latitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void longitudeTextBox_Enter(object sender, EventArgs e)
        {
            if (longitudeTextBox.Text == "Долгота")
            {
                longitudeTextBox.Text = null;
                longitudeTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void longitudeTextBox_Leave(object sender, EventArgs e)
        {
            if (longitudeTextBox.Text == "")
            {
                longitudeTextBox.Text = "Долгота";
                longitudeTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void areaTextBox_Enter(object sender, EventArgs e)
        {
            if (areaTextBox.Text == "Площадь")
            {
                areaTextBox.Text = null;
                areaTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void areaTextBox_Leave(object sender, EventArgs e)
        {
            if (areaTextBox.Text == "")
            {
                areaTextBox.Text = "Площадь";
                areaTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void floorTextBox_Enter(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (floorTextBox.Text == "Этажность")
                {
                    floorTextBox.Text = null;
                    floorTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (floorTextBox.Text == "Этаж")
                {
                    floorTextBox.Text = null;
                    floorTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
                }
            }
        }

        private void floorTextBox_Leave(object sender, EventArgs e)
        {
            if (Text.Contains("дом"))
            {
                if (floorTextBox.Text == "")
                {
                    floorTextBox.Text = "Этажность";
                    floorTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
            else if (Text.Contains("квартир"))
            {
                if (floorTextBox.Text == "")
                {
                    floorTextBox.Text = "Этаж";
                    floorTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                }
            }
        }

        private void roomTextBox_Enter(object sender, EventArgs e)
        {
            if (roomTextBox.Text == "Количество комнат")
            {
                roomTextBox.Text = null;
                roomTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void roomTextBox_Leave(object sender, EventArgs e)
        {
            if (roomTextBox.Text == "")
            {
                roomTextBox.Text = "Количество комнат";
                roomTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void floorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void roomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void RealEstateInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((RealEstateForm)Application.OpenForms[1]).UpdateRealEstateListWithFilter();
        }

        private void areaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только вещественных чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void areaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            double doubleValue;

            //Ввод только вещественных чисел
            if (!double.TryParse(areaTextBox.Text, out doubleValue))
                areaTextBox.Text = "";
        }

        private void latitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только вещественных чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void latitudeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            double doubleValue;

            //Ограничение ввода (-90 - 90)
            if (double.TryParse(latitudeTextBox.Text, out doubleValue))
            {
                if (doubleValue > 90)
                    latitudeTextBox.Text = "90";
                else if (doubleValue < -90)
                    latitudeTextBox.Text = "-90";
            }
            else
                latitudeTextBox.Text = "";
        }

        private void longitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только вещественных чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void longitudeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            double doubleValue;

            //Ограничение ввода (-90 - 90)
            if (double.TryParse(longitudeTextBox.Text, out doubleValue))
            {
                if (doubleValue > 180)
                    longitudeTextBox.Text = "180";
                else if (doubleValue < -180)
                    longitudeTextBox.Text = "-180";
            }
            else
                longitudeTextBox.Text = "";
        }      
    }
}
