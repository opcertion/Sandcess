namespace Sandcess
{
    partial class FileSystemForm
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
            tabControlSettings = new TabControl();
            tabPagePermission = new TabPage();
            checkedListBoxNetworkPermission = new CheckedListBox();
            labelNetwork = new Label();
            checkedListBoxProcessPermission = new CheckedListBox();
            labelProcess = new Label();
            checkedListBoxFilePermission = new CheckedListBox();
            labelFile = new Label();
            tabPageContainer = new TabPage();
            checkedListBoxContainer = new CheckedListBox();
            panelSettings = new Panel();
            btnFileApply = new FontAwesome.Sharp.IconButton();
            listViewFile = new ListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderFilePath = new ColumnHeader();
            panelFileList = new Panel();
            tabControlSettings.SuspendLayout();
            tabPagePermission.SuspendLayout();
            tabPageContainer.SuspendLayout();
            panelSettings.SuspendLayout();
            panelFileList.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlSettings
            // 
            tabControlSettings.Controls.Add(tabPagePermission);
            tabControlSettings.Controls.Add(tabPageContainer);
            tabControlSettings.Dock = DockStyle.Fill;
            tabControlSettings.Location = new Point(0, 0);
            tabControlSettings.Name = "tabControlSettings";
            tabControlSettings.SelectedIndex = 0;
            tabControlSettings.Size = new Size(272, 570);
            tabControlSettings.TabIndex = 0;
            // 
            // tabPagePermission
            // 
            tabPagePermission.Controls.Add(checkedListBoxNetworkPermission);
            tabPagePermission.Controls.Add(labelNetwork);
            tabPagePermission.Controls.Add(checkedListBoxProcessPermission);
            tabPagePermission.Controls.Add(labelProcess);
            tabPagePermission.Controls.Add(checkedListBoxFilePermission);
            tabPagePermission.Controls.Add(labelFile);
            tabPagePermission.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPagePermission.Location = new Point(4, 29);
            tabPagePermission.Name = "tabPagePermission";
            tabPagePermission.Padding = new Padding(3);
            tabPagePermission.Size = new Size(264, 537);
            tabPagePermission.TabIndex = 0;
            tabPagePermission.Text = "Permission";
            tabPagePermission.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxNetworkPermission
            // 
            checkedListBoxNetworkPermission.CheckOnClick = true;
            checkedListBoxNetworkPermission.FormattingEnabled = true;
            checkedListBoxNetworkPermission.Items.AddRange(new object[] { "Send", "Receive" });
            checkedListBoxNetworkPermission.Location = new Point(20, 350);
            checkedListBoxNetworkPermission.Name = "checkedListBoxNetworkPermission";
            checkedListBoxNetworkPermission.Size = new Size(223, 114);
            checkedListBoxNetworkPermission.TabIndex = 5;
            // 
            // labelNetwork
            // 
            labelNetwork.AutoSize = true;
            labelNetwork.Location = new Point(26, 330);
            labelNetwork.Name = "labelNetwork";
            labelNetwork.Size = new Size(72, 20);
            labelNetwork.TabIndex = 6;
            labelNetwork.Text = "Network";
            // 
            // checkedListBoxProcessPermission
            // 
            checkedListBoxProcessPermission.CheckOnClick = true;
            checkedListBoxProcessPermission.FormattingEnabled = true;
            checkedListBoxProcessPermission.Items.AddRange(new object[] { "Create" });
            checkedListBoxProcessPermission.Location = new Point(20, 198);
            checkedListBoxProcessPermission.Name = "checkedListBoxProcessPermission";
            checkedListBoxProcessPermission.Size = new Size(223, 114);
            checkedListBoxProcessPermission.TabIndex = 3;
            // 
            // labelProcess
            // 
            labelProcess.AutoSize = true;
            labelProcess.Location = new Point(26, 178);
            labelProcess.Name = "labelProcess";
            labelProcess.Size = new Size(65, 20);
            labelProcess.TabIndex = 4;
            labelProcess.Text = "Process";
            // 
            // checkedListBoxFilePermission
            // 
            checkedListBoxFilePermission.CheckOnClick = true;
            checkedListBoxFilePermission.FormattingEnabled = true;
            checkedListBoxFilePermission.Items.AddRange(new object[] { "Read", "Write", "Move" });
            checkedListBoxFilePermission.Location = new Point(20, 44);
            checkedListBoxFilePermission.Name = "checkedListBoxFilePermission";
            checkedListBoxFilePermission.Size = new Size(223, 114);
            checkedListBoxFilePermission.TabIndex = 0;
            // 
            // labelFile
            // 
            labelFile.AutoSize = true;
            labelFile.Location = new Point(26, 24);
            labelFile.Name = "labelFile";
            labelFile.Size = new Size(34, 20);
            labelFile.TabIndex = 2;
            labelFile.Text = "File";
            // 
            // tabPageContainer
            // 
            tabPageContainer.Controls.Add(checkedListBoxContainer);
            tabPageContainer.Location = new Point(4, 29);
            tabPageContainer.Name = "tabPageContainer";
            tabPageContainer.Padding = new Padding(3);
            tabPageContainer.Size = new Size(264, 537);
            tabPageContainer.TabIndex = 1;
            tabPageContainer.Text = "Container";
            tabPageContainer.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxContainer
            // 
            checkedListBoxContainer.CheckOnClick = true;
            checkedListBoxContainer.Dock = DockStyle.Fill;
            checkedListBoxContainer.FormattingEnabled = true;
            checkedListBoxContainer.Location = new Point(3, 3);
            checkedListBoxContainer.Name = "checkedListBoxContainer";
            checkedListBoxContainer.SelectionMode = SelectionMode.None;
            checkedListBoxContainer.Size = new Size(258, 531);
            checkedListBoxContainer.Sorted = true;
            checkedListBoxContainer.TabIndex = 1;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(btnFileApply);
            panelSettings.Controls.Add(tabControlSettings);
            panelSettings.Dock = DockStyle.Right;
            panelSettings.Location = new Point(835, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(272, 570);
            panelSettings.TabIndex = 1;
            // 
            // btnFileApply
            // 
            btnFileApply.Dock = DockStyle.Bottom;
            btnFileApply.IconChar = FontAwesome.Sharp.IconChar.None;
            btnFileApply.IconColor = Color.Black;
            btnFileApply.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileApply.Location = new Point(0, 541);
            btnFileApply.Name = "btnFileApply";
            btnFileApply.Size = new Size(272, 29);
            btnFileApply.TabIndex = 1;
            btnFileApply.Text = "Apply";
            btnFileApply.UseVisualStyleBackColor = true;
            btnFileApply.Click += btnFileApply_Click;
            // 
            // listViewFile
            // 
            listViewFile.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderFilePath });
            listViewFile.Dock = DockStyle.Fill;
            listViewFile.FullRowSelect = true;
            listViewFile.Location = new Point(0, 0);
            listViewFile.MultiSelect = false;
            listViewFile.Name = "listViewFile";
            listViewFile.Size = new Size(835, 570);
            listViewFile.Sorting = SortOrder.Ascending;
            listViewFile.TabIndex = 2;
            listViewFile.UseCompatibleStateImageBehavior = false;
            listViewFile.View = View.Details;
            listViewFile.SelectedIndexChanged += listViewFile_SelectedIndexChanged;
            listViewFile.DoubleClick += listViewFile_DoubleClick;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "File Name";
            columnHeaderFileName.Width = 200;
            // 
            // columnHeaderFilePath
            // 
            columnHeaderFilePath.Text = "File Path";
            columnHeaderFilePath.Width = 480;
            // 
            // panelFileList
            // 
            panelFileList.Controls.Add(listViewFile);
            panelFileList.Dock = DockStyle.Fill;
            panelFileList.Location = new Point(0, 0);
            panelFileList.Name = "panelFileList";
            panelFileList.Size = new Size(835, 570);
            panelFileList.TabIndex = 3;
            // 
            // FileSystemForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 570);
            Controls.Add(panelFileList);
            Controls.Add(panelSettings);
            Name = "FileSystemForm";
            Text = "FileSystemForm";
            tabControlSettings.ResumeLayout(false);
            tabPagePermission.ResumeLayout(false);
            tabPagePermission.PerformLayout();
            tabPageContainer.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelFileList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlSettings;
        private TabPage tabPagePermission;
        private CheckedListBox checkedListBoxNetworkPermission;
        private Label labelNetwork;
        private CheckedListBox checkedListBoxProcessPermission;
        private Label labelProcess;
        private CheckedListBox checkedListBoxFilePermission;
        private Label labelFile;
        private TabPage tabPageContainer;
        private CheckedListBox checkedListBoxContainer;
        private Panel panelSettings;
        private FontAwesome.Sharp.IconButton btnFileApply;
        private ListView listViewFile;
        private ColumnHeader columnHeaderFileName;
        private ColumnHeader columnHeaderFilePath;
        private Panel panelFileList;
    }
}