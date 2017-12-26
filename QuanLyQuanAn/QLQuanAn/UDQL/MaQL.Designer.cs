namespace QLQuanAn
{
    partial class MaQL
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
            this.label1 = new System.Windows.Forms.Label();
            this.btXacNhan = new System.Windows.Forms.Button();
            this.txtMaXacNhan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin Vui Lòng Nhập Mã";
            // 
            // btXacNhan
            // 
            this.btXacNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btXacNhan.Location = new System.Drawing.Point(115, 116);
            this.btXacNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(100, 28);
            this.btXacNhan.TabIndex = 1;
            this.btXacNhan.Text = "Xác Nhận";
            this.btXacNhan.UseVisualStyleBackColor = true;
            // 
            // txtMaXacNhan
            // 
            this.txtMaXacNhan.Location = new System.Drawing.Point(73, 70);
            this.txtMaXacNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaXacNhan.Name = "txtMaXacNhan";
            this.txtMaXacNhan.PasswordChar = '*';
            this.txtMaXacNhan.Size = new System.Drawing.Size(175, 22);
            this.txtMaXacNhan.TabIndex = 2;
            // 
            // MaQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 171);
            this.Controls.Add(this.txtMaXacNhan);
            this.Controls.Add(this.btXacNhan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MaQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác Nhận";
            this.Load += new System.EventHandler(this.MaQL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btXacNhan;
        private System.Windows.Forms.TextBox txtMaXacNhan;
    }
}