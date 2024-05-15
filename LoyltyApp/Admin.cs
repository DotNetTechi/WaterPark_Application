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
using System.IO;
using System.Drawing.Imaging;

namespace LoyltyApp
{
    public partial class Admin : Form
    {
        #region variable
        private BindingSource bindingSource1 = new BindingSource();
        byte[] photo_aray;
        DataTable dtTable1;
        DataTable dtTable2;
        DataTable dtTable3;
       
        //CLASS VARIABLES
        clsFunctions sFunctions = new clsFunctions();
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();
        //Sql VARIABLES
        SqlCommand sOleDbCommand = new SqlCommand();
        clsConnections sConnections = new clsConnections();
        bool User = false;
        bool Recharge = false;
        bool Product = false;
        bool companyRpt = false;
        bool Purchase = false;
        bool AddCard = false;
        bool ChanPassword = false;
        #endregion

        public Admin()
        {
            InitializeComponent();
            AdmintabControl.TabPages.Remove(UpdateChangeToCash);
        }

        #region Update User Profile
        #region Update Profile
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (picBox.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picBox.Image.Save(ms, ImageFormat.Jpeg);
                    photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);
                }
                CheckPrivilege();

                sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                sOleDbCommand.CommandText = "update UserPrivilege set Password=@Password,MobileNumber=@MobileNumber,EmailAddress=@EmailAddress,Address=@Address,AddUser=@AddUser,Recharge=@Recharge,AddProduct=@AddProduct,companyRpt=@companyRpt,Purchase=@Purchase,AddCard=@AddCard,ChangePassword=@ChangePassword,UImage=@UImage where LoginId='" + txtUserName.Text.Trim() + "'";

                sOleDbCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
                sOleDbCommand.Parameters.Add("@Address", SqlDbType.VarChar, 250);
                sOleDbCommand.Parameters.Add("@AddUser", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@Recharge", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@AddProduct", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@companyRpt", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@Purchase", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@AddCard", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@ChangePassword", SqlDbType.Bit);
                sOleDbCommand.Parameters.Add("@UImage", SqlDbType.VarBinary);


                sOleDbCommand.Parameters["@Password"].Value = txtpassword.Text.Trim();
                sOleDbCommand.Parameters["@MobileNumber"].Value = txtMobileNumber.Text.Trim();
                sOleDbCommand.Parameters["@EmailAddress"].Value = txtEmailAddress.Text.Trim();
                sOleDbCommand.Parameters["@Address"].Value = txtAddress.Text.Trim();
                sOleDbCommand.Parameters["@AddUser"].Value = User;
                sOleDbCommand.Parameters["@Recharge"].Value = Recharge;
                sOleDbCommand.Parameters["@AddProduct"].Value = Product;
                sOleDbCommand.Parameters["@companyRpt"].Value = companyRpt;
                sOleDbCommand.Parameters["@Purchase"].Value = Purchase;
                sOleDbCommand.Parameters["@AddCard"].Value = AddCard;
                sOleDbCommand.Parameters["@ChangePassword"].Value = ChanPassword;
                sOleDbCommand.Parameters["@UImage"].Value = photo_aray;

                sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                sFunctions.setMessageBox("User Has Been Successfully Updated.", 1);
            }
            catch (Exception exp)
            { }
        }
        #endregion

        #region Populateotherdetails
        private void PopulateOtherDetails()
        {
            txtuname.Text = "";
            txtpassword.Text = "";
            txtMobileNumber.Text = "";
            txtEmailAddress.Text = "";
            txtAddress.Text = "";
            picBox.Image = null;

            try
            {
                string sqlString = "SELECT * FROM UserPrivilege WHERE LoginId='" + idcat.Text.Trim() + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString, "UserPrivilege");
                DataTable dtTable = sVariables.sDataSet.Tables["UserPrivilege"];

                txtuname.Text = Convert.ToString(dtTable.Rows[0]["LoginId"]);
                txtpassword.Text = Convert.ToString(dtTable.Rows[0]["Password"]);
                txtMobileNumber.Text = Convert.ToString(dtTable.Rows[0]["MobileNumber"]);
                txtEmailAddress.Text = Convert.ToString(dtTable.Rows[0]["EmailAddress"]);
                txtAddress.Text = Convert.ToString(dtTable.Rows[0]["Address"]);
                picBox.Image = Image.FromStream(new MemoryStream((byte[])(dtTable.Rows[0]["UImage"])));
                User = Convert.ToBoolean(dtTable.Rows[0]["AddUser"]);
                Recharge = Convert.ToBoolean(dtTable.Rows[0]["Recharge"]);
                Product = Convert.ToBoolean(dtTable.Rows[0]["AddProduct"]);
                companyRpt = Convert.ToBoolean(dtTable.Rows[0]["companyRpt"]);
                Purchase = Convert.ToBoolean(dtTable.Rows[0]["Purchase"]);
                AddCard = Convert.ToBoolean(dtTable.Rows[0]["AddCard"]);
                ChanPassword = Convert.ToBoolean(dtTable.Rows[0]["ChangePassword"]);
            }
            catch (Exception ex)
            { }

            DisplayUserPrivilege();
        }
        #endregion

        #region DisplayUserPrivilege
        public void DisplayUserPrivilege()
        {
            if (User == true)
            {
                checkBox1.Checked = true;
            }
            if (Recharge == true)
            {
                checkBox10.Checked = true;
            }
            if (Product == true)
            {
                checkBox2.Checked = true;
            }
            if (companyRpt == true)
            {
                checkBox4.Checked = true;
            }
            if (Purchase == true)
            {
                checkBox5.Checked = true;
            }
            if (AddCard == true)
            {
                checkBox6.Checked = true;
            }
            if (ChanPassword == true)
            {
                checkBox9.Checked = true;
            }
        }
        #endregion

        #region Upload Click
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    picBox.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ep) { }
        }
        #endregion

        #region CheckPrivilege
        public void CheckPrivilege()
        {
            if (checkBox1.Checked == true)
            {
                User = true;
            }
            if (checkBox10.Checked == true)
            {
                Recharge = true;
            }
            if (checkBox2.Checked == true)
            {
                Product = true;
            }
            if (checkBox4.Checked == true)
            {
                companyRpt = true;
            }
            if (checkBox5.Checked == true)
            {
                Purchase = true;
            }
            if (checkBox6.Checked == true)
            {
                AddCard = true;
            }
            if (checkBox9.Checked == true)
            {
                ChanPassword = true;
            }
        }
        #endregion

        #region Admin Load
        private void Admin_Load(object sender, EventArgs e)
        {
           
            try
            {
                string sqlString1 = "SELECT DISTINCT LoginId FROM UserPrivilege";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString1, "UserPrivilege");
                dtTable1 = sVariables.sDataSet.Tables["UserPrivilege"];
                for (int j = 0; j <= dtTable1.Rows.Count - 1; j++)
                {
                    idcat.Items.Add(dtTable1.Rows[j]["LoginId"].ToString());

                }
            }
            catch(Exception exp){}
        }
        #endregion

        #region Category Selected Index Changed
        private void idcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                PopulateOtherDetails();
            }
            catch (Exception exp) { }
        }
        #endregion
        #endregion

        #region Update CashToPoint
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                sOleDbCommand.CommandText = "update UserLogin set CTP=@CTP";
                sOleDbCommand.Parameters.Add("@CTP", SqlDbType.VarChar, 10);

                sOleDbCommand.Parameters["@CTP"].Value = textBox1.Text.Trim();
                sFunctions.setOledbConnCommand_Close(sOleDbCommand);
                sFunctions.setMessageBox("CTP rate has been successfully saved.", 1);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Field is empty");
            }

        }
        #endregion

        #region add User Tab
        #region variables
        bool UUser = false;
        bool URecharge = false;
        bool UProduct = false;
        bool UcompanyRpt = false;
        bool UPurchase = false;
        bool UAddCard = false;
        bool UChanPassword = false;
        #endregion

        #region AddUser Click
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                CheckPrivilegeADD();
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Please Enter UserName First");
                    txtuname.Focus();
                }
                else if (txtAddPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password For User");
                    txtAddPassword.Focus();
                }
                else
                {
                    if (picBox1.Image != null)
                    {
                        //using MemoryStream:
                        MemoryStream ms = new MemoryStream();
                        picBox1.Image.Save(ms, ImageFormat.Jpeg);
                        photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                    }

                    sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM UserPrivilege WHERE LoginId LIKE '" + txtUserName.Text.Trim() + "'", "UserPrivilege");
                    int iTips = sVariables.sDataSet.Tables["UserPrivilege"].Rows.Count;
                    if (iTips <= 0)
                    {
                        sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                        sOleDbCommand.CommandText = "insert into UserPrivilege([LoginId],[Password],[MobileNumber],[EmailAddress],[Address],[AddUser],[Recharge],[AddProduct],[companyRpt],[Purchase],[AddCard],[ChangePassword],[UImage]) values(@LoginId,@Password,@MobileNumber,@EmailAddress,@Address,@AddUser,@Recharge,@AddProduct,@companyRpt,@Purchase,@AddCard,@ChangePassword,@UImage)";

                        sOleDbCommand.Parameters.Add("@LoginId", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
                        sOleDbCommand.Parameters.Add("@Address", SqlDbType.VarChar, 250);
                        sOleDbCommand.Parameters.Add("@AddUser", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@Recharge", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@AddProduct", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@companyRpt", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@Purchase", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@AddCard", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@ChangePassword", SqlDbType.Bit);
                        sOleDbCommand.Parameters.Add("@UImage", SqlDbType.VarBinary);

                        sOleDbCommand.Parameters["@LoginId"].Value = txtUserName.Text.Trim();
                        sOleDbCommand.Parameters["@Password"].Value = txtAddPassword.Text.Trim();
                        sOleDbCommand.Parameters["@MobileNumber"].Value = txtMobNum.Text.Trim();
                        sOleDbCommand.Parameters["@EmailAddress"].Value = txtEmailAdd.Text.Trim();
                        sOleDbCommand.Parameters["@Address"].Value = txtAdd.Text.Trim();
                        sOleDbCommand.Parameters["@AddUser"].Value = UUser;
                        sOleDbCommand.Parameters["@Recharge"].Value = URecharge;
                        sOleDbCommand.Parameters["@AddProduct"].Value = UProduct;
                        sOleDbCommand.Parameters["@companyRpt"].Value = UcompanyRpt;
                        sOleDbCommand.Parameters["@Purchase"].Value = UPurchase;
                        sOleDbCommand.Parameters["@AddCard"].Value = UAddCard;
                        sOleDbCommand.Parameters["@ChangePassword"].Value = UChanPassword;
                        sOleDbCommand.Parameters["@UImage"].Value = photo_aray;

                        sFunctions.setOledbConnCommand_Close(sOleDbCommand);

                        sFunctions.setMessageBox("User Has Been Successfully Added.", 1);
                        txtUserName.Clear();
                        txtAddPassword.Clear();
                        txtMobNum.Clear();
                        txtEmailAdd.Clear();
                        txtAdd.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Company Category Name already Exists");
                    }
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region Upload
        private void btnAddUserUpload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    picBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception exp) { }
        }
        #endregion

        #region CheckPrivilege Add User
        public void CheckPrivilegeADD()
        {
            if (checkBox19.Checked == true)
            {
                UUser = true;
            }
            if (checkBox11.Checked == true)
            {
                URecharge = true;
            }
            if (checkBox20.Checked == true)
            {
                UProduct = true;
            }
            if (checkBox17.Checked == true)
            {
                UcompanyRpt = true;
            }
            if (checkBox16.Checked == true)
            {
                UPurchase = true;
            }
            if (checkBox15.Checked == true)
            {
                UAddCard = true;
            }
            if (checkBox12.Checked == true)
            {
                UChanPassword = true;
            }
        }
        #endregion

        #endregion
    }

 }
