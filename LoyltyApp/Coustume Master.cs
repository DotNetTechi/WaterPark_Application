using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;

namespace LoyltyApp
{
    public partial class Coustume_Master : Form
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

        #region Initialisation
        public Coustume_Master()
        {
            InitializeComponent();
        }

        private void Coustume_Master_Load(object sender, EventArgs e)
        {
            try
            {
                DisplayCategory();
               // tabControlProductMaster.TabPages.Remove(AddProductDiscount);
            }
            catch (Exception)
            {
                // Handle exceptions silently or log them if necessary
            }
        }

        private void CategoryCombo()
        {
            string sqlString1 = "SELECT DISTINCT CategoryName FROM tbl_Category";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString1, "tbl_Category");
            dtTable1 = sVariables.sDataSet.Tables["tbl_Category"];
            for (int j = 0; j <= dtTable1.Rows.Count - 1; j++)
            {
                idcat.Items.Add(dtTable1.Rows[j]["CategoryName"].ToString());
                //comboBox1.Items.Add(dtTable1.Rows[j]["CategoryName"].ToString());
            }
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
        #endregion

        #region for Submit button
        private void button2_Click_1(object sender, EventArgs e)
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
                            //sOleDbCommand.Parameters["@ServiceTax"].Value = txtServiceTax.Text.Trim();
                            //sOleDbCommand.Parameters["@Vat"].Value = txtVAT.Text.Trim();
                            sOleDbCommand.Parameters["@Quantity"].Value = txtQuantity.Text.Trim();

                            sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                            sFunctions.setMessageBox("Record has been successfully saved.", 1);
                            idcat.Text = "";
                            txtQuantity.Clear();
                            price.Clear();
                            pname.Text = "";
                            //txtServiceTax.Text = "";
                            //txtVAT.Text = "";
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
                        //sOleDbCommand.Parameters["@ServiceTax"].Value = txtServiceTax.Text.Trim();
                        //sOleDbCommand.Parameters["@Vat"].Value = txtVAT.Text.Trim();
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
        #endregion

        #region datagrid
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
                    //txtVAT.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                    //txtServiceTax.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                    pname.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                    StrProductID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    button2.Text = "Update";
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Category Selected Index Changed
        private void idcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pname.Items.Clear();
                txtQuantity.Text = "";
                //txtServiceTax.Text = "";
                //txtVAT.Text = "";
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
        #endregion




        //#region Add Discount
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        pid.Items.Clear();
        //        otype.Items.Clear();
        //        string sqlString2 = "SELECT DISTINCT ProductName FROM tbl_product where CategoryName='" + comboBox1.Text + "'";
        //        sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString2, "tbl_product");
        //        dtTable2 = sVariables.sDataSet.Tables["tbl_product"];
        //        for (int k = 0; k <= dtTable2.Rows.Count - 1; k++)
        //        {
        //            pid.Items.Add(dtTable2.Rows[k]["ProductName"].ToString());

        //        }
        //        otype.Items.Add("Cash Back");
        //        otype.Items.Add("Discount in %");
        //        otype.Items.Add("Others");
        //        DisplayProductDiscount();
        //    }
        //    catch (Exception exp) { }
        //}

        //#region DataGrid Cell Click
        ////private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        ////{
        ////    try
        ////    {
        ////        string strCellValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        ////        if (strCellValue != "" && strCellValue != null)
        ////        {
        ////            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        ////            pid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        ////            otype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        ////            oname.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        ////            Discount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        ////            sdate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
        ////            edate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
        ////            odescription.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        ////            StrOfferID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        ////            button1.Text = "Update";
        ////        }
        ////    }
        ////    catch (Exception exp) { }
        ////}
        //#endregion

        //#region Pid Selected Index Changed
        ////private void pid_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        oname.Clear();
        ////        odescription.Clear();
        ////        Discount.Clear();
        ////        otype.SelectedIndex = 0;
        ////        sdate.Value = DateTime.Now;
        ////        edate.Value = DateTime.Now;
        ////    }
        ////    catch (Exception exp) { }
        ////}

        //#endregion

        //#region Button Click
        ////private void button1_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        if (pid.Text == "")
        ////        {
        ////            sFunctions.setEmptyField("product name");
        ////            pid.Focus();
        ////        }

        ////        else if (otype.Text == "")
        ////        {
        ////            sFunctions.setEmptyField("Offer type");
        ////            otype.Focus();
        ////        }


