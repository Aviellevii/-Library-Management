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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from IRbook where std_enroll='" + txtEnrol.Text + "' and b_return is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Enroll Or not null book", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int id;
        String Bname;
        String Issue;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]!=null)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                Issue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtbname.Text = Bname;
            txtIssue.Text = Issue;
        }
        public void show()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from IRbook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Update IRbook set b_return='" + dateTimePicker1.Text + "' where std_enroll='" + txtEnrol.Text + "' and id='" +id + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("I am Return", "Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReturnBook_Click(object sender, EventArgs e)
        {

        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtbname.Clear();
            txtIssue.Clear();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            txtEnrol.Clear();
            dataGridView1.DataSource=null;
            panel1.Visible = false;
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("you shure","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
