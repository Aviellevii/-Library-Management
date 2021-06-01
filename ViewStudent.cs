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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text!="")
            {
                Image img = Image.FromFile("C:/Users/Aviel Levi/Desktop/Liberay Management System/search1.gif");
                pictureBox1.Image = img;
                panel2.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from newStudent where enroll LIKE'"+txtSearch.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                
                Image img = Image.FromFile("C:/Users/Aviel Levi/Desktop/Liberay Management System/search.gif");
                pictureBox1.Image = img;
                panel2.Visible = false;
                load();
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from newStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds= new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from newStudent where stuid='" + bid + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtNO.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepart.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemes.Text = ds.Tables[0].Rows[0][4].ToString();
            txtConta.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String NO = txtNO.Text;
            String Depart = txtDepart.Text;
            String Semester = txtSemes.Text;
            String contact = txtConta.Text;
            String email = txtEmail.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update newStudent set sname='" + name + "',enroll='" + NO + "',dep='" + Depart + "',sem='" + Semester + "',contact='" + contact + "',email='" + email + "' where stuid='" + bid + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("You Update", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shure", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from newStudent where stuid='" + bid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                load();
            }
        }
        public void load()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from newStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtSearch.Clear();
            load();
        }
    }
    
}
