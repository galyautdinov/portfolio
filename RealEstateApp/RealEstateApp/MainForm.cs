using System;
using System.Windows.Forms;

namespace RealEstateApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //Настройка домена
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath.Replace(@"\bin\Debug", ""));
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            Hide();
            clientForm.Show();
        }

        private void buttonAgents_Click(object sender, EventArgs e)
        {
            AgentForm agentForm = new AgentForm();
            Hide();
            agentForm.Show();
        }

        private void buttonRealEstate_Click(object sender, EventArgs e)
        {
            RealEstateForm realEstateForm = new RealEstateForm();
            Hide();
            realEstateForm.Show();
        }

        private void buttonSupply_Click(object sender, EventArgs e)
        {
            SupplyForm supplyForm = new SupplyForm();
            Hide();
            supplyForm.Show();
        }

        private void buttonDemand_Click(object sender, EventArgs e)
        {
            DemandForm demandForm = new DemandForm();
            Hide();
            demandForm.Show();
        }

        private void buttonDeal_Click(object sender, EventArgs e)
        {
            DealForm dealForm = new DealForm();
            Hide();
            dealForm.Show();
        }
    }
}
