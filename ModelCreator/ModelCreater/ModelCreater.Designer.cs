namespace ModelCreater
{
    partial class frmMain
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
            this.grpBoxAuth = new System.Windows.Forms.GroupBox();
            this.rdbSqlAuthentication = new System.Windows.Forms.RadioButton();
            this.rdbWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lboxTableSet = new System.Windows.Forms.ListBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.grpBoxConn = new System.Windows.Forms.GroupBox();
            this.grpBoxTable = new System.Windows.Forms.GroupBox();
            this.grpBoxCols = new System.Windows.Forms.GroupBox();
            this.dgvCols = new System.Windows.Forms.DataGridView();
            this.grpBoxFile = new System.Windows.Forms.GroupBox();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.lblClassname = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.grpBoxAuth.SuspendLayout();
            this.grpBoxConn.SuspendLayout();
            this.grpBoxTable.SuspendLayout();
            this.grpBoxCols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCols)).BeginInit();
            this.grpBoxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxAuth
            // 
            this.grpBoxAuth.Controls.Add(this.rdbSqlAuthentication);
            this.grpBoxAuth.Controls.Add(this.rdbWindowsAuthentication);
            this.grpBoxAuth.Controls.Add(this.lblPassword);
            this.grpBoxAuth.Controls.Add(this.lblLogin);
            this.grpBoxAuth.Controls.Add(this.txtLogin);
            this.grpBoxAuth.Controls.Add(this.txtPassword);
            this.grpBoxAuth.Location = new System.Drawing.Point(17, 117);
            this.grpBoxAuth.Name = "grpBoxAuth";
            this.grpBoxAuth.Size = new System.Drawing.Size(301, 152);
            this.grpBoxAuth.TabIndex = 0;
            this.grpBoxAuth.TabStop = false;
            this.grpBoxAuth.Text = "Authentication";
            // 
            // rdbSqlAuthentication
            // 
            this.rdbSqlAuthentication.AutoSize = true;
            this.rdbSqlAuthentication.Location = new System.Drawing.Point(20, 42);
            this.rdbSqlAuthentication.Name = "rdbSqlAuthentication";
            this.rdbSqlAuthentication.Size = new System.Drawing.Size(151, 17);
            this.rdbSqlAuthentication.TabIndex = 3;
            this.rdbSqlAuthentication.Text = "SQL Server Authentication";
            this.rdbSqlAuthentication.UseVisualStyleBackColor = true;
            this.rdbSqlAuthentication.CheckedChanged += new System.EventHandler(this.RdbSqlAuthenticationCheckedChanged);
            // 
            // rdbWindowsAuthentication
            // 
            this.rdbWindowsAuthentication.AutoSize = true;
            this.rdbWindowsAuthentication.Checked = true;
            this.rdbWindowsAuthentication.Location = new System.Drawing.Point(20, 19);
            this.rdbWindowsAuthentication.Name = "rdbWindowsAuthentication";
            this.rdbWindowsAuthentication.Size = new System.Drawing.Size(140, 17);
            this.rdbWindowsAuthentication.TabIndex = 2;
            this.rdbWindowsAuthentication.TabStop = true;
            this.rdbWindowsAuthentication.Text = "Windows Authentication";
            this.rdbWindowsAuthentication.UseVisualStyleBackColor = true;
            this.rdbWindowsAuthentication.CheckedChanged += new System.EventHandler(this.RdbWindowsAuthenticationCheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(28, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password :";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(28, 74);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(70, 13);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login Name :";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(109, 74);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(180, 20);
            this.txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(28, 22);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(44, 13);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Server :";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(28, 55);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(59, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database :";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(109, 19);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(180, 20);
            this.txtServer.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(108, 52);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(181, 20);
            this.txtDatabase.TabIndex = 1;
            // 
            // lboxTableSet
            // 
            this.lboxTableSet.FormattingEnabled = true;
            this.lboxTableSet.Location = new System.Drawing.Point(6, 19);
            this.lboxTableSet.Name = "lboxTableSet";
            this.lboxTableSet.Size = new System.Drawing.Size(305, 134);
            this.lboxTableSet.TabIndex = 6;
            this.lboxTableSet.SelectedIndexChanged += new System.EventHandler(this.LboxTableSetSelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(205, 406);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(60, 406);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(75, 23);
            this.btnPopulate.TabIndex = 7;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.BtnPopulateClick);
            // 
            // grpBoxConn
            // 
            this.grpBoxConn.Controls.Add(this.txtServer);
            this.grpBoxConn.Controls.Add(this.txtDatabase);
            this.grpBoxConn.Controls.Add(this.lblDatabase);
            this.grpBoxConn.Controls.Add(this.lblServer);
            this.grpBoxConn.Location = new System.Drawing.Point(17, 12);
            this.grpBoxConn.Name = "grpBoxConn";
            this.grpBoxConn.Size = new System.Drawing.Size(301, 99);
            this.grpBoxConn.TabIndex = 9;
            this.grpBoxConn.TabStop = false;
            this.grpBoxConn.Text = "Location";
            // 
            // grpBoxTable
            // 
            this.grpBoxTable.Controls.Add(this.lboxTableSet);
            this.grpBoxTable.Location = new System.Drawing.Point(346, 13);
            this.grpBoxTable.Name = "grpBoxTable";
            this.grpBoxTable.Size = new System.Drawing.Size(317, 163);
            this.grpBoxTable.TabIndex = 10;
            this.grpBoxTable.TabStop = false;
            this.grpBoxTable.Text = "Tables";
            // 
            // grpBoxCols
            // 
            this.grpBoxCols.Controls.Add(this.dgvCols);
            this.grpBoxCols.Location = new System.Drawing.Point(346, 191);
            this.grpBoxCols.Name = "grpBoxCols";
            this.grpBoxCols.Size = new System.Drawing.Size(317, 244);
            this.grpBoxCols.TabIndex = 0;
            this.grpBoxCols.TabStop = false;
            this.grpBoxCols.Text = "Columns";
            // 
            // dgvCols
            // 
            this.dgvCols.AllowUserToAddRows = false;
            this.dgvCols.AllowUserToDeleteRows = false;
            this.dgvCols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCols.Location = new System.Drawing.Point(6, 19);
            this.dgvCols.Name = "dgvCols";
            this.dgvCols.ReadOnly = true;
            this.dgvCols.Size = new System.Drawing.Size(305, 219);
            this.dgvCols.TabIndex = 0;
            // 
            // grpBoxFile
            // 
            this.grpBoxFile.Controls.Add(this.lblNameSpace);
            this.grpBoxFile.Controls.Add(this.lblClassname);
            this.grpBoxFile.Controls.Add(this.txtNameSpace);
            this.grpBoxFile.Controls.Add(this.txtClassName);
            this.grpBoxFile.Location = new System.Drawing.Point(17, 290);
            this.grpBoxFile.Name = "grpBoxFile";
            this.grpBoxFile.Size = new System.Drawing.Size(301, 100);
            this.grpBoxFile.TabIndex = 1;
            this.grpBoxFile.TabStop = false;
            this.grpBoxFile.Text = "Content";
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(28, 22);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(72, 13);
            this.lblNameSpace.TabIndex = 11;
            this.lblNameSpace.Text = "NameSpace :";
            // 
            // lblClassname
            // 
            this.lblClassname.AutoSize = true;
            this.lblClassname.Location = new System.Drawing.Point(28, 53);
            this.lblClassname.Name = "lblClassname";
            this.lblClassname.Size = new System.Drawing.Size(66, 13);
            this.lblClassname.TabIndex = 12;
            this.lblClassname.Text = "ClassName :";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(108, 19);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(181, 20);
            this.txtNameSpace.TabIndex = 13;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(109, 50);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(180, 20);
            this.txtClassName.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 447);
            this.Controls.Add(this.grpBoxFile);
            this.Controls.Add(this.grpBoxCols);
            this.Controls.Add(this.grpBoxTable);
            this.Controls.Add(this.grpBoxConn);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpBoxAuth);
            this.Name = "frmMain";
            this.Text = "ModelCreater";
            this.grpBoxAuth.ResumeLayout(false);
            this.grpBoxAuth.PerformLayout();
            this.grpBoxConn.ResumeLayout(false);
            this.grpBoxConn.PerformLayout();
            this.grpBoxTable.ResumeLayout(false);
            this.grpBoxCols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCols)).EndInit();
            this.grpBoxFile.ResumeLayout(false);
            this.grpBoxFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxAuth;
        private System.Windows.Forms.RadioButton rdbSqlAuthentication;
        private System.Windows.Forms.RadioButton rdbWindowsAuthentication;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.ListBox lboxTableSet;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.GroupBox grpBoxConn;
        private System.Windows.Forms.GroupBox grpBoxTable;
        private System.Windows.Forms.GroupBox grpBoxCols;
        private System.Windows.Forms.DataGridView dgvCols;
        private System.Windows.Forms.GroupBox grpBoxFile;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.Label lblClassname;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.TextBox txtClassName;
    }
}

