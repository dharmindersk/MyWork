using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace ModelCreater
{
    public partial class frmMain : Form
    {
        private readonly BusinessLayer _biz;
        private string _server;
        private string _dataBase;
        private string _userId;
        private string _password;
        private string _authenticationType;
        private string _tableName;
        private Dictionary<string, string> _colList;


        public frmMain()
        {
            InitializeComponent();
            _biz = new BusinessLayer();
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
            txtServer.Text = "rome";
            txtDatabase.Text = "dhotelcontentstaging";
            txtNameSpace.Text = "a";
            txtClassName.Text = "a";

        }


        private void RdbWindowsAuthenticationCheckedChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void RdbSqlAuthenticationCheckedChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void BtnPopulateClick(object sender, EventArgs e)
        {
            _server = txtServer.Text;
            _dataBase = txtDatabase.Text;
            _userId = txtLogin.Text;
            _password = txtPassword.Text;
            _authenticationType = rdbSqlAuthentication.Checked ? "SQL" : "WIN";

            lboxTableSet.DataSource = _biz.GetTableList(_server, _dataBase, _userId, _password, _authenticationType);

        }

        private void BtnGenerateClick(object sender, EventArgs e)
        {
            MessageBox.Show(_biz.GenerateModel(txtNameSpace.Text, txtClassName.Text, _colList)
                                ? "Model generated !!"
                                : "Error occurred !!");
        }

        private void LboxTableSetSelectedIndexChanged(object sender, EventArgs e)
        {
            var lb = sender as ListBox;
            if (lb == null)
                return;

            _server = txtServer.Text;
            _dataBase = txtDatabase.Text;
            _userId = txtLogin.Text;
            _password = txtPassword.Text;
            _tableName = lboxTableSet.SelectedValue.ToString();
            _authenticationType = rdbSqlAuthentication.Checked ? "SQL" : "WIN";
            _tableName = lboxTableSet.GetItemText(lboxTableSet.SelectedItem);

            var columnList = _biz.GetTableColumnList(_server, _dataBase, _userId, _password, _authenticationType, _tableName);
            //  dgvCols.Columns.Add(new DataGridViewColumn { HeaderText = "S No",CellTemplate = new DataGridViewCell()});
            dgvCols.DataSource = new BindingSource(columnList, null);
            dgvCols.Columns[0].HeaderText = "Column Name";
            dgvCols.Columns[1].HeaderText = "Data Type";
            dgvCols.AutoResizeColumn(0);
            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Aqua;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgvCols.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            _colList = columnList;
        }
    }
}
