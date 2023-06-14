using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shikhvaleeva
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadData();
            StartPosition = FormStartPosition.CenterScreen;//Форма запускается по центру
        }
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-J3F0GHQ\SQLEXPRESS;Initial Catalog =Shop; Integrated Security = True;");
        private void LoadData()// Выборка из базы
        {
            adapter = new SqlDataAdapter("SELECT * FROM Shop ", con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)// Кнопка назад
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shopDataSet.shop". При необходимости она может быть перемещена или удалена.
            this.shopTableAdapter.Fill(this.shopDataSet.shop);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)// кнока большая скидка
        {
            PaintRows();
        }

        private void PaintRows() // Заливка строки
        {
            var c = System.Drawing.ColorTranslator.FromHtml("#7fff00");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (int.Parse(row.Cells[5].Value.ToString()) > 15)
                        row.DefaultCellStyle.BackColor = c;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
                catch { }
            }
        }
        private void button1_Click(object sender, EventArgs e)//Сортировка по возрастанию
        {
            dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)//Сортировка по убыванию
        {
            dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)// Сотрировка скидки
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Dectvusga skidka] <=9";
                    break;

                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Dectvusga skidka] >=10 AND [Dectvusga skidka] <=14";
                    break;

                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Dectvusga skidka] >=15";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//Показ картинок
        {
            switch(comboBox2.SelectedIndex)
            {
                    case 0:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\B111C5.jpeg");
                    break;
                    case 1:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\E112C6.jpg");
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\K839K3.jpg");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\L293S9.jpg");
                    break;
                case 4:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\M112C8.jpg");
                    break;
                case 5:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\M294G9.jpg");
                    break;
                case 6:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\M398S9.jpg");
                    break;
                case 7:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\N283K3.jpg");
                    break;
                case 8:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\S384K2.jpg");
                    break;
                case 9:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\ПК-6-85\Desktop\Вариант 9\Импорт\Товар_import\T238C7.jpg");
                    break;
            }
        }
    }
}
