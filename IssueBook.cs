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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }
        int count;
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtEnrol.Text!="")
            {
                String enroll = txtEnrol.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from newStudent where enroll='" + enroll + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //count
                cmd.CommandText = "select count(std_enroll) from IRbook where std_enroll='" + enroll + "' and b_return is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                if (ds.Tables[0].Rows.Count!=0)
                {
                    txtStud.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("Eror", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("invalid enroll no", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select bname from newBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                for(int i=0;i<sdr.FieldCount;i++)
                {
                    txtbname.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(txtStud.Text!="")
            {
                if(txtbname.SelectedIndex!=-1 && count <=2)
                {
                    String enroll = txtEnrol.Text;
                    String Student = txtStud.Text;
                    String Dep = txtDep.Text;
                    String Sem = txtSem.Text;
                    Int64 contat = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bname = txtbname.Text;
                    String issue = dateTimePicker1.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=LAPTOP-8A5S46S3\\AVIEL;Initial Catalog=ConnectionD;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into IRbook(std_enroll,std_name,std_dep,std_sem,std_contact,std_email,b_name,b_issue) values ('" + enroll + "','"+ Student + "','"+ Dep + "','"+ Sem + "','"+ contat + "','"+ email + "','"+ bname + "','"+ issue + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("I am in", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid input", "EROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            txtEnrol.Clear();
            txtStud.Clear();
            txtDep.Clear();
            txtSem.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtbname.SelectedIndex=-1;
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You Shure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
