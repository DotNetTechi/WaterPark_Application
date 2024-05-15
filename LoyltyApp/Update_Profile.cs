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
    public partial class Update_Profile : Form
    {
        #region variable and initialization
        private BindingSource bindingSource1 = new BindingSource();
        byte[] photo_aray;
       
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

        public Update_Profile()
        {
            InitializeComponent();
            PopulateOtherDetails();
            
        }
        #endregion

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
                //sCommands.getOleDbRecordCount(sVariables.sDataSet, "SELECT * FROM UserPrivilege WHERE LoginId LIKE '" + txtuname.Text.Trim() + "'", "UserPrivilege");
                //int iTips = sVariables.sDataSet.Tables["UserPrivilege"].Rows.Count;
                //if (iTips <= 0)
                //{

                sFunctions.setOledbConnCommand_Open(sOleDbCommand);

                sOleDbCommand.CommandText = "update UserPrivilege set Password=@Password,MobileNumber=@MobileNumber,EmailAddress=@EmailAddress,Address=@Address,AddUser=@AddUser,Recharge=@Recharge,AddProduct=@AddProduct,companyRpt=@companyRpt,Purchase=@Purchase,AddCard=@AddCard,ChangePassword=@ChangePassword,UImage=@UImage where LoginId='" + txtuname.Text + "'";

                //sOleDbCommand.Parameters.Add("@LoginId",SqlDbType.VarChar,50);
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

                //sOleDbCommand.Parameters["@LoginId"].Value = txtuname.Text.Trim();
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
                string sqlString = "SELECT * FROM UserPrivilege WHERE LoginId='" + clsVariables.sUsername + "'";
                sCommands.setOledbCommand(sVariables.sDataSet, sVariables.sOleDbDataAdapter, sqlString, "UserPrivilege");
                DataTable dtTable = sVariables.sDataSet.Tables["UserPrivilege"];

                txtuname.Text = Convert.ToString(dtTable.Rows[0]["LoginId"]);
                txtpassword.Text = Convert.ToString(dtTable.Rows[0]["Password"]);
                txtMobileNumber.Text = Convert.ToString(dtTable.Rows[0]["MobileNumber"]);
                txtEmailAddress.Text = Convert.ToString(dtTable.Rows[0]["EmailAddress"]);
                txtAddress.Text = Convert.ToString(dtTable.Rows[0]["Address"]);
                User = Convert.ToBoolean(dtTable.Rows[0]["AddUser"]);
                Recharge = Convert.ToBoolean(dtTable.Rows[0]["Recharge"]);
                Product = Convert.ToBoolean(dtTable.Rows[0]["AddProduct"]);
                companyRpt = Convert.ToBoolean(dtTable.Rows[0]["companyRpt"]);
                Purchase = Convert.ToBoolean(dtTable.Rows[0]["Purchase"]);
                AddCard = Convert.ToBoolean(dtTable.Rows[0]["AddCard"]);
                ChanPassword = Convert.ToBoolean(dtTable.Rows[0]["ChangePassword"]);
                picBox.Image = Image.FromStream(new MemoryStream((byte[])(dtTable.Rows[0]["UImage"])));
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
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
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
                openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
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
    }

 }
