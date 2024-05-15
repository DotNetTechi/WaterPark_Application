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
    public partial class Company_Report : Form
    {
        #region variable and initialization
        DataTable dtTable1;
        DataTable dtTable2;
        DataTable dtTable3;
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        private BindingSource bindingSource4 = new BindingSource();
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //Sql VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();

        public Company_Report()
        {
            InitializeComponent();
        }
        #endregion

        #region Billing Report
        private void btnGetReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception exp) { }
        }

        #region dgView Cell Click
        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strCellValue = dgView.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strCellValue != "" && strCellValue != null)
                {
                    clsVariables.sCardid = dgView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    clsVariables.sPurchaseDate = dgView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    clsVariables.sInvoiceNO = dgView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    popUpDisplay();
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Export To CSV
        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Export in CSV format";
            dlg.CheckPathExists = true;
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {
                int numRows = dgView.Rows.Count;
                StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                for (int row = 0; row < numRows; row++)
                {
                    string lines = "";
                    for (int col = 0; col < 4; col++)
                    {
                        lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dgView.Rows[row].Cells[col].Value.ToString();
                    }

                    streamWriter.WriteLine(lines);
                }
                streamWriter.Close();
            }
        }
        #endregion

        #endregion

        #region Category Wise Report
        private void idcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pid.Items.Clear();
                string sqlString2 = "SELECT DISTINCT ProductName FROM tbl_product where CategoryName='" + idcat.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString2, "tbl_product");
                dtTable1 = sVariables.sDataSet.Tables["tbl_product"];
                for (int k = 0; k <= dtTable1.Rows.Count - 1; k++)
                {
                    pid.Items.Add(dtTable1.Rows[k]["ProductName"].ToString());
                }
            }
            catch (Exception exp) { }
        }

        private void pid_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sSQL = "SELECT * FROM tbl_Invoice where ProductName='" + pid.Text.Trim() + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Invoice");
            DataTable sDataTable = sVariables.sDataSet.Tables["tbl_Invoice"];
            bindingSource3.DataSource = sDataTable;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource3;
        }

        private void button2_Click(object sender, EventArgs e)
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
                    for (int col = 0; col < 12; col++)
                    {
                        lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dataGridView1.Rows[row].Cells[col].Value.ToString();
                    }

                    streamWriter.WriteLine(lines);
                }
                streamWriter.Close();
            }
        }
        #endregion

        #region Product Wise Report
        private void cmbBoxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "SELECT * FROM tbl_product where CategoryName='" + cmbBoxCategoryName.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_product");
                DataTable sDataTable = sVariables.sDataSet.Tables["tbl_product"];
                bindingSource4.DataSource = sDataTable;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bindingSource4;
            }
            catch (Exception exp) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "csv files (*.csv)|*.csv";
            dlg.Title = "Export in CSV format";
            dlg.CheckPathExists = true;
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {
                int numRows = dgView.Rows.Count;
                StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                for (int row = 0; row < numRows; row++)
                {
                    string lines = "";
                    for (int col = 0; col < 7; col++)
                    {
                        lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dgView.Rows[row].Cells[col].Value.ToString();
                    }

                    streamWriter.WriteLine(lines);
                }
                streamWriter.Close();
            }
        }
        #endregion

        #region Tab Changed
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["CategoryWiseProductReport"])
                {
                    idcat.Items.Clear();
                    dataGridView2.Refresh();
                    string sqlString1 = "SELECT DISTINCT CategoryName FROM tbl_Category";
                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString1, "tbl_Category");
                    dtTable2 = sVariables.sDataSet.Tables["tbl_Category"];
                    for (int j = 0; j <= dtTable2.Rows.Count - 1; j++)
                    {
                        idcat.Items.Add(dtTable2.Rows[j]["CategoryName"].ToString());
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["ProductWiseReport"])
                {
                    cmbBoxCategoryName.Items.Clear();
                    dataGridView1.Refresh();
                    string sqlString1 = "SELECT DISTINCT CategoryName FROM tbl_Category";
                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString1, "tbl_Category");
                    dtTable3 = sVariables.sDataSet.Tables["tbl_Category"];
                    for (int j = 0; j <= dtTable3.Rows.Count - 1; j++)
                    {
                        cmbBoxCategoryName.Items.Add(dtTable3.Rows[j]["CategoryName"].ToString());

                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["BillingReport"])
                {
                    dgView.Refresh();
                    dgViewpopup.Visible = false;
                    btnExportToCSV.Visible = false;
                    dgView.Visible = false;
                    button3.Visible = false;
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Page Load
        private void Company_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlString1 = "SELECT DISTINCT CategoryName FROM tbl_Category";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString1, "tbl_Category");
                dtTable2 = sVariables.sDataSet.Tables["tbl_Category"];
                for (int j = 0; j <= dtTable2.Rows.Count - 1; j++)
                {
                    idcat.Items.Add(dtTable2.Rows[j]["CategoryName"].ToString());
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region PopUp
        public void popUpDisplay()
        {
            dgViewpopup.Visible = true;
            btnExportToCSV.Visible = false;
            dgView.Visible = false;
            button3.Visible =true ;
            string sSQL = "SELECT * FROM tbl_Invoice where Cardid='" + clsVariables.sCardid + "' AND PurchaseDate='" + clsVariables.sPurchaseDate + "' AND InvoiceNo = '" + clsVariables.sInvoiceNO + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Invoice");
            DataTable PopDataTable = sVariables.sDataSet.Tables["tbl_Invoice"];
            bindingSource2.DataSource = PopDataTable;
            dgViewpopup.AutoGenerateColumns = true;
            dgViewpopup.DataSource = bindingSource2;
        }

        #endregion 

        #region Export To CSV Complete
        private void button3_Click(object sender, EventArgs e)
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
                    int numRows = dgView.Rows.Count;
                    StreamWriter streamWriter = new StreamWriter(dlg.FileName);
                    for (int row = 0; row < numRows; row++)
                    {
                        string lines = "";
                        for (int col = 0; col < 12; col++)
                        {
                            lines += (string.IsNullOrEmpty(lines) ? " " : ", ") + dgView.Rows[row].Cells[col].Value.ToString();
                        }

                        streamWriter.WriteLine(lines);
                    }
                    streamWriter.Close();
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Populate Main Grid
        public void PopulateGrid()
        {
            button3.Visible = false;
            dgViewpopup.Visible = false;
            btnExportToCSV.Visible = true;
            dgView.Visible = true;
            
            string todate = dateTimePicker1.Value.ToShortDateString();
            string fromdate = dateTimePicker2.Value.ToShortDateString();
            string sSQL = "SELECT * FROM InvoiceDetails where PurchaseDate >='" + todate + "'AND PurchaseDate <='" + fromdate + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "InvoiceDetails");
            DataTable sDataTable = sVariables.sDataSet.Tables["InvoiceDetails"];
            bindingSource1.DataSource = sDataTable;
            dgView.AutoGenerateColumns = true;
            dgView.DataSource = bindingSource1;
        }
        #endregion
    }
}
