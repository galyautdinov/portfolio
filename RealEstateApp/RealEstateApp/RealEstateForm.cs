using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class RealEstateForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public RealEstateForm()
        {
            InitializeComponent();
        }

        private void RealEstateForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            realEstatePanel.AutoScroll = true;

            comboBox.SelectedItem = "Все";

            UpdateRealEstateList();
        }

        public void UpdateRealEstateList()
        {
            realEstatePanel.Controls.Clear();

            int bottom = 0;

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateSet_Apartment", connection);
            da.Fill(dt);

            RealEstateApartment[] realEstateApartments = new RealEstateApartment[dt.Rows.Count];

            //Настройка списка кнопок (для квартир)
            for (int i = 0; i < realEstateApartments.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][3]}", connection);
                da1.Fill(dt1);

                RealEstateApartment realEstateApartment = new RealEstateApartment
                {
                    TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                    Rooms = Convert.ToInt32(dt.Rows[i][1]),
                    Floor = Convert.ToInt32(dt.Rows[i][2]),
                    Id = Convert.ToInt32(dt.Rows[i][3]),
                    AddressCity = dt1.Rows[0][1].ToString(),
                    AddressStreet = dt1.Rows[0][2].ToString(),
                    AddressHouse = dt1.Rows[0][3].ToString(),
                    AddressNumber = dt1.Rows[0][4].ToString(),
                    Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                    Longitude = Convert.ToDouble(dt1.Rows[0][6])
                };

                realEstateApartments[i] = realEstateApartment;

                Button button = new Button();

                button.Name = "Apartment&" + realEstateApartment.Id;
                button.Text = "(Квартира) " + realEstateApartment.AddressCity + ", " + realEstateApartment.AddressStreet + " " + realEstateApartment.AddressHouse + ", кв. " + realEstateApartment.AddressNumber;
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(realEstatePanel.Width, 50);
                button.Location = new Point(0, bottom);
                button.Click += Button_Click;

                realEstatePanel.Controls.Add(button);

                bottom += 50;
            }

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateSet_House", connection);
            da.Fill(dt);

            RealEstateHouse[] realEstateHouses = new RealEstateHouse[dt.Rows.Count];

            //Настройка списка кнопок (для домов)
            for (int i = 0; i < realEstateHouses.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][2]}", connection);
                da1.Fill(dt1);

                RealEstateHouse realEstateHouse = new RealEstateHouse
                {
                    TotalArea = Convert.ToDouble(dt.Rows[i][1]),
                    TotalFloors = Convert.ToInt32(dt.Rows[i][0]),
                    Id = Convert.ToInt32(dt.Rows[i][2]),
                    AddressCity = dt1.Rows[0][1].ToString(),
                    AddressStreet = dt1.Rows[0][2].ToString(),
                    AddressHouse = dt1.Rows[0][3].ToString(),
                    AddressNumber = dt1.Rows[0][4].ToString(),
                    Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                    Longitude = Convert.ToDouble(dt1.Rows[0][6])
                };

                realEstateHouses[i] = realEstateHouse;

                Button button = new Button();

                button.Name = "House&" + realEstateHouse.Id;
                button.Text = "(Дом) " + realEstateHouse.AddressCity + ", " + realEstateHouse.AddressStreet + " " + realEstateHouse.AddressHouse;
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(realEstatePanel.Width, 50);
                button.Location = new Point(0, bottom);
                button.Click += Button_Click;

                realEstatePanel.Controls.Add(button);

                bottom += 50;
            }

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from RealEstateSet_Land", connection);
            da.Fill(dt);

            RealEstateLand[] realEstateLands = new RealEstateLand[dt.Rows.Count];

            //Настройка списка кнопок (для земель)
            for (int i = 0; i < realEstateLands.Length; i++)
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][1]}", connection);
                da1.Fill(dt1);

                RealEstateLand realEstateLand = new RealEstateLand
                {
                    TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                    Id = Convert.ToInt32(dt.Rows[i][1]),
                    AddressCity = dt1.Rows[0][1].ToString(),
                    AddressStreet = dt1.Rows[0][2].ToString(),
                    AddressHouse = dt1.Rows[0][3].ToString(),
                    AddressNumber = dt1.Rows[0][4].ToString(),
                    Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                    Longitude = Convert.ToDouble(dt1.Rows[0][6])
                };

                realEstateLands[i] = realEstateLand;

                Button button = new Button();

                button.Name = "Land&" + realEstateLand.Id;
                button.Text = "(Земля) " + realEstateLand.AddressCity + ", " + realEstateLand.AddressStreet;
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(realEstatePanel.Width, 50);
                button.Location = new Point(0, bottom);
                button.Click += Button_Click;

                realEstatePanel.Controls.Add(button);

                bottom += 50;
            }
        }

        public void UpdateRealEstateListWithFilter()
        {
            if (searchTextBox.Text != "" || comboBox.Text != "Все")
            {
                realEstatePanel.Controls.Clear();

                int bottom = 0;

                //При выборе в поле фильтрации квартир
                if (comboBox.Text == "Все" || comboBox.Text == "Квартиры")
                {
                    dt.Reset();
                    da.SelectCommand = new SqlCommand("select * from RealEstateSet_Apartment", connection);
                    da.Fill(dt);

                    RealEstateApartment[] realEstateApartments = new RealEstateApartment[dt.Rows.Count];

                    //Фильтрация списка кнопок с помощью расстояния Левенштейна (для квартир)
                    for (int i = 0; i < realEstateApartments.Length; i++)
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][3]}", connection);
                        da1.Fill(dt1);

                        if (LevenshteinDistance(dt1.Rows[0][1].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][2].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][3].ToString(), searchTextBox.Text) <= 1 ||
                            LevenshteinDistance(dt1.Rows[0][4].ToString(), searchTextBox.Text) <= 1 &&
                            searchTextBox.Text != "")
                        {
                            RealEstateApartment realEstateApartment = new RealEstateApartment
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                                Rooms = Convert.ToInt32(dt.Rows[i][1]),
                                Floor = Convert.ToInt32(dt.Rows[i][2]),
                                Id = Convert.ToInt32(dt.Rows[i][3]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateApartments[i] = realEstateApartment;

                            Button button = new Button();

                            button.Name = "Apartment&" + realEstateApartment.Id;
                            button.Text = "(Квартира) " + realEstateApartment.AddressCity + ", " + realEstateApartment.AddressStreet + " " + realEstateApartment.AddressHouse + ", кв. " + realEstateApartment.AddressNumber;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                        else if (searchTextBox.Text == "")
                        {
                            RealEstateApartment realEstateApartment = new RealEstateApartment
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                                Rooms = Convert.ToInt32(dt.Rows[i][1]),
                                Floor = Convert.ToInt32(dt.Rows[i][2]),
                                Id = Convert.ToInt32(dt.Rows[i][3]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateApartments[i] = realEstateApartment;

                            Button button = new Button();

                            button.Name = "Apartment&" + realEstateApartment.Id;
                            button.Text = "(Квартира) " + realEstateApartment.AddressCity + ", " + realEstateApartment.AddressStreet + " " + realEstateApartment.AddressHouse + ", кв. " + realEstateApartment.AddressNumber;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                    }
                }

                //При выборе в поле фильтрации домов               
                if (comboBox.Text == "Все" || comboBox.Text == "Дома")
                {
                    dt.Reset();
                    da.SelectCommand = new SqlCommand("select * from RealEstateSet_House", connection);
                    da.Fill(dt);

                    RealEstateHouse[] realEstateHouses = new RealEstateHouse[dt.Rows.Count];

                    //Фильтрация списка кнопок с помощью расстояния Левенштейна (для домов)
                    for (int i = 0; i < realEstateHouses.Length; i++)
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][2]}", connection);
                        da1.Fill(dt1);

                        if (LevenshteinDistance(dt1.Rows[0][1].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][2].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][3].ToString(), searchTextBox.Text) <= 1 ||
                            LevenshteinDistance(dt1.Rows[0][4].ToString(), searchTextBox.Text) <= 1 &&
                            searchTextBox.Text != "")
                        {
                            RealEstateHouse realEstateHouse = new RealEstateHouse
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][1]),
                                TotalFloors = Convert.ToInt32(dt.Rows[i][0]),
                                Id = Convert.ToInt32(dt.Rows[i][2]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateHouses[i] = realEstateHouse;

                            Button button = new Button();

                            button.Name = "House&" + realEstateHouse.Id;
                            button.Text = "(Дом) " + realEstateHouse.AddressCity + ", " + realEstateHouse.AddressStreet + " " + realEstateHouse.AddressHouse;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                        else if (searchTextBox.Text == "")
                        {
                            RealEstateHouse realEstateHouse = new RealEstateHouse
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][1]),
                                TotalFloors = Convert.ToInt32(dt.Rows[i][0]),
                                Id = Convert.ToInt32(dt.Rows[i][2]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateHouses[i] = realEstateHouse;

                            Button button = new Button();

                            button.Name = "House&" + realEstateHouse.Id;
                            button.Text = "(Дом) " + realEstateHouse.AddressCity + ", " + realEstateHouse.AddressStreet + " " + realEstateHouse.AddressHouse;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                    }
                }

                //При выборе в поле фильтрации земель
                if (comboBox.Text == "Все" || comboBox.Text == "Земли")
                {
                    dt.Reset();
                    da.SelectCommand = new SqlCommand("select * from RealEstateSet_Land", connection);
                    da.Fill(dt);

                    RealEstateLand[] realEstateLands = new RealEstateLand[dt.Rows.Count];

                    //Фильтрация списка кнопок с помощью расстояния Левенштейна (для земель)
                    for (int i = 0; i < realEstateLands.Length; i++)
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][1]}", connection);
                        da1.Fill(dt1);

                        if (LevenshteinDistance(dt1.Rows[0][1].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][2].ToString(), searchTextBox.Text) <= 3 ||
                            LevenshteinDistance(dt1.Rows[0][3].ToString(), searchTextBox.Text) <= 1 ||
                            LevenshteinDistance(dt1.Rows[0][4].ToString(), searchTextBox.Text) <= 1 &&
                            searchTextBox.Text != "")
                        {
                            RealEstateLand realEstateLand = new RealEstateLand
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                                Id = Convert.ToInt32(dt.Rows[i][1]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateLands[i] = realEstateLand;

                            Button button = new Button();

                            button.Name = "Land&" + realEstateLand.Id;
                            button.Text = "(Земля) " + realEstateLand.AddressCity + ", " + realEstateLand.AddressStreet;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                        else if (searchTextBox.Text == "")
                        {
                            RealEstateLand realEstateLand = new RealEstateLand
                            {
                                TotalArea = Convert.ToDouble(dt.Rows[i][0]),
                                Id = Convert.ToInt32(dt.Rows[i][1]),
                                AddressCity = dt1.Rows[0][1].ToString(),
                                AddressStreet = dt1.Rows[0][2].ToString(),
                                AddressHouse = dt1.Rows[0][3].ToString(),
                                AddressNumber = dt1.Rows[0][4].ToString(),
                                Latitude = Convert.ToDouble(dt1.Rows[0][5]),
                                Longitude = Convert.ToDouble(dt1.Rows[0][6])
                            };

                            realEstateLands[i] = realEstateLand;

                            Button button = new Button();

                            button.Name = "Land&" + realEstateLand.Id;
                            button.Text = "(Земля) " + realEstateLand.AddressCity + ", " + realEstateLand.AddressStreet;
                            button.Cursor = Cursors.Hand;
                            button.BackColor = Color.FromArgb(255, 236, 239, 241);
                            button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.Font = new Font("Roboto", 10);
                            button.Size = new Size(realEstatePanel.Width, 50);
                            button.Location = new Point(0, bottom);
                            button.Click += Button_Click;

                            realEstatePanel.Controls.Add(button);

                            bottom += 50;
                        }
                    }
                }
            }
            else
                UpdateRealEstateList();
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            RealEstateInfoForm realEstateInfoForm = new RealEstateInfoForm(((Button)sender).Name, connection, false);
            realEstateInfoForm.Show();
        }

        //Нажатие на кнопку добавления квартиры
        private void addApartmentButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            RealEstateInfoForm realEstateInfoForm = new RealEstateInfoForm("Apartment&", connection, true);
            realEstateInfoForm.Show();
        }

        //Нажатие на кнопку добавления дома
        private void addHouseButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            RealEstateInfoForm realEstateInfoForm = new RealEstateInfoForm("House&", connection, true);
            realEstateInfoForm.Show();
        }

        //Нажатие на кнопку добавления земли
        private void addLandButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            RealEstateInfoForm realEstateInfoForm = new RealEstateInfoForm("Land&", connection, true);
            realEstateInfoForm.Show();
        }

        //Вычисление минимума
        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

        //Вычисление расстояния Левенштейна
        static int LevenshteinDistance(string firstWord, string secondWord)
        {
            var n = firstWord.Length + 1;
            var m = secondWord.Length + 1;
            var matrixD = new int[n, m];

            const int deletionCost = 1;
            const int insertionCost = 1;

            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,          // удаление
                                            matrixD[i, j - 1] + insertionCost,         // вставка
                                            matrixD[i - 1, j - 1] + substitutionCost); // замена
                }
            }

            return matrixD[n - 1, m - 1];
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Обновление списка во время поиска
            UpdateRealEstateListWithFilter();
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            //Обновление списка во время фильтрации
            UpdateRealEstateListWithFilter();
        }

        private void RealEstateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
