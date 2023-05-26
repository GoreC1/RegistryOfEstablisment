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
using RegistryOfEstablisment.View;

namespace RegistryOfEstablisment
{
    public partial class AuthorisationForm : Form
    {
        public AuthorisationForm()
        {
            InitializeComponent();
        }

        private void AuthorisationForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            if (AuthController.Authentificate(LoginTextBox.Text, PasswordTextBox.Text) == true)
            {
                //открывается форма
            }
            else
            {
                MessageBox().Show("Логин или пароль ввёдён неправильно!");
            }
            AuthController.Authentificate(LoginTextBox.Text, PasswordTextBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
