using NLog;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class FilterForm : Form
    {
        private readonly IUnitOfControl _unit;
        private RegistryForm _registry;
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public FilterForm(IUnitOfControl unit, RegistryForm registry)
        {
            InitializeComponent();
            _registry = registry;
            _unit = unit;
            Logger.Debug("Открыта форма фильтров реестра");
        }

        public Expression<Func<Enterprise, bool>>[] GetFilters()
        {
            List<Expression<Func<Enterprise, bool>>> expressions = new();

            if (nameBox.Text != "")
            {
                expressions.Add((c => c.Name.StartsWith(nameBox.Text)));
                Logger.Trace($"Фильтр имени изменён на {nameBox.Text}");
            }

            if (ITNBox.Text != "")
            {
                expressions.Add((c => c.ITN.ToString().StartsWith(ITNBox.Text)));
                Logger.Trace($"Фильтр ИИН изменён на {ITNBox.Text}");
            }

            if (checkpointBox.Text != "")
            {
                expressions.Add((c => c.Checkpoint.ToString().StartsWith(checkpointBox.Text)));
                Logger.Trace($"Фильтр КПП изменён на {checkpointBox.Text}");
            }

            if (addressBox.Text != "")
            {
                expressions.Add((c => c.Address.StartsWith(addressBox.Text)));
                Logger.Trace($"Фильтр адреса регистрации изменён на {addressBox.Text}");
            }

            if (realAddressBox.Text != "")
            {
                expressions.Add((c => c.RealAddress.StartsWith(realAddressBox.Text)));
                Logger.Trace($"Фильтр фактического адреса изменён на {realAddressBox.Text}");
            }

            if (typeBox.SelectedItem != null)
            {
                expressions.Add((c => c.Type == typeBox.SelectedItem));
                Logger.Trace($"Фильтр типа организации изменён на {typeBox.SelectedItem}");
            }

            if (legalEntityBox.Text != "")
            {
                expressions.Add((c => c.LegalEntity.StartsWith(legalEntityBox.Text)));
                Logger.Trace($"Фильтр юр. лица изменён на {legalEntityBox.Text}");
            }

            _registry.filterCache[0] = nameBox.Text;
            _registry.filterCache[1] = ITNBox.Text;
            _registry.filterCache[2] = checkpointBox.Text;
            _registry.filterCache[3] = addressBox.Text;
            _registry.filterCache[4] = realAddressBox.Text;
            _registry.filterCache[5] = typeBox.SelectedItem;
            _registry.filterCache[6] = legalEntityBox.Text;

            return expressions.ToArray();

        }

        public void ClearFields()
        {
            nameBox.Text = "";
            ITNBox.Text = "";
            checkpointBox.Text = "";
            addressBox.Text = "";
            realAddressBox.Text = "";
            typeBox.SelectedItem = null;
            legalEntityBox.Text = "";
            Logger.Debug("Фильтры очищены");
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            _registry.filters = GetFilters();
            _registry.isFiltersApplied = true;
            Logger.Debug("Фильтры применены");

            this.DialogResult = DialogResult.OK;
            this.Close();
            Logger.Debug("Форма фильтров закрыта");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            Logger.Debug("Форма фильтров закрыта");
        }

        //проверка ввода КПП
        private void checkpointBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || checkpointBox.Text.Length == 9)
                e.Handled = true;
        }

        //Проверка ввода ИНН
        private void ITNBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || ITNBox.Text.Length == 12)
                e.Handled = true;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            typeBox.Items.AddRange(_unit.EnterpriseTypeController.GetAllTypes().ToArray());
            nameBox.Text = _registry.filterCache[0].ToString();
            ITNBox.Text = _registry.filterCache[1].ToString();
            checkpointBox.Text = _registry.filterCache[2].ToString();
            addressBox.Text = _registry.filterCache[3].ToString();
            realAddressBox.Text = _registry.filterCache[4].ToString();
            typeBox.SelectedItem = _registry.filterCache[5];
            legalEntityBox.Text = _registry.filterCache[6].ToString();

            Logger.Debug("Значения фильтров подгружены");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
            _registry.isFiltersApplied = false;
            _registry.filters = new Expression<Func<Enterprise,bool>>[] { };
            _registry.filterCache = new object[] { "", "", "", "", "", null, "" }; 
        }
    }
}
