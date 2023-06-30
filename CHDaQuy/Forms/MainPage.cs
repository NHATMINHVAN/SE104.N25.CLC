using CHDaQuy.Forms;
using FontAwesome.Sharp;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class MainPage : Form
    {
        public Point mouseLocation;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private int permission;
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
        public MainPage(FormLogin form)
        {
            InitializeComponent();

            //Thiết lập giao diện Form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Thay đổi Menu tùy vào permission của Người Dùng
            GetUser();
            if (permission == 0)
            {
                btnAddStaff.Visible = false;
                btnManage.Visible = false;
                btnStatistic.Visible = false;
                iconButton3.Visible = false;
            }
            else if (permission == 1)
            {
                btnStatistic.Visible = false;
                btnAddStaff.Visible = false;
            }
        }
        public struct RGBColors
        {
            public static Color color1 = Color.White;
        }

        //Khi nhấn vào button trên Menu sẽ thay đổi nền, làm nổi bật cho button
        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(32, 83, 117); // current choosing
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = Color.FromArgb(246, 107, 14); ;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                panelLogo.BackColor = Color.FromArgb(246, 107, 14);
                iconTitle.IconChar = currentBtn.IconChar;
                iconTitle.IconColor = currentBtn.IconColor;
            }
        }

        //Vô hiệu quá tính năng nổi bật cho button
        public void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.WhiteSmoke;
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //Lấy Họ tên, permission từ database
        private void GetUser()
        {
            con.Open();
            string getName = "SELECT HoTen, permission FROM nguoidung WHERE username= '" + FormLogin.acc + "'";
            SqlDataAdapter da = new SqlDataAdapter(getName, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string name = dt.Rows[0]["HoTen"].ToString().Trim();
            permission = int.Parse(dt.Rows[0]["Permission"].ToString().Trim());
            txtDisplayName.Text = name;
        }


        //Kết thúc chương trình
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Thu nhỏ Form
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Đăng xuất 
        private void ibtDX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban có muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                FormLogin fLogin = new FormLogin();
                fLogin.ShowDialog();
                this.Close();
            }
        }

        //Form trở về bình thường
        private void iconButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            iconButton2.Visible = true;
            iconButton1.Visible = false;
        }

        //Phóng to Form
        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            iconButton2.Visible = false;
            iconButton1.Visible = true;
        }

        //Hiện UI của Home khi click vào mục Home trên Menu
        private void btnHome_Click(object sender, EventArgs e)
        {
            uCtrl_HomePage1.BringToFront();
            lbTitle.Text = btnHome.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Hiện UI của Shopping khi click vào mục Shopping trên Menu
        private void btnShop_Click(object sender, EventArgs e)
        {
            uCtrl_Shopping1.BringToFront();
            lbTitle.Text = btnShop.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Hiện UI của Shopping Cart khi click vào mục Shopping Cart trên Menu
        private void btnCart_Click(object sender, EventArgs e)
        {
            UCtrl_ShoppingCart uCtrl_ShoppingCart11 = uCtrl_ShoppingCart1;
            uCtrl_ShoppingCart11.BringToFront();
            lbTitle.Text = btnCart.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Hiện UI của Manage Products khi click vào mục Manage Products trên Menu
        private void btnManage_Click(object sender, EventArgs e)
        {
            uCtrl_ManageProduct1.BringToFront();
            lbTitle.Text = btnManage.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Hiện UI của Statistic khi click vào mục Statistic trên Menu
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            uCtrl_Statistic1.BringToFront();
            lbTitle.Text = btnStatistic.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Hiện UI của AddStaff khi click vào mục AddStaff trên Menu
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            uCtrl_AddStaff1.BringToFront();
            lbTitle.Text = btnAddStaff.Text;
            ActivateButton(sender, RGBColors.color1);
        }

        //Di chuyển Form theo con trỏ chuột khi nhấn giữ chuột trái
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void txtDisplayName_Click(object sender, EventArgs e)
        {
            FormUserInfo form = new FormUserInfo();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            usCtr_ManageService1.BringToFront();
            lbTitle.Text = iconButton3.Text;
            ActivateButton(sender, RGBColors.color1);
        }
    }
}
