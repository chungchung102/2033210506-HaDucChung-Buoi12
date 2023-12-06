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
namespace WindowsFormsApplication1
{
    public partial class frmBaiTap2 : Form
    {
        public SqlConnection connect;
        string abc = "Data Source=A209PC36;Initial Catalog=QL_SinhVien;Integrated Security=True";
        public frmBaiTap2()
        {
            InitializeComponent();
        }
        private void Them(string a,string b)
        {
            try
            {

                connect = new SqlConnection(abc);
                connect.Open();
                string InsertString = "insert into SINHVIEN values(N'" + a + "','" + b + "');";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Them(textBox1.Text ,textBox2.Text);
            Show();

        }
        private void Xoa(string a)
        {
            try
            {

                connect = new SqlConnection(abc);
                connect.Open();
                string DeleteString = "delete SINHVIEN where ID = '" + a + "'";
                SqlCommand cmd = new SqlCommand(DeleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Xoa(textBox2.Text);
            Show();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Sua(textBox1.Text, textBox2.Text);
            Show();
        }
        private void Sua(string a,string b)
        {
            try
            {

                connect = new SqlConnection(abc);
                connect.Open();
                string UpdateString = "update SINHVIEN set  Name= '" + a + "' where ID = '" + b + "'";
                SqlCommand cmd = new SqlCommand(UpdateString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Show();
        }
        private void Show()
        {
            connect = new SqlConnection(abc);
            connect.Open();
            string ShowString = "select * from SINHVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrrow;
            numrrow = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[numrrow].Cells[1].Value.ToString();
        }
    }
}
