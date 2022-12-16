using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Office.Interop.Excel;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using NLog;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        private readonly IUnitOfControl _unit;
        public bool isFiltersApplied;
        public Expression<Func<Enterprise, bool>>[] filters;
        public object[] filterCache = new object[]{"","","","","",null,""};

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public RegistryForm(IUnitOfControl unit)
        {
            InitializeComponent();
            changeESButton.Enabled = false;
            deleteButton.Enabled = false;
            _unit = unit;
        }

        private void RegistryForm_Load(object sender, EventArgs e)
        {
            Logger.Info("Приложение запущено");
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

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }

                Logger.Info($"Реестр загружен, всего доступных организаций - {list.Count}");
                return;
            }

            this.Close();
        }

        //получает список организаций
        private List<ValueTuple<Enterprise, bool>> GetOrgsRegistry(int index, int count)
        {
            return _unit.EnterpriseController.GetRegistryList(index, count);
        }

        //получает фильтрованный список организаций
        private List<ValueTuple<Enterprise, bool>> GetFilteredOrgsRegistry(Expression<Func<Enterprise, bool>>[] filters, int index, int count)
        {
            return _unit.EnterpriseController.GetFilteredEnterprises(filters, index, count);
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

            if (pageBox.Items.Count == 0)
            {
                pageBox.Items.Add(1);
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
        private void AddESButton_Click(object sender, EventArgs e)
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
                    Logger.Debug("Фильтры реестра применены");
                    return;
                }
                PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));

                Logger.Debug("Реестр обновлён");
            }

        }

        //открывает форму изменения организации
        private void ChangeESButton_Click(object sender, EventArgs e)
        {
            EstablishmentChangingForm esForm = new(_unit, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            esForm.ShowDialog();

            if (esForm.DialogResult == DialogResult.OK)
            {
                int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
                int currentPage = Convert.ToInt32(pageBox.SelectedItem) - 1;

                if (isFiltersApplied == true)
                {
                    PopulatePageBox(_unit.EnterpriseController.GetFilteredCount(filters), paginationCount);
                    PopulateGridRows(_unit.EnterpriseController.GetFilteredEnterprises(filters, currentPage, paginationCount));
                    Logger.Debug("Фильтры реестра применены");
                    return;
                }

                PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));
                Logger.Debug("Реестр обновлён");
            }
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
                Logger.Debug("Фильтры реестра применены");
            }
            else if (isFiltersApplied == false)
            {
                PopulatePageBox(_unit.EnterpriseController.GetCount(), currentPagination);
                PopulateGridRows(GetOrgsRegistry((currentPage - 1) * currentPagination, currentPagination));
                Logger.Debug("Фильтры реестра не применены");
            }
        }

        //Проверят доступность редактирования/удаления организации
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
                list = GetFilteredOrgsRegistry(filters, 0, paginationCount);
                PopulateGridRows(list);
                return;
            }

            PopulatePageBox(_unit.EnterpriseController.GetCount(), paginationCount);
            list = GetOrgsRegistry(0, paginationCount);
            PopulateGridRows(list);
        }

        //Удаление организции
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены что хотите продолжить??", "Удаление", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes) 
            {
                Logger.Debug($"Удаление организации [ID - {dataGridView1.CurrentRow.Cells[0].Value}]{dataGridView1.CurrentRow.Cells[1].Value}");
                _unit.EnterpriseController.DeleteEnterprise(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
                int currentPage = Convert.ToInt32(pageBox.SelectedItem) - 1;

                if (isFiltersApplied == true)
                {
                    PopulatePageBox(_unit.EnterpriseController.GetFilteredCount(filters), paginationCount);
                    PopulateGridRows(_unit.EnterpriseController.GetFilteredEnterprises(filters, currentPage, paginationCount));
                    Logger.Debug("Фильтры реестра применены");
                    return;
                }
                PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));
                Logger.Debug("Реестр обновлён");
            } 
            else
            {
                Logger.Info($"Удаление организации [ID - {dataGridView1.CurrentRow.Cells[0].Value}]{dataGridView1.CurrentRow.Cells[1].Value} отменено");
            }
        }

        //переходит на нужную страницу DataGridView
        private void PageBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int paginationCount = Convert.ToInt32(paginationBox.SelectedItem);
            int currentPage = Convert.ToInt32(pageBox.SelectedItem) - 1;

            if (isFiltersApplied == true)
            {
                PopulateGridRows(GetFilteredOrgsRegistry(filters, currentPage * paginationCount, paginationCount));
                Logger.Debug("Фильтры реестра применены");
                return;
            }

            PopulateGridRows(GetOrgsRegistry(currentPage * paginationCount, paginationCount));
            Logger.Debug($"Выполнен переход на {pageBox.SelectedItem} страницу");
        }

        //экспорт в Excel
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("В таблице отсутствуют данные");
                Logger.Warn("Таблица в Microsoft Excel не может быть создана - реестр пуст");
                return;
            }

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            
            app.Visible = true;
            
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Лист1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            worksheet.Name = $"Exported by {CurrentUser.Name}";

            List<DataGridViewColumn> columns = new();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Visible == true)
                {
                    columns.Add(dataGridView1.Columns[i]);
                }
            }

            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cells[1, i+2] = columns[i].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 1; j < columns.Count+1; j++)
                {
                    if (j==2 || j==3)
                    {
                        worksheet.Cells[i + 2, j + 1] =  $"\"{dataGridView1.Rows[i].Cells[j].Value}\"";
                        continue;
                    }

                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            
            Logger.Info($"Реестр из {dataGridView1.Columns.Count} записей экспортирован в Microsoft Excel пользователем [{CurrentUser.Id}]{CurrentUser.Name}");
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridView1.Columns[e.ColumnIndex];

            switch (column.HeaderCell.SortGlyphDirection)
            {
                case SortOrder.None:
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if ((dataGridView1.Columns[i] == column))
                            continue;

                        dataGridView1.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                    dataGridView1.Sort(column, ListSortDirection.Ascending);
                    column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    break;

                case SortOrder.Ascending:
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if ((dataGridView1.Columns[i] == column))
                            continue;

                        dataGridView1.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                    dataGridView1.Sort(column, ListSortDirection.Descending);
                    column.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                    break;

                case SortOrder.Descending:
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    dataGridView1.Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    break;
            }
            Logger.Trace("Реестр отсортирован");
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}
