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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String enrol = txtEn.Text;
            String dep = txtDepart.Text;
            String semes = txtSemes.Text;
            Int64 contact = Int64.Parse(txtCon.Text);
            String email=txtEmail.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into newStudent values('" + name + "','" + enrol + "','" + dep + "','" + semes + "','" + contact + "','" + email + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("The Value insert", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtName.Clear();
            txtEn.Clear();
            txtDepart.Clear();
            txtSemes.Clear();
            txtCon.Clear();
            txtEmail.Clear();
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
