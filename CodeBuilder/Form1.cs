using CodeHelper;
using CodeModel;
using PMDReader;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeBuilder
{
    public partial class Form1 : Form
    {
        public string DbComStr = "PDM";
        PdmModels models;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btConnection_Click(object sender, EventArgs e)
        {
            if (DbComStr == "PDM")
            {
                PdmReader reader = new PdmReader();
                models = reader.ReadFromFile(txtPdm.Text);
                lbTableList.DisplayMember = "Name";
                lbTableList.ValueMember = "Code";
                lbTableList.DataSource = models.Tables;
                //注意，view暂时没有放出来
            }
            else
            {
                #region
                string service = txtService.Text;
                string userName = txtUserName.Text;
                string pwd = txtPwd.Text;
                if (string.IsNullOrEmpty(service) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("请输入必要的信息");
                    return;
                }
                ArrayList dbNameList = new ArrayList();
                //dbNameList.Add("请选择");
                DataTable dbNameTable = new DataTable();
                try
                {
                    string strConnection = $"server={service};database=master; uid={userName};pwd={pwd};Enlist=true";
                    SqlConnection conn = new SqlConnection(strConnection);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select name from master..sysdatabases", conn);
                    lock (adapter)
                    {
                        adapter.Fill(dbNameTable);
                    }
                    foreach (DataRow row in dbNameTable.Rows)
                    {
                        dbNameList.Add(row["name"]);
                    }
                    conn.Close();
                    cbDBList.DisplayMember = "name";
                    cbDBList.ValueMember = "name";
                    cbDBList.DataSource = dbNameList;
                    MessageBox.Show("连接成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        private void btBuilder_Click(object sender, EventArgs e)
        {
            string nameSpace = txtNamespace.Text;
            if (string.IsNullOrEmpty(nameSpace))
            {
                nameSpace = "Model";
            }
            string path = txtCodePath.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (DbComStr == "PDM")
            {
                #region PDM生成代码
                foreach (var item in lbTableList.SelectedItems)
                {
                    var table = item as TableInfo;

                    CreatCodeByPDM(nameSpace, path, table);

                }
                #endregion
            }
            else
            {
                #region Sql Server数据库 生成代码

                string dbName = cbDBList.SelectedItem.ToString();
                if (cbDBList.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择数据库");
                    return;
                }
                string service = txtService.Text;
                string userName = txtUserName.Text;
                string pwd = txtPwd.Text;
                if (string.IsNullOrEmpty(service) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("请输入必要的信息");
                    return;
                }

                try
                {
                    string strConnection = $"server={service};database={dbName}; uid={userName};pwd={pwd};Enlist=true";
                    SqlConnection conn = new SqlConnection(strConnection);
                    conn.Open();
                    foreach (var item in lbTableList.SelectedItems)
                    {
                        string tableName = item.ToString();
                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", conn);
                        DataTable dt = new DataTable();
                        lock (adapter)
                        {
                            adapter.Fill(dt);
                        }
                        if (true)
                        {
                            tableName = tableName.Replace("_", "");
                        }
                        BuilderCode(tableName, nameSpace, path, dt);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                #endregion

            }

            MessageBox.Show("生成成功！");

        }

        private void CreatCodeByPDM(string nameSpace, string filePath, TableInfo table)
        {
            string tableName = table.Code;
            TableHelper helper = new TableHelper(false, false, false);
            NormalModel model = new NormalModel();
            model.NameSpace = nameSpace;
            model.TableName = tableName;
            model.Title = table.Name;
            
            //model.ColumnList = table.Columns;
            // model.SearchColumnsStr
            List<CodeModel.ColumnInfo> list = new List<CodeModel.ColumnInfo>();
            foreach (var row in table.Columns)
            {
                CodeModel.ColumnInfo column = new CodeModel.ColumnInfo();
                column.ColumnName = row.Code;
                column.DBType = row.DataType;
                column.Comment = row.Name;
                column.IsAutoIncrement = row.Identity;
                column.IsMainKey = row.IsPrimaryKey;
                list.Add(column);

            }
            model.ColumnList = list;
            string content = helper.GetClassString(model,true);
            string fileName = filePath +"\\"+ tableName + ".cs";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);

            }

        }


        /// <summary>
        /// SQL Server生成代码
        /// </summary>
        /// <param name="className"></param>
        /// <param name="nameSpace"></param>
        /// <param name="filePath"></param>
        /// <param name="dt"></param>
        private void BuilderCode(string className, string nameSpace, string filePath, DataTable dt)
        {
            TableHelper helper = new TableHelper(false, false, false);
            NormalModel model = new NormalModel();
            model.NameSpace = nameSpace;
            model.TableName = className;
            model.Title = className;
            // model.SearchColumnsStr
            List<CodeModel.ColumnInfo> list = new List<CodeModel.ColumnInfo>();
            foreach (DataRow row in dt.Rows)
            {
                CodeModel.ColumnInfo column = new CodeModel.ColumnInfo();
                column.ColumnName = row["COLUMN_NAME"].ToString();
                column.DBType = row["DATA_TYPE"].ToString();
                list.Add(column);

            }
            model.ColumnList = list;
            string content = helper.GetClassString(model);
            string fileName = filePath + className + ".cs";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
                //fs.Flush();
                //fs.Close();
            }
        }
        private void cbDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = cbDBList.SelectedItem.ToString();
            if (cbDBList.SelectedIndex < 0)
            {
                MessageBox.Show("请选择数据库");
                return;
            }
            string service = txtService.Text;
            string userName = txtUserName.Text;
            string pwd = txtPwd.Text;
            if (string.IsNullOrEmpty(service) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入必要的信息");
                return;
            }

            ArrayList dbNameList = new ArrayList();
            DataTable dbNameTable = new DataTable();
            try
            {
                string strConnection = $"server={service};database={dbName}; uid={userName};pwd={pwd};Enlist=true";
                SqlConnection conn = new SqlConnection(strConnection);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name FROM SysObjects  Where XType='U' orDER BY Name", conn);
                lock (adapter)
                {
                    adapter.Fill(dbNameTable);
                }
                foreach (DataRow row in dbNameTable.Rows)
                {
                    dbNameList.Add(row["name"]);

                }
                conn.Close();
                lbTableList.DisplayMember = "name";
                lbTableList.ValueMember = "name";
                lbTableList.DataSource = dbNameList;
                //MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.ShowDialog();
            txtCodePath.Text = browserDialog.SelectedPath;
        }

        private void btnPdm_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            txtPdm.Text = dialog.FileName;
        }

        private void rbPDM_CheckedChanged(object sender, EventArgs e)
        {
            DbComStr = rbPDM.Text;
        }

        private void rbSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            DbComStr = rbSQLServer.Text;
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbTableList.Items.Count; i++)
            {
                lbTableList.SetSelected(i, true);
            }

        }

        private void btnNoSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbTableList.Items.Count; i++)
            {
                lbTableList.SetSelected(i, false);
            }
        }
    }
}
