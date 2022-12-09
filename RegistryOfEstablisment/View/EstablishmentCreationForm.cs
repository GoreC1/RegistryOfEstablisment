using RegistryOfEstablisment.Controller;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class EstablismentCreationForm : Form
    {
        readonly IUnitOfControl _unit;
        public EstablismentCreationForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
        }

        private void EstablismentCreationForm_Load(object sender, EventArgs e)
        {
            EnterpriseType[] types = _unit.RegistryController.GetTypes().ToArray();
            typeBox.Items.AddRange(types);
            
            ManagementTerritory[] territories = _unit.RegistryController.GetTerritories().ToArray();
            territoryBox.Items.AddRange(territories);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!CheckCompletion())
            {
                MessageBox.Show("Данные заполнены некорректно!");
                return;
            }

            Enterprise ent = new()
            {
                Name = nameBox.Text,
                LegalEntity = legalEntityBox.Text,
                RealAddress = factAdressBox.Text,
                Address = regAdressBox.Text,
                Type = (EnterpriseType)typeBox.SelectedItem,
                Checkpoint = Convert.ToInt32(checkpointBox.Text),
                ITN = Convert.ToInt64(ITNBox.Text),
                ManagementTerritory = (ManagementTerritory)territoryBox.SelectedItem,
                TelephoneNumber = telBox.Text,
                WebSite = webSiteBox.Text,
                Email = mailBox.Text
            };
            
            _unit.EnterpriseController.AddEnterprise(ent);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool CheckCompletion()
        {
            string regTel = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            string regMail = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            string regWeb = @"(https?:\/\/|ftps?:\/\/|www\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}";
            return nameBox.Text.Length > 0 && legalEntityBox.Text.Length > 0 && factAdressBox.Text.Length > 0 && regAdressBox.Text.Length > 0 && typeBox.SelectedItem != null 
                && checkpointBox.Text.Length > 0 && ITNBox.Text.Length > 0 && territoryBox.SelectedItem != null && Regex.IsMatch(telBox.Text, regTel) && Regex.IsMatch(webSiteBox.Text, regWeb) 
                && Regex.IsMatch(mailBox.Text, regMail);
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkpointBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || checkpointBox.Text.Length==9)
                e.Handled = true;
        }

        private void ITNBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || ITNBox.Text.Length == 12)
                e.Handled = true;
        }
    }
}