        ////        else if (oname.Text == "")
        ////        {
        ////            sFunctions.setEmptyField("Offer name");
        ////            oname.Focus();
        ////        }
        ////        else if (Discount.Text == "")
        ////        {
        ////            sFunctions.setEmptyField("discount offered");
        ////            Discount.Focus();
        ////        }
        ////        else if (otype.SelectedIndex == 1 && Convert.ToDouble(Discount.Text) > 100)
        ////        {
        ////            MessageBox.Show("Discount Value not acceptable");
        ////        }

        ////        else if (otype.SelectedIndex == 1 && Convert.ToDouble(Discount.Text) < 0)
        ////        {
        ////            MessageBox.Show("Discount Value not acceptable");
        ////        }


        ////        else
        ////        {
        ////            if (button1.Text == "Submit")
        ////            {
        ////                sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM tbl_ProductDiscount WHERE OfferName LIKE '" + oname.Text.Trim() + "'", "tbl_ProductDiscount");
        ////                int iTips = sVariables.sDataSet.Tables["tbl_ProductDiscount"].Rows.Count;
        ////                if (iTips <= 0)
        ////                {
        ////                    sFunctions.setOledbConnCommand_Open(sOleDbCommand);

        ////                    sOleDbCommand.CommandText = "insert into tbl_ProductDiscount (CategoryName,ProductName,OfferType,OfferName,DiscountOffered,StartDate,EndDate,OfferDescription) values (@CategoryName,@ProductName,@OfferType,@OfferName,@DiscountOffered,@StartDate,@EndDate,@OfferDescription)";

        ////                    sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50);
        ////                    sOleDbCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
        ////                    sOleDbCommand.Parameters.Add("@OfferType", SqlDbType.VarChar, 50);
        ////                    sOleDbCommand.Parameters.Add("@OfferName", SqlDbType.VarChar, 50);
        ////                    sOleDbCommand.Parameters.Add("@DiscountOffered", SqlDbType.VarChar, 50);
        ////                    sOleDbCommand.Parameters.Add("@StartDate", SqlDbType.Date);
        ////                    sOleDbCommand.Parameters.Add("@EndDate", SqlDbType.Date);
        ////                    sOleDbCommand.Parameters.Add("@OfferDescription", SqlDbType.VarChar, 200);

        ////                    sOleDbCommand.Parameters["@CategoryName"].Value = comboBox1.Text.Trim();
        ////                    sOleDbCommand.Parameters["@ProductName"].Value = pid.Text.Trim();
        ////                    sOleDbCommand.Parameters["@OfferType"].Value = otype.Text.Trim();
        ////                    sOleDbCommand.Parameters["@OfferName"].Value = oname.Text.Trim();
        ////                    sOleDbCommand.Parameters["@DiscountOffered"].Value = Discount.Text.Trim();
        ////                    sOleDbCommand.Parameters["@StartDate"].Value = sdate.Value.ToShortDateString();
        ////                    sOleDbCommand.Parameters["@EndDate"].Value = edate.Value.ToShortDateString();
        ////                    sOleDbCommand.Parameters["@OfferDescription"].Value = odescription.Text.Trim();


        ////                    sFunctions.setOledbConnCommand_Close(sOleDbCommand);

        ////                    sFunctions.setMessageBox("Record has been successfully saved.", 1);
        ////                    pid.Text = "";
        ////                    otype.Text = "";

        ////                    oname.Clear();
        ////                    Discount.Clear();
        ////                    odescription.Clear();
        ////                    sdate.Value = System.DateTime.Now;
        ////                    edate.Value = System.DateTime.Now;

        ////                    DisplayProductDiscount();
        ////                }
        ////                else
        ////                {
        ////                    MessageBox.Show("Offer Name already Exists");
        ////                }
        ////            }
        ////            else if (button1.Text == "Update")
        ////            {
        ////                sFunctions.setOledbConnCommand_Open(sOleDbCommand);

        ////                sOleDbCommand.CommandText = "update tbl_ProductDiscount set CategoryName=@CategoryName,ProductName=@ProductName,OfferType=@OfferType,OfferName=@OfferName,DiscountOffered=@DiscountOffered,StartDate=@StartDate,EndDate=@EndDate,OfferDescription=@OfferDescription where OfferID =" + StrOfferID;

