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
        //private bool isFill = false;
        //private bool isAll = false;

        //по кнопке идет проверка всех полей
        private void button1_Click(object sender, EventArgs e)
        {
            RegisterFormCheck formCheck = new RegisterFormCheck();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                formCheck.username = textBox1.Text;
                formCheck.fio = textBox2.Text;
                formCheck.passport = textBox3.Text; 
                formCheck.card = textBox4.Text;
                formCheck.birthday = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                bool[] formCorrect = formCheck.CheckForm();
                // MessageBox.Show(formCorrect[4].ToString());
                label7.Text =  formCorrect[0] ? "Все норм" : "Неправильно набран логин";
                label8.Text = formCorrect[1] ? "Все норм" : "Неправильно набран fio";
                label9.Text = formCorrect[2] ? "Все норм" : "Неправильно набран birthday";
                label10.Text = formCorrect[3] ? "Все норм" : "Неправильно набран passport";
                label11.Text = formCorrect[4] ? "Все норм" : "Неправильно набран card";
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
