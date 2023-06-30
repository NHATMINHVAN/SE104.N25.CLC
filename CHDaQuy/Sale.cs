using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHDaQuy
{

    public partial class Sale : Form
    {
        public Point mouseLocation;
        SqlConnection connection = new SqlConnection(Resource.connectionString);
        SqlDataAdapter adapt;
        DataTable table;

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
        public Sale()
        {
            InitializeComponent();

            //Thiết kế hình dạng Form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }


        void LoadProvider()
        {
            string Sql = "select TENcc  from NHACUNGCAP";

            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cbProvider.Items.Add(reader[0]);

            }
            connection.Close();
        }
        //Insert các CTHD vào database
        private void InsertCTHD()
        {
            //Update SoHD va NgayHD
            lbSoHD.Text = Resource.GetFieldValues("select top 1 MaHD from HOADON order by MaHD Desc");
            lbReceiptDate.Text = Resource.GetFieldValues("select NgayHD from HOADON where MaHD = " + lbSoHD.Text);

            //Insert CTHD
            DataTable d = UCtrl_ShoppingCart.dataTable;
            for (int i = 0; i < d.Rows.Count; i++)
            {
                connection.Open();
                DataRow r = d.Rows[i];
                SqlCommand cmd = new SqlCommand("insert into CTHD (MaHD, MaSP, SL) values (" + lbSoHD.Text +
                                                ", " + r["MaSP"].ToString() + ", " + r["SL"].ToString() + ")", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            //Update Tong tien
            string money = Resource.GetFieldValues("select TriGiaHD from HOADON where MaHD = " + lbSoHD.Text);
            lbTongTien.Text = string.Format("{0:#,###} VNĐ", int.Parse(money));
        }

        //Xuất hóa đơn bằng file PDF
        private void XuatPDF_Click(object sender, EventArgs e)
        {

            if (dataGVReceipt.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "HD" + lbSoHD.Text + ".pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {

                            PdfPTable pdfTable = new PdfPTable(dataGVReceipt.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGVReceipt.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(RemoveUnicode(column.HeaderText)));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGVReceipt.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(RemoveUnicode(cell.EditedFormattedValue.ToString()));
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);

                                pdfDoc.Open();

                                Paragraph para = new Paragraph();
                                para.Alignment = Element.ALIGN_CENTER;
                                para.Add("Cua Hang Da Quy");
                                para.Font.Size = 12f;
                                pdfDoc.Add(new Paragraph(para));
                                pdfDoc.Add(new Paragraph("So hoa don: " + lbSoHD.Text.ToString()));
                                pdfDoc.Add(new Paragraph("Ngay mua: " + lbReceiptDate.Text.ToString()));
                                pdfDoc.Add(new Paragraph("Ten khach hang: " + RemoveUnicode(tbxHoTen.Text.ToString())));
                                pdfDoc.Add(new Paragraph("So dien thoai: " + tbxSDT.Text.ToString()));
                                pdfDoc.Add(new Paragraph("Dia chi: " + RemoveUnicode(cbProvider.SelectedItem.ToString())));
                                pdfDoc.Add(new Paragraph("Ghi chu: " + RemoveUnicode(tbxDiaChi.Text.ToString())));
                                pdfDoc.Add(new Paragraph("\n"));
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Add(new Paragraph("Tong tien: " + RemoveUnicode(lbTongTien.Text.ToString())));
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
            Close();
        }

        //Di chuyển Form theo con trỏ chuột khi nhấn giữ chuột trái
        private void guna2CustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void guna2CustomGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        //Thay thế các chữ Tiếng Việt có dấu bằng chữ không dấu
        public static string RemoveUnicode(string text)

        {

            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ", "đ", "é", "è", "ẻ", "ẽ", "ẹ", "ê", "ế", "ề", "ể", "ễ", "ệ", "í", "ì", "ỉ", "ĩ", "ị", "ó", "ò", "ỏ", "õ", "ọ", "ô", "ố", "ồ", "ổ", "ỗ", "ộ", "ơ", "ớ", "ờ", "ở", "ỡ", "ợ", "ú", "ù", "ủ", "ũ", "ụ", "ư", "ứ", "ừ", "ử", "ữ", "ự", "ý", "ỳ", "ỷ", "ỹ", "ỵ", };

            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "d", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "i", "i", "i", "i", "i", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "y", "y", "y", "y", "y", };

            for (int i = 0; i < arr1.Length; i++)

            {

                text = text.Replace(arr1[i], arr2[i]);

                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());

            }

            return text;

        }

        private void Sale_Load(object sender, EventArgs e)
        {
            LoadProvider();
        }

        private void cbProvider_SelectedValueChanged(object sender, EventArgs e)
        {
            string Sql = "select DIACHI, SoDT from NHACUNGCAP where tencc = N'" + cbProvider.SelectedItem.ToString() + "'";

            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tbxDiaChi.Text = reader[0].ToString();
                tbxSDT.Text = reader[1].ToString();

            }
            connection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