        ////                sOleDbCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50);
        ////                sOleDbCommand.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
        ////                sOleDbCommand.Parameters.Add("@OfferType", SqlDbType.VarChar, 50);
        ////                sOleDbCommand.Parameters.Add("@OfferName", SqlDbType.VarChar, 50);
        ////                sOleDbCommand.Parameters.Add("@DiscountOffered", SqlDbType.VarChar, 50);
        ////                sOleDbCommand.Parameters.Add("@StartDate", SqlDbType.Date);
        ////                sOleDbCommand.Parameters.Add("@EndDate", SqlDbType.Date);
        ////                sOleDbCommand.Parameters.Add("@OfferDescription", SqlDbType.VarChar, 200);

        ////                sOleDbCommand.Parameters["@CategoryName"].Value = comboBox1.Text.Trim();
        ////                sOleDbCommand.Parameters["@ProductName"].Value = pid.Text.Trim();
        ////                sOleDbCommand.Parameters["@OfferType"].Value = otype.Text.Trim();
        ////                sOleDbCommand.Parameters["@OfferName"].Value = oname.Text.Trim();
        ////                sOleDbCommand.Parameters["@DiscountOffered"].Value = Discount.Text.Trim();
        ////                sOleDbCommand.Parameters["@StartDate"].Value = sdate.Value.ToShortDateString();
        ////                sOleDbCommand.Parameters["@EndDate"].Value = edate.Value.ToShortDateString();
        ////                sOleDbCommand.Parameters["@OfferDescription"].Value = odescription.Text.Trim();


        ////                sFunctions.setOledbConnCommand_Close(sOleDbCommand);

        ////                sFunctions.setMessageBox("Record has been successfully saved.", 1);
        ////                pid.Text = "";
        ////                otype.Text = "";

        ////                oname.Clear();
        ////                Discount.Clear();
        ////                odescription.Clear();
        ////                sdate.Value = System.DateTime.Now;
        ////                edate.Value = System.DateTime.Now;


        ////                DisplayProductDiscount();

        ////                button1.Text = "Submit";
        ////            }
        ////        }
        ////    }
        ////    catch (Exception exp) { }
        ////}


        //#endregion

        //#region for Display
        //private void DisplayProductDiscount()
        //{
        //    string sSQL = "SELECT * FROM tbl_ProductDiscount where CategoryName='" + comboBox1.Text.Trim() + "'";

        //    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_ProductDiscount");
        //    DataTable sDataTable = sVariables.sDataSet.Tables["tbl_ProductDiscount"];
        //    bindingSource2.DataSource = sDataTable;
        //    dataGridView1.AutoGenerateColumns = true;
        //    dataGridView1.DataSource = bindingSource2;
        //}
        //#endregion

        //#endregion

        #region Tab Selceted Index Changed
        private void tabControlFoodMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["AddCostumeCategory"])
                {
                    DisplayCategory();
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["AddCostumeProduct"])
                {
                    string sSQL = "SELECT * FROM tbl_product";
                    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_product");
                    DataTable proDataTable = sVariables.sDataSet.Tables["tbl_product"];
                    bindingSource1.DataSource = proDataTable;
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.DataSource = bindingSource1;
                    DisplayProduct();
                    idcat.Items.Clear();
                    CategoryCombo();
                }
                //if (tabControlFoodMaster.SelectedTab == tabControlFoodMaster.TabPages["AddProductDiscount"])
                //{
                //    string sSQL = "SELECT * FROM tbl_ProductDiscount";

                //    sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_ProductDiscount");
                //    DataTable sDataTable = sVariables.sDataSet.Tables["tbl_ProductDiscount"];
                //    bindingSource6.DataSource = sDataTable;
                //    dataGridView1.AutoGenerateColumns = true;
                //    dataGridView1.DataSource = bindingSource6;
                //    DisplayProductDiscount();
                //    comboBox1.Items.Clear();
                //    CategoryCombo();
                //}
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Add Category
        #region Add Category Button Click
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
        #endregion

        #region for Load Method Function
        private void DisplayCategory()
        {
            string sSQL = "SELECT * FROM tbl_Category";
            sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sSQL, "tbl_Category");
            DataTable sDataTable = sVariables.sDataSet.Tables["tbl_Category"];
            bindingSource3.DataSource = sDataTable;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = bindingSource3;
        }
        #endregion

        #region Category Grid Cell Click
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
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



        #endregion

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //private void tabControlFoodMaster_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}

