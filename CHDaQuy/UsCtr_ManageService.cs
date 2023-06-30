using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class usCtr_ManageService : UserControl
    {
        SqlConnection con = new SqlConnection(Resource.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        public usCtr_ManageService()
        {
            InitializeComponent();
            loadDatabase();
        }
        private void loadDatabase()
        {
            con.Open();
            //string sql = "SELECT TenDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap,TongTien,SL,SoDT,DonGiaDV,DonGiaDT,SoPhieu FROM PHIEUDV";
            string sql = "SELECT TenDV, UserName,SL,DonGiaDV,TinhTrang,NgLap,TongTien FROM PHIEUDV";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGVProduct.DataSource = dt;
            txtDateCre.Text = "0";
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }



        // XỬ lí chức năng thêm mới
        private bool checkBlankInput()
        {
            if (txtProductName.Text == "" || txtUser.Text == "" || txtPrePrice.Text == "" ||
                txtDateDelivery.Text == "" || txtStatus.Text == "" || txtDateCre.Text == "" || txtTotalPrice.Text == "" || txtQuantity.Text == "" || txtPhone.Text == "" ||
                txtPrice.Text == "" || txtUnit.Text == ""   )
            {
                return true;
            }
            return false;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (checkBlankInput())
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO PHIEUDV(TenDV, UserName, TraTrc, NgGiao, TinhTrang, NgLap,TongTien,SL,SoDT,DonGiaDV,DonGiaDT) " +
                    "VALUES(N'" + txtProductName.Text.Trim() + "',N'" + txtUser.Text.Trim() + "','"+ txtPrePrice.Text.Trim() + "',N'" + txtDateDelivery.Text.Trim() + "',"
                    +"N'"+ txtStatus.Text.Trim()+ "','" + txtDateCre.Text.Trim() + "'," + txtTotalPrice.Text.Trim() +  ","
                    + txtQuantity.Text.Trim() + ",'" + txtPhone.Text.Trim() + "'," + txtPrice.Text.Trim() +","+ txtUnit.Text.Trim() +")";
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadDatabase();
            }
        }


        // Không đụng đến
        private void btnCancelTextbox_Click(object sender, EventArgs e)
        {
    
             

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBrandCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGVProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {

        }
    }
}
