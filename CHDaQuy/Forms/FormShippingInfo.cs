using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class FormShippingInfo : Form
    {
        public Point mouseLocation;
        SqlConnection connection;
        string ConnectionString = Resource.connectionString;
        public static string MaGH;

        public FormShippingInfo()
        {
            InitializeComponent();
            DisplayInfo();
        }

        //Đóng Form
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Xử lý chức năng Đặt hàng
        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (textBoxSDT.Text == "" || textBoxDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin giao hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult d = MessageBox.Show("Bạn có chắc chắn là muốn ĐẶT HÀNG?", "Câu hỏi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (d == DialogResult.Yes)
                {
                    InsertShippingInfotoDB();

                    this.Hide();
                    MaGH = Resource.GetFieldValues("select top 1 MaGH from GIAOHANG order by MaGH Desc ");

                    FormReceipt formReceipt = new FormReceipt();
                    formReceipt.ShowDialog();
                    this.Close();
                }
                return;
            }
        }

        //Insert Thông tin Giao hàng vào database
        private void InsertShippingInfotoDB()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO GIAOHANG (MaKH, SDT, DiaChi, GhiChu) " +
                                                "VALUES (" + FormLogin.MaKH + ", '" + textBoxSDT.Text + "', N'" +
                                                textBoxDiaChi.Text + "', N'" + textBoxGhiChu.Text + "')", connection);

            command.ExecuteNonQuery();
            connection.Close();
        }

        //Hiện thị lại Số điện thoại, Địa chỉ từ database
        private void DisplayInfo()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Sdt, DiaChi " +
              "from NGUOIDUNG where  MaKH = " + FormLogin.MaKH, connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBoxSDT.Text = read["Sdt"].ToString();
                textBoxDiaChi.Text = read["DiaChi"].ToString();

            }
            connection.Close();
        }

        //Xử lý lỗi hiển thị chữ của label
        private void FormShippingInfo_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.AutoSize = guna2HtmlLabel3.AutoSize =
            guna2HtmlLabel4.AutoSize = guna2HtmlLabel5.AutoSize = true;
        }

        //Di chuyển Form theo con trỏ chuột khi nhấn giữ chuột trái
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        //Chỉ cho nhập Số điện thoại bằng phím số và phím Control
        private void textBoxSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
