using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Collections;
using System.Data.SqlClient;

namespace LoyltyApp
{
    public partial class Customer_Report : Form
    {
        #region All
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //Sql VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
        
        public static int g_rHandle, g_retCode;
        public static bool g_isConnected = false;
        public static byte g_Sec;
        public static byte[] g_pKey = new byte[6];

        public Customer_Report()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SelectCard();
            }
            catch (Exception exp) { }
        }

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
                lblCardid.Text = SN.Trim();
            }
        }
        #endregion

        #endregion

        #region Recharge Report
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                string todate = dateTimePicker1.Value.ToShortDateString();
                string fromdate = dateTimePicker2.Value.ToShortDateString();
                string sSQL = "SELECT * FROM RechargeDetails where Cardid='" + lblCardid.Text + "' AND RechDate >='" + todate + "' AND RechDate <='" + fromdate + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "RechargeDetails");
                DataTable sDataTable = sVariables.sDataSet.Tables["RechargeDetails"];
                bindingSource1.DataSource = sDataTable;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bindingSource1;
            }
            catch (Exception exp) { }
        }

        #region Export To CSV
        private void btnRechExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "csv files (*.csv)|*.csv";
                dlg.Title = "Export in CSV format";
                dlg.CheckPathExists = true;
                dlg.ShowDialog();

                if (dlg.FileName != "")
                {
                    int numRows = dataGridView1.Rows.Count;
                    StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                    for (int row = 0; row < numRows; row++)
                    {
                        string lines = "";
                        for (int col = 0; col < 4; col++)
                        {
                            lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dataGridView1.Rows[row].Cells[col].Value.ToString();
                        }

                        streamWriter.WriteLine(lines);
                    }
                    streamWriter.Close();
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #endregion

        #region Transaction Report
        private void btnTranGet_Click(object sender, EventArgs e)
        {
            try
            {
                clsVariables sVariables = new clsVariables();
                string todate = dateTimePicker1.Value.ToShortDateString();
                string fromdate = dateTimePicker2.Value.ToShortDateString();
                string sSQL = "SELECT * FROM tbl_Invoice where Cardid='" + lblCardid.Text.Trim() + "' AND PurchaseDate >='" + todate + "'AND PurchaseDate <='" + fromdate + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Invoice");
                DataTable tranDataTable = sVariables.sDataSet.Tables["tbl_Invoice"];
                bindingSource2.DataSource = tranDataTable;
                dgViewTransaction.AutoGenerateColumns = true;
                dgViewTransaction.DataSource = bindingSource2;
            }
            catch (Exception exp) { }
        }

        private void btnTranExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "csv files (*.csv)|*.csv";
                dlg.Title = "Export in CSV format";
                dlg.CheckPathExists = true;
                dlg.ShowDialog();

                if (dlg.FileName != "")
                {
                    int numRows = dgViewTransaction.Rows.Count;
                    StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                    for (int row = 0; row < numRows; row++)
                    {
                        string lines = "";
                        for (int col = 0; col < 12; col++)
                        {
                            lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dgViewTransaction.Rows[row].Cells[col].Value.ToString();
                        }

                        streamWriter.WriteLine(lines);
                    }
                    streamWriter.Close();
                }
            }
            catch(Exception exp)
            {}
        }

        #endregion

        #region Statement Report
        private void btnStatGet_Click(object sender, EventArgs e)
        {
            try
            {
                clsVariables sVariables = new clsVariables();
                string todate = dateTimePicker1.Value.ToShortDateString();
                string fromdate = dateTimePicker2.Value.ToShortDateString();
                string sSQL = "SELECT InvoiceDetails.CardID,InvoiceDetails.PurchaseDate,InvoiceDetails.Amount,CustomerCard.CustomerName,CustomerCard.ContactNo,CustomerCard.Email,RechargeDetails.RechAmount,RechargeDetails.RechDate FROM InvoiceDetails,CustomerCard,RechargeDetails where InvoiceDetails.Cardid='" + lblCardid.Text.Trim() + "' AND InvoiceDetails.PurchaseDate >='" + todate + "'AND InvoiceDetails.PurchaseDate <='" + fromdate + "' AND InvoiceDetails.CardID = CustomerCard.Cardid AND InvoiceDetails.CardID=RechargeDetails.Cardid AND InvoiceDetails.PurchaseDate = RechargeDetails.RechDate";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Invoice");
                DataTable statDataTable = sVariables.sDataSet.Tables["tbl_Invoice"];
                bindingSource3.DataSource = statDataTable;
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = bindingSource3;
            }
            catch(Exception exp){}
        }

        #region Export To CSV
        private void btnStatExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = "csv files (*.csv)|*.csv";
                dlg.Title = "Export in CSV format";
                dlg.CheckPathExists = true;
                dlg.ShowDialog();

                if (dlg.FileName != "")
                {
                    int numRows = dataGridView3.Rows.Count;
                    StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                    for (int row = 0; row < numRows; row++)
                    {
                        string lines = "";
                        for (int col = 0; col < 7; col++)
                        {
                            lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dataGridView3.Rows[row].Cells[col].Value.ToString();
                        }

                        streamWriter.WriteLine(lines);
                    }
                    streamWriter.Close();
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #endregion

        #region Tab Select
        private void tabCustomerRpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabCustomerRpt.SelectedTab == tabCustomerRpt.TabPages["RechargeReport"])
                {
                    dataGridView1.DataSource = null;
                }
                if (tabCustomerRpt.SelectedTab == tabCustomerRpt.TabPages["TransactionReport"])
                {
                    dgViewTransaction.DataSource = null;
                }
                if (tabCustomerRpt.SelectedTab == tabCustomerRpt.TabPages["StatementReport"])
                {                                        
                    dataGridView3.DataSource = null;
                }
            }
            catch(Exception exp){}
        }
        #endregion
    }
}
