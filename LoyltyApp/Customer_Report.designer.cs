namespace LoyltyApp
{
    partial class Customer_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCardid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabCustomerRpt = new System.Windows.Forms.TabControl();
            this.RechargeReport = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RechargeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RechDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RechAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cardid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRechExport = new System.Windows.Forms.Button();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.TransactionReport = new System.Windows.Forms.TabPage();
            this.dgViewTransaction = new System.Windows.Forms.DataGridView();
            this.btnTranExport = new System.Windows.Forms.Button();
            this.btnTranGet = new System.Windows.Forms.Button();
            this.StatementReport = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Card_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rech_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rech_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStatExport = new System.Windows.Forms.Button();
            this.btnStatGet = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            this.tabCustomerRpt.SuspendLayout();
            this.RechargeReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TransactionReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTransaction)).BeginInit();
            this.StatementReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCardid
            // 
            this.lblCardid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCardid.BackColor = System.Drawing.Color.Transparent;
            this.lblCardid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardid.ForeColor = System.Drawing.Color.White;
            this.lblCardid.Location = new System.Drawing.Point(146, 62);
            this.lblCardid.Name = "lblCardid";
            this.lblCardid.Size = new System.Drawing.Size(200, 25);
            this.lblCardid.TabIndex = 3;
            this.lblCardid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Card ID :-";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(548, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(165, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date :-";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "From Date :-";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(548, 88);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(165, 26);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCardid);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(295, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 148);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Customer Report";
            // 
            // tabCustomerRpt
            // 
            this.tabCustomerRpt.Controls.Add(this.RechargeReport);
            this.tabCustomerRpt.Controls.Add(this.TransactionReport);
            this.tabCustomerRpt.Controls.Add(this.StatementReport);
            this.tabCustomerRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCustomerRpt.Location = new System.Drawing.Point(46, 175);
            this.tabCustomerRpt.Name = "tabCustomerRpt";
            this.tabCustomerRpt.SelectedIndex = 0;
            this.tabCustomerRpt.Size = new System.Drawing.Size(1275, 495);
            this.tabCustomerRpt.TabIndex = 13;
            this.tabCustomerRpt.SelectedIndexChanged += new System.EventHandler(this.tabCustomerRpt_SelectedIndexChanged);
            // 
            // RechargeReport
            // 
            this.RechargeReport.BackColor = System.Drawing.Color.Black;
            this.RechargeReport.Controls.Add(this.dataGridView1);
            this.RechargeReport.Controls.Add(this.btnRechExport);
            this.RechargeReport.Controls.Add(this.btnGetReport);
            this.RechargeReport.Location = new System.Drawing.Point(4, 27);
            this.RechargeReport.Name = "RechargeReport";
            this.RechargeReport.Padding = new System.Windows.Forms.Padding(3);
            this.RechargeReport.Size = new System.Drawing.Size(1267, 464);
            this.RechargeReport.TabIndex = 0;
            this.RechargeReport.Text = "Recharge Report";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 26;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RechargeId,
            this.RechDate,
            this.RechAmount,
            this.Cardid});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(308, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(664, 458);
            this.dataGridView1.TabIndex = 14;
            // 
            // RechargeId
            // 
            this.RechargeId.DataPropertyName = "RechargeId";
            this.RechargeId.HeaderText = "Recharge Id";
            this.RechargeId.Name = "RechargeId";
            this.RechargeId.ReadOnly = true;
            this.RechargeId.Width = 150;
            // 
            // RechDate
            // 
            this.RechDate.DataPropertyName = "RechDate";
            this.RechDate.HeaderText = "Recharge Date";
            this.RechDate.Name = "RechDate";
            this.RechDate.ReadOnly = true;
            this.RechDate.Width = 170;
            // 
            // RechAmount
            // 
            this.RechAmount.DataPropertyName = "RechAmount";
            this.RechAmount.HeaderText = "Recharge Amount";
            this.RechAmount.Name = "RechAmount";
            this.RechAmount.ReadOnly = true;
            this.RechAmount.Width = 170;
            // 
            // Cardid
            // 
            this.Cardid.DataPropertyName = "Cardid";
            this.Cardid.HeaderText = "Card Id";
            this.Cardid.Name = "Cardid";
            this.Cardid.ReadOnly = true;
            this.Cardid.Width = 170;
            // 
            // btnRechExport
            // 
            this.btnRechExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRechExport.BackColor = System.Drawing.Color.DarkGray;
            this.btnRechExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRechExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechExport.Location = new System.Drawing.Point(1047, 217);
            this.btnRechExport.Name = "btnRechExport";
            this.btnRechExport.Size = new System.Drawing.Size(163, 50);
            this.btnRechExport.TabIndex = 13;
            this.btnRechExport.Text = "Export To CSV";
            this.btnRechExport.UseVisualStyleBackColor = false;
            this.btnRechExport.Click += new System.EventHandler(this.btnRechExport_Click);
            // 
            // btnGetReport
            // 
            this.btnGetReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetReport.BackColor = System.Drawing.Color.DarkGray;
            this.btnGetReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetReport.Location = new System.Drawing.Point(1063, 142);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(120, 46);
            this.btnGetReport.TabIndex = 12;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseVisualStyleBackColor = false;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // TransactionReport
            // 
            this.TransactionReport.BackColor = System.Drawing.Color.LightSlateGray;
            this.TransactionReport.Controls.Add(this.dgViewTransaction);
            this.TransactionReport.Controls.Add(this.btnTranExport);
            this.TransactionReport.Controls.Add(this.btnTranGet);
            this.TransactionReport.Location = new System.Drawing.Point(4, 27);
            this.TransactionReport.Name = "TransactionReport";
            this.TransactionReport.Padding = new System.Windows.Forms.Padding(3);
            this.TransactionReport.Size = new System.Drawing.Size(1267, 464);
            this.TransactionReport.TabIndex = 1;
            this.TransactionReport.Text = "Transaction Report";
            // 
            // dgViewTransaction
            // 
            this.dgViewTransaction.AllowUserToAddRows = false;
            this.dgViewTransaction.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgViewTransaction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewTransaction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgViewTransaction.BackgroundColor = System.Drawing.Color.Silver;
            this.dgViewTransaction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgViewTransaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewTransaction.ColumnHeadersHeight = 26;
            this.dgViewTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewTransaction.EnableHeadersVisualStyles = false;
            this.dgViewTransaction.Location = new System.Drawing.Point(4, 1);
            this.dgViewTransaction.Name = "dgViewTransaction";
            this.dgViewTransaction.ReadOnly = true;
            this.dgViewTransaction.RowHeadersVisible = false;
            this.dgViewTransaction.Size = new System.Drawing.Size(1106, 458);
            this.dgViewTransaction.TabIndex = 17;
            // 
            // btnTranExport
            // 
            this.btnTranExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTranExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranExport.Location = new System.Drawing.Point(1116, 214);
            this.btnTranExport.Name = "btnTranExport";
            this.btnTranExport.Size = new System.Drawing.Size(145, 56);
            this.btnTranExport.TabIndex = 16;
            this.btnTranExport.Text = "Export To CSV";
            this.btnTranExport.UseVisualStyleBackColor = true;
            this.btnTranExport.Click += new System.EventHandler(this.btnTranExport_Click);
            // 
            // btnTranGet
            // 
            this.btnTranGet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTranGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranGet.Location = new System.Drawing.Point(1126, 142);
            this.btnTranGet.Name = "btnTranGet";
            this.btnTranGet.Size = new System.Drawing.Size(127, 53);
            this.btnTranGet.TabIndex = 15;
            this.btnTranGet.Text = "Get Report";
            this.btnTranGet.UseVisualStyleBackColor = true;
            this.btnTranGet.Click += new System.EventHandler(this.btnTranGet_Click);
            // 
            // StatementReport
            // 
            this.StatementReport.BackColor = System.Drawing.Color.LightSlateGray;
            this.StatementReport.Controls.Add(this.dataGridView3);
            this.StatementReport.Controls.Add(this.btnStatExport);
            this.StatementReport.Controls.Add(this.btnStatGet);
            this.StatementReport.Location = new System.Drawing.Point(4, 27);
            this.StatementReport.Name = "StatementReport";
            this.StatementReport.Size = new System.Drawing.Size(1267, 464);
            this.StatementReport.TabIndex = 2;
            this.StatementReport.Text = "Statement Report";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView3.ColumnHeadersHeight = 26;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Card_ID,
            this.PurchaseDate,
            this.Amount,
            this.CustomerName,
            this.ContactNo,
            this.Email,
            this.Rech_Amount,
            this.Rech_Date});
            this.dataGridView3.EnableHeadersVisualStyles = false;
            this.dataGridView3.Location = new System.Drawing.Point(90, 1);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(995, 458);
            this.dataGridView3.TabIndex = 17;
            // 
            // Card_ID
            // 
            this.Card_ID.DataPropertyName = "CardID";
            this.Card_ID.HeaderText = "CardID";
            this.Card_ID.Name = "Card_ID";
            this.Card_ID.ReadOnly = true;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.DataPropertyName = "PurchaseDate";
            this.PurchaseDate.HeaderText = "Purchase Date";
            this.PurchaseDate.Name = "PurchaseDate";
            this.PurchaseDate.ReadOnly = true;
            this.PurchaseDate.Width = 140;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 150;
            // 
            // ContactNo
            // 
            this.ContactNo.DataPropertyName = "ContactNo";
            this.ContactNo.HeaderText = "Contact No";
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.ReadOnly = true;
            this.ContactNo.Width = 120;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email Address";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 140;
            // 
            // Rech_Amount
            // 
            this.Rech_Amount.DataPropertyName = "RechAmount";
            this.Rech_Amount.HeaderText = "RechAmount";
            this.Rech_Amount.Name = "Rech_Amount";
            this.Rech_Amount.ReadOnly = true;
            this.Rech_Amount.Width = 120;
            // 
            // Rech_Date
            // 
            this.Rech_Date.DataPropertyName = "RechDate";
            this.Rech_Date.HeaderText = "RechDate";
            this.Rech_Date.Name = "Rech_Date";
            this.Rech_Date.ReadOnly = true;
            this.Rech_Date.Width = 120;
            // 
            // btnStatExport
            // 
            this.btnStatExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStatExport.BackColor = System.Drawing.Color.DarkGray;
            this.btnStatExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStatExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatExport.Location = new System.Drawing.Point(1103, 217);
            this.btnStatExport.Name = "btnStatExport";
            this.btnStatExport.Size = new System.Drawing.Size(145, 53);
            this.btnStatExport.TabIndex = 16;
            this.btnStatExport.Text = "Export To CSV";
            this.btnStatExport.UseVisualStyleBackColor = false;
            this.btnStatExport.Click += new System.EventHandler(this.btnStatExport_Click);
            // 
            // btnStatGet
            // 
            this.btnStatGet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStatGet.BackColor = System.Drawing.Color.DarkGray;
            this.btnStatGet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStatGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatGet.Location = new System.Drawing.Point(1109, 146);
            this.btnStatGet.Name = "btnStatGet";
            this.btnStatGet.Size = new System.Drawing.Size(127, 48);
            this.btnStatGet.TabIndex = 15;
            this.btnStatGet.Text = "Get Report";
            this.btnStatGet.UseVisualStyleBackColor = false;
            this.btnStatGet.Click += new System.EventHandler(this.btnStatGet_Click);
            // 
            // Customer_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 682);
            this.Controls.Add(this.tabCustomerRpt);
            this.Controls.Add(this.groupBox1);
            this.Name = "Customer_Report";
            this.Text = "Customer Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCustomerRpt.ResumeLayout(false);
            this.RechargeReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TransactionReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTransaction)).EndInit();
            this.StatementReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCardid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabCustomerRpt;
        private System.Windows.Forms.TabPage RechargeReport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRechExport;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.TabPage TransactionReport;
        private System.Windows.Forms.TabPage StatementReport;
        private System.Windows.Forms.DataGridView dgViewTransaction;
        private System.Windows.Forms.Button btnTranExport;
        private System.Windows.Forms.Button btnTranGet;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnStatExport;
        private System.Windows.Forms.Button btnStatGet;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RechargeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RechDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RechAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cardid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Card_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rech_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rech_Date;

    }
}