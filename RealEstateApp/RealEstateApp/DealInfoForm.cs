using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RealEstateApp
{
    public partial class DealInfoForm : Form
    {
        string dealId;
        string demandId;
        string supplyId;
        SqlConnection connection;
        bool fromAdd;

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt1 = new DataTable();
        SqlDataAdapter da1 = new SqlDataAdapter();

        DataTable dt2 = new DataTable();
        SqlDataAdapter da2 = new SqlDataAdapter();

        DataTable dt3 = new DataTable();
        SqlDataAdapter da3 = new SqlDataAdapter();

        public DealInfoForm(string DealId, string DemandId, string SupplyId, SqlConnection Connection, bool FromAdd)
        {
            InitializeComponent();
            connection = Connection;
            dealId = DealId;
            demandId = DemandId;
            supplyId = SupplyId;
            fromAdd = FromAdd;
        }

        private void DealInfoForm_Load(object sender, EventArgs e)
        {
            //Настройка размера списков
            demandComboBox.DropDownWidth = 660;
            supplyComboBox.DropDownWidth = 660;
            supplyComboBox.Enabled = false;

            demandComboBox.Items.Clear();

            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DemandSet", connection);
                da.Fill(dt);

                //Заполнение списка потребностей
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[i][7]}", connection);
                    da1.Fill(dt1);

                    dt2.Reset();
                    da2.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[i][8]}", connection);
                    da2.Fill(dt2);

                    dt3.Reset();
                    da3.SelectCommand = new SqlCommand($"select Demand_Id from DealSet where Demand_Id = {dt.Rows[i][0]}", connection);
                    da3.Fill(dt3);

                    if (dt3.Rows.Count == 0)
                        demandComboBox.Items.Add($"({dt.Rows[i][10].ToString()}) Риэлтор: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. --- Клиент: {dt2.Rows[0][1].ToString()} {dt2.Rows[0][2].ToString().ToUpper()[0]}. {dt2.Rows[0][3].ToString().ToUpper()[0]}. ({dt.Rows[i][0].ToString()})");
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                Text = "Информация о сделке";
                addUpdateClientButton.Text = "Удалить сделку";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from DemandSet", connection);
                da.Fill(dt);

                //Заполнение списка потребностей
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[i][7]}", connection);
                    da1.Fill(dt1);

                    dt2.Reset();
                    da2.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[i][8]}", connection);
                    da2.Fill(dt2);

                    dt3.Reset();
                    da3.SelectCommand = new SqlCommand($"select Demand_Id from DealSet where Demand_Id = {dt.Rows[i][0]}", connection);
                    da3.Fill(dt3);

                    demandComboBox.Items.Add($"({dt.Rows[i][10].ToString()}) Риэлтор: {dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}. --- Клиент: {dt2.Rows[0][1].ToString()} {dt2.Rows[0][2].ToString().ToUpper()[0]}. {dt2.Rows[0][3].ToString().ToUpper()[0]}. ({dt.Rows[i][0].ToString()})");
                }

                //Выбор текущей потребности
                foreach (string item in demandComboBox.Items)
                    if (item.Split('(')[2].Split(')')[0] == demandId)
                        demandComboBox.SelectedItem = item;

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where Id = {supplyId}", connection);
                da.Fill(dt);

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[0][2]}", connection);
                da1.Fill(dt1);

                string agentName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}.";

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[0][3]}", connection);
                da1.Fill(dt1);

                string clientName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}.";

                //Заполнение списка предложений
                supplyComboBox.Items.Add($"({dt.Rows[0][5].ToString()}) Клиент: {clientName} --- Риэлтор: {agentName} ({dt.Rows[0][0].ToString()})");

                //Выбор текущего предложения
                supplyComboBox.SelectedItem = $"({dt.Rows[0][5].ToString()}) Клиент: {clientName} --- Риэлтор: {agentName} ({dt.Rows[0][0].ToString()})";

                demandComboBox.Enabled = false;
                supplyComboBox.Enabled = false;
            }
        }

        private void addUpdateClientButton_Click(object sender, EventArgs e)
        {
            //Если форма открыта с помощью кнопки добавения
            if (fromAdd)
            {
                //Проверка незаполненных полей
                if (supplyComboBox.SelectedItem == null || demandComboBox.SelectedItem == null || supplyComboBox.SelectedItem.ToString() == "Нет удовлетворяющих предложений")
                {
                    MessageBox.Show("Есть незаполненные поля выбора");
                }
                else
                {
                    //Оформление сделки
                    da.InsertCommand = new SqlCommand($"insert into DealSet(Supply_Id, Demand_Id) values({supplyComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}, {demandComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]})", connection);
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Сделка оформлена");
                    Close();
                }
            }
            //Если форма открыта с помощью кнопки из списка
            else
            {
                //Удаление сделки
                da.DeleteCommand = new SqlCommand($"delete from DealSet where Demand_Id = {demandId} and Supply_Id = {supplyId}", connection);
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Сделка удалена");
                Close();
            }
        }

        private void supplyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplyRichTextBox.Text = "";

            if (supplyComboBox.SelectedItem.ToString() != "" && supplyComboBox.SelectedItem.ToString() != "Нет удовлетворяющих предложений")
            {
                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from SupplySet where Id = {supplyComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da.Fill(dt);

                //Заполнение крупного текстового поля предложения
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Для квартиры
                    if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Квартира")
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet_Apartment where Id = {dt.Rows[i][4].ToString()}", connection);
                        da1.Fill(dt1);

                        dt2.Reset();
                        da2.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][4].ToString()}", connection);
                        da2.Fill(dt2);

                        supplyRichTextBox.Text += $"Город: {dt2.Rows[0][1].ToString()}\n" +
                                            $"Улица: {dt2.Rows[0][2].ToString()}\n" +
                                            $"Дом: {dt2.Rows[0][3].ToString()}\n" +
                                            $"Квартира: {dt2.Rows[0][4].ToString()}\n" +
                                            $"Широта: {Convert.ToDouble(dt2.Rows[0][5])}\n" +
                                            $"Долгота: {Convert.ToDouble(dt2.Rows[0][6])}\n" +
                                            $"Тип недвижимости: Квартира\n" +
                                            $"Цена: {Convert.ToInt32(dt.Rows[i][1])}\n" +
                                            $"Площадь: {Convert.ToDouble(dt1.Rows[0][0])}\n" +
                                            $"Количество комнат: {Convert.ToInt32(dt1.Rows[0][1])}\n" +
                                            $"Этаж: {Convert.ToInt32(dt.Rows[0][2])}\n\n";
                    }

                    //Для дома
                    if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Дом")
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet_House where Id = {dt.Rows[i][4].ToString()}", connection);
                        da1.Fill(dt1);

                        dt2.Reset();
                        da2.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][4].ToString()}", connection);
                        da2.Fill(dt2);

                        supplyRichTextBox.Text += $"Город: {dt2.Rows[0][1].ToString()}\n" +
                                            $"Улица: {dt2.Rows[0][2].ToString()}\n" +
                                            $"Дом: {dt2.Rows[0][3].ToString()}\n" +
                                            $"Квартира: {dt2.Rows[0][4].ToString()}\n" +
                                            $"Широта: {Convert.ToDouble(dt2.Rows[0][5])}\n" +
                                            $"Долгота: {Convert.ToDouble(dt2.Rows[0][6])}\n" +
                                            $"Тип недвижимости: Дом\n" +
                                            $"Цена: {Convert.ToInt32(dt.Rows[i][1])}\n" +
                                            $"Площадь: {Convert.ToDouble(dt1.Rows[0][1])}\n" +
                                            $"Количество этажей: {Convert.ToInt32(dt.Rows[0][0])}\n\n";
                    }

                    //Для земли
                    if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Земля")
                    {
                        dt1.Reset();
                        da1.SelectCommand = new SqlCommand($"select * from RealEstateSet_Land where Id = {dt.Rows[i][4].ToString()}", connection);
                        da1.Fill(dt1);

                        dt2.Reset();
                        da2.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][4].ToString()}", connection);
                        da2.Fill(dt2);

                        supplyRichTextBox.Text += $"Город: {dt2.Rows[0][1].ToString()}\n" +
                                            $"Улица: {dt2.Rows[0][2].ToString()}\n" +
                                            $"Дом: {dt2.Rows[0][3].ToString()}\n" +
                                            $"Квартира: {dt2.Rows[0][4].ToString()}\n" +
                                            $"Широта: {Convert.ToDouble(dt2.Rows[0][5])}\n" +
                                            $"Долгота: {Convert.ToDouble(dt2.Rows[0][6])}\n" +
                                            $"Тип недвижимости: Земля\n" +
                                            $"Цена: {Convert.ToInt32(dt.Rows[i][1])}\n" +
                                            $"Площадь: {Convert.ToDouble(dt1.Rows[0][0])}\n";

                    }
                }

                double clientSeller = 0;
                double clientBuyer = 0;
                double agentSeller = 0;
                double agentBuyer = 0;
                double company = 0;

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select AgentId from DemandSet where Id = {demandComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da.Fill(dt);

                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select AgentId from SupplySet where Id = {supplyComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da1.Fill(dt1);

                dt2.Reset();
                da2.SelectCommand = new SqlCommand($"select DealShare from AgentsSet where Id = {dt.Rows[0][0]}", connection);
                da2.Fill(dt2);

                dt3.Reset();
                da3.SelectCommand = new SqlCommand($"select DealShare from AgentsSet where Id = {dt1.Rows[0][0]}", connection);
                da3.Fill(dt3);

                //Расчеты (для квартиры)
                if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Квартира")
                {
                    clientSeller = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 36000;
                    clientBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03;
                    agentSeller = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 36000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100);
                    agentBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100);
                    company = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 36000) - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 36000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100) +
                              Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100));
                }
                //Расчеты (для дома)
                else if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Дом")
                {
                    clientSeller = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 30000;
                    clientBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03;
                    agentSeller = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 30000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100);
                    agentBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100);
                    company = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 30000) - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.01 + 30000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100) +
                              Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100));
                }
                //Расчеты (для земли)
                else if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == "Земля")
                {
                    clientSeller = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.02 + 30000;
                    clientBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03;
                    agentSeller = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.02 + 30000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100);
                    agentBuyer = Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100);
                    company = (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.02 + 30000) - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.02 + 30000) * (Convert.ToDouble(dt3.Rows[0][0]) / 100) +
                              Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 - (Convert.ToDouble(supplyRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Площадь", "").Replace(" ", "")) * 0.03 * (Convert.ToDouble(dt2.Rows[0][0]) / 100));
                }

                //Заполнение крупного текстового поля расчетов
                priceRichTextBox.Text = $"Cтоимость услуг для клиента-продавца: {clientSeller.ToString("#.##")} ₽\n" + 
                                        $"Стоимость услуг для клиента-покупателя: {clientBuyer.ToString("#.##")} ₽\n" +
                                        $"Размер отчислений риэлтору клиента-продавца: {agentSeller.ToString("#.##")} ₽\n" +
                                        $"Размер отчислений риэлтору клиента-покупателя: {agentBuyer.ToString("#.##")} ₽\n" +
                                        $"Размер отчислений компании: {company.ToString("#.##")} ₽";
            }
        }

        private void demandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplyComboBox.Enabled = true;
            supplyComboBox.Items.Clear();
            supplyComboBox.SelectedItem = "";
            demandRichTextBox.Text = "";
            supplyRichTextBox.Text = "";
            priceRichTextBox.Text = "";

            //Заполнение крупного текстового поля потребностей (для квартиры)
            if (demandComboBox.SelectedItem.ToString().Contains("Квартира"))
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da1.Fill(dt1);

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_ApartmentFilter where Id = {dt1.Rows[0][9].ToString()}", connection);
                da.Fill(dt);

                demandRichTextBox.Text = $"Город: {dt1.Rows[0][1].ToString()}\n" +
                                $"Улица: {dt1.Rows[0][2].ToString()}\n" +
                                $"Дом: {dt1.Rows[0][3].ToString()}\n" +
                                $"Квартира: {dt1.Rows[0][4].ToString()}\n" +
                                $"Минимальная цена: {Convert.ToInt32(dt1.Rows[0][5])}\n" +
                                $"Максимальная цена: {Convert.ToInt32(dt1.Rows[0][6])}\n" +
                                $"Тип недвижимости: {dt1.Rows[0][10].ToString()}\n" +
                                $"Минимальная площадь: {dt.Rows[0][0].ToString()}\n" +
                                $"Максимальная площадь: {dt.Rows[0][1].ToString()}\n" +
                                $"Минимальное количество комнат: {dt.Rows[0][2].ToString()}\n" +
                                $"Максимальное количество комнат: {dt.Rows[0][3].ToString()}\n" +
                                $"Минимальный этаж: {dt.Rows[0][4].ToString()}\n" +
                                $"Максимальный этаж: {dt.Rows[0][5].ToString()}";

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_ApartmentFilter where Id = {dt1.Rows[0][9].ToString()}", connection);
                da.Fill(dt);
            }
            //Заполнение крупного текстового поля потребностей (для дома)
            else if (demandComboBox.SelectedItem.ToString().Contains("Дом"))
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da1.Fill(dt1);

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_HouseFilter where Id = {dt1.Rows[0][9].ToString()}", connection);
                da.Fill(dt);

                demandRichTextBox.Text = $"Город: {dt1.Rows[0][1].ToString()}\n" +
                                $"Улица: {dt1.Rows[0][2].ToString()}\n" +
                                $"Дом: {dt1.Rows[0][3].ToString()}\n" +
                                $"Квартира: {dt1.Rows[0][4].ToString()}\n" +
                                $"Минимальная цена: {Convert.ToInt32(dt1.Rows[0][5])}\n" +
                                $"Максимальная цена: {Convert.ToInt32(dt1.Rows[0][6])}\n" +
                                $"Тип недвижимости: {dt1.Rows[0][10].ToString()}\n" +
                                $"Минимальная площадь: {dt.Rows[0][2].ToString()}\n" +
                                $"Максимальная площадь: {dt.Rows[0][3].ToString()}\n" +
                                $"Минимальное количество комнат: {dt.Rows[0][4].ToString()}\n" +
                                $"Максимальное количество комнат: {dt.Rows[0][5].ToString()}\n" +
                                $"Минимальное количество этажей: {dt.Rows[0][0].ToString()}\n" +
                                $"Максимальное количество этажей: {dt.Rows[0][1].ToString()}";

            }
            //Заполнение крупного текстового поля потребностей (для земли)
            else if (demandComboBox.SelectedItem.ToString().Contains("Земля"))
            {
                dt1.Reset();
                da1.SelectCommand = new SqlCommand($"select * from DemandSet where Id = {demandComboBox.SelectedItem.ToString().Split('(')[2].Split(')')[0]}", connection);
                da1.Fill(dt1);

                dt.Reset();
                da.SelectCommand = new SqlCommand($"select * from RealEstateFilterSet_LandFilter where Id = {dt1.Rows[0][9].ToString()}", connection);
                da.Fill(dt);

                demandRichTextBox.Text = $"Город: {dt1.Rows[0][1].ToString()}\n" +
                                $"Улица: {dt1.Rows[0][2].ToString()}\n" +
                                $"Дом: {dt1.Rows[0][3].ToString()}\n" +
                                $"Квартира: {dt1.Rows[0][4].ToString()}\n" +
                                $"Минимальная цена: {Convert.ToInt32(dt1.Rows[0][5])}\n" +
                                $"Максимальная цена: {Convert.ToInt32(dt1.Rows[0][6])}\n" +
                                $"Тип недвижимости: {dt1.Rows[0][10].ToString()}\n" +
                                $"Минимальная площадь: {dt.Rows[0][0].ToString()}\n" +
                                $"Максимальная площадь: {dt.Rows[0][1].ToString()}";

            }

            //Обновление списка предложений
            UpdateSupplyList();

            //Если предложения не найдены
            if (supplyComboBox.Items.Count < 1)
            {
                supplyComboBox.Items.Add("Нет удовлетворяющих предложений");
                supplyComboBox.SelectedItem = "Нет удовлетворяющих предложений";
                supplyComboBox.Enabled = false;
            }
        }

        private void UpdateSupplyList()
        {
            dt.Reset();
            da.SelectCommand = new SqlCommand($"select * from SupplySet", connection);
            da.Fill(dt);

            //Заполнение списка предложений (в соответствии со всеми условиями потребности)
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Проверка типа недвижимости
                if (demandComboBox.SelectedItem.ToString().Split(')')[0].Split('(')[1] == dt.Rows[i][5].ToString())
                {
                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from AgentsSet where Id = {dt.Rows[i][2]}", connection);
                    da1.Fill(dt1);

                    string agentName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}.";

                    dt1.Reset();
                    da1.SelectCommand = new SqlCommand($"select * from ClientsSet where Id = {dt.Rows[i][3]}", connection);
                    da1.Fill(dt1);

                    string clientName = $"{dt1.Rows[0][1].ToString()} {dt1.Rows[0][2].ToString().ToUpper()[0]}. {dt1.Rows[0][3].ToString().ToUpper()[0]}.";

                    dt2.Reset();
                    da2.SelectCommand = new SqlCommand($"select * from RealEstateSet where Id = {dt.Rows[i][4]}", connection);
                    da2.Fill(dt2);

                    //Проверка цены
                    if (Convert.ToInt32(dt.Rows[i][1]) >= Convert.ToInt32(demandRichTextBox.Text.Split(':')[5].Split(':')[0].Replace("Максимальная цена", "").Replace(" ", ""))
                        && Convert.ToInt32(dt.Rows[i][1]) <= Convert.ToInt32(demandRichTextBox.Text.Split(':')[6].Split(':')[0].Replace("Тип недвижимости", "").Replace(" ", "")))
                    {
                        string city = "";
                        string street = "";
                        string house = "";
                        string number = "";
                      
                        if (demandRichTextBox.Text.Split(':')[1].Split(':')[0].Replace("Улица", "").Remove(0, 1).Replace("\n", "") != "")
                            city = demandRichTextBox.Text.Split(':')[1].Split(':')[0].Replace("Улица", "").Remove(0, 1).Replace("\n", "");
                        if (demandRichTextBox.Text.Split(':')[2].Split(':')[0].Replace("Дом", "").Remove(0, 1).Replace("\n", "") != "")
                            street = demandRichTextBox.Text.Split(':')[2].Split(':')[0].Replace("Дом", "").Remove(0, 1).Replace("\n", "");
                        if (demandRichTextBox.Text.Split(':')[3].Split(':')[0].Replace("Квартира", "").Remove(0, 1).Replace("\n", "") != "")
                            house = demandRichTextBox.Text.Split(':')[3].Split(':')[0].Replace("Квартира", "").Remove(0, 1).Replace("\n", "");
                        if (demandRichTextBox.Text.Split(':')[4].Split(':')[0].Replace("Минимальная цена", "").Remove(0, 1).Replace("\n", "") != "")
                            number = demandRichTextBox.Text.Split(':')[4].Split(':')[0].Replace("Минимальная цена", "").Remove(0, 1).Replace("\n", "");

                        //Проверка адреса
                        if ((city == "" || city == dt2.Rows[0][1].ToString()) && (street == "" || street == dt2.Rows[0][2].ToString()) && (house == "" || house == dt2.Rows[0][3].ToString()) && (number == "" || number == dt2.Rows[0][4].ToString()))
                        {
                            //Для квартиры
                            if (dt.Rows[i][5].ToString() == "Квартира")
                            {
                                dt3.Reset();
                                da3.SelectCommand = new SqlCommand($"select * from RealEstateSet_Apartment where Id = {dt.Rows[i][4]}", connection);
                                da3.Fill(dt3);

                                string minArea = "";
                                string maxArea = "";
                                string minRooms = "";
                                string maxRooms = "";
                                string minFloor = "";
                                string maxFloor = "";

                                if (demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "") != "")
                                    minArea = demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[9].Split(':')[0].Replace("Минимальное количество комнат", "").Remove(0, 1).Replace("\n", "") != "")
                                    maxArea = demandRichTextBox.Text.Split(':')[9].Split(':')[0].Replace("Минимальное количество комнат", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[10].Split(':')[0].Replace("Максимальное количество комнат", "").Remove(0, 1).Replace("\n", "") != "")
                                    minRooms = demandRichTextBox.Text.Split(':')[10].Split(':')[0].Replace("Максимальное количество комнат", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[11].Split(':')[0].Replace("Минимальный этаж", "").Remove(0, 1).Replace("\n", "") != "")
                                    maxRooms = demandRichTextBox.Text.Split(':')[11].Split(':')[0].Replace("Минимальный этаж", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[12].Split(':')[0].Replace("Максимальный этаж", "").Remove(0, 1).Replace("\n", "") != "")
                                    minFloor = demandRichTextBox.Text.Split(':')[12].Split(':')[0].Replace("Максимальный этаж", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[13].Remove(0, 1).Replace("\n", "") != "")
                                    maxFloor = demandRichTextBox.Text.Split(':')[13].Remove(0, 1).Replace("\n", "");

                                //Проверка дополнительных сведений
                                if ((Convert.ToDouble(dt3.Rows[0][0]) >= Convert.ToDouble(minArea) || minArea == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][0]) <= Convert.ToDouble(maxArea) || maxArea == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][1]) >= Convert.ToInt32(minRooms) || minRooms == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][1]) <= Convert.ToInt32(maxRooms) || maxRooms == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][2]) >= Convert.ToInt32(minFloor) || minFloor == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][2]) <= Convert.ToInt32(maxFloor) || maxFloor == ""))
                                {
                                    dt3.Reset();
                                    da3.SelectCommand = new SqlCommand($"select Supply_Id from dealSet where Supply_Id = {dt.Rows[i][0]}", connection);
                                    da3.Fill(dt3);

                                    //Проверка на наличие в сделке
                                    if (dt3.Rows.Count == 0)
                                        supplyComboBox.Items.Add($"({dt.Rows[i][5].ToString()}) Клиент: {clientName} --- Риэлтор: {agentName} ({dt.Rows[i][0].ToString()})");
                                }
                            }
                            //Для дома
                            else if (dt.Rows[i][5].ToString() == "Дом")
                            {
                                dt3.Reset();
                                da3.SelectCommand = new SqlCommand($"select * from RealEstateSet_House where Id = {dt.Rows[i][4]}", connection);
                                da3.Fill(dt3);

                                string minArea = "";
                                string maxArea = "";
                                string minFloor = "";
                                string maxFloor = "";

                                if (demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "") != "")
                                    minArea = demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[9].Split(':')[0].Replace("Минимальное количество комнат", "").Remove(0, 1).Replace("\n", "") != "")
                                    maxArea = demandRichTextBox.Text.Split(':')[9].Split(':')[0].Replace("Минимальное количество комнат", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[12].Split(':')[0].Replace("Максимальное количество этажей", "").Remove(0, 1).Replace("\n", "") != "")
                                    minFloor = demandRichTextBox.Text.Split(':')[12].Split(':')[0].Replace("Максимальное количество этажей", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[13].Remove(0, 1).Replace("\n", "") != "")
                                    maxFloor = demandRichTextBox.Text.Split(':')[13].Remove(0, 1).Replace("\n", "");

                                //Проверка дополнительных сведений
                                if ((Convert.ToDouble(dt3.Rows[0][0]) >= Convert.ToInt32(minFloor) || minFloor == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][0]) <= Convert.ToInt32(maxFloor) || maxFloor == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][1]) >= Convert.ToDouble(minArea) || minArea == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][1]) <= Convert.ToDouble(maxArea) || maxArea == ""))
                                {
                                    dt3.Reset();
                                    da3.SelectCommand = new SqlCommand($"select Supply_Id from dealSet where Supply_Id = {dt.Rows[i][0]}", connection);
                                    da3.Fill(dt3);

                                    //Проверка на наличие в сделке
                                    if (dt3.Rows.Count == 0)
                                        supplyComboBox.Items.Add($"({dt.Rows[i][5].ToString()}) Клиент: {clientName} --- Риэлтор: {agentName} ({dt.Rows[i][0].ToString()})");
                                }
                            }
                            //Для земли
                            else if (dt.Rows[i][5].ToString() == "Земля")
                            {
                                dt3.Reset();
                                da3.SelectCommand = new SqlCommand($"select * from RealEstateSet_Land where Id = {dt.Rows[i][4]}", connection);
                                da3.Fill(dt3);

                                string minArea = "";
                                string maxArea = "";

                                if (demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "") != "")
                                    minArea = demandRichTextBox.Text.Split(':')[8].Split(':')[0].Replace("Максимальная площадь", "").Remove(0, 1).Replace("\n", "");
                                if (demandRichTextBox.Text.Split(':')[9].Remove(0, 1).Replace("\n", "") != "")
                                    maxArea = demandRichTextBox.Text.Split(':')[9].Remove(0, 1).Replace("\n", "");

                                //Проверка дополнительных сведений
                                if ((Convert.ToDouble(dt3.Rows[0][0]) >= Convert.ToDouble(minArea) || minArea == "") &&
                                    (Convert.ToDouble(dt3.Rows[0][0]) <= Convert.ToDouble(maxArea) || maxArea == ""))
                                {
                                    dt3.Reset();
                                    da3.SelectCommand = new SqlCommand($"select Supply_Id from dealSet where Supply_Id = {dt.Rows[i][0]}", connection);
                                    da3.Fill(dt3);

                                    //Проверка на наличие в сделке
                                    if (dt3.Rows.Count == 0)
                                        supplyComboBox.Items.Add($"({dt.Rows[i][5].ToString()}) Клиент: {clientName} --- Риэлтор: {agentName} ({dt.Rows[i][0].ToString()})");
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void DealInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[1].Enabled = true;
            ((DealForm)Application.OpenForms[1]).UpdateDealList();
        }
    }
}
