using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;

namespace LoyltyApp
{
    public partial class Recharge : Form
    {
        #region For Recharge Card
        #region variable
        string lBalance;
        double lTotalBalance;
        private BindingSource bindingSource1 = new BindingSource();
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //OLEDB VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
         #endregion

        #region WriteVariables
        public static int g_rHandle, g_retCode;
        public static bool g_isConnected = false;
        public static byte g_Sec;
        public static byte[] g_pKey = new byte[6];
        string CardBalance, dstrpass1;
        
        #endregion

        #region initialization
        public Recharge()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        #endregion

        #region Select
        private void SelectCard()
        {
            //Variable Declarations
            byte[] ResultSN = new byte[11];
            byte ResultTag = 0x00;
            byte[] TagType = new byte[51];
            int ctr = 0;
            string SN = "";

            LoginScreen.g_retCode = ACR120U.ACR120_Select(LoginScreen.g_rHandle, ref TagType[0], ref ResultTag, ref ResultSN[0]);
            if (LoginScreen.g_retCode < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Reader Got Unplugged. Restart Your Application While Reader Connected.");
            }
            else
            {
                if ((TagType[0] == 4) || (TagType[0] == 5))
                {

                    SN = "";
                    for (ctr = 0; ctr < 7; ctr++)
                    {
                        SN = SN + string.Format("{0:X2} ", ResultSN[ctr]);
                    }

                }
                else
                {

                    SN = "";
                    for (ctr = 0; ctr < ResultTag; ctr++)
                    {
                        SN = SN + string.Format("{0:X2} ", ResultSN[ctr]);
                    }

                }
                //if (txtCardId.Text == "")
                //{
                txtCardId.Text = SN.Trim();
                //}
            }
        }
        #endregion

        #region RechargeButton
        private void btnRecharge_Click(object sender, EventArgs e)
        {
            try
            {
                lBalance = ReadBalance();
                lTotalBalance = Convert.ToDouble(lBalance) + Convert.ToDouble(txtRechargeAmount.Text);
                WriteBalance();
                double total = Convert.ToDouble(lblBalance.Text) + Convert.ToDouble(txtRechargeAmount.Text);
                lblBalance.Text = total.ToString();

                //save in Database
                sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                sOleDbCommand.CommandText = "update CustomerCard set AvailableBalance = @AvailableBalance where Cardid = '" + txtCardId.Text.Trim() + "'";
                sOleDbCommand.Parameters.Add("@AvailableBalance", SqlDbType.VarChar, 10);

                sOleDbCommand.Parameters["@AvailableBalance"].Value = lblBalance.Text.Trim();
                sFunctions.setOledbConnCommand_Close(sOleDbCommand);


                //Save Recharge Details
                sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                sOleDbCommand.CommandText = "INSERT INTO RechargeDetails([Cardid],[RechAmount],[RechDate]) values (@Cardid,@RechAmount,@RechDate)";

                sOleDbCommand.Parameters.Add("@Cardid", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@RechAmount", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@RechDate", SqlDbType.Date);

                sOleDbCommand.Parameters["@Cardid"].Value = txtCardId.Text.Trim();
                sOleDbCommand.Parameters["@RechAmount"].Value = txtRechargeAmount.Text.Trim();
                sOleDbCommand.Parameters["@RechDate"].Value = DateTime.Now.Date;

                sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                sFunctions.setMessageBox("Recharge Amount has been successfully saved.", 1);
                txtRechargeAmount.Text = "";
                txtCardId.Text = "";
            }
            catch(Exception exp){}
        }
        #endregion

        #region WriteBalance
        private void WriteBalance()
        {
            // write balance
            long sto = 0;
            byte vKeyType = 0x00;
            int PhysicalSector = 0;
            int ctr, tmpInt = 0;
            byte Blck2 = 1;
            byte[] dout = new byte[16];
            char[] charArray1 = new char[16];

            #region Write for Sector 0
            vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_A;
            //vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_STORED_A;
            g_Sec = 0;
            PhysicalSector = Convert.ToInt16(g_Sec);
            tmpInt = Convert.ToInt16(Blck2);
            sto = 30;
            for (ctr = 0; ctr < 6; ctr++)
                g_pKey[ctr] = 0xFF;
            g_retCode = ACR120U.ACR120_Login(g_rHandle, Convert.ToByte(PhysicalSector), Convert.ToInt16(vKeyType),
                                         Convert.ToByte(sto), ref g_pKey[0]);
            if (g_retCode < 0)

                MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));

