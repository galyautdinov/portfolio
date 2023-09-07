using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class AgentInfoForm : Form
    {
        string agentId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public AgentInfoForm(string AgentId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            agentId = AgentId;
            connection = Connection;
            fromAdd = FromAdd;
        }

        private void AgentInfoForm_Load(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                addUpdateAgentButton.Text = "Обновить риэлтора";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {agentId}", connection);
                da.Fill(dt);

                Agent agent = new Agent
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    FirstName = dt.Rows[0][1].ToString(),
                    MiddleName = dt.Rows[0][2].ToString(),
                    LastName = dt.Rows[0][3].ToString(),
                    DealShare = Convert.ToInt32(dt.Rows[0][4].ToString())
                };

                //Заполнение полей
                firstnameTextBox.Text = agent.FirstName;
                middlenameTextBox.Text = agent.MiddleName;
                lastnameTextBox.Text = agent.LastName;
                dealShareTextBox.Text = agent.DealShare.ToString();

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DemandSet where AgentId = {agentId}", connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[0][8]}", connection);
                    da1.Fill(dt1);

                    //Заполнение крупного текстового поля потребностей
                    demandRichTextBox.Text += $"({dt.Rows[0][10].ToString()}) Риэлтор: {agent.FirstName} {agent.MiddleName.ToUpper()[0]}. {agent.LastName.ToUpper()[0]}. --- Клиент: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. ({dt.Rows[0][0].ToString()})\n";
                }

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where AgentId = {agentId}", connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[0][3]}", connection);
                    da1.Fill(dt1);

                    //Заполнение крупного текстового поля предложений
                    supplyRichTextBox.Text += $"({dt.Rows[0][5].ToString()}) Риэлтор: {agent.FirstName} {agent.MiddleName.ToUpper()[0]}. {agent.LastName.ToUpper()[0]}. --- Клиент: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. ({dt.Rows[0][0].ToString()})\n";
                }
            }
            //Если форма открыта с помощью кнопки добавения
            else
            {
                Text = "Добавление риэлтора";

                addUpdateAgentButton.Text = "Добавить риэлтора";
                deleteAgentButton.Visible = false;

                foreach (TextBox obj in Controls.OfType<TextBox>())
                    if (obj.Text != "0")
                        obj.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void addUpdateAgentButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                //Проверка заполнения полей
                if (firstnameTextBox.Text == "Фамилия" || middlenameTextBox.Text == "Имя" || lastnameTextBox.Text == "Отчество")
                {
                    foreach (TextBox obj in Controls.OfType<TextBox>())
                        if (obj.Text == "Фамилия" || obj.Text == "Имя" || obj.Text == "Отчество")
                            obj.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Есть незаполненные поля!");
                }
                //Добавление
                else
                {
                    da.InsertCommand = new SqlCommand($"insert into AgentsSet values((select max(Id)+1 from AgentsSet), '{firstnameTextBox.Text}', '{middlenameTextBox.Text}', '{lastnameTextBox.Text}', {dealShareTextBox.Text})", connection);
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Риэлтор добавлен");
                    Close();
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                //Проверка заполнения полей
                if (firstnameTextBox.Text == "Фамилия" || middlenameTextBox.Text == "Имя" || lastnameTextBox.Text == "Отчество")
                {
                    foreach (TextBox obj in Controls.OfType<TextBox>())
                        if (obj.Text == "Фамилия" || obj.Text == "Имя" || obj.Text == "Отчество")
                            obj.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Есть незаполненные поля!");
                }
                //Обновление
                else
                {
                    da.UpdateCommand = new SqlCommand($"update AgentsSet set FirstName = '{firstnameTextBox.Text}', MiddleName = '{middlenameTextBox.Text}', LastName = '{lastnameTextBox.Text}', DealShare = {dealShareTextBox.Text} where Id = {agentId}", connection);
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Риэлтор обновлен");
                    Close();
                }
            }
        }

        private void deleteAgentButton_Click(object sender, EventArgs e)
        {
            //Проверка на наличие связей с потребностью или предложением
            if (demandRichTextBox.Text == "" && supplyRichTextBox.Text == "")
            {
                //Удаление
                da.DeleteCommand = new SqlCommand($"delete from AgentsSet where Id = {agentId}", connection);
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Риэлтор удален");
                Close();
            }
            else
            {
                MessageBox.Show("Риэлтор связан с потребностью или предложением. Удаление невозможно");
            }
        }

        private void firstnameTextBox_Enter(object sender, EventArgs e)
        {
            if (firstnameTextBox.Text == "Фамилия")
            {
                firstnameTextBox.Text = null;
                firstnameTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void firstnameTextBox_Leave(object sender, EventArgs e)
        {
            if (firstnameTextBox.Text == "")
            {
                firstnameTextBox.Text = "Фамилия";
                firstnameTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void middlenameTextBox_Enter(object sender, EventArgs e)
        {
            if (middlenameTextBox.Text == "Имя")
            {
                middlenameTextBox.Text = null;
                middlenameTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void middlenameTextBox_Leave(object sender, EventArgs e)
        {
            if (middlenameTextBox.Text == "")
            {
                middlenameTextBox.Text = "Имя";
                middlenameTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void lastnameTextBox_Enter(object sender, EventArgs e)
        {
            if (lastnameTextBox.Text == "Отчество")
            {
                lastnameTextBox.Text = null;
                lastnameTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void lastnameTextBox_Leave(object sender, EventArgs e)
        {
            if (lastnameTextBox.Text == "")
            {
                lastnameTextBox.Text = "Отчество";
                lastnameTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void dealShareTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dealShareTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Ограничение ввода (0 - 100)
            if (dealShareTextBox.Text == "")
                dealShareTextBox.Text = "0";
            else if (Convert.ToInt32(dealShareTextBox.Text) > 100 || dealShareTextBox.Text.Length > 2 && dealShareTextBox.Text != "100")
                dealShareTextBox.Text = "100";
            else if (dealShareTextBox.Text[0] == '0' && dealShareTextBox.Text != "0")
                dealShareTextBox.Text = dealShareTextBox.Text.Remove(0, 1);
        }

        private void AgentInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((AgentForm)Application.OpenForms[1]).UpdateAgentListWithFilter();
        }
    }
}
