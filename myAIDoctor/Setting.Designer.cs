namespace myAIDoctor
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.runOpen = new System.Windows.Forms.CheckBox();
            this.autoOpenWindow = new System.Windows.Forms.CheckBox();
            this.channel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoLogin = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // runOpen
            // 
            this.runOpen.AutoSize = true;
            this.runOpen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runOpen.Location = new System.Drawing.Point(22, 52);
            this.runOpen.Name = "runOpen";
            this.runOpen.Size = new System.Drawing.Size(75, 21);
            this.runOpen.TabIndex = 0;
            this.runOpen.Text = "开机启动";
            this.runOpen.UseVisualStyleBackColor = true;
            // 
            // autoOpenWindow
            // 
            this.autoOpenWindow.AutoSize = true;
            this.autoOpenWindow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoOpenWindow.Location = new System.Drawing.Point(121, 52);
            this.autoOpenWindow.Name = "autoOpenWindow";
            this.autoOpenWindow.Size = new System.Drawing.Size(75, 21);
            this.autoOpenWindow.TabIndex = 0;
            this.autoOpenWindow.Text = "自动弹出";
            this.autoOpenWindow.UseVisualStyleBackColor = true;
            // 
            // channel
            // 
            this.channel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.channel.Location = new System.Drawing.Point(92, 91);
            this.channel.Name = "channel";
            this.channel.Size = new System.Drawing.Size(50, 23);
            this.channel.TabIndex = 1;
            this.channel.Text = "取消";
            this.channel.UseVisualStyleBackColor = true;
            this.channel.Click += new System.EventHandler(this.Channel_Click);
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(167, 91);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(44, 23);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 35);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "设置";
            // 
            // autoLogin
            // 
            this.autoLogin.AutoSize = true;
            this.autoLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoLogin.Location = new System.Drawing.Point(217, 52);
            this.autoLogin.Name = "autoLogin";
            this.autoLogin.Size = new System.Drawing.Size(75, 21);
            this.autoLogin.TabIndex = 3;
            this.autoLogin.Text = "自动登录";
            this.autoLogin.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(308, 135);
            this.Controls.Add(this.autoLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.channel);
            this.Controls.Add(this.autoOpenWindow);
            this.Controls.Add(this.runOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Setting";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox runOpen;
        private System.Windows.Forms.CheckBox autoOpenWindow;
        private System.Windows.Forms.Button channel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox autoLogin;
    }
}