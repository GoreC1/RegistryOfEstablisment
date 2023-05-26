using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class RegistrationForm : Form
    {
        private readonly IUnitOfControl _unit;
        private readonly Enterprise _enterprise;
        public RegistrationForm(IUnitOfControl unit, Enterprise enterprise)
        {
            InitializeComponent();
            _unit = unit;
            _enterprise = enterprise;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            OwnerTextBox.Text = CurrentUser.Name;
            AdressTextBox.Text = CurrentUser.Address;
            TelephoneNumberTextBox.Text = CurrentUser.TelephoneNumber;
            DateTime currentDate = DateTime.Today;

            for (int i = 0; i < 15; i++)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    currentDate = currentDate.AddDays(1);
                    continue;
                }

                DateBox.Items.Add(currentDate.ToShortDateString());
                currentDate = currentDate.AddDays(1);
            }
        }

        //Прогрузка свободного времени для записи
        private void DateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Registration> regs = _unit.RegistrationController.GetRegistrationsByDayAndEnterprise(Convert.ToDateTime(DateBox.SelectedItem), _enterprise).ToList();
            DateTime startOfWork = new DateTime(2022, 1, 1, 9, 0, 0);

            List<string> currentAppointments = regs.Select(c => c.AppointmentTime.ToShortTimeString()).ToList();

            for (int i = 0; i < 19; i++)
            {
                if (i >= 8 && i <= 10)
                    continue;

                if (!currentAppointments.Contains(startOfWork.AddHours(0.5 * i).ToShortTimeString()))
                    TimeBox.Items.Add(startOfWork.AddHours(0.5 * i).ToShortTimeString());
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (!CheckCompletion())
            {
                MessageBox.Show("Данные заполнены некорректно!");
                return;
            }

            DateTime appointmentDate = Convert.ToDateTime(DateBox.SelectedItem);
            DateTime appointmentTime = Convert.ToDateTime(TimeBox.SelectedItem);

            DateTime actualAppointmentTime = new(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, appointmentTime.Hour, appointmentTime.Minute, 0);

            DialogResult confirmation = MessageBox.Show(
                                                    $"Вы будете записаны на {appointmentDate.ToLongDateString()} {appointmentTime.ToShortTimeString()}. Продолжить?",
                                                    "Запись",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly);
            if (!(confirmation == DialogResult.Yes))
                return;

            Registration newReg = new()
            {
                User = _unit.UserController.GetUserById(CurrentUser.Id),
                Enterprise = _enterprise,
                PetName = PetNameTextBox.Text,
                PetType = PetTypeTextBox.Text,
                AppointmentTime = actualAppointmentTime
            };

            _unit.RegistrationController.AddNewRegistration(newReg);
            MessageBox.Show($"Вы были записаны на {appointmentDate.ToLongDateString()} {appointmentTime.ToShortTimeString()}");
            this.Close();
        }

        //Проверка заполнения формы
        private bool CheckCompletion()
        {
            string regTel = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

            return OwnerTextBox.Text.Length > 0 && AdressTextBox.Text.Length > 0 && Regex.IsMatch(TelephoneNumberTextBox.Text, regTel) && PetNameTextBox.Text.Length > 0
                   && PetTypeTextBox.Text.Length > 0 && DateBox.SelectedItem != null && TimeBox.SelectedItem != null;
        }
    }
}
