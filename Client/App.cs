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
        private User loginUser;

        public App()
        {
            InitializeComponent();
        }

        public App(User newUser)
        {
            this.loginUser = newUser;
            InitializeComponent();
        }
        private int id = 0;
        DataSet ds = new DataSet();
        private void App_Load(object sender, EventArgs e)
        {
            var srv = new ServiceReference1.Service1Client();
            ds = srv.OutStation();
            comboBox1.DataSource = ds.Tables["Stations"];
            comboBox1.DisplayMember = "Street";
            comboBox1.ValueMember = "CountFreeBikes";
           // MessageBox.Show(Convert.ToInt32(comboBox1.SelectedValue).ToString());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                textBox1.Text = "На данной станции нет свободных велосипедов";
            }
            else
            {
                
                var srv = new ServiceReference1.Service1Client();
                srv.BookBike(comboBox1.Text, (int)comboBox1.SelectedValue);
                UpdateBox(srv);
                var query = from station in ds.Tables["Stations"].AsEnumerable()
                            where (string)station["Street"] == comboBox1.Text
                            select new { Limit = station["limit"] };
                int _limit = 0;
                foreach (var limit in query)
                {
                    _limit = (int)(limit.Limit);
                }
                string pinCode = GeneratePin();
                srv.AddPin(loginUser.Username,pinCode);
                richTextBox1.Text = pinCode;
                textBox1.Text = "Вас ожидает велосипед на станции. " + " " + ((int)comboBox1.SelectedValue).ToString() + " осталось из" + _limit;
            }
        }

        private static string GeneratePin()
        {
            string pinCode = "";
            var rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                pinCode += rand.Next(9).ToString();
            }

            return pinCode;
        }

        private void UpdateBox(ServiceReference1.Service1Client srv)
        {
            ds = srv.OutStation();
            comboBox1.DataSource = ds.Tables["Stations"];
            comboBox1.DisplayMember = "Street";
            comboBox1.ValueMember = "CountFreeBikes";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var srv = new ServiceReference1.Service1Client();
            //DataSet ds = srv.OutStation();
            //int count = Convert.ToInt32(comboBox1.SelectedValue);
            //textBox1.Text = $"На данной станции {Convert.ToInt32(comboBox1.SelectedValue).ToString()} свободных велосипедов";
        }
    }
}