            tmpInt = tmpInt + Convert.ToInt16(g_Sec) * 4;
            Blck2 = Convert.ToByte(tmpInt);

            charArray1 = lTotalBalance.ToString().ToCharArray();

            for (ctr = 0; ctr < 16; ctr++)
            {
                if (ctr < charArray1.Length)
                    dout[ctr] = Convert.ToByte(charArray1[ctr]);
                else
                    ctr = 16;
            }

            g_retCode = ACR120U.ACR120_Write(g_rHandle, Blck2, ref dout[0]);

            if (g_retCode < 0)
            MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));
            #endregion
        }
        #endregion

        #region ReadBalance
        private string ReadBalance()
        {
            byte[] PassRead = new byte[16];
            byte Blck2 = 1;
            long sto = 0;
            byte vKeyType = 0x00;
            int PhysicalSector = 0;
            int ctr, tmpInt2 = 2;


            vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_A;
            //vKeyType1 = ACR120U.ACR120_LOGIN_KEYTYPE_STORED_A;
            g_Sec = 0;
            PhysicalSector = Convert.ToInt16(g_Sec);
            tmpInt2 = Convert.ToInt16(Blck2);
            sto = 30;
            for (ctr = 0; ctr < 6; ctr++)
                g_pKey[ctr] = 0xFF;
            g_retCode = ACR120U.ACR120_Login(g_rHandle, Convert.ToByte(PhysicalSector), Convert.ToInt16(vKeyType),
                                             Convert.ToByte(sto), ref g_pKey[0]);
            if (g_retCode < 0)
                MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));
            tmpInt2 = tmpInt2 + Convert.ToInt16(g_Sec) * 4;

            Blck2 = Convert.ToByte(tmpInt2);

            g_retCode = ACR120U.ACR120_Read(g_rHandle, Blck2, ref PassRead[0]);
            if (g_retCode < 0)
                MessageBox.Show("[X] " + ACR120U.GetErrMsg(g_retCode));
            else
            {
                dstrpass1 = "";
                for (ctr = 0; ctr < 16; ctr++)
                {
                    dstrpass1 = dstrpass1 + char.ToString((char)(PassRead[ctr]));
                }
                CardBalance = Convert.ToString(dstrpass1);
                if (CardBalance == "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                    CardBalance = "0";
            }
            return CardBalance;
        }
        #endregion

        #region timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SelectCard();
                lblBalance.Text = ReadBalance();
                PopulateOtherDetails();
            }
            catch(Exception exp){}
        }
        #endregion

        #region Populateotherdetails
        private void PopulateOtherDetails()
        {

            lblCustomerName.Text = "";
            lblMobileNo.Text = "";
            lblEmailAdd.Text = "";
            lblAddress.Text = "";
            picBoxUImage.Image = null;

            try
            {
                string sqlString = "SELECT * FROM CustomerCard WHERE Cardid='" + txtCardId.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString, "CustomerCard");
                DataTable dtTable = sVariables.sDataSet.Tables["CustomerCard"];

                lblCustomerName.Text = Convert.ToString(dtTable.Rows[0]["CustomerName"]);
                lblMobileNo.Text = Convert.ToString(dtTable.Rows[0]["ContactNo"]);
                lblEmailAdd.Text = Convert.ToString(dtTable.Rows[0]["Email"]);
                lblAddress.Text = Convert.ToString(dtTable.Rows[0]["Address"]);
                picBoxUImage.Image = Image.FromStream(new MemoryStream((byte[])(dtTable.Rows[0]["UImage"])));
            }
            catch (Exception ex)
            { }

        }
        #endregion
        #endregion

    }
   
}
