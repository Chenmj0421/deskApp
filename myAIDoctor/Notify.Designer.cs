namespace myAIDoctor
{
    partial class Notify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notify));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.myMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mentSwitchUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mentSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mentQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.myMenu;
            this.notifyIcon1.Text = "认识医生";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mentSwitchUser,
            this.mentSetting,
            this.mentQuit});
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // mentSwitchUser
            // 
            this.mentSwitchUser.Name = "mentSwitchUser";
            this.mentSwitchUser.Size = new System.Drawing.Size(124, 22);
            this.mentSwitchUser.Text = "切换账号";
            this.mentSwitchUser.Click += new System.EventHandler(this.MentSwitchUser_Click);
            // 
            // mentSetting
            // 
            this.mentSetting.Image = ((System.Drawing.Image)(resources.GetObject("mentSetting.Image")));
            this.mentSetting.Name = "mentSetting";
            this.mentSetting.Size = new System.Drawing.Size(124, 22);
            this.mentSetting.Text = "设置";
            this.mentSetting.Click += new System.EventHandler(this.MenuSetting_Click);
            // 
            // mentQuit
            // 
            this.mentQuit.Image = ((System.Drawing.Image)(resources.GetObject("mentQuit.Image")));
            this.mentQuit.Name = "mentQuit";
            this.mentQuit.Size = new System.Drawing.Size(124, 22);
            this.mentQuit.Text = "退出";
            this.mentQuit.Click += new System.EventHandler(this.MenuQuit_Click);
            // 
            // Notify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 250);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "认识医生";
            this.Load += new System.EventHandler(this.Notify_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Notify_MouseDown);
            this.myMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem mentSetting;
        private System.Windows.Forms.ToolStripMenuItem mentQuit;
        private System.Windows.Forms.ToolStripMenuItem mentSwitchUser;
    }
}

