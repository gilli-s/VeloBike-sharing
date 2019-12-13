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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        //private bool isAll = false;
        
        //по кнопке идет проверка всех полей
        private void button1_Click(object sender, EventArgs e)
        {
            
            RegisterFormCheck formCheck = new RegisterFormCheck();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                bool isFill = true;
                formCheck.username = textBox1.Text;
                formCheck.fio = textBox2.Text;
                formCheck.passport = textBox3.Text; 
                formCheck.card = textBox4.Text;
                formCheck.birthday = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                formCheck.pass = textBox5.Text;
                formCheck.confPass = textBox6.Text;
                
                bool[] formCorrect = formCheck.CheckForm();
                //MessageBox.Show(textBox6.Text);
                label7.Text =  formCorrect[0] ? "Все норм" : "Неправильно набран логин";
                label8.Text = formCorrect[1] ? "Все норм" : "Неправильно набран fio";
                label9.Text = formCorrect[2] ? "Все норм" : "Неправильно набран birthday";
                label10.Text = formCorrect[3] ? "Все норм" : "Неправильно набран passport";
                label11.Text = formCorrect[4] ? "Все норм" : "Неправильно набран card";
                label15.Text = formCorrect[5] ? "Все норм" : "Неправильно набран password";
                foreach (bool t in formCorrect)
                {
                    if (!t) isFill = false;
                }
                if (isFill)
                {
                    User newUser = new User(formCheck.username, formCheck.fio, formCheck.birthday, formCheck.passport,formCheck.card,formCheck.pass);
                    var srv = new ServiceReference1.Service1Client();
                    srv.InsertIntoUser(newUser.Username,newUser.FIO, newUser.Birthday,newUser.Passport,newUser.Card,newUser.Password);
                    App appForm = new App(newUser);
                    appForm.Show();
                   
                }
            }
            else
            {
                label6.Text = "проверьте заполнение полей";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kek = "Привет";
            Login login = new Login(kek);
            login.Show();
            Hide();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBox1.Text = "lal";
            textBox2.Text = "Гилев Александр Владимирович";
            textBox3.Text = "6713 367853";
            textBox4.Text = "5469670025758189";
            textBox5.Text = "1234";
            textBox6.Text = "1234";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
