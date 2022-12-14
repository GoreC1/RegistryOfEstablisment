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

        public FilterForm(IUnitOfControl unit, RegistryForm registry)
        {
            InitializeComponent();
            _registry = registry;
            _unit = unit;
        }

        public Expression<Func<Enterprise, bool>>[] GetFilters()
        {
            List<Expression<Func<Enterprise, bool>>> expressions = new();

            if (nameBox.Text != "")
            {
                expressions.Add((c => c.Name.StartsWith(nameBox.Text)));
            }    

            if (ITNBox.Text != "")
            {
                expressions.Add((c => c.ITN.ToString().StartsWith(ITNBox.Text)));
            }

            if (checkpointBox.Text != "")
            {
                expressions.Add((c => c.Checkpoint.ToString().StartsWith(checkpointBox.Text)));
            }

            if (addressBox.Text != "")
            {
                expressions.Add((c => c.Address.StartsWith(addressBox.Text)));
            }

            if (realAddressBox.Text != "")
            {
                expressions.Add((c => c.RealAddress.StartsWith(realAddressBox.Text)));
            }

            if (typeBox.SelectedItem != null)
            {
                expressions.Add((c => c.Type == typeBox.SelectedItem));
            }

            if (legalEntityBox.Text != "")
            {
                expressions.Add((c => c.LegalEntity.StartsWith(legalEntityBox.Text)));
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
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            _registry.filters = GetFilters();
            _registry.isFiltersApplied = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
