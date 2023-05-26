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
using RegistryOfEstablisment.Unit;
using RegistryOfEstablisment.View;

namespace RegistryOfEstablisment
{
    public partial class AuthorisationForm : Form
    {
        private readonly IUnitOfWork _unit;
        public AuthorisationForm(IUnitOfWork unit)
        {
            InitializeComponent();
            InitializePasswordTextBox();
            _unit = unit;
        }

        private void AuthorisationForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            AuthController auth = new AuthController(_unit);
            if (!auth.Authentificate(LoginTextBox.Text, PasswordTextBox.Text))
            {
                falseAuthLabel.Visible = true;
                return;
            }
            return;
        }

        private void InitializePasswordTextBox()
        {
            PasswordTextBox.Text = "";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.MaxLength = 21;
        }
    }
}
