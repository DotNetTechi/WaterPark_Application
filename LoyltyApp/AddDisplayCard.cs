using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LoyltyApp
{
    public partial class AddDisplayCard : Form
    {
        #region for variable and initilaization
        private BindingSource bindingSource1 = new BindingSource();
        byte[] photo_aray;
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //Sql VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
        DataTable dtTable;
        //ReadBalance
        string lBalance;
        double lTotalBalance;
        public static int g_rHandle, g_retCode;
        public static bool g_isConnected = false;
        public static byte g_Sec;
        public static byte[] g_pKey = new byte[6];
        string CardBalance, dstrpass1;
        string CardPoints, dstrpass2;
        #endregion

        public AddDisplayCard()
        {
            InitializeComponent();
            timerAddCard.Enabled = true;

        }


        #region AddCard
        #region Select
        private void SelectCard()
        {

            //=====================================================================
            // This function selects a single card in range and return the Serial No.
            //=====================================================================

            //Variable Declarations
            byte[] ResultSN = new byte[11];
            byte ResultTag = 0x00;
            byte[] TagType = new byte[51];
            int ctr = 0;
            string SN = "";


            //Select specific card based from serial number	
            LoginScreen.g_retCode = ACR120U.ACR120_Select(LoginScreen.g_rHandle, ref TagType[0], ref ResultTag, ref ResultSN[0]);
            if (LoginScreen.g_retCode < 0)
            {
                timerAddCard.Enabled = false;
                MessageBox.Show("Reader Got Unplugged. Restart Your Application While Reader Connected.");
            }
            else
            {
                //  MessageBox.Show("Select Success");
                //get serial number and convert to hex

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

                //Display Serial Number
                // MessageBox.Show("( i ) Card Serial Number: " + SN + " ( " + ACR120U.GetTagType1(TagType[0]) + " )");
                comvendor.Text = SN.Trim();
            }
        }
        #endregion

        #region LOAD
        private void CardIssueForVendor_Load(object sender, EventArgs e)
        {
            ProductItem();
            tabControl1.TabPages.Remove(DisplayPoints);
        }
        #endregion

        #region LOAD METHOD FUNCTION
        private void ProductItem()
        {
            string sSQL = "SELECT Cardid,CustomerCode,CustomerName,Address,ContactNo,Email,DateOfSubscription,UImage FROM CustomerCard";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "CustomerCard");
            dtTable = sVariables.sDataSet.Tables["CustomerCard"];
            bindingSource1.DataSource = dtTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
        }
        #endregion

        #region issue card button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = comvendor.Text.Trim();
                if (picBox.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picBox.Image.Save(ms, ImageFormat.Jpeg);
                    photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);
                }

                if (comvendor.Text == "")
                {
                    sFunctions.setEmptyField("Card ID");
                    comvendor.Focus();
                }
                else if (ccode.Text == "")
                {
                    sFunctions.setEmptyField("Customer Code");
                    ccode.Focus();
                }
                else if (button1.Text == "Issue Card")
                {
                    try
                    {
                        sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT Cardid,CustomerCode,CustomerName,Address,ContactNo,Email,DateOfSubscription FROM CustomerCard WHERE Cardid = '" + str + "'", "CustomerCard");
                        int iTipsMember = sVariables.sDataSet.Tables["CustomerCard"].Rows.Count;
                        if (iTipsMember <= 0)
                        {
                            sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT Cardid,CustomerCode,CustomerName,Address,ContactNo,Email,DateOfSubscription FROM CustomerCard WHERE CardID = '" + str + "'", "CustomerCard");
                            int iTips = sVariables.sDataSet.Tables["CustomerCard"].Rows.Count;
                            if (iTips <= 0)
                            {
                                sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                                sOleDbCommand.CommandText = "INSERT INTO CustomerCard(Cardid,CustomerCode,CustomerName,Address,ContactNo,Email,DateOfSubscription,Points,AvailableBalance,UImage) values (@Cardid,@CustomerCode,@CustomerName,@Address,@ContactNo,@Email,@DateOfSubscription,@Points,@AvailableBalance,@UImage)";

                                sOleDbCommand.Parameters.Add("@Cardid", SqlDbType.VarChar, 12);
                                sOleDbCommand.Parameters.Add("@CustomerCode", SqlDbType.VarChar, 20);
                                sOleDbCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar, 30);
                                sOleDbCommand.Parameters.Add("@Address", SqlDbType.VarChar, 50);
                                sOleDbCommand.Parameters.Add("@ContactNo", SqlDbType.VarChar, 20);
                                sOleDbCommand.Parameters.Add("@Email", SqlDbType.VarChar, 30);
                                sOleDbCommand.Parameters.Add("@DateOfSubscription", SqlDbType.Date);
                                sOleDbCommand.Parameters.Add("@Points", SqlDbType.VarChar, 10);
                                sOleDbCommand.Parameters.Add("@AvailableBalance", SqlDbType.VarChar, 10);
                                sOleDbCommand.Parameters.Add("@UImage", SqlDbType.VarBinary);

                                sOleDbCommand.Parameters["@Cardid"].Value = comvendor.Text.Trim();
                                sOleDbCommand.Parameters["@CustomerCode"].Value = ccode.Text.Trim();
                                sOleDbCommand.Parameters["@CustomerName"].Value = name.Text.Trim();
                                sOleDbCommand.Parameters["@Address"].Value = address.Text.Trim();
                                sOleDbCommand.Parameters["@ContactNo"].Value = number.Text.Trim();
                                sOleDbCommand.Parameters["@Email"].Value = mail.Text.Trim();
                                sOleDbCommand.Parameters["@DateOfSubscription"].Value = date.Value.ToShortDateString();
                                sOleDbCommand.Parameters["@Points"].Value = "0";
                                sOleDbCommand.Parameters["@AvailableBalance"].Value = "0";
                                //sOleDbCommand.Parameters["@UImage"].Value = photo_aray;

                                sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                                sFunctions.setMessageBox("Record has been successfully added.", 1);
                                ProductItem();
                                comvendor.Text = "";
                                ccode.Clear();
                                name.Clear();
                                address.Clear();
                                mail.Clear();
                                number.Clear();

                                comvendor.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Card No has Already Exists");
                                ProductItem();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Card No has Already Exists");
                            ProductItem();
                        }
                    }
                    catch (Exception ex) { sFunctions.setCreateError(ex.Message, AppDomain.CurrentDomain.BaseDirectory + "\\Errors\\", Convert.ToDateTime(DateTime.Now.ToString()).ToString("MMM dd, yy - hh-mm-ss ttttt")); }
                }
                else if (button1.Text == "Update")
                {
                    sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                    sOleDbCommand.CommandText = "update CustomerCard set Cardid=@Cardid,CustomerCode=@CustomerCode,CustomerName=@CustomerName,Address=@Address,ContactNo=@ContactNo,Email=@Email,DateOfSubscription=@DateOfSubscription,UImage=@UImage where Cardid ='" + str + "'";



                    sOleDbCommand.Parameters.Add("@Cardid", SqlDbType.VarChar, 15);
                    sOleDbCommand.Parameters.Add("@CustomerCode", SqlDbType.VarChar, 15);
                    sOleDbCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@Address", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@DateOfSubscription", SqlDbType.Date);
                    sOleDbCommand.Parameters.Add("@UImage", SqlDbType.VarBinary);

                    sOleDbCommand.Parameters["@Cardid"].Value = comvendor.Text.Trim();
                    sOleDbCommand.Parameters["@CustomerCode"].Value = ccode.Text.Trim();
                    sOleDbCommand.Parameters["@CustomerName"].Value = name.Text.Trim();
                    sOleDbCommand.Parameters["@Address"].Value = address.Text.Trim();
                    sOleDbCommand.Parameters["@ContactNo"].Value = number.Text.Trim();
                    sOleDbCommand.Parameters["@Email"].Value = mail.Text.Trim();
                    sOleDbCommand.Parameters["@DateOfSubscription"].Value = date.Value.ToShortDateString();
                    //sOleDbCommand.Parameters["@UImage"].Value = photo_aray;

                    sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                    sFunctions.setMessageBox("Record has been successfully saved.", 1);
                    ccode.Text = "";
                    comvendor.Text = "";
                    address.Clear();
                    number.Clear();
                    mail.Clear();
                    name.Clear();
                    comvendor.Focus();

                    button1.Text = "Issue Card";
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region datagrid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strCellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (strCellValue != "" && strCellValue != null)
                {
                    comvendor.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ccode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    name.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    address.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    number.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    mail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    date.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                    picBox.Image = Image.FromStream(new MemoryStream((byte[])(dataGridView1.Rows[e.RowIndex].Cells[7].Value)));

                    button1.Text = "Update";
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region UploadImage
        //private void btnUpload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
        //        DialogResult res = openFileDialog1.ShowDialog();
        //        if (res == DialogResult.OK)
        //        {
        //            picBox.Image = Image.FromFile(openFileDialog1.FileName);
        //        }
        //    }
        //    catch(Exception exp){}
        //}
        #endregion


        #endregion

        #region DisplayPoints
        #region Populateotherdetails
        private void PopulateOtherDetails()
        {

            label10.Text = "";
            label1.Text = "";
            label17.Text = "";
            lblMobileNo.Text = "";
            lblEmailAdd.Text = "";
            lblAddress.Text = "";
            lblDateOfSub.Text = "";
            picBoxUImage.Image = null;

            try
            {
                string sqlString = "SELECT * FROM CustomerCard WHERE Cardid='" + label14.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString, "CustomerCard");
                DataTable dtTable = sVariables.sDataSet.Tables["CustomerCard"];

                label10.Text = Convert.ToString(dtTable.Rows[0]["CustomerCode"]);
                label17.Text = Convert.ToString(dtTable.Rows[0]["CustomerName"]);
                label1.Text = Convert.ToString(dtTable.Rows[0]["Points"]);
                lblMobileNo.Text = Convert.ToString(dtTable.Rows[0]["ContactNo"]);
                lblEmailAdd.Text = Convert.ToString(dtTable.Rows[0]["Email"]);
                lblAddress.Text = Convert.ToString(dtTable.Rows[0]["Address"]);
                lblDateOfSub.Text = Convert.ToString(dtTable.Rows[0]["DateOfSubscription"]);
                picBoxUImage.Image = Image.FromStream(new MemoryStream((byte[])(dtTable.Rows[0]["UImage"])));
            }
            catch (Exception ex)
            { }

        }
        #endregion

        #region TimerTick
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SelectCardID();
                PopulateOtherDetails();
                lblBalanceAmt.Text = ReadBalance();
                label1.Text = ReadPoints();
            }
            catch (Exception exp) { }
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

        #region ReadPoints
        private string ReadPoints()
        {
            byte[] PassRead = new byte[16];
            byte Blck2 = 1;
            long sto = 0;
            byte vKeyType = 0x00;
            int PhysicalSector = 0;
            int ctr, tmpInt2 = 2;


            vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_A;
            //vKeyType1 = ACR120U.ACR120_LOGIN_KEYTYPE_STORED_A;
            g_Sec = 2;
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
                dstrpass2 = "";
                for (ctr = 0; ctr < 16; ctr++)
                {
                    dstrpass2 = dstrpass2 + char.ToString((char)(PassRead[ctr]));
                }
                CardPoints = Convert.ToString(dstrpass2);
                if (CardPoints == "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                    CardPoints = "0";
            }
            return CardPoints;
        }

        private void DisplayPoints_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Select
        private void SelectCardID()
        {

            //=====================================================================
            // This function selects a single card in range and return the Serial No.
            //=====================================================================

            //Variable Declarations
            byte[] ResultSN = new byte[11];
            byte ResultTag = 0x00;
            byte[] TagType = new byte[51];
            int ctr = 0;
            string SN = "";


            //Select specific card based from serial number	
            LoginScreen.g_retCode = ACR120U.ACR120_Select(LoginScreen.g_rHandle, ref TagType[0], ref ResultTag, ref ResultSN[0]);
            if (LoginScreen.g_retCode < 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Reader Got Unplugged. Restart Your Application While Reader Connected.");
            }
            else
            {
                //  MessageBox.Show("Select Success");
                //get serial number and convert to hex

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

                //Display Serial Number
                // MessageBox.Show("( i ) Card Serial Number: " + SN + " ( " + ACR120U.GetTagType1(TagType[0]) + " )");
                label14.Text = SN.Trim();
            }
        }
        #endregion

        #region Tab Index Changed
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["AddCard"])
                {
                    timer1.Enabled = false;
                    timerAddCard.Enabled = true;
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["DisplayPoints"])
                {
                    timerAddCard.Enabled = false;
                    timer1.Enabled = true;
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #endregion

        #region Timer Tick
        private void timerAddCard_Tick(object sender, EventArgs e)
        {
            if (comvendor.Text == "")
            {
                ccode.Clear();
                address.Clear();
                number.Clear();
                mail.Clear();
                name.Clear();
                SelectCard();
            }
        }
        #endregion
    }
}
