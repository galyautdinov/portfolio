using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class AgentForm : Form
    {
        //Строка подключения
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.RealEstateDBConnectionString);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        public AgentForm()
        {
            InitializeComponent();
        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            connection.Open();

            agentPanel.AutoScroll = true;

            UpdateAgentList();
        }

        public void UpdateAgentList()
        {
            agentPanel.Controls.Clear();

            dt.Reset();
            da.SelectCommand = new SqlCommand("select * from AgentsSet", connection);
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
                button.Size = new Size(agentPanel.Width, 50);
                button.Location = new Point(0, i * 50);
                button.Click += Button_Click;

                agentPanel.Controls.Add(button);
            }
        }

        public void UpdateAgentListWithFilter()
        {
            if (searchTextBox.Text != "")
            {
                agentPanel.Controls.Clear();

                dt.Reset();
                da.SelectCommand = new SqlCommand("select * from AgentsSet", connection);
                da.Fill(dt);

                List<Agent> agents = new List<Agent>();

                //Фильтрация с помощью расстояния Левенштейна 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (LevenshteinDistance(dt.Rows[i][1].ToString(), searchTextBox.Text) <= 3 ||
                        LevenshteinDistance(dt.Rows[i][2].ToString(), searchTextBox.Text) <= 3 ||
                        LevenshteinDistance(dt.Rows[i][3].ToString(), searchTextBox.Text) <= 3)
                    {
                        Agent agent = new Agent
                        {
                            Id = Convert.ToInt32(dt.Rows[i][0]),
                            FirstName = dt.Rows[i][1].ToString(),
                            MiddleName = dt.Rows[i][2].ToString(),
                            LastName = dt.Rows[i][3].ToString(),
                            DealShare = Convert.ToInt32(dt.Rows[i][4])
                        };

                        agents.Add(agent);
                    }
                }

                //Настройка списка кнопок
                for (int i = 0; i < agents.Count; i++)
                {
                    Button button = new Button();

                    button.Name = agents[i].Id.ToString();
                    button.Text = agents[i].FirstName.ToString() + " " + agents[i].MiddleName.ToString() + " " + agents[i].LastName.ToString();
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Color.FromArgb(255, 236, 239, 241);
                    button.ForeColor = Color.FromArgb(1, 55, 71, 79);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Roboto", 10);
                    button.Size = new Size(agentPanel.Width, 50);
                    button.Location = new Point(0, i * 50);
                    button.Click += Button_Click;

                    agentPanel.Controls.Add(button);
                }
            }
            else
                UpdateAgentList();
        }

        //Нажатие на кнопку из списка
        private void Button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            AgentInfoForm agentInfoForm = new AgentInfoForm(((Button)sender).Name, connection, false);
            agentInfoForm.Show();
        }

        //Нажатие на кнопку добавления
        private void addAgentButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            AgentInfoForm agentInfoForm = new AgentInfoForm("", connection, true);
            agentInfoForm.Show();
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
            UpdateAgentListWithFilter();
        }

        private void AgentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            Application.OpenForms[0].Show();
        }
    }
}
