namespace CodeBuilder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btBuilder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDBList = new System.Windows.Forms.ComboBox();
            this.lbTableList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dbPannel = new System.Windows.Forms.Panel();
            this.rbSQLServer = new System.Windows.Forms.RadioButton();
            this.rbPDM = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPdm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPdm = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtCodePath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnNoSelect = new System.Windows.Forms.Button();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.dbPannel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConnection
            // 
            this.btConnection.Location = new System.Drawing.Point(924, 277);
            this.btConnection.Name = "btConnection";
            this.btConnection.Size = new System.Drawing.Size(176, 41);
            this.btConnection.TabIndex = 0;
            this.btConnection.Text = "连接";
            this.btConnection.UseVisualStyleBackColor = true;
            this.btConnection.Click += new System.EventHandler(this.btConnection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(99, 14);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(379, 28);
            this.txtService.TabIndex = 2;
            this.txtService.Text = "192.168.199.101\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "登录名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "命名空间：";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(146, 335);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(379, 28);
            this.txtNamespace.TabIndex = 6;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(99, 124);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(379, 28);
            this.txtPwd.TabIndex = 7;
            this.txtPwd.Text = "061740";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(99, 72);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(379, 28);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.Text = "sa";
            // 
            // btBuilder
            // 
            this.btBuilder.Location = new System.Drawing.Point(924, 578);
            this.btBuilder.Name = "btBuilder";
            this.btBuilder.Size = new System.Drawing.Size(176, 41);
            this.btBuilder.TabIndex = 9;
            this.btBuilder.Text = "生成";
            this.btBuilder.UseVisualStyleBackColor = true;
            this.btBuilder.Click += new System.EventHandler(this.btBuilder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "数据库列表：";
            // 
            // cbDBList
            // 
            this.cbDBList.FormattingEnabled = true;
            this.cbDBList.Items.AddRange(new object[] {
            "name"});
            this.cbDBList.Location = new System.Drawing.Point(566, 72);
            this.cbDBList.Name = "cbDBList";
            this.cbDBList.Size = new System.Drawing.Size(176, 26);
            this.cbDBList.TabIndex = 12;
            this.cbDBList.SelectedIndexChanged += new System.EventHandler(this.cbDBList_SelectedIndexChanged);
            // 
            // lbTableList
            // 
            this.lbTableList.FormattingEnabled = true;
            this.lbTableList.ItemHeight = 18;
            this.lbTableList.Location = new System.Drawing.Point(12, 399);
            this.lbTableList.Name = "lbTableList";
            this.lbTableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTableList.Size = new System.Drawing.Size(813, 418);
            this.lbTableList.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "表名：";
            // 
            // dbPannel
            // 
            this.dbPannel.Controls.Add(this.cbDBList);
            this.dbPannel.Controls.Add(this.label5);
            this.dbPannel.Controls.Add(this.label1);
            this.dbPannel.Controls.Add(this.txtUserName);
            this.dbPannel.Controls.Add(this.txtService);
            this.dbPannel.Controls.Add(this.txtPwd);
            this.dbPannel.Controls.Add(this.label2);
            this.dbPannel.Controls.Add(this.label3);
            this.dbPannel.Location = new System.Drawing.Point(12, 90);
            this.dbPannel.Name = "dbPannel";
            this.dbPannel.Size = new System.Drawing.Size(781, 185);
            this.dbPannel.TabIndex = 15;
            // 
            // rbSQLServer
            // 
            this.rbSQLServer.AutoSize = true;
            this.rbSQLServer.Location = new System.Drawing.Point(29, 27);
            this.rbSQLServer.Name = "rbSQLServer";
            this.rbSQLServer.Size = new System.Drawing.Size(114, 22);
            this.rbSQLServer.TabIndex = 16;
            this.rbSQLServer.Text = "SQLServer";
            this.rbSQLServer.UseVisualStyleBackColor = true;
            this.rbSQLServer.CheckedChanged += new System.EventHandler(this.rbSQLServer_CheckedChanged);
            // 
            // rbPDM
            // 
            this.rbPDM.AutoSize = true;
            this.rbPDM.Checked = true;
            this.rbPDM.Location = new System.Drawing.Point(199, 27);
            this.rbPDM.Name = "rbPDM";
            this.rbPDM.Size = new System.Drawing.Size(60, 22);
            this.rbPDM.TabIndex = 19;
            this.rbPDM.TabStop = true;
            this.rbPDM.Text = "PMD";
            this.rbPDM.UseVisualStyleBackColor = true;
            this.rbPDM.CheckedChanged += new System.EventHandler(this.rbPDM_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "数据源：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbPDM);
            this.panel1.Controls.Add(this.rbSQLServer);
            this.panel1.Location = new System.Drawing.Point(95, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 62);
            this.panel1.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "存放路径：";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtPdm
            // 
            this.txtPdm.Location = new System.Drawing.Point(903, 43);
            this.txtPdm.Name = "txtPdm";
            this.txtPdm.Size = new System.Drawing.Size(263, 28);
            this.txtPdm.TabIndex = 25;
            this.txtPdm.Text = "C:\\Work\\和弘\\HHCRM\\pdm\\HHCRM.pdm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(795, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "PDM路径：";
            // 
            // btnPdm
            // 
            this.btnPdm.Location = new System.Drawing.Point(924, 90);
            this.btnPdm.Name = "btnPdm";
            this.btnPdm.Size = new System.Drawing.Size(138, 44);
            this.btnPdm.TabIndex = 13;
            this.btnPdm.Text = "选择PMD";
            this.btnPdm.UseVisualStyleBackColor = true;
            this.btnPdm.Click += new System.EventHandler(this.btnPdm_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(569, 285);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(185, 39);
            this.btnChooseFile.TabIndex = 26;
            this.btnChooseFile.Text = "选择生成文件路径";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtCodePath
            // 
            this.txtCodePath.Location = new System.Drawing.Point(146, 285);
            this.txtCodePath.Name = "txtCodePath";
            this.txtCodePath.Size = new System.Drawing.Size(379, 28);
            this.txtCodePath.TabIndex = 27;
            this.txtCodePath.Text = "C:\\Users\\marks\\Desktop\\Test\\";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Title = "请选择文件夹";
            // 
            // btnNoSelect
            // 
            this.btnNoSelect.Location = new System.Drawing.Point(924, 500);
            this.btnNoSelect.Name = "btnNoSelect";
            this.btnNoSelect.Size = new System.Drawing.Size(176, 41);
            this.btnNoSelect.TabIndex = 28;
            this.btnNoSelect.Text = "全不选";
            this.btnNoSelect.UseVisualStyleBackColor = true;
            this.btnNoSelect.Click += new System.EventHandler(this.btnNoSelect_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(924, 430);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(176, 41);
            this.btnAllSelect.TabIndex = 29;
            this.btnAllSelect.Text = "全选";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 852);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.btnNoSelect);
            this.Controls.Add(this.txtCodePath);
            this.Controls.Add(this.btnPdm);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.txtPdm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btConnection);
            this.Controls.Add(this.dbPannel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTableList);
            this.Controls.Add(this.btBuilder);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "代码生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dbPannel.ResumeLayout(false);
            this.dbPannel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btBuilder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDBList;
        private System.Windows.Forms.ListBox lbTableList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel dbPannel;
        private System.Windows.Forms.RadioButton rbSQLServer;
        private System.Windows.Forms.RadioButton rbPDM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPdm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPdm;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtCodePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnNoSelect;
        private System.Windows.Forms.Button btnAllSelect;
    }
}

