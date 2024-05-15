using System;
using System.Collections;
using System.Data;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoyltyApp
{
    class clsVariables 
    {
        //Sql VARIABLES
        public static SqlConnection sOleDbConnection = new SqlConnection();
        public SqlDataAdapter sOleDbDataAdapter = new SqlDataAdapter();
        public SqlCommand sOleDbCommand = new SqlCommand();
        public static SqlDataReader sOleDbDataReader;

        //DATASET VARIABLES
        public DataSet sDataSet = new DataSet();
      //  public dsTables datasetTables = new dsTables();
 
        //INTEGER VARIABLES
        public int iPageCurrent;
        public int iPageNext;
        public int iPagePrevious;
        public int iPageTotal;
        public int iColumnToSort;
        public int iSeconds = 10;
        public int iTimerCount = 0;

        //LONG VARIABLES
        public long sImageFileLength = 0;

        //BYTE VARIABLES
        public static byte[] sBarrImg;

        //STRING VARIABLES
        public static string sMessageBox = "[ E-Purse ]";
        public static string sUsername;
        public static string sUserFullname;
        public static string sUserLogin;
        public static string sUserLogout;
        public static string sUserType;
        public static string sCardid;
        public static string sPurchaseDate;
        public static string sInvoiceNO;
        
        //BOOLEAN VARIABLES
        public static bool boolConnected = false;
        public static bool nonNumberEntered = false;

        //SORT ORDER VARIABLES
        public System.Data.SqlClient.SortOrder OrderOfSort;

        //CASE INSENSITIVE COMPARERER VARIABLES
        public CaseInsensitiveComparer ObjectCompare;

        //FILE DIALOG VARIABLES
        public OpenFileDialog openIMG = new OpenFileDialog();
        public SaveFileDialog saveIMG = new SaveFileDialog();

        
    }
}
