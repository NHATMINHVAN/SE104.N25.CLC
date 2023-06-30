using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class UCtrl_AddStaff : UserControl
    {
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
        public UCtrl_AddStaff()
        {
            InitializeComponent();
            LoadData();

            //Thiết kế hình dạng Form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            txtUsername.AutoSize = txtPassword.AutoSize = txtConfirmPassword.AutoSize =
            txtAddress.AutoSize = txtFullname.AutoSize = txtPhone.AutoSize = true;
        }

        //Xử lý chức năng hiển thị Mật Khẩu
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSPassSU.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPassword.PasswordChar = '•';

            }
        }

        //Xử lý chức năng Đăng Ký nhân viên của Shop
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == ""
                || txtConfirmPassword.Text == "" || txtAddress.Text == "" || txtFullname.Text == ""
                || txtPhone.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.CompareTo(txtConfirmPassword.Text) != 0)
            {
                MessageBox.Show("Mật khẩu xác nhận chưa đúng!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string check = "SELECT username FROM nguoidung WHERE username= '" + txtUsername.Text.Trim() + "'";
                cmd = new SqlCommand(check, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại! Hãy thử một tên khác!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    int permission = cbPosition.SelectedIndex;
                    con.Open();
                    string register = "INSERT INTO NGUOIDUNG (username,password,permission,hoten,sdt,diachi,doanhso) " +
                        "VALUES ('" + txtUsername.Text.Trim() + "','" + txtPassword.Text.Trim() + "'," +
                        permission + ",N'" + txtFullname.Text
                        + "','" + txtPhone.Text + "',N'" + txtAddress.Text + "',0)";
                    cmd = new SqlCommand(register, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtUsername.Text = txtPassword.Text = txtAddress.Text = txtFullname.Text = txtPhone.Text = "";

                    MessageBox.Show("Tài khoản đã được tạo", "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            LoadData();
        }


        private void LoadData()
        {
            con.Open();
            string sql = "SELECT USERNAME, HOTEN,PASSWORD, SDT, DIACHI FROM NGUOIDUNG WHERE PERMISSION = 2 or PERMISSION = 1";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGVStaff.DataSource = dt;
        }

        //Chỉ nhận phím số và phím Control
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Xử lý khi nhập Username khi Đăng ký
        private void textSignUpUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 6 && txtUsername.Text.Length > 0)
            {
                lbUsername.Text = "Tên đăng nhập phải từ đủ 6 ký tự !!!";
            }
            else
            {
                lbUsername.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == ""
                || txtConfirmPassword.Text == "" || txtAddress.Text == "" || txtFullname.Text == ""
                || txtPhone.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.CompareTo(txtConfirmPassword.Text) != 0)
            {
                MessageBox.Show("Mật khẩu xác nhận chưa đúng!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string check = "SELECT username FROM nguoidung WHERE username= '" + txtUsername.Text.Trim() + "'";
                cmd = new SqlCommand(check, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.HasRows)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại!", "Cập nhật thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    int permission = cbPosition.SelectedIndex;
                    con.Open();
                    string update = "UPDATE NGUOIDUNG SET USERNAME = '" + txtUsername.Text.Trim() + "', " +
                        "PASSWORD = '" + txtPassword.Text.Trim() + "', " +
                        "HOTEN = N'" + txtFullname.Text.Trim() + "', " +
                        "DIACHI = N'" + txtAddress.Text.Trim() + "', " +
                        "SDT = " + txtPhone.Text + "," +
                        "PERMISSION = " + cbPosition.SelectedIndex +
                        " WHERE USERNAME = '" + txtUsername.Text.Trim() + "'";
                    cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtUsername.Text = txtPassword.Text = txtAddress.Text = txtFullname.Text = txtPhone.Text = "";

                    MessageBox.Show("Tài khoản đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            LoadData();
        }

        private void dataGVStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            txtUsername.Text = dataGVStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFullname.Text = dataGVStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPassword.Text = dataGVStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtConfirmPassword.Text = dataGVStaff.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dataGVStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dataGVStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
            con.Open();
            string getPermission = "SELECT PERMISSION from NGUOIDUNG where USERNAME = '" + txtUsername.Text.Trim() + "'";
            cmd = new SqlCommand(getPermission, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    cbPosition.SelectedIndex = int.Parse(reader["PERMISSION"].ToString());
                }
            }
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == ""
                || txtConfirmPassword.Text == "" || txtAddress.Text == "" || txtFullname.Text == ""
                || txtPhone.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.CompareTo(txtConfirmPassword.Text) != 0)
            {
                MessageBox.Show("Mật khẩu xác nhận chưa đúng!", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Không thể xoá nhân viên này!\nBạn có thể hạ quyền thành khách hàng!", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    con.Open();
                    string update = "UPDATE NGUOIDUNG SET PERMISSION = 0 WHERE USERNAME = '" + txtUsername.Text.Trim() + "'";
                    cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadData();
        }
    }
}
