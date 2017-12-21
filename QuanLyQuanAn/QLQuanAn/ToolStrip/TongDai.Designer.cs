namespace QLQuanAn
{
    partial class TongDai
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TongDai));
            this.ttMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lbPhone = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btChiNhanh = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btGuiDonHang = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lvGioHangTongDai = new System.Windows.Forms.ListView();
            this.nbudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.cbMonAn = new System.Windows.Forms.ComboBox();
            this.cbDanhMuc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChiNhanh = new System.Windows.Forms.ComboBox();
            this.ttMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // ttMenu
            // 
            this.ttMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ttMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ttMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.lbPhone,
            this.toolStripSeparator1,
            this.btChiNhanh});
            this.ttMenu.Location = new System.Drawing.Point(0, 0);
            this.ttMenu.Name = "ttMenu";
            this.ttMenu.Size = new System.Drawing.Size(843, 25);
            this.ttMenu.TabIndex = 0;
            this.ttMenu.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNew,
            this.btExit});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // btNew
            // 
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(152, 22);
            this.btNew.Text = "New";
            // 
            // btExit
            // 
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(152, 22);
            this.btExit.Text = "Exit";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // lbPhone
            // 
            this.lbPhone.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(101, 22);
            this.lbPhone.Text = "Phone: 080808008";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btChiNhanh
            // 
            this.btChiNhanh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btChiNhanh.Image = ((System.Drawing.Image)(resources.GetObject("btChiNhanh.Image")));
            this.btChiNhanh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btChiNhanh.Name = "btChiNhanh";
            this.btChiNhanh.Size = new System.Drawing.Size(68, 22);
            this.btChiNhanh.Text = "Chi Nhánh";
            this.btChiNhanh.Click += new System.EventHandler(this.btChiNhanh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(507, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Giỏ Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "MENU";
            // 
            // btGuiDonHang
            // 
            this.btGuiDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuiDonHang.Location = new System.Drawing.Point(657, 298);
            this.btGuiDonHang.Name = "btGuiDonHang";
            this.btGuiDonHang.Size = new System.Drawing.Size(134, 42);
            this.btGuiDonHang.TabIndex = 19;
            this.btGuiDonHang.Text = "Gửi Đơn Hàng";
            this.btGuiDonHang.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.lvGioHangTongDai);
            this.panel1.Controls.Add(this.nbudSoLuong);
            this.panel1.Controls.Add(this.btnThemMon);
            this.panel1.Controls.Add(this.cbMonAn);
            this.panel1.Controls.Add(this.cbDanhMuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbChiNhanh);
            this.panel1.Controls.Add(this.btGuiDonHang);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 347);
            this.panel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 26);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(12, 242);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(152, 20);
            this.txtTongTien.TabIndex = 27;
            // 
            // lvGioHangTongDai
            // 
            this.lvGioHangTongDai.Location = new System.Drawing.Point(263, 40);
            this.lvGioHangTongDai.Name = "lvGioHangTongDai";
            this.lvGioHangTongDai.Size = new System.Drawing.Size(577, 252);
            this.lvGioHangTongDai.TabIndex = 26;
            this.lvGioHangTongDai.UseCompatibleStateImageBehavior = false;
            // 
            // nbudSoLuong
            // 
            this.nbudSoLuong.Location = new System.Drawing.Point(12, 105);
            this.nbudSoLuong.Name = "nbudSoLuong";
            this.nbudSoLuong.Size = new System.Drawing.Size(51, 20);
            this.nbudSoLuong.TabIndex = 25;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(12, 131);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(90, 42);
            this.btnThemMon.TabIndex = 24;
            this.btnThemMon.Text = "Thêm Món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // cbMonAn
            // 
            this.cbMonAn.FormattingEnabled = true;
            this.cbMonAn.Location = new System.Drawing.Point(12, 78);
            this.cbMonAn.Name = "cbMonAn";
            this.cbMonAn.Size = new System.Drawing.Size(204, 21);
            this.cbMonAn.TabIndex = 23;
            // 
            // cbDanhMuc
            // 
            this.cbDanhMuc.FormattingEnabled = true;
            this.cbDanhMuc.Location = new System.Drawing.Point(12, 40);
            this.cbDanhMuc.Name = "cbDanhMuc";
            this.cbDanhMuc.Size = new System.Drawing.Size(204, 21);
            this.cbDanhMuc.TabIndex = 22;
            this.cbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbDanhMuc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(379, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Chi Nhánh:";
            // 
            // cbChiNhanh
            // 
            this.cbChiNhanh.FormattingEnabled = true;
            this.cbChiNhanh.Location = new System.Drawing.Point(455, 310);
            this.cbChiNhanh.Name = "cbChiNhanh";
            this.cbChiNhanh.Size = new System.Drawing.Size(185, 21);
            this.cbChiNhanh.TabIndex = 8;
            // 
            // TongDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ttMenu);
            this.Name = "TongDai";
            this.Text = "Tổng Đài";
            this.ttMenu.ResumeLayout(false);
            this.ttMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ttMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btNew;
        private System.Windows.Forms.ToolStripMenuItem btExit;
        private System.Windows.Forms.ToolStripLabel lbPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGuiDonHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChiNhanh;
        private System.Windows.Forms.ToolStripButton btChiNhanh;
        private System.Windows.Forms.NumericUpDown nbudSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.ComboBox cbMonAn;
        private System.Windows.Forms.ComboBox cbDanhMuc;
        private System.Windows.Forms.ListView lvGioHangTongDai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}