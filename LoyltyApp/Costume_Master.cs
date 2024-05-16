using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoyltyApp
{
    public partial class Costume_Master : Form
    {

        #region variable and initialization
        string StrProductID;
        DataTable dtTable1;
        DataTable dtTable2;
        DataTable dtTable3;
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        private BindingSource bindingSource5 = new BindingSource();
        private BindingSource bindingSource6 = new BindingSource();
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //OLEDB VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
        string StrOfferID;
        string StrCategoryID;
        #endregion
        public Costume_Master()
        {
            InitializeComponent();
        }

        private void Costume_Master_Load(object sender, EventArgs e)
        {
            try
            {
                DisplayCategory();
                tabControlProductMaster.TabPages.Remove(AddProductDiscount);

            }
            catch (Exception exp) { }
        }
        private void DisplayProduct()
        {
            string sSQL = "SELECT * FROM tbl_product where CategoryName='" + idcat.Text.Trim() + "'";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_product");
            DataTable bindDataTable = sVariables.sDataSet.Tables["tbl_product"];
            bindingSource5.DataSource = bindDataTable;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSource5;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (idcat.Text == "")
                {
                    sFunctions.setEmptyField("Category ID");
                    idcat.Focus();
                }
                else if (txtQuantity.Text == "")
                {
                    sFunctions.setEmptyField("product name");
                    txtQuantity.Focus();
                }
                else if (price.Text == "")
                {
                    sFunctions.setEmptyField("Price");
                    price.Focus();
                }

                else
                {
                    if (button2.Text == "Submit")
                    {
                        sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM tbl_product WHERE ProductName LIKE '" + txtQuantity.Text.Trim() + "'", "tbl_product");
                        int iTips = sVariables.sDataSet.Tables["tbl_product"].Rows.Count;
                        if (iTips <= 0)
                        {
                            sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                            sOleDbCommand.CommandText = "insert into tbl_product (CategoryName,ProductName,Price,ServiceTax,Vat,Quantity) values (@CategoryName,@ProductName,@Price,@ServiceTax,@Vat,@Quantity)";

                            sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 15);
                            sOleDbCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
                            sOleDbCommand.Parameters.Add("@Price", SqlDbType.VarChar, 20);
                            sOleDbCommand.Parameters.Add("@ServiceTax", SqlDbType.VarChar, 20);
                            sOleDbCommand.Parameters.Add("@Vat", SqlDbType.VarChar, 20);
                            sOleDbCommand.Parameters.Add("@Quantity", SqlDbType.VarChar, 20);

                            sOleDbCommand.Parameters["@CategoryName"].Value = idcat.Text.Trim();
                            sOleDbCommand.Parameters["@ProductName"].Value = pname.Text.Trim();
                            sOleDbCommand.Parameters["@Price"].Value = price.Text.Trim();
                            sOleDbCommand.Parameters["@ServiceTax"].Value = txtServiceTax.Text.Trim();
                            sOleDbCommand.Parameters["@Vat"].Value = txtVAT.Text.Trim();
                            sOleDbCommand.Parameters["@Quantity"].Value = txtQuantity.Text.Trim();

                            sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                            sFunctions.setMessageBox("Record has been successfully saved.", 1);
                            idcat.Text = "";
                            txtQuantity.Clear();
                            price.Clear();
                            pname.Text = "";
                            txtServiceTax.Text = "";
                            txtVAT.Text = "";
                            DisplayProduct();
                        }
                        else
                        {
                            MessageBox.Show("Product Name already Exists");
                        }
                    }
                    else if (button2.Text == "Update")
                    {
                        sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                        sOleDbCommand.CommandText = "update tbl_product set CategoryName=@CategoryName,ProductName=@ProductName,Price=@Price,ServiceTax=@ServiceTax,Vat=@Vat,Quantity=@Quantity where ProductID =" + StrProductID;

                        sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 15);
                        sOleDbCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@Price", SqlDbType.VarChar, 20);
                        sOleDbCommand.Parameters.Add("@ServiceTax", SqlDbType.VarChar, 20);
                        sOleDbCommand.Parameters.Add("@Vat", SqlDbType.VarChar, 20);
                        sOleDbCommand.Parameters.Add("@Quantity", SqlDbType.VarChar, 20);


                        sOleDbCommand.Parameters["@CategoryName"].Value = idcat.Text.Trim();
                        sOleDbCommand.Parameters["@ProductName"].Value = pname.Text.Trim();
                        sOleDbCommand.Parameters["@Price"].Value = price.Text.Trim();
                        sOleDbCommand.Parameters["@ServiceTax"].Value = txtServiceTax.Text.Trim();
                        sOleDbCommand.Parameters["@Vat"].Value = txtVAT.Text.Trim();
                        sOleDbCommand.Parameters["@Quantity"].Value = txtQuantity.Text.Trim();


                        sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                        sFunctions.setMessageBox("Record has been successfully saved.", 1);
                        idcat.Text = ""; ;
                        txtQuantity.Clear();
                        price.Clear();


                        DisplayProduct();

                        button2.Text = "Submit";
                    }
                }
            }
            catch (Exception exp) { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string strCellValue = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strCellValue != "" && strCellValue != null)
                {
                    idcat.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtQuantity.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                    price.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtVAT.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtServiceTax.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                    pname.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                    StrProductID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    button2.Text = "Update";
                }
            }
            catch (Exception exp) { }
        }

        private void idcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pname.Items.Clear();
                txtQuantity.Text = "";
                txtServiceTax.Text = "";
                txtVAT.Text = "";
                price.Text = "";
                string sqlString2 = "SELECT DISTINCT ProductName FROM tbl_product where CategoryName='" + idcat.Text + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString2, "tbl_product");
                dtTable3 = sVariables.sDataSet.Tables["tbl_product"];
                for (int k = 0; k <= dtTable3.Rows.Count - 1; k++)
                {
                    pname.Items.Add(dtTable3.Rows[k]["ProductName"].ToString());

                }
                DisplayProduct();
            }
            catch (Exception exp) { }
        }

        private void tabControlProductMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControlProductMaster.SelectedTab == tabControlProductMaster.TabPages["AddCategory"])
                {
                    DisplayCategory();
                }
                if (tabControlProductMaster.SelectedTab == tabControlProductMaster.TabPages["AddProduct"])
                {
                    string sSQL = "SELECT * FROM tbl_product";
                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_product");
                    DataTable proDataTable = sVariables.sDataSet.Tables["tbl_product"];
                    bindingSource1.DataSource = proDataTable;
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.DataSource = bindingSource1;
                    DisplayProduct();
                    idcat.Items.Clear();
                    //CategoryCombo();
                }
                if (tabControlProductMaster.SelectedTab == tabControlProductMaster.TabPages["AddProductDiscount"])
                {
                    string sSQL = "SELECT * FROM tbl_ProductDiscount";

                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_ProductDiscount");
                    DataTable sDataTable = sVariables.sDataSet.Tables["tbl_ProductDiscount"];
                    bindingSource6.DataSource = sDataTable;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = bindingSource6;
                    //DisplayProductDiscount();
                    comboBox1.Items.Clear();
                    ///CategoryCombo();
                }
            }
            catch (Exception exp) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcname.Text == "")
                {
                    sFunctions.setEmptyField("Category Name");
                    txtcname.Focus();
                }
                else if (txtdescription.Text == "")
                {
                    sFunctions.setEmptyField("Description");
                    txtdescription.Focus();
                }
                else
                {
                    if (button3.Text == "Submit")
                    {
                        sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM tbl_Category WHERE CategoryName LIKE '" + txtcname.Text.Trim() + "'", "tbl_Category");
                        int iTips = sVariables.sDataSet.Tables["tbl_Category"].Rows.Count;
                        if (iTips <= 0)
                        {
                            sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                            sOleDbCommand.CommandText = "insert into tbl_Category (CategoryName,Description) values (@CategoryName,@Description)";

                            sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50);
                            sOleDbCommand.Parameters.Add("@Description", SqlDbType.VarChar, 250);

                            sOleDbCommand.Parameters["@CategoryName"].Value = txtcname.Text.Trim();
                            sOleDbCommand.Parameters["@Description"].Value = txtdescription.Text.Trim();

                            sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                            sFunctions.setMessageBox("Record has been successfully saved.", 1);
                            txtcname.Clear();
                            txtdescription.Clear();
                            DisplayCategory();
                        }
                        else
                        {
                            MessageBox.Show("Company Category Name already Exists");
                        }
                    }
                    else if (button3.Text == "Update")
                    {
                        sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                        sOleDbCommand.CommandText = "update tbl_Category set CategoryName=@CategoryName,Description=@Description where CategoryID =" + StrCategoryID;

                        sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@Description", SqlDbType.VarChar, 250);

                        sOleDbCommand.Parameters["@CategoryName"].Value = txtcname.Text.Trim();
                        sOleDbCommand.Parameters["@Description"].Value = txtdescription.Text.Trim();

                        sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                        sFunctions.setMessageBox("Record has been updated successfully saved.", 1);
                        txtcname.Clear();
                        txtdescription.Clear();
                        DisplayCategory();
                        button3.Text = "Submit";
                    }
                }
            }
            catch (Exception exp) { }
        }
        private void DisplayCategory()
        {
            string sSQL = "SELECT * FROM tbl_Category";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Category");
            DataTable sDataTable = sVariables.sDataSet.Tables["tbl_Category"];
            bindingSource3.DataSource = sDataTable;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = bindingSource3;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string strCellValue = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strCellValue != "" && strCellValue != null)
                {
                    txtcname.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtdescription.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                    StrCategoryID = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    button3.Text = "Update";
                }
            }
            catch (Exception exp) { }
        }



        //private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
