

namespace CHDaQuy
{
    partial class ShopItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopItem));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tbxSoLuong = new System.Windows.Forms.TextBox();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.BuyNow = new FontAwesome.Sharp.IconButton();
            this.guna2RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.tbxSoLuong);
            this.guna2Panel1.Controls.Add(this.lbSoLuong);
            this.guna2Panel1.Controls.Add(this.BuyNow);
            this.guna2Panel1.Controls.Add(this.guna2RatingStar1);
            this.guna2Panel1.Controls.Add(this.lbPrice);
            this.guna2Panel1.Controls.Add(this.lbName);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(350, 200);
            this.guna2Panel1.TabIndex = 0;
            // 
            // tbxSoLuong
            // 
            this.tbxSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbxSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSoLuong.Location = new System.Drawing.Point(287, 110);
            this.tbxSoLuong.MaxLength = 9;
            this.tbxSoLuong.Name = "tbxSoLuong";
            this.tbxSoLuong.Size = new System.Drawing.Size(60, 24);
            this.tbxSoLuong.TabIndex = 8;
            this.tbxSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSoLuong.Visible = false;
            this.tbxSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSoLuong_KeyPress);
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(302, 83);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(32, 24);
            this.lbSoLuong.TabIndex = 7;
            this.lbSoLuong.Text = "SL";
            this.lbSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSoLuong.Visible = false;
            // 
            // BuyNow
            // 
            this.BuyNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuyNow.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.BuyNow.IconColor = System.Drawing.Color.Black;
            this.BuyNow.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BuyNow.IconSize = 40;
            this.BuyNow.Location = new System.Drawing.Point(287, 3);
            this.BuyNow.Name = "BuyNow";
            this.BuyNow.Size = new System.Drawing.Size(60, 60);
            this.BuyNow.TabIndex = 5;
            this.BuyNow.UseVisualStyleBackColor = true;
            this.BuyNow.Click += new System.EventHandler(this.BuyNow_Click);
            // 
            // guna2RatingStar1
            // 
            this.guna2RatingStar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2RatingStar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2RatingStar1.Location = new System.Drawing.Point(18, 173);
            this.guna2RatingStar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2RatingStar1.Name = "guna2RatingStar1";
            this.guna2RatingStar1.RatingColor = System.Drawing.Color.Gold;
            this.guna2RatingStar1.Size = new System.Drawing.Size(107, 22);
            this.guna2RatingStar1.TabIndex = 3;
            this.guna2RatingStar1.Value = 4F;
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.Tomato;
            this.lbPrice.Location = new System.Drawing.Point(218, 164);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(98, 20);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "15.000.000&đ";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(15, 150);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(122, 18);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Giàn Tạ Đa Năng";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(47, 15);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(220, 119);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ShopItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ShopItem";
            this.Size = new System.Drawing.Size(350, 200);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2RatingStar guna2RatingStar1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbName;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private FontAwesome.Sharp.IconButton BuyNow;
        private System.Windows.Forms.TextBox tbxSoLuong;
        private System.Windows.Forms.Label lbSoLuong;
    }
}
