using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        //для динамического добавления созданной формы, в кэш
        internal ValueTuple<Enterprise, bool> addedEnterprise = (default(Enterprise), default(bool));
        private readonly IUnitOfControl _unit;

        //буль, для понимания внутри логики программы, с каким кэшем работать
        private bool isFiltersApplied;
        
        //кэш без фильтра и с фильтром, для ускорения работы программы, за счёт меньшего количества запросов в БД
        private List<ValueTuple<Enterprise, bool>> unfiltredCache = new();
        private List<ValueTuple<Enterprise, bool>> filtredCache = new();

        public RegistryForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
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

        //получает список организаций
        private void GetOrgsRegistry()
        {
            unfiltredCache = _unit.EnterpriseController.GetRegistriesList();

            PopulateGridColumns();
            paginationBox.SelectedIndex = paginationBox.Items.Count - 1;
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
        private void PopulateGridRows(List<ValueTuple<Enterprise, bool>> entList, int count)
        {
            dataGridView1.Rows.Clear();
            int currentPage = Convert.ToInt32(pageBox.SelectedItem);
            int startIndex = 0 + (currentPage - 1) * count;
            int objectsLeft = entList.Count - (currentPage - 1) * count;

            Enterprise ent = new();
            bool isAccessible;


            if (objectsLeft < count)
                entList = entList.GetRange(startIndex, objectsLeft);
            else
                entList = entList.GetRange(startIndex, count);

            foreach (var item in entList)
            {
                ent = item.Item1;
                isAccessible = item.Item2;
                dataGridView1.Rows.Add(ent.Id.ToString(), ent.Name, ent.ITN.ToString(), ent.Checkpoint.ToString(), ent.Address, ent.Type.Name,
                                       ent.LegalEntity, ent.RealAddress, ent.WebSite, ent.Email, ent.TelephoneNumber, isAccessible ? "Yes" : "No");
            }
        }

        //заполняет comboBox с количеством страниц, в зависимости от размера пагинации
        public void PopulatePageBox(int count)
        {
            int maxPages = Convert.ToInt32(Math.Ceiling(count / Convert.ToDouble(paginationBox.SelectedItem)));
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

            Enterprise currentEnt = unfiltredCache.Find(c => c.Item1.Id == Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value)).Item1;

            if (currentEnt == default(Enterprise))
                currentEnt = filtredCache.Find(c => c.Item1.Id == Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value)).Item1;

            if (currentEnt == default(Enterprise))
                currentEnt = _unit.EnterpriseController.GetEnterprise(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value));

            Form entCard = new EstablishmentForm(_unit, currentEnt);
            entCard.ShowDialog();
        }

        //меняет количество строк в DataGridView 
        private void paginationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);

            if (isFiltersApplied == true)
            {
                PopulatePageBox(filtredCache.Count);
                PopulateGridRows(filtredCache, paginationCount);
                return;
            }

            PopulatePageBox(unfiltredCache.Count);
            PopulateGridRows(unfiltredCache, paginationCount);
        }

        //открывает форму добавления организации
        private void addESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new(_unit, this);
            esForm.ShowDialog();

            if (addedEnterprise != (default(Enterprise),default(bool)))
            {
                unfiltredCache.Add(addedEnterprise);
                PopulateGridRows(unfiltredCache, Convert.ToInt32(paginationBox.SelectedItem));
                addedEnterprise = (default(Enterprise), default(bool));
            }
        }

        //открывает форму изменения организации
        private void changeESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new(_unit, this);
            esForm.ShowDialog();
        }

        //открывает форму фильтров
        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new(_unit);
            filterForm.ShowDialog();
        }

        //переходит на нужную страницу DataGridViewS
        private void pageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);

            if (isFiltersApplied == true)
            {
                PopulateGridRows(filtredCache, paginationCount);
                return;
            }

            PopulateGridRows(unfiltredCache, paginationCount);
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
    }
}
