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
    public partial class frmBaiTap1 : Form
    {
        string connectionString = "server=.; database=QL_SinhVien;integrated security=true";
        private SqlConnection connect;
        public frmBaiTap1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(connectionString);
            try
            {
                connect = new SqlConnection(connectionString);

                connect.Open();
                MessageBox.Show("ket noi thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //bool KT_MaKhoa(string ID)
        //{
        //    try
        //    {
        //        connect.Open();
        //        string selectString = "select count(*) from SINHVIEN where ID='" + ID + "'";
        //        SqlCommand cmd = new SqlCommand(selectString, connect);
        //        int count = (int)cmd.ExecuteScalar();
        //        connect.Close();
        //        if (count >= 1)
        //            return false;
        //        return true;

        //    }
        //    catch (Exception ex) { return false; };
        //}
        private void btn2_Click(object sender, EventArgs e)
        {
            
          
            try
            {
                
                    connect = new SqlConnection(connectionString);
                    connect.Open();
                    string insertString = "insert into SINHVIEN values(N' " + textBox1.Text + " ',  ' " + textBox2.Text + " ') ";
                    SqlCommand cmd = new SqlCommand(insertString, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("thanh cong");
                
           

            }
            catch (Exception ex)
            {
                MessageBox.Show("that bai");
            }

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteString = "delete SINHVIEN where ID = " + textBox2.Text + " ";
                SqlCommand cmd = new SqlCommand(deleteString, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                MessageBox.Show("thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show("that bai");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                string updateString = "update SINHVIEN set ID = " + 10 + "  where ID = " + 1 + "";
                SqlCommand cmd = new SqlCommand(updateString, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                MessageBox.Show("thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show("that bai");
            }
        }



        
    }
}
