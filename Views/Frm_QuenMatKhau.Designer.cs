namespace QL_CuaHangBanThuocTruSau.Views
{
    partial class Frm_QuenMatKhau
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlStep1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnIdentify = new Guna.UI2.WinForms.Guna2Button();
            this.txtIdentifier = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBackToLogin = new System.Windows.Forms.Label();
            this.pnlStep2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnVerify = new Guna.UI2.WinForms.Guna2Button();
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblResendOTP = new System.Windows.Forms.Label();
            this.pnlStep3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnlStep1.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.pnlStep3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel2.Location = new System.Drawing.Point(-1, -2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(472, 669);
            this.guna2Panel2.TabIndex = 5;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.Logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(31, 156);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(438, 320);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverState.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.delete_button2;
            this.btnExit.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.delete_button;
            this.btnExit.Location = new System.Drawing.Point(985, -2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(46, 46);
            this.btnExit.TabIndex = 6;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(504, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(450, 60);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Quên mật khẩu";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(504, 86);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(400, 30);
            this.lblSubTitle.TabIndex = 4;
            this.lblSubTitle.Text = "Vui lòng làm theo các bước";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSubTitle.Click += new System.EventHandler(this.lblSubTitle_Click);
            // 
            // pnlStep1
            // 
            this.pnlStep1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlStep1.BorderColor = System.Drawing.Color.Silver;
            this.pnlStep1.BorderRadius = 5;
            this.pnlStep1.BorderThickness = 1;
            this.pnlStep1.Controls.Add(this.btnIdentify);
            this.pnlStep1.Controls.Add(this.txtIdentifier);
            this.pnlStep1.Controls.Add(this.btnBackToLogin);
            this.pnlStep1.Location = new System.Drawing.Point(504, 154);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(490, 350);
            this.pnlStep1.TabIndex = 2;
            // 
            // btnIdentify
            // 
            this.btnIdentify.BorderRadius = 10;
            this.btnIdentify.FillColor = System.Drawing.Color.SteelBlue;
            this.btnIdentify.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnIdentify.ForeColor = System.Drawing.Color.White;
            this.btnIdentify.Location = new System.Drawing.Point(40, 160);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(410, 70);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "Tiếp tục";
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.BorderRadius = 10;
            this.txtIdentifier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentifier.DefaultText = "";
            this.txtIdentifier.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtIdentifier.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources.user;
            this.txtIdentifier.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtIdentifier.Location = new System.Drawing.Point(40, 60);
            this.txtIdentifier.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.PlaceholderText = "Email hoặc Tên tài khoản";
            this.txtIdentifier.SelectedText = "";
            this.txtIdentifier.Size = new System.Drawing.Size(410, 60);
            this.txtIdentifier.TabIndex = 0;
            // 
            // btnBackToLogin
            // 
            this.btnBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnBackToLogin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnBackToLogin.ForeColor = System.Drawing.Color.Gray;
            this.btnBackToLogin.Location = new System.Drawing.Point(160, 260);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(200, 30);
            this.btnBackToLogin.TabIndex = 2;
            this.btnBackToLogin.Text = "Quay lại đăng nhập";
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // pnlStep2
            // 
            this.pnlStep2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlStep2.BorderColor = System.Drawing.Color.Silver;
            this.pnlStep2.BorderRadius = 5;
            this.pnlStep2.BorderThickness = 1;
            this.pnlStep2.Controls.Add(this.btnVerify);
            this.pnlStep2.Controls.Add(this.txtOTP);
            this.pnlStep2.Controls.Add(this.lblResendOTP);
            this.pnlStep2.Location = new System.Drawing.Point(504, 214);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(490, 290);
            this.pnlStep2.TabIndex = 7;
            this.pnlStep2.Visible = false;
            // 
            // btnVerify
            // 
            this.btnVerify.BorderRadius = 10;
            this.btnVerify.FillColor = System.Drawing.Color.SteelBlue;
            this.btnVerify.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(40, 160);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(410, 70);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Xác nhận";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.BorderRadius = 10;
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtOTP.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources._lock;
            this.txtOTP.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtOTP.Location = new System.Drawing.Point(40, 60);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PlaceholderText = "Mã xác thực (6 số)";
            this.txtOTP.SelectedText = "";
            this.txtOTP.Size = new System.Drawing.Size(410, 60);
            this.txtOTP.TabIndex = 0;
            // 
            // lblResendOTP
            // 
            this.lblResendOTP.BackColor = System.Drawing.Color.Transparent;
            this.lblResendOTP.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblResendOTP.ForeColor = System.Drawing.Color.Gray;
            this.lblResendOTP.Location = new System.Drawing.Point(170, 260);
            this.lblResendOTP.Name = "lblResendOTP";
            this.lblResendOTP.Size = new System.Drawing.Size(95, 18);
            this.lblResendOTP.TabIndex = 2;
            this.lblResendOTP.Text = "Gửi lại mã (60s)";
            // 
            // pnlStep3
            // 
            this.pnlStep3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlStep3.BorderColor = System.Drawing.Color.Silver;
            this.pnlStep3.BorderRadius = 5;
            this.pnlStep3.BorderThickness = 1;
            this.pnlStep3.Controls.Add(this.btnReset);
            this.pnlStep3.Controls.Add(this.txtNewPassword);
            this.pnlStep3.Controls.Add(this.txtConfirmPassword);
            this.pnlStep3.Location = new System.Drawing.Point(504, 154);
            this.pnlStep3.Name = "pnlStep3";
            this.pnlStep3.Size = new System.Drawing.Size(490, 486);
            this.pnlStep3.TabIndex = 8;
            this.pnlStep3.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 10;
            this.btnReset.FillColor = System.Drawing.Color.SteelBlue;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(40, 344);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(410, 70);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Đặt lại mật khẩu";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderRadius = 10;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNewPassword.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources._lock;
            this.txtNewPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtNewPassword.Location = new System.Drawing.Point(40, 132);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Mật khẩu mới";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(410, 60);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 10;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtConfirmPassword.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources._lock;
            this.txtConfirmPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtConfirmPassword.Location = new System.Drawing.Point(40, 226);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Xác nhận mật khẩu";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(410, 60);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // Frm_QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 665);
            this.Controls.Add(this.pnlStep3);
            this.Controls.Add(this.pnlStep2);
            this.Controls.Add(this.pnlStep1);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.guna2Panel2);
            this.Font = new System.Drawing.Font("Tahoma", 10.19469F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_QuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnlStep1.ResumeLayout(false);
            this.pnlStep1.PerformLayout();
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.pnlStep3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlStep1;
        private Guna.UI2.WinForms.Guna2TextBox txtIdentifier;
        private Guna.UI2.WinForms.Guna2Button btnIdentify;
        private System.Windows.Forms.Label btnBackToLogin;
        private Guna.UI2.WinForms.Guna2Panel pnlStep2;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnVerify;
        private System.Windows.Forms.Label lblResendOTP;
        private Guna.UI2.WinForms.Guna2Panel pnlStep3;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2Button btnReset;
    }
}
