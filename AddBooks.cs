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

namespace WindowsFormsApp3
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String bname = txtBook.Text;
            String bautor = txtAuthor.Text;
            String publication = txtpubli.Text;
            String pdate = dateTimePicker1.Text;
            Int64 price = Int64.Parse(txtPrice.Text);
            Int64 quan = Int64.Parse(txtQuan.Text);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into newBook values ('" + bname + "','" + bautor + "','" + publication + "','" + pdate + "','" + price + "','" + quan + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtBook.Clear();
            txtAuthor.Clear();
            txtpubli.Clear();
            txtPrice.Clear();
            txtQuan.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Shure","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
