using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Little_Red_Store_Of_Books
{
    public partial class frmMain : Form
    {
        public frmMain()
        {

            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }
        SqlConnection con = new SqlConnection(@"Data Source=Disala;Initial Catalog=Little_red;Integrated Security=True");

        public void StartForm()
        {
            Application.Run(new frmsplashscreen());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookname = txtBookName.Text;
            string Author = txtAuthor.Text;
            string insert_query = "insert into Book_shop values('" + bookname + "','" + Author + "')";
            SqlCommand cmdInsert = new SqlCommand(insert_query, con);
            con.Open();
            cmdInsert.ExecuteNonQuery();
            MessageBox.Show("Succsessfully Book Added!");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bookname = txtBookName.Text;
            string Author = txtAuthor.Text;
            string find = txtFind.Text;
            string update_query = "update Book_shop Set Book_name= '" + bookname + "',Book_author='" + Author + "' where Book_name='" + find + "'";
            SqlCommand cmdUpdate = new SqlCommand(update_query, con);
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            MessageBox.Show("Book Updated Succussfully!");
            con.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Find = txtFind.Text;
            string delete_query = "delete Book_shop where Book_name='"+Find+"'";
            SqlCommand cmdDelete = new SqlCommand(delete_query, con);
            con.Open();
            cmdDelete.ExecuteNonQuery();
            MessageBox.Show("Book Deleted Succsessfully!");
            con.Close();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = "";
            txtBookName.Text = "";
            txtFind.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
