using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class UCtrl_ShoppingCart : UserControl
    {
        SqlConnection connection = new SqlConnection(Resource.connectionString);
        SqlDataAdapter adapter;
        public static DataTable dataTable;
        BindingManagerBase current;

        static String MaKH;

        public UCtrl_ShoppingCart()
        {
            InitializeComponent();
            MaKH = FormLogin.MaKH;
        }

        public void UpdateDataGridView()
        {
            try
            {
                // Khởi tạo bộ đọc ghi dữ liệu 
                adapter = new SqlDataAdapter("SELECT ct.MaSP, TenSP, DVT, Gia, SL " +
                                             "FROM CTGH ct, SANPHAM sp " +
                                             "WHERE ct.MaSP = sp.MaSP AND ct.MaKH = " + MaKH, connection);

                // Bộ phát sinh lệnh
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);

                // Khởi tạo bảng 
                dataTable = new DataTable();

                // Gán dữ liệu cho dataTable
                adapter.FillSchema(dataTable, SchemaType.Mapped);

                // Lấy dữ liệu đổ vào dataTable 
                adapter.Fill(dataTable);

                // Gán dữ liệu nguồn cho DataGridView
                dataGVShoppingCart.DataSource = dataTable;

                // Gán nguồn
                current = BindingContext[dataTable];

                // Hiện tổng số tiền cần thanh toán
                UpdateTongSoTien();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //Hiển thị Tổng số điền trên Giỏ Hàng
        public void UpdateTongSoTien()
        {
            string SQL = "SELECT TriGiaGioHang FROM GIOHANG gh WHERE gh.MaKH = " + MaKH;
            labelTongTien.Text = string.Format("{0:#,###} VNĐ", int.Parse(Resource.GetFieldValues(SQL)));
        }

        private void UCtrl_ShoppingCart_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        //Xóa các sản phẩm mà Người Dùng click vào
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng của bạn rỗng!!!\n Không thể Xóa được", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này ?", "Thông báo", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string MaSP = dataTable.Rows[current.Position][0].ToString();

                    connection = new SqlConnection(Resource.connectionString);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM CTGH WHERE MaSP = " + MaSP + " and MaKH = " + MaKH, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa sản phẩm. Lỗi phát sinh: " + ex.Message);
                dataTable.RejectChanges();
            }
        }

        //Hiện ra Form Giao hàng khi click vào Button Thanh Toán
        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng của bạn rỗng!!!\n Không thể thực hiện Thanh Toán", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormShippingInfo formShipping = new FormShippingInfo();
            formShipping.ShowDialog();
        }

        //Làm mới lại bảng khi có sự thay đổi trong Giỏ hàng
        private void Refresh_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }
    }
}
