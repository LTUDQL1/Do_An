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
            this.btGhiChu = new System.Windows.Forms.Button();
            this.btXoaHet = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btGuiDonHang = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbChiNhanh = new System.Windows.Forms.ComboBox();
            this.ttMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
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
            // 
            // btGhiChu
            // 
            this.btGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGhiChu.Location = new System.Drawing.Point(231, 61);
            this.btGhiChu.Name = "btGhiChu";
            this.btGhiChu.Size = new System.Drawing.Size(89, 23);
            this.btGhiChu.TabIndex = 18;
            this.btGhiChu.Text = "Ghi Chú";
            this.btGhiChu.UseVisualStyleBackColor = true;
            // 
            // btXoaHet
            // 
            this.btXoaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoaHet.Location = new System.Drawing.Point(231, 111);
            this.btXoaHet.Name = "btXoaHet";
            this.btXoaHet.Size = new System.Drawing.Size(89, 23);
            this.btXoaHet.TabIndex = 16;
            this.btXoaHet.Text = "Xóa Hết";
            this.btXoaHet.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(231, 153);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(89, 23);
            this.btXoa.TabIndex = 15;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 8);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(11, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 273);
            this.panel3.TabIndex = 11;
            // 
            // btGuiDonHang
            // 
            this.btGuiDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuiDonHang.Location = new System.Drawing.Point(520, 295);
            this.btGuiDonHang.Name = "btGuiDonHang";
            this.btGuiDonHang.Size = new System.Drawing.Size(134, 42);
            this.btGuiDonHang.TabIndex = 19;
            this.btGuiDonHang.Text = "Gửi Đơn Hàng";
            this.btGuiDonHang.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.dgvGioHang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbChiNhanh);
            this.panel1.Controls.Add(this.btGuiDonHang);
            this.panel1.Controls.Add(this.btGhiChu);
            this.panel1.Controls.Add(this.btXoaHet);
            this.panel1.Controls.Add(this.btXoa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 347);
            this.panel1.TabIndex = 20;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Location = new System.Drawing.Point(326, 40);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(514, 222);
            this.dgvGioHang.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Chi Nhánh:";
            // 
            // cbbChiNhanh
            // 
            this.cbbChiNhanh.FormattingEnabled = true;
            this.cbbChiNhanh.Location = new System.Drawing.Point(520, 268);
            this.cbbChiNhanh.Name = "cbbChiNhanh";
            this.cbbChiNhanh.Size = new System.Drawing.Size(185, 21);
            this.cbbChiNhanh.TabIndex = 8;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ttMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btNew;
        private System.Windows.Forms.ToolStripMenuItem btExit;
        private System.Windows.Forms.ToolStripLabel lbPhone;
        private System.Windows.Forms.Button btGhiChu;
        private System.Windows.Forms.Button btXoaHet;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btGuiDonHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbChiNhanh;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.ToolStripButton btChiNhanh;
    }
}