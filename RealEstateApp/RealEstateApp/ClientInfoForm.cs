using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class ClientInfoForm : Form
    {
        string clientId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        public ClientInfoForm(string ClientId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            clientId = ClientId;
            connection = Connection;
            fromAdd = FromAdd;
        }

        private void ClientInfoForm_Load(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки из списка
            if (!fromAdd)
            {
                addUpdateClientButton.Text = "Обновить клиента";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {clientId}", connection);
                da.Fill(dt);

                Client client = new Client
                {
                    Id = Convert.ToInt32(dt.Rows[0][0]),
                    FirstName = dt.Rows[0][1].ToString(),
                    MiddleName = dt.Rows[0][2].ToString(),
                    LastName = dt.Rows[0][3].ToString(),
                    Phone = dt.Rows[0][4].ToString(),
                    Email = dt.Rows[0][5].ToString(),
                };

                //Заполнение полей
                firstnameTextBox.Text = client.FirstName;
                middlenameTextBox.Text = client.MiddleName;
                lastnameTextBox.Text = client.LastName;
                if (client.Phone != "")
                    phoneTextBox.Text = client.Phone;
                else
                {
                    phoneTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                    phoneTextBox.Text = "Телефон";
                }
                if (client.Email != "")
                    emailTextBox.Text = client.Email;
                else
                {
                    emailTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
                    emailTextBox.Text = "Почта";
                }

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DemandSet where ClientId = {clientId}", connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[0][7]}", connection);
                    da1.Fill(dt1);

                    //Заполнение крупного текстового поля потребностей
                    demandRichTextBox.Text += $"({dt.Rows[0][10].ToString()}) Риэлтор: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. --- Клиент: {client.FirstName} {client.MiddleName.ToUpper()[0]}. {client.LastName.ToUpper()[0]}. ({dt.Rows[0][0].ToString()})\n";
                }

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where ClientId = {clientId}", connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[0][2]}", connection);
                    da1.Fill(dt1);

                    //Заполнение крупного текстового поля предложений
                    supplyRichTextBox.Text += $"({dt.Rows[0][5].ToString()}) Риэлтор: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. --- Клиент: {client.FirstName} {client.MiddleName.ToUpper()[0]}. {client.LastName.ToUpper()[0]}. ({dt.Rows[0][0].ToString()})\n";
                }
            }
            //Если форма открыта с помощью кнопки добавения
            else
            {
                Text = "Добавление клиента";

                addUpdateClientButton.Text = "Добавить клиента";
                deleteClientButton.Visible = false;

                foreach(TextBox obj in Controls.OfType<TextBox>())
                    obj.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void addUpdateClientButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                //Проверка полей
                if (firstnameTextBox.Text == "Фамилия" || middlenameTextBox.Text == "Имя" || lastnameTextBox.Text == "Отчество")
                { 
                    foreach (TextBox obj in Controls.OfType<TextBox>())
                        if (obj.Text == "Фамилия" || obj.Text == "Имя" || obj.Text == "Отчество")
                            obj.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Есть незаполненные поля!");
                }
                else if(emailTextBox.Text != "Почта" && !emailTextBox.Text.Contains("@"))
                {
                    MessageBox.Show("Не хватает символа '@' в поле почты!");
                }
                else if (emailTextBox.Text == "Почта" && phoneTextBox.Text == "Телефон")
                {
                    emailTextBox.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    phoneTextBox.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Заполните поле телефона или почты!");
                }
                //Добавление
                else
                {
                    if (phoneTextBox.Text == "Телефон")
                        phoneTextBox.Text = "";

                    if (emailTextBox.Text == "Почта")
                        emailTextBox.Text = "";

                    da.InsertCommand = new SqlCommand($"insert into ClientsSet values((select max(Id)+1 from ClientsSet), '{firstnameTextBox.Text}', '{middlenameTextBox.Text}', '{lastnameTextBox.Text}', '{phoneTextBox.Text}', '{emailTextBox.Text}')", connection);
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Клиент добавлен");
                    Close();
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                //Проверка полей
                if (firstnameTextBox.Text == "Фамилия" || middlenameTextBox.Text == "Имя" || lastnameTextBox.Text == "Отчество")
                {
                    foreach (TextBox obj in Controls.OfType<TextBox>())
                        if (obj.Text == "Фамилия" || obj.Text == "Имя" || obj.Text == "Отчество")
                            obj.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Есть незаполненные поля!");
                }
                else if (emailTextBox.Text != "Почта" && !emailTextBox.Text.Contains("@"))
                {
                    MessageBox.Show("Не хватает символа '@' в поле почты!");
                }
                else if (emailTextBox.Text == "Почта" && phoneTextBox.Text == "Телефон")
                {
                    emailTextBox.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    phoneTextBox.ForeColor = Color.FromArgb(1, 255, 23, 68);
                    MessageBox.Show("Заполните поле телефона или почты!");
                }
                //Обновление
                else
                {
                    if (phoneTextBox.Text == "Телефон")
                        phoneTextBox.Text = "";

                    if (emailTextBox.Text == "Почта")
                        emailTextBox.Text = "";

                    da.UpdateCommand = new SqlCommand($"update ClientsSet set FirstName = '{firstnameTextBox.Text}', MiddleName = '{middlenameTextBox.Text}', LastName = '{lastnameTextBox.Text}', Phone = '{phoneTextBox.Text}', Email = '{emailTextBox.Text}' where Id = {clientId}", connection);
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Клиент обновлен");
                    Close();
                }
            }
        }

        private void deleteClientButton_Click(object sender, EventArgs e)
        {
            //Проверка на наличие связей с потребностью или предложением
            if (demandRichTextBox.Text == "" && supplyRichTextBox.Text == "")
            {
                //Удаление
                da.DeleteCommand = new SqlCommand($"delete from ClientsSet where Id = {clientId}", connection);
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Клиент удален");
                Close();
            }
            else
            {
                MessageBox.Show("Клиент связан с потребностью или предложением. Удаление невозможно");
            }
        }

        private void phoneTextBox_Enter(object sender, EventArgs e)
        {
            if (phoneTextBox.Text == "Телефон")
            {
                phoneTextBox.Text = null;
                phoneTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void phoneTextBox_Leave(object sender, EventArgs e)
        {
            if (phoneTextBox.Text == "")
            {
                phoneTextBox.Text = "Телефон";
                phoneTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "Почта")
            {
                emailTextBox.Text = null;
                emailTextBox.ForeColor = Color.FromArgb(1, 55, 71, 79);
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                emailTextBox.Text = "Почта";
                emailTextBox.ForeColor = Color.FromArgb(1, 176, 190, 197);
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

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //Ввод только чисел
            if (!char.IsDigit(number) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void emailTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Изменение цвета текста в поле ввода почты при наличии символа '@'
            if (emailTextBox.Text.Contains("@"))
                emailTextBox.ForeColor = Color.FromArgb(1, 0, 191, 165);
            else
                emailTextBox.ForeColor = Color.FromArgb(1, 255, 23, 68);
        }

        private void ClientInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((ClientForm)Application.OpenForms[1]).UpdateClientListWithFilter();
        }
    }
}
