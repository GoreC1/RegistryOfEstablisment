using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistryOfEstablisment.Controller;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using RegistryOfEstablisment.View;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        private readonly IUnitOfControl _unit;
        public RegistryForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
        }

        //private void openESButton_Click(object sender, EventArgs e)
        //{
        //    OpenEnterpriseCard(1);
        //    EstablishmentForm ESform = new EstablishmentForm();
        //    ESform.Show();
        //}

        private void addESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new(_unit);
            esForm.ShowDialog();
        }

        private void changeESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new(_unit);
            esForm.ShowDialog();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new();
            filterForm.ShowDialog();
        }

        private void RegistryForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Form auth = new AuthorisationForm(_unit);
            auth.ShowDialog();
            if (auth.DialogResult == DialogResult.OK)
            {
                GetOrgsRegistry();
                return;
            }
            this.Close();
        }

        //private void deleteButton_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = MessageBox.Show("Вы уверены что хотите продолжить??",
        //              "Удаление", MessageBoxButtons.YesNo);
        //    DeleteEnterprise(1);
        //}

        private void GetOrgsRegistry()
        {
            List<ValueTuple<Enterprise, bool>> entList = _unit.RegistryController.GetRegistriesList();
            PopulateGridColumns();
            foreach (var item in entList)
            {
                Enterprise ent = item.Item1;
                bool isAccessible = item.Item2;
                dataGridView1.Rows.Add(ent.Id.ToString(), ent.Name, ent.ITN.ToString(), ent.Checkpoint.ToString(), ent.Address, ent.Type.Name, 
                                       ent.LegalEntity, ent.RealAddress, ent.WebSite, ent.Email, ent.TelephoneNumber, isAccessible ? "Yes" : "No");
            }
        }

        private void PopulateGridColumns()
        {
            dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn { Name = "ID", Visible = false }, new DataGridViewTextBoxColumn { Name = "Наименование" }, new DataGridViewTextBoxColumn { Name = "ИНН" },
                new DataGridViewTextBoxColumn { Name = "КПП" }, new DataGridViewTextBoxColumn { Name = "Адрес" }, new DataGridViewTextBoxColumn { Name = "Тип организации" }, new DataGridViewTextBoxColumn { Name = "ИП/Юрлицо" },
                new DataGridViewTextBoxColumn { Name = "RealAdress", Visible = false }, new DataGridViewTextBoxColumn { Name = "WebSite", Visible = false }, new DataGridViewTextBoxColumn { Name = "Email", Visible = false }, 
                new DataGridViewTextBoxColumn { Name = "Telephone", Visible = false }, new DataGridViewTextBoxColumn { Name = "isAccessible", Visible = false });
        }

        //private void OpenEnterpriseCard(int id)
        //{
        //    EnterpriseController.GetEnterpise(id);
        //    EnterpriseController.GetRegistrations(id);
        //}

        //private void DeleteEnterprise(int enterpriseid)
        //{
        //    EnterpriseController.DeleteEnterprise(enterpriseid);
        //}

        //private void RegistryForm_Load(object sender, EventArgs e)
        //{

    }
    }
