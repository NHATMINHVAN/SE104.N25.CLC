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
    public partial class ShopItem : UserControl
    {
        SqlConnection con = new SqlConnection(Resource.connectionString);
        String maSP;

        public ShopItem()
        {
            InitializeComponent();
        }
        public Image ItemImage
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }
        public string ItemPrice
        {
            get { return lbPrice.Text; }
            set { lbPrice.Text = value; }
        }
        public string ItemName
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }
        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        //Xử lý chức năng Thêm vào Giỏ hàng
        private void BuyNow_Click(object sender, EventArgs e)
        {
            //Nếu label Số Lượng và textBox Số Lượng đã hiển thị 
            if (lbSoLuong.Visible == true && tbxSoLuong.Visible == true)
            {
                if (String.IsNullOrEmpty(tbxSoLuong.Text))
                {
                    MessageBox.Show("Không được để trống!!!\n" +
                                    "Mời bạn nhập Số Lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxSoLuong.Focus();
                    return;
                }

                DialogResult d = MessageBox.Show("Bạn có chắc là muốn thêm vào giỏ hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (d == DialogResult.Yes)
                {
                    if (CheckProductExist() == 1) AddProductExist();
                    else InsertShoppingCart();
                    tbxSoLuong.Text = "";
                }
                else
                {
                    tbxSoLuong.Text = "";
                    lbSoLuong.Visible = false;
                    tbxSoLuong.Visible = false;
                }
            }

            //Nếu label Số Lượng và textBox Số Lượng chưa hiển thị hiển thị 
            else
            {
                lbSoLuong.Visible = true;
                tbxSoLuong.Visible = true;
                return;
            }
        }
        
        //Thêm sản phẩm đã chọn vào giỏ hàng
        private void InsertShoppingCart()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CTGH (MaKH, MaSP, SL) " +
                                                "values (" + FormLogin.MaKH + ", " + MaSP + ", " + tbxSoLuong.Text + ") ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm vào giỏ hàng Thành Công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbSoLuong.Visible = false;
                tbxSoLuong.Visible = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        //Kiểm tra sản phẩm đã có trong Giỏ hàng hay chưa
        private int CheckProductExist()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CTGH where MaKH = " + FormLogin.MaKH + " and MaSP = " + MaSP, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    return 1;
                }
                dr.Close();
                con.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            return 0;
        }

        //Thêm số lượng sản phẩm mà đã có trong Giỏ hàng
        private void AddProductExist()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update CTGH set SL = SL + " + tbxSoLuong.Text + 
                                                " where MaKH = " + FormLogin.MaKH + " and MaSP = " + MaSP, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm vào giỏ hàng Thành Công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbSoLuong.Visible = false;
                tbxSoLuong.Visible = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        //TextBox số lượng chỉ nhận phím số và phím control
        private void tbxSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
