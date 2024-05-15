using System;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoyltyApp
{
   public class clsFunctions
    {
        //CLASS VARIABLES
        clsCommands sCommands = new clsCommands();
        clsVariables sVariables = new clsVariables();

        public void setOledbConnCommand_Open(SqlCommand sCommand)
        {
            clsConnections.setOleDbConnectionState();
            clsVariables.sOleDbConnection.Open();
            sCommand.Connection = clsVariables.sOleDbConnection;
        }

        public void setOledbConnCommand_Close(SqlCommand sCommand)
        {
            sCommand.ExecuteNonQuery();
            sCommand.Parameters.Clear();
            sCommand.Connection.Close();
            clsVariables.sOleDbConnection.Close();
        }
        public void setEmptyField(string sField)
        {
            MessageBox.Show(sField + " is empty.Please check it!", clsVariables.sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void setMessageBox(string sMessage, int iWhich)
        {
            switch (iWhich)
            {
                case 1:
                    MessageBox.Show(sMessage, clsVariables.sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(sMessage, clsVariables.sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show(sMessage, clsVariables.sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public void setCreateError(string sErrorMessage, string sLocation, string sFileName)
        {
            try
            {
                MessageBox.Show(sErrorMessage, clsVariables.sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);

                FileStream sFileStream = new FileStream(sLocation + sFileName + ".err", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sStreamWriter = new StreamWriter(sFileStream);

                // Write to the file using StreamWriter class 
                sStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                sStreamWriter.WriteLine(sErrorMessage);
                sStreamWriter.Flush();
            }
            catch (Exception ex) { }
        }

    }
}
