using pv03_1702752_aqhbarhabib.Model;
using pv03_1702752_aqhbarhabib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pv03_1702752_aqhbarhabib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitNim_Click(object sender, EventArgs e)
        {
            TodoRepository todo = new TodoRepository();

            
            
            
            string nim = tbNim.Text;

           

           //dataGridView1.DataSource = todo.getByNim(nim);

            if (todo.getByCek(nim)==1)
            {
                btnAdd.Enabled = true;
                tbNim.Enabled = false;
                submitNim.Enabled = false;
                dataGridView1.DataSource = todo.getByNim(nim);
            }
            else
            {
                tbNim.Text = "";
                tbNim.Focus();
                string message = "Datamu Tidak Ada Cukkk !!!";
                string caption = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
           
         
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = tbNim.Text;
            temp.Nama = tbNama.Text;
            temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Todo temp = new Todo();

            temp.Id = Convert.ToInt16(textBox1.Text);

            TodoRepository todo = new TodoRepository();

            todo.deleteTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            textBox4.Enabled = false;
            Todo temp = new Todo();

            temp.Id = Convert.ToInt16(textBox4.Text);
            temp.Nama = textBox3.Text;
            temp.Kategori = textBox2.Text;

            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }
    }
}
