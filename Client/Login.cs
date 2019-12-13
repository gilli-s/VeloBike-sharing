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
    public partial class Login : Form
    {
        private string kek;

        public Login()
        {
            InitializeComponent();
        }

        public Login(string kek)
        {
            this.kek = kek;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register logoutForm = new Register();
            logoutForm.Show();
            Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text!= "")
            {
                string login = textBox1.Text;
                string password = textBox2.Text;
                var srv = new ServiceReference1.Service1Client();
                User userlogin = (User)srv.CheckUser(login, password);
                App appForm = new App(userlogin);
                appForm.Show();
                Hide();
                //MessageBox.Show(userlogin.Username.ToString());
            }
        }
    }
}
