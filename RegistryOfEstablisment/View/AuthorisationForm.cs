﻿using RegistryOfEstablisment.UnitControl;
using System;
using System.Windows.Forms;
using NLog;
using RegistryOfEstablisment.Model.Entities;
using System.Drawing;
using RegistryOfEstablisment.Properties;
using System.Collections.ObjectModel;

namespace RegistryOfEstablisment
{
    public partial class AuthorisationForm : Form
    {
        private readonly IUnitOfControl _unit;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public AuthorisationForm(IUnitOfControl unit)
        {
            InitializeComponent();
            InitializePasswordTextBox();
            _unit = unit;
            Logger.Debug("Форма авторизации загружена");
        }

        //Подтверждает аутентификацию
        private void AuthButton_Click(object sender, EventArgs e)
        {
            if (!_unit.AuthController.Authentificate(LoginTextBox.Text, PasswordTextBox.Text))
            {
                Logger.Warn($"Авторизация не выполнена - данные введены некорректно");
                falseAuthLabel.Visible = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
            Logger.Debug($"Пользователь [ID - {CurrentUser.Id}]{CurrentUser.Name} авторизовался");
            this.Close();
            Logger.Debug("Форма авторизации закрыта");
        }

        //Настройка поля пароля, для отображения звёздочек и максимального количество символов
        private void InitializePasswordTextBox()
        {
            PasswordTextBox.Text = "";
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.MaxLength = 21;
        }

        private void AuthorisationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                return;

            this.DialogResult = DialogResult.Cancel;
        }

        //Вход без нажатия кнопки
        private void LoginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(PasswordTextBox.Text.Length > 0)
                {
                    AuthButton_Click(sender, e);
                }
                else
                {
                    PasswordTextBox.Focus();
                }
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AuthButton_Click(sender, e);
            }
        }

        private void AuthorisationForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие на изображение с раскрытием пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Resources.free_icon_eye_158746;
            PasswordTextBox.UseSystemPasswordChar = false;
        }

        /// <summary>
        /// Обрабатывает отпускание мыши с изображения с скрытием пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Resources.free_icon_hide_2767146;
            PasswordTextBox.UseSystemPasswordChar = true;
        }
    }
}
