using RegistryOfEstablisment.Controller;
using RegistryOfEstablisment.UnitControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryOfEstablisment.View
{
    public partial class RegistrationForm : Form
    {
        private readonly IUnitOfControl _unit;
        public RegistrationForm(IUnitOfControl unit)
        {
            InitializeComponent();
            _unit = unit;
        }
    }
}
