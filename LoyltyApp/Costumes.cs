using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;


namespace LoyltyApp
{
    public partial class Costumes : Form
    {
        #region Variable declaration
        private BindingSource bindingSource1 = new BindingSource();
        DataTable dtTable1;
        DataTable dtTable;

        DataTable dtTable2;
        DataTable dtTable3;
        DataTable dtTable4;
        DataTable dtTable5;
        DataTable dtTable6;

        DataTable table = new DataTable();
        int a = 0, b = 0, c = 0;
        int z = 0;
        int d = 0;
        decimal sum = 0, sum1 = 0, sum2 = 0;
        double lLeftBalance;
        double cPoints;
        int lHeight, lWidth;
        int pHeight, pWidth;
        string ProdBtnName;

        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //Sql VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
        clsConnections sConnections = new clsConnections();
        
        //Variables
        public static int g_rHandle, g_retCode;
        public static bool g_isConnected = false;
        public static byte g_Sec;
        public static byte[] g_pKey = new byte[6];
        string dstrpass, dstrpass1;

        #region Print Variables
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        #endregion
        #endregion

        #region intialization
        public Costumes()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        #endregion

        #region load 
        private void billing_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCategory();

                listBox1.Items.Add("YES");
                listBox1.Items.Add("NO");
                listBox1.SelectedItem = "YES";
                pnlRedeemPointsPopUp.Visible = false;
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Select Offer
        private void oname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mrp.Text = "";
                discount.Text = "";

                price.Text = "";

