using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class SupplyInfoForm : Form
    {
        string supplyId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        public SupplyInfoForm(string SupplyId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            supplyId = SupplyId;
            connection = Connection;
            fromAdd = FromAdd;
        }

        private void SupplyInfoForm_Load(object sender, EventArgs e)
        {
            //Настройка размера списков
            agentComboBox.DropDownWidth = 400;
            clientComboBox.DropDownWidth = 400;
            RealEstateComboBox.DropDownWidth = 500;

            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                addUpdateSupplyButton.Text = "Обновить предложение";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where Id = {supplyId}", connection);
                da.Fill(dt);

                Supply supply = new Supply
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    Price = Convert.ToInt32(dt.Rows[0][1]),
                    AgentId = Convert.ToInt32(dt.Rows[0][2]),
                    ClientId = Convert.ToInt32(dt.Rows[0][3]),
                    RealEstateId = Convert.ToInt32(dt.Rows[0][4])
                };

                //Заполнение списков и полей
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet", connection);
                da.Fill(dt);

                for(int i = 0; i < dt.Rows.Count; i++)
                    agentComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {supply.AgentId}", connection);
                da.Fill(dt);

                agentComboBox.SelectedItem = $"{dt.Rows[0][1].ToString()} {dt.Rows[0][2].ToString()} {dt.Rows[0][3].ToString()} ({dt.Rows[0][0].ToString()})";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    clientComboBox.Items.Add($"{dt.Rows[i][1].ToString()} {dt.Rows[i][2].ToString()} {dt.Rows[i][3].ToString()} ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {supply.ClientId}", connection);
                da.Fill(dt);

                clientComboBox.SelectedItem = $"{dt.Rows[0][1].ToString()} {dt.Rows[0][2].ToString()} {dt.Rows[0][3].ToString()} ({dt.Rows[0][0].ToString()})";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Apartment where RealEstateSet.Id = RealEstateSet_Apartment.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Квартира) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + ", кв. " + dt.Rows[i][4].ToString() + $" ({ dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Apartment where RealEstateSet.Id = {supply.RealEstateId}", connection);
                da.Fill(dt);

                RealEstateComboBox.SelectedItem = "(Квартира) " + dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString() + ", кв. " + dt.Rows[0][4].ToString() + $" ({ dt.Rows[0][0].ToString()})";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_House where RealEstateSet.Id = RealEstateSet_House.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Дом) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + $" ({ dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_House where RealEstateSet.Id = {supply.RealEstateId}", connection);
                da.Fill(dt);

                RealEstateComboBox.SelectedItem = "(Дом) " + dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString() + $" ({ dt.Rows[0][0].ToString()})";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Land where RealEstateSet.Id = RealEstateSet_Land.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Земля) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + $" ({ dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Land where RealEstateSet.Id = {supply.RealEstateId}", connection);
                da.Fill(dt);

                RealEstateComboBox.SelectedItem = "(Земля) " + dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString() + $" ({ dt.Rows[0][0].ToString()})";

                priceTextBox.Text = supply.Price.ToString();
            }
            //Если форма открыта с помощью кнопки добавения
            else
            {
                Text = "Добавление предложения";

                addUpdateSupplyButton.Text = "Добавить предложение";
                deleteSupplyButton.Visible = false;

                clientComboBox.SelectedItem = "";
                agentComboBox.SelectedItem = "";
                RealEstateComboBox.SelectedItem = "";

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

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Apartment where RealEstateSet.Id = RealEstateSet_Apartment.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Квартира) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + ", кв. " + dt.Rows[i][4].ToString() + $" ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_House where RealEstateSet.Id = RealEstateSet_House.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Дом) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + $" ({dt.Rows[i][0].ToString()})");

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateSet, RealEstateSet_Land where RealEstateSet.Id = RealEstateSet_Land.Id", connection);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                    RealEstateComboBox.Items.Add("(Земля) " + dt.Rows[i][1].ToString() + ", " + dt.Rows[i][2].ToString() + $" ({dt.Rows[i][0].ToString()})");      
            }
        }

        private void addUpdateSupplyButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                //Проверка незаполненных полей
                if (clientComboBox.SelectedItem == null || agentComboBox.SelectedItem == null || RealEstateComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Есть незаполненные поля выбора");
                }
                else
                {
                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_Apartment where Id = {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                    da.Fill(dt);

                    //Добавление предложения (для квартиры)
                    if (dt.Rows.Count > 0)
                    {
                        da.InsertCommand = new SqlCommand($"insert into SupplySet(Price, AgentId, ClientId, RealEstateId, RealEstate_Type) values({priceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}, 'Квартира')", connection);
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Предложение добавлено");
                        Close();
                    }

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_House where Id = {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                    da.Fill(dt);

                    //Добавление предложения (для дома)
                    if (dt.Rows.Count > 0)
                    {
                        da.InsertCommand = new SqlCommand($"insert into SupplySet(Price, AgentId, ClientId, RealEstateId, RealEstate_Type) values({priceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}, 'Дом')", connection);
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Предложение добавлено");
                        Close();
                    }

                    dt.Reset();
                    da.SelectCommand = new SqlCommand($"select * from RealEstateSet_Land where Id = {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                    da.Fill(dt);

                    //Добавление предложения (для земли)
                    if (dt.Rows.Count > 0)
                    {
                        da.InsertCommand = new SqlCommand($"insert into SupplySet(Price, AgentId, ClientId, RealEstateId, RealEstate_Type) values({priceTextBox.Text}, {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}, 'Земля')", connection);
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Предложение добавлено");
                        Close();
                    }
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                //Проверка незаполненных полей
                if (clientComboBox.SelectedItem == null || agentComboBox.SelectedItem == null || RealEstateComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Есть незаполненные поля выбора");
                }
                else
                {
                    //Обновление предложения
                    da.UpdateCommand = new SqlCommand($"update SupplySet set Price = {priceTextBox.Text}, AgentId = {agentComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, ClientId = {clientComboBox.SelectedItem.ToString().Split('(')[1].Split(')')[0]}, RealEstateId = {RealEstateComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]} where Id = {supplyId}", connection);
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Предложение обновлено");
                    Close();
                }
            }
        }

        private void deleteSupplyButton_Click(object sender, EventArgs e)
        {
            dt.Reset();
            da.SelectCommand = new SqlCommand($"select * from DealSet where Supply_Id = {supplyId}", connection);
            da.Fill(dt);

            //Проверка на наличие связей со сделкой
            if (dt.Rows.Count == 0)
            {
                //Удаление
                da.DeleteCommand = new SqlCommand($"delete from SupplySet where Id = {supplyId}", connection);
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Предложение удалено");
                Close();
            }
            else
            {
                MessageBox.Show("Предложение связано со сделкой. Удаление невозможно");
            }
        }

        private void priceTextBox_Enter(object sender, EventArgs e)
        {
            if (priceTextBox.Text == "Цена")
            {
                priceTextBox.Text = null;
                priceTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {
            if (priceTextBox.Text == "")
            {
                priceTextBox.Text = "Цена";
                priceTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void priceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Ограничение ввода (> 0)
            if (priceTextBox.Text == "")
                priceTextBox.Text = "0";
        }

        private void SupplyInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((SupplyForm)Application.OpenForms[1]).UpdateSupplyList();
        }
    }
}
