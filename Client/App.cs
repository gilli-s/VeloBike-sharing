using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class App : Form
    {
        private User newUser;

        public App()
        {
            InitializeComponent();
        }

        public App(User newUser)
        {
            this.newUser = newUser;
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {

        }
    }
}
