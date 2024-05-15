namespace LoyltyApp
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoodBeverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costumesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoodMastertoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CostumeMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monorailZiplinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardIssueDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RechargetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.companyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminToolStripMenuItem,
            this.CostumeMasterToolStripMenuItem,
            this.costumesToolStripMenuItem,
            this.FoodMastertoolStripMenuItem1,
            this.FoodBeverageToolStripMenuItem,
            this.monorailZiplinesToolStripMenuItem,
            this.cardIssueDetailsToolStripMenuItem,
            this.RechargetoolStripMenuItem1,
            this.companyReportToolStripMenuItem,
            this.customerReportToolStripMenuItem,
            this.ProfileToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1294, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AdminToolStripMenuItem
            // 
            this.AdminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem";
            this.AdminToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.AdminToolStripMenuItem.Text = "Admin";
            this.AdminToolStripMenuItem.Click += new System.EventHandler(this.AdminToolStripMenuItem_Click);
            // 
            // FoodBeverageToolStripMenuItem
            // 
            this.FoodBeverageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FoodBeverageToolStripMenuItem.Name = "FoodBeverageToolStripMenuItem";
            this.FoodBeverageToolStripMenuItem.Size = new System.Drawing.Size(113, 23);
            this.FoodBeverageToolStripMenuItem.Text = "Food&Beverage";
            // 
            // costumesToolStripMenuItem
            // 
            this.costumesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.costumesToolStripMenuItem.Name = "costumesToolStripMenuItem";
            this.costumesToolStripMenuItem.Size = new System.Drawing.Size(85, 23);
            this.costumesToolStripMenuItem.Text = "Costumes";
            this.costumesToolStripMenuItem.Click += new System.EventHandler(this.calculateBillToolStripMenuItem_Click);
            // 
            // FoodMastertoolStripMenuItem1
            // 
            this.FoodMastertoolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.FoodMastertoolStripMenuItem1.Name = "FoodMastertoolStripMenuItem1";
            this.FoodMastertoolStripMenuItem1.Size = new System.Drawing.Size(102, 23);
            this.FoodMastertoolStripMenuItem1.Text = "Food Master";
            this.FoodMastertoolStripMenuItem1.Click += new System.EventHandler(this.ProductMastertoolStripMenuItem1_Click);
            // 
            // CostumeMasterToolStripMenuItem
            // 
            this.CostumeMasterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CostumeMasterToolStripMenuItem.Name = "CostumeMasterToolStripMenuItem";
            this.CostumeMasterToolStripMenuItem.Size = new System.Drawing.Size(128, 23);
            this.CostumeMasterToolStripMenuItem.Text = "Costume Master";
            this.CostumeMasterToolStripMenuItem.Click += new System.EventHandler(this.foodBevarageToolStripMenuItem_Click);
            // 
            // monorailZiplinesToolStripMenuItem
            // 
            this.monorailZiplinesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.monorailZiplinesToolStripMenuItem.Name = "monorailZiplinesToolStripMenuItem";
            this.monorailZiplinesToolStripMenuItem.Size = new System.Drawing.Size(136, 23);
            this.monorailZiplinesToolStripMenuItem.Text = "Monorail/Ziplines";
            this.monorailZiplinesToolStripMenuItem.Click += new System.EventHandler(this.monorailZiplinesToolStripMenuItem_Click);
            // 
            // cardIssueDetailsToolStripMenuItem
            // 
            this.cardIssueDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cardIssueDetailsToolStripMenuItem.Name = "cardIssueDetailsToolStripMenuItem";
            this.cardIssueDetailsToolStripMenuItem.Size = new System.Drawing.Size(134, 23);
            this.cardIssueDetailsToolStripMenuItem.Text = "Add/Display Card";
            this.cardIssueDetailsToolStripMenuItem.Click += new System.EventHandler(this.cardIssueDetailsToolStripMenuItem_Click);
            // 
            // RechargetoolStripMenuItem1
            // 
            this.RechargetoolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.RechargetoolStripMenuItem1.Name = "RechargetoolStripMenuItem1";
            this.RechargetoolStripMenuItem1.Size = new System.Drawing.Size(116, 23);
            this.RechargetoolStripMenuItem1.Text = "Recharge Card";
            this.RechargetoolStripMenuItem1.Click += new System.EventHandler(this.RechargetoolStripMenuItem1_Click);
            // 
            // companyReportToolStripMenuItem
            // 
            this.companyReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.companyReportToolStripMenuItem.Name = "companyReportToolStripMenuItem";
            this.companyReportToolStripMenuItem.Size = new System.Drawing.Size(128, 23);
            this.companyReportToolStripMenuItem.Text = "Company Report";
            this.companyReportToolStripMenuItem.Click += new System.EventHandler(this.companyReportToolStripMenuItem_Click);
            // 
            // customerReportToolStripMenuItem
            // 
            this.customerReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.customerReportToolStripMenuItem.Name = "customerReportToolStripMenuItem";
            this.customerReportToolStripMenuItem.Size = new System.Drawing.Size(130, 23);
            this.customerReportToolStripMenuItem.Text = "Customer Report";
            this.customerReportToolStripMenuItem.Click += new System.EventHandler(this.customerReportToolStripMenuItem_Click);
            // 
            // ProfileToolStripMenuItem
            // 
            this.ProfileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            this.ProfileToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.ProfileToolStripMenuItem.Text = "Profile";
            this.ProfileToolStripMenuItem.Click += new System.EventHandler(this.ProfileToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1294, 722);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loyalty Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costumesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardIssueDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RechargetoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FoodMastertoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CostumeMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monorailZiplinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FoodBeverageToolStripMenuItem;
    }
}

