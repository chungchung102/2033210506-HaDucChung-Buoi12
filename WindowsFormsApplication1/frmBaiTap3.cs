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
    public partial class frmBaiTap3 : Form
    {
        public SqlConnection connect;
        string abc = "Data Source=A209PC36;Initial Catalog=QLHN;Integrated Security=True";
        public frmBaiTap3()
        {
            InitializeComponent();
        }
        private void Them(string a, string b)
        {
            try
            {

                connect = new SqlConnection(abc);
                connect.Open();
                string InsertString = "insert into  HoiNghi values(N'" + a + "','" + b + "');";
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
        private void btn2_Click(object sender, EventArgs e)
        {
            Them(textBox1.Text, textBox2.Text);
            Show();

        }
        private void Xoa(string a)
        {
            try
            {

                connect = new SqlConnection(abc);
                connect.Open();
                string DeleteString = "delete HoiNghi where maHoiNghi = '" + a + "'";
                SqlCommand cmd = new SqlCommand(DeleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Xoa(textBox2.Text);
            Show();
        }
        private void Show()
        {
            connect = new SqlConnection(abc);
            connect.Open();
            string ShowString = "select *from HoiNghi";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
       

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Show();
            int numrrow;
            numrrow = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[numrrow].Cells[1].Value.ToString();
        }

        private void frmBaiTap3_Load(object sender, EventArgs e)
        {
            Show();
            string ShowString = "select maLoaiPhong from LoaiPhong";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "maLoaiPhong";
        }

        
    }
}
