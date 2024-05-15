using System;
using System.Data;
using System.Windows.Forms;

namespace LoyltyApp
{
    public partial class LoginScreen : Form
    {
        #region variables 
        public static int g_rHandle, g_retCode;
        public static bool g_isConnected = false;
        public static byte g_Sec;
        public static byte[] g_pKey = new byte[6];
        ComboBox cbPort = new ComboBox();
        public LoginScreen() { InitializeComponent(); }

        //CLASS VARIABLES
        clsCommands sCommands = new clsCommands();
        clsFunctions sFunctions = new clsFunctions();
        clsVariables sVariables = new clsVariables();

        //INTEGER VARIABLES
        int iTips;
        int iAttempt;

        bool User = false;
        bool Recharge = false;
        bool Product = false;
        bool ProductDiscount = false;
        bool companyRpt = false;
        bool Purchase = false;
        bool AddCard = false;
        bool CheckPoints = false;
        bool CashtoPoint = false;
        bool ChanPassword = false;
        #endregion

        #region for load and activation
        private void LoginScreen_Activated(object sender, EventArgs e) 
        { 
            txtUsername.Focus();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            //Buttons
            cbPort.Items.Add("USB1");
            cbPort.SelectedIndex = 0;


        }
        #endregion

        #region cancel button
        private void bttnCancel_Click(object sender, EventArgs e) 
        {
            Close();
        }
        #endregion

        #region login button
        private void bttnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM UserPrivilege WHERE LoginId LIKE '" + txtUsername.Text + "' And Password LIKE '" + txtPassword.Text + "'", "tblusers");
                iTips = sVariables.sDataSet.Tables["tblUsers"].Rows.Count;
                if (iTips >= 1)
                {
                    string sSQL = "SELECT * FROM UserPrivilege WHERE LoginId LIKE '" + txtUsername.Text + "' ";

                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "UserPrivilege");
                    DataRow sDataRow = sVariables.sDataSet.Tables["UserPrivilege"].Rows[0];
                    clsVariables.sUsername = txtUsername.Text;
                    //clsVariables.sUserType = sDataRow["AdminType"].ToString();
                    clsVariables.sUserLogin = Convert.ToDateTime(DateTime.Now.ToString()).ToString("MMM dd, yy - hh:mm:ss ttttt");
                    clsVariables.boolConnected = true;
                    User = (bool)sDataRow["AddUser"];
                    Recharge = (bool)sDataRow["Recharge"];
                    Product = (bool)sDataRow["FoodMaster"];
                    companyRpt = (bool)sDataRow["companyRpt"];
                    Purchase = (bool)sDataRow["Purchase"];
                    AddCard = (bool)sDataRow["AddCard"];
                    ChanPassword = (bool)sDataRow["ChangePassword"];
                    FoodBeverage=(bool)sDataRow["Food&Beverage"];
                    Connect();
                    FrmMain f = new FrmMain();
                    f = (FrmMain)this.MdiParent;

                    if (User == true)
                    {
                        f.ChanPassword();
                    }
                    if (Recharge == true)
                    {
                        f.recharge();
                    }
                    if (Product == true)
                    {
                        f.AddProduct();
                    }
                    if (companyRpt == true)
                    {
                        f.companyRpt();
                    }
                    if (Purchase == true)
                    {
                        f.Purchase();
                    }
                    if (AddCard == true)
                    {
                        f.AddCard();
                    }
                    if (ChanPassword == true)
                    {
                        f.updateProfile();
                    }
                    if( ==true)
                    {

                    }
                    f.loginDisable();
                    Close();

                }
                else
                {
                    if (lblAttempt.Text == "1")
                    {
                        sFunctions.setMessageBox("You already used all the attempts.\nThis will terminate the application.", 3);
                        Close();
                    }
                    else
                    {
                        iAttempt = Convert.ToInt32(lblAttempt.Text) - 1;
                        lblAttempt.Text = iAttempt.ToString();
                        sFunctions.setMessageBox("Invalid Username/Password. Please try again.\n\nWarning: You only have " + lblAttempt.Text + " attempt.", 3);
                    }
                }
                //  }
                //  else
                //    MessageBox.Show("You are not authorise user");
                
            }
            catch(Exception exp){}
        }
        #endregion

        #region For Connect
        private void Connect()
        {

            //=====================================================================
            // This function opens the port(connection) to ACR120 reader
            //=====================================================================

            // Variable declarations
            int ctr = 0;
            byte[] FirmwareVer = new byte[31];
            byte[] FirmwareVer1 = new byte[20];
            byte infolen = 0x00;
            string FirmStr;
            ACR120U.tReaderStatus ReaderStat = new ACR120U.tReaderStatus();

            if (g_isConnected)
            {

                MessageBox.Show("Device is already connected.");
                return;

            }

            g_rHandle = ACR120U.ACR120_Open(0);
            if (g_rHandle != 0)

                MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_rHandle));

            else
            {

               // MessageBox.Show("Connected to USB" + string.Format("{0}", cbPort.SelectedIndex + 1));
                g_isConnected = true;

                //Get the DLL version the program is using
                g_retCode = ACR120U.ACR120_RequestDLLVersion(ref infolen, ref FirmwareVer[0]);
                if (g_retCode < 0)

                    MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));

                else
                {
                    FirmStr = "";
                    for (ctr = 0; ctr < Convert.ToInt16(infolen) - 1; ctr++)
                        FirmStr = FirmStr + char.ToString((char)(FirmwareVer[ctr]));
                    //  MessageBox.Show("DLL Version : " + FirmStr);
                }

                //Routine to get the firmware version.
                g_retCode = ACR120U.ACR120_Status(g_rHandle, ref FirmwareVer1[0], ref ReaderStat);
                if (g_retCode < 0)

                    MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));

                else
                {
                    FirmStr = "";
                    for (ctr = 0; ctr < Convert.ToInt16(infolen); ctr++)
                        if ((FirmwareVer1[ctr] != 0x00) && (FirmwareVer1[ctr] != 0xFF))
                            FirmStr = FirmStr + char.ToString((char)(FirmwareVer1[ctr]));
                    //    MessageBox.Show("Firmware Version : " + FirmStr);
                }

            }
        }
        #endregion

        #region for chkUnmask
        private void chkUnmask_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUnmask.Checked == true) { this.txtPassword.PasswordChar = Convert.ToChar(0); }
                else { this.txtPassword.PasswordChar = '•'; }
            }
            catch(Exception exp){}
        }
        #endregion
    
    }
}