                displaymrpbeforeadd();
                displaydiscountbeforeadd();
            }
            catch (Exception exp) { }
        }
        #endregion

        #region for dispaly details before add
        public void displaymrpbeforeadd()
        {

            string sqlString3 = "SELECT Price,Quantity FROM tbl_product WHERE ProductName='" + ProdBtnName + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString3, "tbl_product");
            dtTable4 = sVariables.sDataSet.Tables["tbl_product"];

            mrp.Text = Convert.ToString(dtTable4.Rows[0]["Price"]);
            txtAvailableQuantity.Text = dtTable4.Rows[0]["Quantity"].ToString();
            price.Text = mrp.Text;


        }
        public void displaydiscountbeforeadd()
        {

            string sqlString4 = "SELECT OfferType,DiscountOffered FROM tbl_ProductDiscount WHERE OfferName='" + oname.Text + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString4, "tbl_ProductDiscount");
            dtTable5 = sVariables.sDataSet.Tables["tbl_ProductDiscount"];

            a = Convert.ToInt32(dtTable5.Rows[0]["DiscountOffered"]);
            b = Convert.ToInt32(mrp.Text);


            if (Convert.ToString(dtTable5.Rows[0]["OfferType"]) == "Cash Back")
            {
                try
                {
                    discount.Text = Convert.ToString(dtTable5.Rows[0]["DiscountOffered"]);
                    price.Text = Convert.ToString(b - a);
                }
                catch (DataException)
                {
                }
            }

            else if (Convert.ToString(dtTable5.Rows[0]["OfferType"]) == "Discount in %")
            {


                c = (a * b) / 100;
                discount.Text = Convert.ToString(c);
                price.Text = Convert.ToString(b - c);

            }
            else if (oname.Text == "")
            { 
                price.Text = Convert.ToString(b - Convert.ToInt32(discount.Text));
            }


        }
        #endregion

        #region for datagrid
        public void displaygrid()
        {
            bindingSource1.DataSource = table;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
        }
        #endregion

        #region for add button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Shwquantity = Convert.ToInt32(quantity.Text);
                int Avlqunty = Convert.ToInt32(txtAvailableQuantity.Text);
                if (Shwquantity < Avlqunty)
                {
                    displaygrid();

                    d = 0;

                    if (mrp.Text == "")
                    {
                        sFunctions.setEmptyField("Product Name");
                        mrp.Focus();
                    }

                    if (quantity.Text == "")
                    {
                        sFunctions.setEmptyField("Quantity");
                        quantity.Focus();
                    }
                    else
                    {
                        if (z == 0)
                        {
                            z++;
                            table.Columns.Add("Product Name");
                            table.Columns.Add("MRP");
                            table.Columns.Add("Offer");
                            table.Columns.Add("Discount");
                            table.Columns.Add("Selling Price");
                            table.Columns.Add("Quantity");
                            table.Columns.Add("Total Price");
                            table.Columns.Add("Taxes");
                            table.Columns.Add("Amount");


                        }
                        if (discount.Text != "")
                        {
                            price.Text = Convert.ToString(Convert.ToInt32(mrp.Text) - Convert.ToInt32(discount.Text));
                        }
                        string totalprice = Convert.ToString(Convert.ToInt32(quantity.Text) * Convert.ToInt32(price.Text));
                        string v = vat.Text;
                        string u = stax.Text;
                        string w = Convert.ToString(Convert.ToDecimal(u) + Convert.ToDecimal(v));
                        string vats = Convert.ToString(Convert.ToDecimal(totalprice) * Convert.ToDecimal(w));
                        string fvats = Convert.ToString(Convert.ToDecimal(vats) / 100);
                        if (listBox1.SelectedIndex == 1)
                        {
                            fvats = Convert.ToString("0");
                        }
                        string amount = Convert.ToString(Convert.ToDecimal(totalprice) + Convert.ToDecimal(fvats));

                        table.Rows.Add(ProdBtnName, mrp.Text, oname.Text, discount.Text, price.Text, quantity.Text, totalprice, fvats, amount);



                        if (listBox1.SelectedIndex == 1)
                        {
                            sum = sum + Convert.ToDecimal(totalprice);

                        }
                        else if (listBox1.SelectedIndex == 0)
                        {
                            sum = sum + Convert.ToDecimal(amount);
                        }
                        bill.Text = Convert.ToString(sum);
                    }
                }
            }
            catch(Exception exp){}
        }
        #endregion

        #region for print n save button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (label17.Text != "")
                {
                    double TotalBill = Convert.ToDouble(bill.Text);
                    double AvlBalance = Convert.ToDouble(label17.Text);
                    if (AvlBalance > TotalBill)
                    {
                        savebill();
                        updateStock();
                        lLeftBalance = Convert.ToDouble(label17.Text) - Convert.ToDouble(bill.Text);
                        WriteBalance();
                        PrintInvoice();
                        mrp.Clear();
                        discount.Clear();
                        price.Clear();
                        sum = 0;
                        table.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("You Dont Have Required Balance Left In Your Card");
                    }
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region for print & save button code
        public void savebill()
        {
            try
            {                
                sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                sOleDbCommand.CommandText = "INSERT INTO InvoiceDetails([InvoiceNo],[CardID],[Amount],[PurchaseDate]) values (@InvoiceNo,@CardID,@Amount,@Date)";

                sOleDbCommand.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20);
                sOleDbCommand.Parameters.Add("@CardId", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@Amount", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@Date", SqlDbType.Date);

                sOleDbCommand.Parameters["@InvoiceNo"].Value = label15.Text.Trim();
                sOleDbCommand.Parameters["@CardID"].Value = cardid.Text.Trim();
                sOleDbCommand.Parameters["@Amount"].Value = sum.ToString();
                sOleDbCommand.Parameters["@Date"].Value = DateTime.Now.Date;

                sFunctions.setOledbConnCommand_Close(sOleDbCommand);
                Updatepoints();
                SaveInvoice();
                MessageBox.Show("The bill has been saved and points are updated");    
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion

        #region updatepoints
        private void Updatepoints()
        {
            try
            {
                string sqlString6 = "SELECT CTP FROM UserLogin";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString6, "UserLogin");
                dtTable5 = sVariables.sDataSet.Tables["UserLogin"];
                
                 double ctp = Convert.ToDouble( dtTable5.Rows[0]["CTP"].ToString());

                 string sqlString7 = "SELECT Points FROM CustomerCard WHERE Cardid='"+cardid.Text+"'";
                 sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString7, "CustomerCard");
                DataTable dtTable6 = sVariables.sDataSet.Tables["CustomerCard"];

                double point = Convert.ToDouble(dtTable6.Rows[0]["Points"].ToString());

                point = point + (Convert.ToDouble(sum) / ctp);
                if (CmBoxRedeemAmt.Text != "" && CmBoxRedeemAmt.Text != null)
                {
                    point = point - Convert.ToDouble(CmBoxRedeemAmt.Text);
                }
                cPoints = Convert.ToDouble(point);
                WritePoints();
                sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                sOleDbCommand.CommandText = "update CustomerCard set Points=@Points WHERE Cardid='" + cardid.Text+"'";
                sOleDbCommand.Parameters.Add("@Points", SqlDbType.VarChar, 15);
                sOleDbCommand.Parameters["@Points"].Value = point.ToString();
                sFunctions.setOledbConnCommand_Close(sOleDbCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Card has not been activated");
            }
        

        }
       #endregion

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
                cardid.Text = SN.Trim();
            }
        }
        #endregion

        #region populate invoiceno and points
        private void PopulateInvoice()
        {
            try
            {
                string sSQL = "SELECT  max(InvoiceNo) FROM InvoiceDetails";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "InvoiceDetails");
                dtTable = sVariables.sDataSet.Tables["InvoiceDetails"];
                int InvoiceID = int.Parse(dtTable.Rows[0][0].ToString());
                InvoiceID = InvoiceID + 1;
                label15.Text = InvoiceID.ToString();
            }
            catch (Exception ex)
            {
                label15.Text = "1";
            }
        }

        private void Populatepoints()
        {
            try
            {
                string sSQL1 = "SELECT  Points FROM CustomerCard WHERE Cardid='"+ cardid.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL1, "CustomerCard");
                DataTable dtTable1 = sVariables.sDataSet.Tables["CustomerCard"];
                label13.Text = dtTable1.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                label13.Text = "0";
            }
        }

        #endregion

        #region Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SelectCard();
                PopulateInvoice();
                Populatepoints();
                label17.Text = AvailableBalance();
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Read
        private string AvailableBalance()
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
                dstrpass = Convert.ToString(dstrpass1);
                if (dstrpass == "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                    dstrpass = "0";
            }
            return dstrpass;
        }
        #endregion

        #region SaveInvoice
        public void SaveInvoice()
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Row.Cells[0].Value.ToString() != "")
                {
                    sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                    sOleDbCommand.CommandText = "INSERT INTO tbl_Invoice([InvoiceNo],[CardID],[PurchaseDate],[ProductName],[Quantity],[Offer],[MRP],[Price],[Discount],[ServiceTax],[MRPTotalPrice],[AmountBill]) values (@InvoiceNo,@CardID,@PurchaseDate,@ProductName,@Quantity,@Offer,@MRP,@Price,@Discount,@ServiceTax,@MRPTotalPrice,@AmountBill)";

                    sOleDbCommand.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20);
                    sOleDbCommand.Parameters.Add("@CardID", SqlDbType.VarChar, 20);
                    sOleDbCommand.Parameters.Add("@PurchaseDate", SqlDbType.Date, 50);
                    sOleDbCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@Quantity", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@Offer", SqlDbType.VarChar, 50);
                    sOleDbCommand.Parameters.Add("@MRP", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@Price", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@Discount", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@ServiceTax", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@MRPTotalPrice", SqlDbType.VarChar, 10);
                    sOleDbCommand.Parameters.Add("@AmountBill", SqlDbType.VarChar, 10);

                    sOleDbCommand.Parameters["@InvoiceNo"].Value = label15.Text.Trim();
                    sOleDbCommand.Parameters["@CardID"].Value = cardid.Text.Trim();
                    sOleDbCommand.Parameters["@PurchaseDate"].Value = DateTime.Now.Date;
                    sOleDbCommand.Parameters["@ProductName"].Value = Row.Cells[0].Value.ToString();
                    sOleDbCommand.Parameters["@Quantity"].Value = Row.Cells[5].Value.ToString();
                    sOleDbCommand.Parameters["@Offer"].Value = Row.Cells[2].Value.ToString();
                    sOleDbCommand.Parameters["@MRP"].Value = Row.Cells[1].Value.ToString();
                    sOleDbCommand.Parameters["@Price"].Value = Row.Cells[4].Value.ToString();
                    sOleDbCommand.Parameters["@Discount"].Value = Row.Cells[3].Value.ToString();
                    sOleDbCommand.Parameters["@ServiceTax"].Value = Row.Cells[7].Value.ToString();
                    sOleDbCommand.Parameters["@MRPTotalPrice"].Value = Row.Cells[6].Value.ToString();
                    sOleDbCommand.Parameters["@AmountBill"].Value = Row.Cells[8].Value.ToString();

                    sFunctions.setOledbConnCommand_Close(sOleDbCommand);
                }
            }
        }
        #endregion

        #region updateStock
        public void updateStock()
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Row.Cells[0].Value.ToString() != "")
                {
                    string sqlString6 = "SELECT Quantity FROM tbl_product WHERE ProductName='" + Row.Cells[0].Value.ToString() + "'";
                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString6, "tbl_product");
                    dtTable6 = sVariables.sDataSet.Tables["tbl_product"];

                    int qant = Convert.ToInt32(dtTable6.Rows[0]["Quantity"]);
                    int rowqant = Convert.ToInt32(Row.Cells[5].Value.ToString());
                    qant = qant - rowqant;
                    sFunctions.setOledbConnCommand_Open(sOleDbCommand);
                    sOleDbCommand.CommandText = "update tbl_product set Quantity = @Quantity where ProductName = '" + Row.Cells[0].Value.ToString() + "'";
                    sOleDbCommand.Parameters.Add("@Quantity", SqlDbType.VarChar, 10);

                    sOleDbCommand.Parameters["@Quantity"].Value = qant.ToString();
                    sFunctions.setOledbConnCommand_Close(sOleDbCommand);
                }
            }
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

            charArray1 = lLeftBalance.ToString().ToCharArray();

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

        #region WritePoints
        private void WritePoints()
        {
            // write balance
            long sto = 0;
            byte vKeyType = 0x00;
            int PhysicalSector = 0;
            int ctr, tmpInt = 0;
            byte Blck2 = 1;
            byte[] dout = new byte[16];
            char[] charArray1 = new char[16];

            #region Write for Sector 2
            vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_A;
            //vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_STORED_A;
            g_Sec = 2;
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

            charArray1 = cPoints.ToString().ToCharArray();

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

        #region for PopulateCategory
        private void PopulateCategory()
        {
            try
            {
                string sSQL = "SELECT CategoryName FROM tbl_Category";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Category");
                DataTable dtCategory = sVariables.sDataSet.Tables["tbl_Category"];
                int lc = dtCategory.Rows.Count;

                lWidth = 24;
                for (int lButton = 0; lButton < dtCategory.Rows.Count; lButton++)
                {
                    Button button = new Button();

                    button.Name = "Button" + lButton.ToString();
                    button.Text = dtCategory.Rows[lButton]["CategoryName"].ToString();
                    button.Width = 120;
                    button.Height = 35;
                    button.TextAlign = ContentAlignment.MiddleCenter;
                    if (lButton % 3 == 0)
                    {
                        lHeight = 20;
                        button.Location = new System.Drawing.Point(lHeight, lWidth);
                    }
                    else if (lButton % 3 == 1)
                    {
                        lHeight = 160;
                        button.Location = new System.Drawing.Point(lHeight, lWidth);

                    }
                    else
                    {
                        lHeight = 300;
                        button.Location = new System.Drawing.Point(lHeight, lWidth);
                        lWidth = lWidth + 40;
                    }
                    button.Click += new EventHandler(button_Click);
                    groupBox3.Controls.Add(button);
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Populate Products 
        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox4.Controls.Clear();
                var myButton = (Button)sender;
                string sSQL = "SELECT DISTINCT ProductName FROM tbl_product where CategoryName='" + myButton.Text.Trim() + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_product");
                DataTable dtProduct = sVariables.sDataSet.Tables["tbl_product"];
                int lc = dtProduct.Rows.Count;

                pWidth = 24;
                for (int lButton = 0; lButton < dtProduct.Rows.Count; lButton++)
                {
                    Button Prodbtn = new Button();
                    // Button customization here...
                    Prodbtn.Name = "Button" + lButton.ToString();
                    Prodbtn.Text = dtProduct.Rows[lButton]["ProductName"].ToString();
                    Prodbtn.Width = 100;
                    Prodbtn.Height = 35;
                    Prodbtn.TextAlign = ContentAlignment.MiddleCenter;
                    if (lButton % 4 == 0)
                    {
                        pHeight = 20;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 1)
                    {
                        pHeight = 130;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 2)
                    {
                        pHeight = 240;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 3)
                    {
                        pHeight = 350;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 4)
                    {
                        pHeight = 460;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 5)
                    {
                        pHeight = 570;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 6)
                    {
                        pHeight = 680;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else if (lButton % 8 == 7)
                    {
                        pHeight = 790;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                    }
                    else
                    {
                        pHeight = 900;
                        Prodbtn.Location = new System.Drawing.Point(pHeight, pWidth);
                        pWidth = pWidth + 40;
                    }
                    Prodbtn.Click += new EventHandler(Prodbtn_Click);
                    groupBox4.Controls.Add(Prodbtn);
                }
            }
            catch (Exception exp) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblAvailableQuantity_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region PrdBtn Click
        private void Prodbtn_Click(object sender, EventArgs e)
        {
            try
            {
                var ProdButton = (Button)sender;
                ProdBtnName = ProdButton.Text.Trim();
                oname.Items.Clear();
                oname.Text = "";
                mrp.Text = "";
                discount.Text = "";
                price.Text = "";
                quantity.Text = "";
                stax.Text = "";
                vat.Text = "";

                string sqlString3 = "SELECT DISTINCT OfferName FROM tbl_ProductDiscount WHERE ProductName='" + ProdButton.Text.Trim() + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString3, "tbl_ProductDiscount");
                dtTable3 = sVariables.sDataSet.Tables["tbl_ProductDiscount"];
                for (int k = 0; k <= dtTable3.Rows.Count - 1; k++)
                {
                    oname.Items.Add(dtTable3.Rows[k]["OfferName"].ToString());

                }

                string s = "SELECT ServiceTax,Vat FROM tbl_product where ProductName='" + ProdButton.Text.Trim() + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, s, "tbl_product");
                dtTable = sVariables.sDataSet.Tables["tbl_product"];
                for (int j = 0; j <= dtTable.Rows.Count - 1; j++)
                {
                    stax.Text = (dtTable.Rows[j]["ServiceTax"].ToString());
                    vat.Text = (dtTable.Rows[j]["Vat"].ToString());
                }

                displaymrpbeforeadd();
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Redeem PopUp
        private void btnRedeemPoint_Click(object sender, EventArgs e)
        {
            try
            {
                pnlRedeemPointsPopUp.Visible = true;
                Redeem();
            }
            catch(Exception exp){}
        }

        private void CmBoxRedeemAmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double amt = Convert.ToDouble(CmBoxRedeemAmt.Text);
                double rdmamt = Convert.ToDouble(label13.Text);
                double bAmt = Convert.ToDouble(bill.Text);
                if (amt < rdmamt)
                {
                    if (bAmt > amt)
                    {
                        double total = bAmt - amt;
                        bill.Text = total.ToString();
                        label7.Text = "Bill After Redeem = Rs";
                        pnlRedeemPointsPopUp.Visible = false;
                        CmBoxRedeemAmt.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Bill Amount Is Not Enough For Redeemption");
                    }
                }
                else
                {
                    MessageBox.Show("This Card Does Not Have Sufficient Values");
                }
            }
            catch(Exception exp){}
        }

        public void Redeem()
        {
            CmBoxRedeemAmt.Items.Add("100");
            CmBoxRedeemAmt.Items.Add("200");
            CmBoxRedeemAmt.Items.Add("300");
            CmBoxRedeemAmt.Items.Add("400");
            CmBoxRedeemAmt.Items.Add("500");
            CmBoxRedeemAmt.Items.Add("600");
            CmBoxRedeemAmt.Items.Add("700");
            CmBoxRedeemAmt.Items.Add("800");
            CmBoxRedeemAmt.Items.Add("900");
            CmBoxRedeemAmt.Items.Add("1000");
        }

        private void btnRedeemClose_Click(object sender, EventArgs e)
        {
            pnlRedeemPointsPopUp.Visible = false;
            CmBoxRedeemAmt.Items.Clear();
        }
        #endregion

        #region PrintPage
        public void PrintInvoice()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;
                printDialog.UseEXDialog = true;

                PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
                objPPdialog.Document = printDocument1;
                objPPdialog.ShowDialog();
            }
            catch(Exception exp){}
        }

        #region BeginPrint
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Print Page
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Invoice Page", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Invoice Page", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Invoice Page", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion
    }
}


