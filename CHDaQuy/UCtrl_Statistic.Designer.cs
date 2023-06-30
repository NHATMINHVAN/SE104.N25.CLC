
namespace CHDaQuy
{
    partial class UCtrl_Statistic
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChooseTypeStac = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ChooseYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbYear = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 17);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1184, 539);
            this.chart.TabIndex = 0;
            // 
            // ChooseTypeStac
            // 
            this.ChooseTypeStac.BackColor = System.Drawing.Color.Transparent;
            this.ChooseTypeStac.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ChooseTypeStac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseTypeStac.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseTypeStac.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseTypeStac.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ChooseTypeStac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ChooseTypeStac.ItemHeight = 30;
            this.ChooseTypeStac.Items.AddRange(new object[] {
            "Tháng",
            "Năm"});
            this.ChooseTypeStac.Location = new System.Drawing.Point(87, 609);
            this.ChooseTypeStac.Name = "ChooseTypeStac";
            this.ChooseTypeStac.Size = new System.Drawing.Size(179, 36);
            this.ChooseTypeStac.TabIndex = 2;
            this.ChooseTypeStac.SelectedIndexChanged += new System.EventHandler(this.ChooseTypeStac_SelectedIndexChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(97, 585);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(113, 18);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Chọn loại thống kê";
            // 
            // ChooseYear
            // 
            this.ChooseYear.BackColor = System.Drawing.Color.Transparent;
            this.ChooseYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ChooseYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ChooseYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ChooseYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ChooseYear.ItemHeight = 30;
            this.ChooseYear.Location = new System.Drawing.Point(304, 609);
            this.ChooseYear.Name = "ChooseYear";
            this.ChooseYear.Size = new System.Drawing.Size(179, 36);
            this.ChooseYear.TabIndex = 2;
            // 
            // lbYear
            // 
            this.lbYear.BackColor = System.Drawing.Color.Transparent;
            this.lbYear.Location = new System.Drawing.Point(314, 585);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(63, 18);
            this.lbYear.TabIndex = 3;
            this.lbYear.Text = "Chọn năm";
            // 
            // UCtrl_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbYear);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ChooseYear);
            this.Controls.Add(this.ChooseTypeStac);
            this.Controls.Add(this.chart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCtrl_Statistic";
            this.Size = new System.Drawing.Size(1187, 692);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private Guna.UI2.WinForms.Guna2ComboBox ChooseTypeStac;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox ChooseYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbYear;
    }
}
