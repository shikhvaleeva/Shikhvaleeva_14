using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shikhvaleeva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//Форма запускается по центру
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.DoEvents();//Форма закрывается через крестик
        }

        private void button1_Click(object sender, EventArgs e)//Кнопка гостя
        {
            MessageBox.Show("Добро пожаловать гость");
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)//кнопка авторизованного пользователя
        {
            SqlDataAdapter adapter= new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-J3F0GHQ\SQLEXPRESS;Initial Catalog =Shop; Integrated Security = True;");
            con.Open();
            try
            {
                string comand = ("SELECT * FROM auto WHERE Login='" + textBox1.Text + "'AND Paroli='" + textBox2.Text + "';");
                SqlCommand check = new SqlCommand(comand, con);
                if(check.ExecuteScalar() != null ) 
                {
                    MessageBox.Show("Добро пожаловать пользователь");
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Вы ввели не правильный логи или пароль");
                }
            }
            finally  
            { 
            }
        }
          
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
