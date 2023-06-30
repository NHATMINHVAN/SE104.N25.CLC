using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CHDaQuy
{
    public partial class UCtrl_Shopping : UserControl
    {
        SqlConnection con = new SqlConnection(Resource.connectionString);
        public UCtrl_Shopping()
        {
            InitializeComponent();

            //Bo góc và cài font chữ của textBox Tìm kiếm Sản phẩm
            tbxSearch.BorderRadius = 17;
            tbxSearch.Font = new Font(Font.FontFamily, 16);

            AutoCompleteText();
        }

        private void UCtrl_Shopping_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
        }

        //Hiển thị tất cả các Sản phẩm trên UI Shopping
        private void LoadAllProducts()
        {
            int sum = int.Parse(Resource.GetFieldValues("select COUNT(*) from SANPHAM "));
            if (sum == 0) return;

            ShopItem[] shopItem = new ShopItem[sum];
            int n = 0;

            con.Open();
            SqlCommand cmd = new SqlCommand("select MaSP, TenSP, Gia, HinhMinhHoa " +
                                                "from SANPHAM ", con);
            SqlDataReader kq = cmd.ExecuteReader();

            if (kq.HasRows)
            {
                while (kq.Read())
                {
                    shopItem[n] = new ShopItem();
                    guna2Panel1.Controls.Add(shopItem[n]);

                    //Thay đổi tên SP, giá và hình ảnh trên UI theo từng hàng dữ liệu lấy được 
                     shopItem[n].ItemImage = Image.FromFile("../../Resources/" + kq["HinhMinhHoa"].ToString());
                    shopItem[n].MaSP = kq["MaSP"].ToString();
                    shopItem[n].ItemName = kq["TenSP"].ToString();
                    shopItem[n].ItemPrice = string.Format("{0:#,###}đ", kq["Gia"]);


                    //Thiết lập vị trí của các item
                    if (n % 3 == 0)
                    {
                        if (n > 0) shopItem[n].Location = new Point(3, shopItem[n - 1].Location.Y + 180);
                        else shopItem[n].Location = new Point(3, 2);
                    }
                    else
                    {
                        shopItem[n].Location = new Point(shopItem[n - 1].Location.X + 290, shopItem[n - 1].Location.Y);
                    }
                    n++;
                }
                kq.Close();
            }
            con.Close();
        }
        
        //Gợi ý tên Sản phẩm khi nhập vào Ô Tìm Kiếm
        private void AutoCompleteText()
        {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();

            con.Open();
            string loadDT = "SELECT TenSP FROM SANPHAM";
            SqlCommand cmd = new SqlCommand(loadDT, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    auto.Add(reader["TenSP"].ToString());
                }
            }
            tbxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbxSearch.AutoCompleteCustomSource = auto;
            con.Close();
        }

        //Khi nhấn Enter sau khi nhập tên vào ô Tìm kiếm, sẽ hiển thị đúng Sản phẩm có tên trùng với tên đã nhập
        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbxSearch.Text))
                {
                    guna2Panel1.Controls.Clear();
                    LoadAllProducts();
                    return;
                }

                guna2Panel1.Controls.Clear();
                int sum = int.Parse(Resource.GetFieldValues("select COUNT(*) from SANPHAM WHERE TenSP = N'" + tbxSearch.Text.Trim() + "'"));
                if (sum == 0) return;

                ShopItem[] shopItem = new ShopItem[sum];
                int n = 0;

                con.Open();
                string loadDT = "SELECT MaSP, TenSP, Gia, HinhMinhHoa FROM SANPHAM WHERE TenSP = N'" + tbxSearch.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(loadDT, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        shopItem[n] = new ShopItem();
                        guna2Panel1.Controls.Add(shopItem[n]);

                        //Thay đổi tên SP, giá và hình ảnh trên UI theo từng hàng dữ liệu lấy được 
                        shopItem[n].ItemImage = Image.FromFile("../../Resources/" + reader["HinhMinhHoa"].ToString());
                        shopItem[n].MaSP = reader["MaSP"].ToString();
                        shopItem[n].ItemName = reader["TenSP"].ToString();
                        shopItem[n].ItemPrice = string.Format("{0:#,###}đ", reader["Gia"]);


                        //Thiết lập vị trí của các item
                        if (n % 3 == 0)
                        {
                            if (n > 0) shopItem[n].Location = new Point(3, shopItem[n - 1].Location.Y + 180);
                            else shopItem[n].Location = new Point(3, 2);
                        }
                        else
                        {
                            shopItem[n].Location = new Point(shopItem[n - 1].Location.X + 290, shopItem[n - 1].Location.Y);
                        }
                        n++;
                    }
                    reader.Close();
                }
                con.Close();
            }
        }
    }
}
