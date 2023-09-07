using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class ClientForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            clientPanel.AutoScroll = true;

            UpdateClientList();          
        }

        public void UpdateClientList()
        {
            clientPanel.Controls.Clear();

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from ClientsSet", connection);
            da.Fill(dt);

            //Настройка списка кнопок
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button button = new Button();

                button.Name = dt.Rows[i][0].ToString();
                button.Text = dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString();
                button.Cursor = Cursors.Hand;
                button.BackColor = Color.FromArgb(255, 236, 239, 241);
                button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Roboto", 10);
                button.Size = new Size(clientPanel.Width, 50);
                button.Location = new Point(0, i * 50);
                button.Click += Button_Click;

                clientPanel.Controls.Add(button);
            }
        }

        public void UpdateClientListWithFilter()
        {
            if (searchTextBox.Text != "")
            {
                clientPanel.Controls.Clear();

                dt.Reset();
                da.SelectCommand = new SqlCommand("select * from ClientsSet", connection);
                da.Fill(dt);

                List<Client> clients = new List<Client>();

                //Фильтрация с помощью расстояния Левенштейна
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (LevenshteinDistance(dt.Rows[i][1].ToString(), searchTextBox.Text) <= 3 ||
                        LevenshteinDistance(dt.Rows[i][2].ToString(), searchTextBox.Text) <= 3 ||
                        LevenshteinDistance(dt.Rows[i][3].ToString(), searchTextBox.Text) <= 3)
                    {
                        Client client = new Client
                        {
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            FirstName = dt.Rows[i][1].ToString(),
                            MiddleName = dt.Rows[i][2].ToString(),
                            LastName = dt.Rows[i][3].ToString(),
                            Phone = dt.Rows[i][4].ToString(),
                            Email = dt.Rows[i][5].ToString(),
                        };

                        clients.Add(client);
                    }
                }

                //Настройка списка кнопок
                for (int i = 0; i < clients.Count; i++)
                {
                    Button button = new Button();

                    button.Name = clients[i].Id.ToString();
                    button.Text = clients[i].FirstName.ToString() + " " + clients[i].MiddleName.ToString() + " " + clients[i].LastName.ToString();
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Color.FromArgb(255, 236, 239, 241);
                    button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Roboto", 10);
                    button.Size = new Size(clientPanel.Width, 50);
                    button.Location = new Point(0, i * 50);
                    button.Click += Button_Click;

                    clientPanel.Controls.Add(button);
                }
            }
            else
                UpdateClientList();
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            ClientInfoForm clientInfoForm = new ClientInfoForm(((Button)sender).Name, connection, false);
            clientInfoForm.Show();
        }

        //Нажатие на кнопку добавления
        private void addClientButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            ClientInfoForm clientInfoForm = new ClientInfoForm("", connection, true);
            clientInfoForm.Show();
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
            UpdateClientListWithFilter();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
