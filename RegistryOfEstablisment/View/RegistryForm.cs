using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        private readonly IUnitOfControl _unit;
        public bool isFiltersApplied;
        public Expression<Func<Enterprise, bool>>[] filters;
        public object[] filterCache = new object[]{"","","","","",null,""};

        public RegistryForm(IUnitOfControl unit)
        {
            InitializeComponent();
            changeESButton.Enabled = false;
            deleteButton.Enabled = false;
            _unit = unit;
        }

        private void RegistryForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            Form auth = new AuthorisationForm(_unit);
            auth.ShowDialog();

            if (auth.DialogResult == DialogResult.OK)
            {
                paginationBox.SelectedIndex = 0;
                int shownEntries = Convert.ToInt32(paginationBox.SelectedItem);
                List<ValueTuple<Enterprise, bool>> list = GetOrgsRegistry(0, shownEntries);
                PopulatePageBox(_unit.EnterpriseController.GetCount(), shownEntries);
                PopulateGridColumns();
                PopulateGridRows(list);
                return;
            }

            this.Close();
        }

        //получает список организаций
        private List<ValueTuple<Enterprise, bool>> GetOrgsRegistry(int index, int count)
        {
            return _unit.EnterpriseController.GetRegistryList(index, count);
        }

        //заполняет столбцы DataGridView
        private void PopulateGridColumns()
        {
            dataGridView1.Columns.AddRange(new DataGridViewTextBoxColumn { Name = "ID", Visible = false }, new DataGridViewTextBoxColumn { Name = "Наименование" }, new DataGridViewTextBoxColumn { Name = "ИНН" },
                new DataGridViewTextBoxColumn { Name = "КПП" }, new DataGridViewTextBoxColumn { Name = "Адрес" }, new DataGridViewTextBoxColumn { Name = "Тип организации" }, new DataGridViewTextBoxColumn { Name = "ИП/Юрлицо" },
                new DataGridViewTextBoxColumn { Name = "RealAdress", Visible = false }, new DataGridViewTextBoxColumn { Name = "WebSite", Visible = false }, new DataGridViewTextBoxColumn { Name = "Email", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Telephone", Visible = false }, new DataGridViewTextBoxColumn { Name = "isAccessible", Visible = false });
        }

        //заполняет строки в соответствии с источником и количеством строк
        private void PopulateGridRows(List<ValueTuple<Enterprise, bool>> entList)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in entList)
            {
                Enterprise ent = item.Item1;
                bool isAccessible = item.Item2;
                dataGridView1.Rows.Add(ent.Id.ToString(), ent.Name, ent.ITN.ToString(), ent.Checkpoint.ToString(), ent.Address, ent.Type.Name,
                                       ent.LegalEntity, ent.RealAddress, ent.WebSite, ent.Email, ent.TelephoneNumber, isAccessible ? "Yes" : "No");
            }
        }

        //заполняет comboBox с количеством страниц, в зависимости от размера пагинации
        public void PopulatePageBox(int entriesCount, int shownEntries)
        {
            int maxPages = Convert.ToInt32(Math.Ceiling(entriesCount / Convert.ToDouble(shownEntries)));
            pageBox.Items.Clear();

            for (int i = 0; i < maxPages; i++)
            {
                pageBox.Items.Add(i + 1);
            }

            pageBox.SelectedIndex = 0;
        }

        //открывает форму организации
        private void OpenESButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
                return;

            Enterprise currentEnt = _unit.EnterpriseController.GetEnterpriseByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));

            Form entCard = new EstablishmentForm(_unit, currentEnt);
            entCard.ShowDialog();
        }

        //открывает форму добавления организации
        private void addESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new(_unit);
            esForm.ShowDialog();

            if (esForm.DialogResult == DialogResult.OK)
            {
                int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
                int currentPage = Convert.ToInt32(pageBox.SelectedItem) - 1;

                if (isFiltersApplied == true)
                {
                    PopulatePageBox(_unit.EnterpriseController.GetFilteredCount(filters), paginationCount);
                    PopulateGridRows(_unit.EnterpriseController.GetFilteredEnterprises(filters, currentPage, paginationCount));
                    return;
                }
                PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));
            }

        }

        //открывает форму изменения организации
        private void changeESButton_Click(object sender, EventArgs e)
        {
            EstablishmentChangingForm esForm = new(_unit, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            esForm.ShowDialog();
        }

        //открывает форму фильтров
        private void filterButton_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(pageBox.SelectedItem);
            int currentPagination = Convert.ToInt32(paginationBox.SelectedItem);

            FilterForm filterForm = new(_unit, this);
            filterForm.ShowDialog();

            if (filterForm.DialogResult == DialogResult.OK)
            {
                PopulatePageBox(_unit.EnterpriseController.GetFilteredCount(filters), currentPagination);
                PopulateGridRows(_unit.EnterpriseController.GetFilteredEnterprises(filters, 0, currentPagination));
            }
            else if (isFiltersApplied == false)
            {
                PopulatePageBox(_unit.EnterpriseController.GetCount(), currentPagination);
                PopulateGridRows(GetOrgsRegistry((currentPage - 1) * currentPagination, currentPagination));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["IsAccessible"].Value.ToString() == "Yes")
            {
                changeESButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else
            {
                changeESButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        //меняет количество строк в DataGridView 
        private void paginationBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
            List<ValueTuple<Enterprise, bool>> list = new();

            if (isFiltersApplied == true)
            {
                PopulatePageBox(_unit.EnterpriseController.GetFilteredCount(filters), paginationCount);
                list = _unit.EnterpriseController.GetFilteredEnterprises(filters, 0, paginationCount);
                PopulateGridRows(list);
                return;
            }

            PopulatePageBox(_unit.EnterpriseController.GetCount(), paginationCount);
            list = GetOrgsRegistry(0, paginationCount);
            PopulateGridRows(list);
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены что хотите продолжить??", "Удаление", MessageBoxButtons.YesNo);
            _unit.EnterpriseController.DeleteEnterprise(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        }

        //private void OpenEnterpriseCard(int id)
        //{
        //    EnterpriseController.GetEnterpise(id);
        //    EnterpriseController.GetRegistrations(id);
        //}

        //переходит на нужную страницу DataGridView
        private void pageBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
            int currentPage = Convert.ToInt32(pageBox.SelectedItem) - 1;

            if (isFiltersApplied == true)
            {
                PopulateGridRows(_unit.EnterpriseController.GetFilteredEnterprises(filters, currentPage * paginationCount, paginationCount));
                return;
            }

            PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));
        }
    }
}
