using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CHDaQuy
{

    public partial class FormLogin : Form
    {
        public Point mouseLocation;
        public static String acc;
        public static String MaKH;

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

        public FormLogin()
        {
            InitializeComponent();

            //Thiết kế hình dạng cho Form
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            registerEvent();
        }

        //Đăng ký các sự kiện click
        void registerEvent()
        {
            ibClose2.Click += LblClose_Click;
            buttomnLoginChange.Click += ButtonLoginChange_Click;
            buttonSignUpChange.Click += ButtonSignUpChange_Click;
        }

        //Đổi sang giao diện Đăng Ký 
        private void ButtonSignUpChange_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelSignUp.Visible = true;
            panelSignUp.Dock = DockStyle.Right;
            textLoginUserName.Text = textLoginUserPass.Text = "";
        }

        //Đổi sang giao diện Đăng Nhập
        private void ButtonLoginChange_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelSignUp.Visible = false;
            textSignUpUserName.Text = textSignUpUserPass.Text = txtPhone.Text = txtFullname.Text = txtAddress.Text = "";
        }

        //Kết thúc chương trình
        private void LblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Xử lý chức năng Đăng Ký
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textSignUpUserName.Text == "" || textSignUpUserPass.Text == ""
                || txtAddress.Text == "" || txtFullname.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string check = "SELECT username FROM nguoidung WHERE username= '" + textSignUpUserName.Text.Trim() + "'";
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
                    con.Open();
                    string register = "INSERT INTO NGUOIDUNG (username,password,permission,hoten,sdt,diachi,doanhso) " +
                        "VALUES ('" + textSignUpUserName.Text.Trim() + "','" + textSignUpUserPass.Text.Trim() + "',0,'" + txtFullname.Text
                        + "','" + txtPhone.Text + "','" + txtAddress.Text + "',0)";
                    cmd = new SqlCommand(register, con);
                    cmd.ExecuteNonQuery();

                    acc = textSignUpUserName.Text.Trim();
                    MaKH = Resource.GetFieldValues("SELECT MaKH FROM NGUOIDUNG WHERE UserName = '" + acc + "'");

                    con.Close();


                    textSignUpUserName.Text = textSignUpUserPass.Text = txtAddress.Text = txtFullname.Text = txtPhone.Text = "";

                    MessageBox.Show("Tài khoản của bạn đã được tạo", "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainPage mainPage = new MainPage(this);
                    mainPage.ShowDialog();
                    this.Close();
                }

                con.Close();
            }

        }

        //Xử lý chức năng Đăng Nhập
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textLoginUserName.Text == "" || textLoginUserPass.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string login = "SELECT * FROM nguoidung WHERE username= '" + textLoginUserName.Text.Trim() + "' and password= '" + textLoginUserPass.Text.Trim() + "'";
                cmd = new SqlCommand(login, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    acc = textLoginUserName.Text;
                    MaKH = Resource.GetFieldValues("SELECT MaKH FROM NGUOIDUNG WHERE UserName = '" + acc + "'");

                    this.Hide();
                    MainPage mainPage = new MainPage(this);
                    mainPage.ShowDialog();
                    this.Close();
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu bị sai, mời nhập lại", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textLoginUserName.Text = "";
                    textLoginUserPass.Text = "";
                    textLoginUserName.Focus();
                }
            }
            con.Close();
        }

        //Xử lý chức năng hiển thị Mật Khẩu
        private void checkBoxSPassSU_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxSPassSU.Checked)
            {
                textSignUpUserPass.PasswordChar = '\0';
                txtPhone.PasswordChar = '\0';
            }
            else
            {
                textSignUpUserPass.PasswordChar = '•';
                txtPhone.PasswordChar = '•';
            }
        }

        //Kết thúc chương trình
        private void ibClose_Click(object sender, EventArgs e)
        {
            LblClose_Click(sender, e);
        }

        //Xử lý chức năng hiển thị Mật Khẩu
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                textLoginUserPass.PasswordChar = '\0';
            }
            else
            {
                textLoginUserPass.PasswordChar = '•';
            }
        }

        //Chỉ cho nhập phím số và phím Control
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Di chuyển Form theo con trỏ chuột khi nhấn giữ chuột trái
        private void guna2PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void guna2PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}
