using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        private readonly IUnitOfControl _unit;
        private List<Enterprise> enterprisesCache = new List<Enterprise>();
        public RegistryForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
        }

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
            FilterForm filterForm = new(_unit);
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

        private void GetOrgsRegistry()
        {
            List<ValueTuple<Enterprise, bool>> entList = _unit.EnterpriseController.GetRegistriesList();
            
            PopulateGridColumns();
            
            foreach (var item in entList)
            {
                Enterprise ent = item.Item1;
                bool isAccessible = item.Item2;
                dataGridView1.Rows.Add(ent.Id.ToString(), ent.Name, ent.ITN.ToString(), ent.Checkpoint.ToString(), ent.Address, ent.Type.Name,
                                       ent.LegalEntity, ent.RealAddress, ent.WebSite, ent.Email, ent.TelephoneNumber, isAccessible ? "Yes" : "No");
                enterprisesCache.Add(ent);
            }
        }

        private void PopulateGridColumns()
        {
            dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn { Name = "ID", Visible = false }, new DataGridViewTextBoxColumn { Name = "Наименование" }, new DataGridViewTextBoxColumn { Name = "ИНН" },
                new DataGridViewTextBoxColumn { Name = "КПП" }, new DataGridViewTextBoxColumn { Name = "Адрес" }, new DataGridViewTextBoxColumn { Name = "Тип организации" }, new DataGridViewTextBoxColumn { Name = "ИП/Юрлицо" },
                new DataGridViewTextBoxColumn { Name = "RealAdress", Visible = false }, new DataGridViewTextBoxColumn { Name = "WebSite", Visible = false }, new DataGridViewTextBoxColumn { Name = "Email", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Telephone", Visible = false }, new DataGridViewTextBoxColumn { Name = "isAccessible", Visible = false });
        }

        private void OpenESButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;

            Enterprise currentEnt = enterprisesCache.Find(c => c.Id == Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));

            Form entCard = new EstablishmentForm(_unit, currentEnt);
            entCard.ShowDialog();
        }
    }
}
