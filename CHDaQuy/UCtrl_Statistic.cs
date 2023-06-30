using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CHDaQuy
{
    public partial class UCtrl_Statistic : UserControl
    {
        private SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(Resource.connectionString);
        public UCtrl_Statistic()
        {
            InitializeComponent();
            ChooseYear.Visible = false;
            lbYear.Visible = false;
            loadChartData();
        }

        //Thống kê doanh số theo từng năm (mặc định)
        private void loadChartData()
        {
            con.Open();
            string ch = "SELECT SUM(TRIGIAHD) DOANHSO, YEAR(NGAYHD) NAM FROM HOADON GROUP BY YEAR(NGAYHD)";
            da = new SqlDataAdapter(ch, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart.DataSource = da;
            chart.ChartAreas["ChartArea1"].AxisX.Title = "Năm";
            chart.ChartAreas["ChartArea1"].AxisY.Title = "Doanh số";

            chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            chart.Series[0].Name = "Doanh số";

            chart.Series["Doanh số"].XValueMember = "NAM";
            chart.Series["Doanh số"].YValueMembers = "DOANHSO";
            con.Close();
        }

        private void ChooseTypeStac_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Nếu chọn thống kê doanh số theo tháng thì hiển thị combobox chọn năm cụ thể để hiện thông số thống kê
            if (ChooseTypeStac.SelectedIndex == 0)
            {
                ChooseYear.Visible = true;
                lbYear.Visible = true;
                LoadComboBox();
                con.Open();
                string ch = "SELECT SUM(TRIGIAHD) DOANHSO, MONTH(NGAYHD) THANG FROM HOADON GROUP BY MONTH(NGAYHD)";
                da = new SqlDataAdapter(ch, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                chart.DataSource = da;
                chart.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                chart.ChartAreas["ChartArea1"].AxisY.Title = "Doanh số";

                chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
                chart.Series[0].Name = "Doanh số";

                chart.Series["Doanh số"].XValueMember = "THANG";
                chart.Series["Doanh số"].YValueMembers = "DOANHSO";
                con.Close();
            }
            else
            {
                ChooseYear.Visible = false;
                lbYear.Visible = false;
                loadChartData();
            }
        }

        //Load các năm vào combobox khi chọn thống kê doanh số theo từng tháng của năm 
        private void LoadComboBox()
        {
            con.Open();
            string ch = "SELECT DISTINCT (YEAR(NGAYHD)) AS Nam FROM HOADON";
            da = new SqlDataAdapter(ch, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ChooseYear.DataSource = dt;
            ChooseYear.DisplayMember = "Nam";
            ChooseYear.ValueMember = "Nam";
            con.Close();
        }
    }
}
