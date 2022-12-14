using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class EstablishmentForm : Form
    {
        private readonly IUnitOfControl _unit;
        private readonly Enterprise _enterprise;
        public EstablishmentForm(IUnitOfControl unit, Enterprise ent)
        {
            InitializeComponent();
            _unit = unit;
            _enterprise = ent;

            if (!_unit.EnterpriseTypeController.IsForRegistration(ent.Type))
            {
                registrationButton.Visible = false;
            }
        }
        private void EstablishmentForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = _enterprise.Name;
            realAddressBox.Text = _enterprise.RealAddress;
            addressBox.Text = _enterprise.Address;
            checkpointBox.Text = _enterprise.Checkpoint.ToString();
            ITNBox.Text = _enterprise.ITN.ToString();
            telBox.Text = _enterprise.TelephoneNumber;
            webSiteBox.Text = _enterprise.WebSite;
            mailBox.Text = _enterprise.Email;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Form registrForm = new RegistrationForm(_unit, _enterprise);
            registrForm.ShowDialog();
        }
    }
}
