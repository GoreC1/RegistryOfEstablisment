using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NLog;
using System.ComponentModel;

namespace RegistryOfEstablisment.View
{
    public partial class EstablismentCreationForm : Form
    {
        readonly IUnitOfControl _unit;
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        public EstablismentCreationForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
            Logger.Debug("Открыта форма добавления организации");
        }

        private void EstablismentCreationForm_Load(object sender, EventArgs e)
        {
            EnterpriseType[] types = _unit.EnterpriseTypeController.GetAccessedTypes().ToArray();
            typeBox.Items.AddRange(types);

            ManagementTerritory[] territories = _unit.ManagementTerritoryController.GetAccessedTerritories().ToArray();
            territoryBox.Items.AddRange(territories);
        }

        //Регистрация новой записи на чипирование
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!CheckCompletion())
            {
                MessageBox.Show("Данные заполнены некорректно!");
                Logger.Warn("Попытка создания провалена - данные заполнены некорректно");
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
            Logger.Trace($"Создан новый экземпляр класса Enterprise {ent.Name}");

            _unit.EnterpriseController.AddEnterprise(ent);

            this.DialogResult = DialogResult.OK;
            this.Close();
            Logger.Trace("Форма добавления организации закрыта");
        }

        //проверка заполнения с указанием неверных полей
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            Logger.Debug("Форма добавления организации закрыта");
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

        //проверка и указанме на неверные поля
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
