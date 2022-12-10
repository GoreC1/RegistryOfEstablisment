using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistryOfEstablisment.UnitControl;
using RegistryOfEstablisment.View;

namespace RegistryOfEstablisment.View
{
    public partial class EstablishmentForm : Form
    {
        private readonly IUnitOfControl _unit;
        public EstablishmentForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
        }
        private void EstablishmentForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new(_unit);
            registrationForm.ShowDialog();
        }
    }
}
