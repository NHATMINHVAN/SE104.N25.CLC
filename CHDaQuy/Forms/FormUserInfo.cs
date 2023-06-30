using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CHDaQuy.Forms
{
    public partial class FormUserInfo : Form
    {
        static String MaKH;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(Resource.connectionString);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );
        public FormUserInfo()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            MaKH = FormLogin.MaKH;
            LoadData();
        }

        private void LoadData()
        {
            con.Open();
            string loadDT = "SELECT hoten, username, password, diachi, sdt, doanhso FROM nguoidung  WHERE MaKH = '" + MaKH + "'";
            cmd = new SqlCommand(loadDT, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    txtFullname.Text = reader["hoten"].ToString();
                    txtUsername.Text = reader["username"].ToString();
                    txtPassword.Text = reader["password"].ToString();
                    txtAddress.Text = reader["diachi"].ToString();
                    txtPhone.Text = reader["sdt"].ToString();
                    txtSales.Text = reader["doanhso"].ToString();
                }
            }
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSales_TextChanged(object sender, EventArgs e)
        {
            if (txtSales.Text == "" || txtSales.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtSales.Text, System.Globalization.NumberStyles.Currency);
            txtSales.Text = number.ToString("#,#");
            txtSales.SelectionStart = txtSales.Text.Length;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == ""
                || txtAddress.Text == "" || txtFullname.Text == ""
                || txtPhone.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Close();
                con.Open();
                string update = "UPDATE NGUOIDUNG SET USERNAME = '" + txtUsername.Text.Trim() + "', " +
                    "PASSWORD = '" + txtPassword.Text.Trim() + "', " +
                    "HOTEN = N'" + txtFullname.Text.Trim() + "', " +
                    "DIACHI = N'" + txtAddress.Text.Trim() + "', " +
                    "SDT = " + txtPhone.Text +
                    " WHERE MaKH = '" + MaKH + "'";
                cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Tài khoản đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void checkBoxSPassSU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSPassSU.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }
    }
}
