using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoyltyApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region MainForm Load
        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;

           // Call the method that changes the background color.
            SetBackGroundColorOfMDIForm();
            disableMenu();
            LoginScreen llogin = new LoginScreen();
            llogin.MdiParent = this;
            llogin.Show();
        }
        #endregion

        #region Background
        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackgroundImage =System.Drawing.Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Picture.jpg");
                }
            }
        #endregion
        }

        private Form lastForm;

        private void showForm(Form frm)
        {
            frm.FormClosed += (sender, ea) =>
            {
                if (object.ReferenceEquals(lastForm, sender)) lastForm = null;
            };
            frm.MdiParent = this;
            frm.Show();
            if (lastForm != null) lastForm.Close();
            lastForm = frm;
        }

        #region enableMenu
        
        public void recharge()
        {
            RechargetoolStripMenuItem1.Enabled = true;
        }

        public void AddProduct()
        {
            FoodMastertoolStripMenuItem1.Enabled = true;
        }

        public void companyRpt()
        {
            companyReportToolStripMenuItem.Enabled=true;
            customerReportToolStripMenuItem.Enabled = true;
        }

        public void Purchase()
        {
            costumesToolStripMenuItem.Enabled=true;
        }

        public void AddCard()
        {
            cardIssueDetailsToolStripMenuItem.Enabled = true;
        }

        public void ChanPassword()
        {
            AdminToolStripMenuItem.Enabled = true;
        }
        public void updateProfile()
        {
            ProfileToolStripMenuItem.Enabled = true;
        }
        #endregion

        #region disableMenu
        public void disableMenu()
        {
            AdminToolStripMenuItem.Enabled = false;
            ProfileToolStripMenuItem.Enabled = false;
            cardIssueDetailsToolStripMenuItem.Enabled = false;
            RechargetoolStripMenuItem1.Enabled = false;
            companyReportToolStripMenuItem.Enabled = false;
            costumesToolStripMenuItem.Enabled = false;
            customerReportToolStripMenuItem.Enabled = false;
            //Costume_MasterToolStripMenuItem.Enabled = false;
            //FoodBeverageToolStripMenuItem.Enabled = false;
            //monorailZiplinesToolStripMenuItem.Enabled = false;
            FoodMastertoolStripMenuItem1.Enabled = false;
            //loginToolStripMenuItem.Enabled = false;
        }

        public void loginDisable()
        {
            loginToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Text = "";
        }
        #endregion

        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Update_Profile());
        }

        private void calculateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Costumes());
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Admin());
        }

        private void cardIssueDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new AddDisplayCard());
        }

        private void RechargetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showForm(new Recharge());
        }

        private void ProductMastertoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showForm(new Add_Product());
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Customer_Report());
        }

        private void companyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Company_Report());
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new LoginScreen());
        }

        private void foodBevarageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new FoodBeverage());
        }

        private void monorailZiplinesToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            showForm(new Monozip());
        }

        private void FoodBeverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(new Costume_Master());
        }
    }
}
