﻿using RegistryOfEstablisment.Model.Entities;
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
    public partial class EstablishmentChangingForm : Form
    {
        readonly IUnitOfControl _unit;
        readonly int ID;
        public EstablishmentChangingForm(IUnitOfControl unit, int enterpriseID)
        {
            InitializeComponent();
            _unit = unit;
            ID = enterpriseID;
        }

        private void EstablishmentChangingForm_Load(object sender, EventArgs e)
        {
            EnterpriseType[] types = _unit.RegistryController.GetTypes().ToArray();
            typeBox.Items.AddRange(types);

            ManagementTerritory[] territories = _unit.RegistryController.GetTerritories().ToArray();
            territoryBox.Items.AddRange(territories);

            InsertValues();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (!CheckCompletion())
            {
                MessageBox.Show("Данные заполнены некорректно!");
                return;
            }

            Enterprise newEnterprise = new()
            {
                Id = ID,
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

            _unit.EnterpriseController.UpdateEnterprise(newEnterprise);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool CheckCompletion()
        {
            string regTel = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            string regMail = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            string regWeb = @"(https?:\/\/|ftps?:\/\/|www\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}";

            ShowTextErrors(nameBox, nameBox.Text.Length > 0);
            ShowTextErrors(legalEntityBox, legalEntityBox.Text.Length > 0);
            ShowTextErrors(factAdressBox, factAdressBox.Text.Length > 0);
            ShowTextErrors(regAdressBox, regAdressBox.Text.Length > 0);
            ShowComboErrors(typeBox, typeBox.SelectedItem != null);
            ShowTextErrors(checkpointBox, checkpointBox.Text.Length > 0);
            ShowTextErrors(ITNBox, ITNBox.Text.Length > 0);
            ShowComboErrors(territoryBox, territoryBox.SelectedItem != null);
            ShowTextErrors(telBox, Regex.IsMatch(telBox.Text, regTel));
            ShowTextErrors(webSiteBox, Regex.IsMatch(webSiteBox.Text, regWeb));
            ShowTextErrors(mailBox, Regex.IsMatch(mailBox.Text, regMail));

            return nameBox.Text.Length > 0 && legalEntityBox.Text.Length > 0 && factAdressBox.Text.Length > 0 && regAdressBox.Text.Length > 0 && typeBox.SelectedItem != null
                && checkpointBox.Text.Length > 0 && ITNBox.Text.Length > 0 && territoryBox.SelectedItem != null && Regex.IsMatch(telBox.Text, regTel) && Regex.IsMatch(webSiteBox.Text, regWeb)
                && Regex.IsMatch(mailBox.Text, regMail);
        }

        private void InsertValues()
        {
            Enterprise ent = _unit.EnterpriseController.GetEnterprise(ID);

            nameBox.Text = ent.Name;
            legalEntityBox.Text = ent.LegalEntity;
            factAdressBox.Text = ent.RealAddress;
            regAdressBox.Text = ent.Address;
            typeBox.SelectedItem = ent.Type;
            checkpointBox.Text = ent.Checkpoint.ToString();
            ITNBox.Text = ent.ITN.ToString();
            territoryBox.SelectedItem = ent.ManagementTerritory;
            telBox.Text = ent.TelephoneNumber;
            webSiteBox.Text = ent.WebSite;
            mailBox.Text = ent.Email;
        }

        private void checkpointBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || checkpointBox.Text.Length == 9)
                e.Handled = true;
        }

        private void ITNBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || ITNBox.Text.Length == 12)
                e.Handled = true;
        }

        private void ShowTextErrors(TextBox box, bool condition)
        {
            if (!condition)
                box.BackColor = Color.IndianRed;
            else
                box.BackColor = SystemColors.Window;
        }

        private void ShowComboErrors(ComboBox box, bool condition)
        {
            if (!condition)
                box.BackColor = Color.IndianRed;
            else
                box.BackColor = SystemColors.Window;
        }
    }
}