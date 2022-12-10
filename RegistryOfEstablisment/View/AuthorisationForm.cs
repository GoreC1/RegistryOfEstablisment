using System;
using System.Windows.Forms;
using RegistryOfEstablisment.UnitControl;

namespace RegistryOfEstablisment
{
    public partial class AuthorisationForm : Form
    {
        private readonly IUnitOfControl _unit;
        public AuthorisationForm(IUnitOfControl unit)
        {
            InitializeComponent();
            InitializePasswordTextBox();
            _unit = unit;
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            if (!_unit.AuthController.Authentificate(LoginTextBox.Text, PasswordTextBox.Text))
            {
                falseAuthLabel.Visible = true;
                return;
            }
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializePasswordTextBox()
        {
            PasswordTextBox.Text = "";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.MaxLength = 21;
        }

        private void AuthorisationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                return;
            
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
