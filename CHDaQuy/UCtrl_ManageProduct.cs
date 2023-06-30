using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class UCtrl_ManageProduct : UserControl
    {
        private String imgName = "no_img.png";
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(Resource.connectionString);
        public UCtrl_ManageProduct()
        {
            InitializeComponent();
            productImg.Image = null;
            productImg.SizeMode = PictureBoxSizeMode.StretchImage;
            loadProductName();
            loadDatabase();
        }

        //Lấy dữ liệu của các sản phẩm hiện có vào Bảng
        private void loadDatabase()
        {
            con.Open();
            string sql = "SELECT MaSP, TenSP, TenThuongHieu, NuocSX, DVT,Gia,TonKho,HinhMinhHoa FROM SANPHAM";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGVProduct.DataSource = dt;
            txtQuantityIn.Text = "0";
        }

        //Xử lý chức năng thêm Hình ảnh
        private void productImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() { Filter = "Image Files (*.bmp;*.png;*.jpg;*.jpeg)|*.bmp;*.png;*.jpg;*.jpeg", Multiselect = false };
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                imgName = dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1);
                Image img = Image.FromFile(dlg.FileName);
                productImg.Image = img;
            }
        }

        //Xử lý chức năng Thêm Sản phẩm vào database
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

                cmd.CommandText = "INSERT INTO SANPHAM(TenSP, DVT, Gia, NuocSX, TenThuongHieu, TonKho, HinhMinhHoa) " +
                    "VALUES(N'" + txtProductName.Text.Trim() + "',N'" + txtUnit.Text.Trim() + "'," + removeDotInPrice(txtPrice.Text.Trim()) + ",N'"
                    + txtBrandCountry.Text.Trim() + "',N'" + txtBrandName.Text.Trim() + "'," + txtQuantity.Text.Trim()
                    + ",'" + imgName + "')";
                cmd.ExecuteNonQuery();

                productImg.Image.Save("../../Resources/" + imgName, System.Drawing.Imaging.ImageFormat.Png);

                con.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                loadDatabase();
            }
        }

        //Chức năng gợi ý tên sản phẩm khi nhập vào TextBox Tên Sản Phẩm
        private void loadProductName()
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();


            con.Open();
            string loadDT = "SELECT TenSP FROM SANPHAM";
            cmd = new SqlCommand(loadDT, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    auto.Add(reader["TenSP"].ToString());
                }
            }
            txtProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = auto;
            con.Close();


        }

        //Trả về kết quả khi chưa điền thông tin vào TextBox
        private bool checkBlankInput()
        {
            if (txtBrandCountry.Text == "" || txtBrandName.Text == "" || txtPrice.Text == "" ||
                txtProductName.Text == "" || txtUnit.Text == "" || txtQuantity.Text == "" || productImg.Image == null)
            {
                return true;
            }
            return false;
        }

        //Xử lý chức năng Hủy, khi chưa muốn thêm sản phẩm vào database
        private void btnCancelTextbox_Click(object sender, EventArgs e)
        {
            txtBrandCountry.Text = txtBrandName.Text = txtPrice.Text =
                txtProductName.Text = txtUnit.Text = txtQuantity.Text = "";
            productImg.Image = null;

        }

        //Chỉ nhận phím số và phím Control
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Thêm dấu chấm hoặc dấu phẩy sau 3 số của giá sản phẩm khi nhập vào
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text == "" || txtPrice.Text == "0") return;
                decimal number;
                number = decimal.Parse(txtPrice.Text, System.Globalization.NumberStyles.Currency);
                txtPrice.Text = number.ToString("#,#");
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        //Xử lý chức năng Sửa đổi thông tin Sản phẩm
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (checkBlankInput())
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE SANPHAM SET TenSp = N'" + txtProductName.Text.Trim() +
                    "',TenThuongHieu = N'" + txtBrandName.Text.Trim() + "',NuocSx = N'" + txtBrandCountry.Text.Trim() +
                    "',Gia = " + removeDotInPrice(txtPrice.Text.Trim()) + ",DVT = N'" + txtUnit.Text.Trim() +
                    "',TonKho = " + (int.Parse(txtQuantity.Text) + int.Parse(txtQuantityIn.Text)).ToString() +
                    ",HinhMinhHoa = '" + imgName + "' WHERE TenSP = N'" + txtProductName.Text.Trim() + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatabase();
            }
        }

        //In hoa Tên sản phẩm khi nhập vào
        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
        }

        //Hiển thị thông tin của sản phẩm vào các textBox khi click vào 1 hàng của Bảng
        private void dataGVProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txtProductName.Text = dataGVProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBrandName.Text = dataGVProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBrandCountry.Text = dataGVProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtUnit.Text = dataGVProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPrice.Text = dataGVProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuantity.Text = dataGVProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
            productImg.Image = Image.FromFile("../../Resources/" + dataGVProduct.Rows[e.RowIndex].Cells[7].Value.ToString());
            //txtQuantityIn.Text = "";
        }

        //Loại bỏ dấu chấm hoặc dấu phẩy của giá sản phẩm
        private string removeDotInPrice(String s)
        {
            s = s.Replace(",", "");
            return s;
        }

        //Hiển thị thông tin của sản phẩm vào các textBox khi nhấn Enter sau khi nhập Tên sản phẩm
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                con.Open();
                string loadDT = "SELECT MaSP, TenThuongHieu, NuocSX, Gia, DVT, TonKho, HinhMinhHoa FROM SANPHAM WHERE TenSP = N'" + txtProductName.Text.Trim() + "'";
                cmd = new SqlCommand(loadDT, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        txtBrandName.Text = reader["TenThuongHieu"].ToString();
                        txtBrandCountry.Text = reader["NuocSX"].ToString();
                        txtPrice.Text = reader["Gia"].ToString();
                        txtUnit.Text = reader["DVT"].ToString();
                        txtQuantity.Text = reader["TonKho"].ToString();
                        productImg.Image = Image.FromFile("../../Resources/" + reader["HinhMinhHoa"].ToString());
                        imgName = reader["HinhMinhHoa"].ToString();
                    }
                }
                con.Close();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Sale fSale = new Sale();
            fSale.ShowDialog();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

