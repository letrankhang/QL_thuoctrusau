namespace QL_CuaHangBanThuocTruSau.Views
{
    partial class Frm_NhapMaXacThuc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnVerify = new Guna.UI2.WinForms.Guna2Button();
            this.lblResendOTP = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.delete_button;
            this.btnExit.Location = new System.Drawing.Point(1012, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(51, 56);
            this.btnExit.TabIndex = 4;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(495, 58);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 41);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Xác thực mã";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(495, 135);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(500, 40);
            this.lblSubTitle.TabIndex = 6;
            this.lblSubTitle.Text = "Nhập mã xác thực đã được gửi tới Email";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOTP
            // 
            this.txtOTP.BorderRadius = 10;
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtOTP.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources._lock;
            this.txtOTP.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtOTP.Location = new System.Drawing.Point(495, 236);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PlaceholderText = "Mã xác thực (6 số)";
            this.txtOTP.SelectedText = "";
            this.txtOTP.Size = new System.Drawing.Size(518, 75);
            this.txtOTP.TabIndex = 0;
            // 
            // btnVerify
            // 
            this.btnVerify.BorderRadius = 10;
            this.btnVerify.FillColor = System.Drawing.Color.SteelBlue;
            this.btnVerify.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(495, 380);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(518, 88);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Xác nhận";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblResendOTP
            // 
            this.lblResendOTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResendOTP.BackColor = System.Drawing.Color.Transparent;
            this.lblResendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResendOTP.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblResendOTP.ForeColor = System.Drawing.Color.Gray;
            this.lblResendOTP.Location = new System.Drawing.Point(712, 507);
            this.lblResendOTP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblResendOTP.Name = "lblResendOTP";
            this.lblResendOTP.Size = new System.Drawing.Size(150, 29);
            this.lblResendOTP.TabIndex = 2;
            this.lblResendOTP.Text = "Gửi lại mã OTP";
            this.lblResendOTP.Click += new System.EventHandler(this.lblResendOTP_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(450, 625);
            this.guna2Panel1.TabIndex = 7;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.Logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 13);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(447, 608);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Frm_NhapMaXacThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1047, 625);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblResendOTP);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_NhapMaXacThuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu - Bước 2";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnVerify;
        private System.Windows.Forms.Label lblResendOTP;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
