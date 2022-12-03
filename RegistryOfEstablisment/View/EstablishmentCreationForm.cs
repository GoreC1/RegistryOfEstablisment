using RegistryOfEstablisment.Controller;
using RegistryOfEstablisment.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class EstablismentCreationForm : Form
    {
        public EstablismentCreationForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EstablismentCreationForm_Load(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void AddNewEnterprise()
        {
            Enterprise e = new Enterprise();
            EnterpriseController.AddEnterprise(e);
        }

        public void UpdateEnterprise(Enterprise enterprise)
        {
            EnterpriseController.UpdateEnterprise(enterprise);
        }
    }
}
