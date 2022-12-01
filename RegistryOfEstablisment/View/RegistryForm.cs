using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistryOfEstablisment.View;

namespace RegistryOfEstablisment.View
{
    public partial class RegistryForm : Form
    {
        public RegistryForm()
        {
            InitializeComponent();
            AuthorisationForm authForm = new AuthorisationForm();
            authForm.ShowDialog();
            this.Hide();
            if (authForm.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openESButton_Click(object sender, EventArgs e)
        {
            EstablishmentForm ESform = new EstablishmentForm();
            ESform.Show();
        }

        private void addESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new EstablismentCreationForm();
            esForm.ShowDialog();
        }

        private void changeESButton_Click(object sender, EventArgs e)
        {
            EstablismentCreationForm esForm = new EstablismentCreationForm();
            esForm.ShowDialog();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены что хотите продолжить??",
                      "Удаление", MessageBoxButtons.YesNo);
        }
    }
}
