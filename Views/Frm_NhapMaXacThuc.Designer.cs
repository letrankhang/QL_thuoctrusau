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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnVerify = new Guna.UI2.WinForms.Guna2Button();
            this.lblResendOTP = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(438, 39);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(356, 56);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Xác thực mã";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(442, 92);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(444, 32);
            this.lblSubTitle.TabIndex = 6;
            this.lblSubTitle.Text = "Nhập mã xác thực đã được gửi đến Email";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVerify
            // 
            this.btnVerify.BorderRadius = 10;
            this.btnVerify.FillColor = System.Drawing.Color.SteelBlue;
            this.btnVerify.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(43, 178);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(387, 85);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Xác nhận";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblResendOTP
            // 
            this.lblResendOTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResendOTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblResendOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResendOTP.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblResendOTP.ForeColor = System.Drawing.Color.Gray;
            this.lblResendOTP.Location = new System.Drawing.Point(317, 107);
            this.lblResendOTP.Margin = new System.Windows.Forms.Padding(3);
            this.lblResendOTP.Name = "lblResendOTP";
            this.lblResendOTP.Size = new System.Drawing.Size(132, 24);
            this.lblResendOTP.TabIndex = 2;
            this.lblResendOTP.Text = "Gửi lại mã OTP";
            this.lblResendOTP.Click += new System.EventHandler(this.lblResendOTP_Click);
            this.lblResendOTP.MouseEnter += new System.EventHandler(this.lblResendOTP_MouseEnter);
            this.lblResendOTP.MouseLeave += new System.EventHandler(this.lblResendOTP_MouseLeave);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(400, 513);
            this.guna2Panel1.TabIndex = 7;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.White;
            this.guna2PictureBox1.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.Logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, -26);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(404, 542);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverState.FillColor = System.Drawing.Color.White;
            this.btnExit.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExit.HoverState.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.delete_button2;
            this.btnExit.Image = global::QL_CuaHangBanThuocTruSau.Properties.Resources.delete_button;
            this.btnExit.Location = new System.Drawing.Point(898, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(46, 53);
            this.btnExit.TabIndex = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.BorderRadius = 10;
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.FocusedState.BorderColor = System.Drawing.Color.SteelBlue;
            this.txtOTP.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtOTP.HoverState.BorderColor = System.Drawing.Color.SteelBlue;
            this.txtOTP.IconLeft = global::QL_CuaHangBanThuocTruSau.Properties.Resources.password;
            this.txtOTP.IconLeftOffset = new System.Drawing.Point(7, 0);
            this.txtOTP.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtOTP.Location = new System.Drawing.Point(43, 40);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(4);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PlaceholderText = "Mã xác thực (6 số)";
            this.txtOTP.SelectedText = "";
            this.txtOTP.Size = new System.Drawing.Size(387, 60);
            this.txtOTP.TabIndex = 0;
            this.txtOTP.TextChanged += new System.EventHandler(this.txtOTP_TextChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 5;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.btnVerify);
            this.guna2Panel2.Controls.Add(this.txtOTP);
            this.guna2Panel2.Controls.Add(this.lblResendOTP);
            this.guna2Panel2.Location = new System.Drawing.Point(437, 174);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(471, 302);
            this.guna2Panel2.TabIndex = 11;
            // 
            // Frm_NhapMaXacThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 513);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_NhapMaXacThuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu - Bước 2";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnVerify;
        private System.Windows.Forms.Label lblResendOTP;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}
