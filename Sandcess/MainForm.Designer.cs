namespace Sandcess
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelSideBar = new Panel();
            panelSideMenu = new Panel();
            btnMenuContainer = new FontAwesome.Sharp.IconButton();
            btnMenuProcess = new FontAwesome.Sharp.IconButton();
            btnMenuFileSystem = new FontAwesome.Sharp.IconButton();
            btnMenuDashboard = new FontAwesome.Sharp.IconButton();
            btnMenuEventLog = new FontAwesome.Sharp.IconButton();
            panelSideMenuHeader = new Panel();
            labelHorizontalLine1 = new Label();
            labelProgramName = new Label();
            panelTitleBar = new Panel();
            labelMainTitle = new Label();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            iconButtonMaximize = new FontAwesome.Sharp.IconButton();
            iconButtonClose = new FontAwesome.Sharp.IconButton();
            panelContent = new Panel();
            tabControlMainContent = new TabControl();
            tabPageDashboard = new TabPage();
            tabPageFileSystem = new TabPage();
            panelListViewFileSystemFile = new Panel();
            listViewFileSystemFile = new ListView();
            columnHeaderFileSystemFileFileName = new ColumnHeader();
            columnHeaderFileSystemFileFilePath = new ColumnHeader();
            panelFileSystemPermissionSetting = new Panel();
            btnFileSystemApply = new FontAwesome.Sharp.IconButton();
            tabControlFileSystemPermission = new TabControl();
            tabPageFileSystemPermissionPermission = new TabPage();
            checkedListBoxFileSystemNetworkPermission = new CheckedListBox();
            labelFileSystemNetwork = new Label();
            checkedListBoxFileSystemProcessPermission = new CheckedListBox();
            labelFileSystemProcess = new Label();
            checkedListBoxFileSystemFileSystemPermission = new CheckedListBox();
            labelFileSystemFile = new Label();
            tabPageFileSystemPermissionContainer = new TabPage();
            checkedListBoxFileSystemContainer = new CheckedListBox();
            tabPageProcess = new TabPage();
            listViewProcessProcess = new ListView();
            columnHeaderProcessProcessProcessId = new ColumnHeader();
            columnHeaderProcessProcessProcessName = new ColumnHeader();
            columnHeaderProcessProcessProcessPath = new ColumnHeader();
            tabPageContainer = new TabPage();
            panelContainerSetupMenu = new Panel();
            panelContainerTargetPath = new Panel();
            listViewContainerTargetPath = new ListView();
            columnHeaderContainerTargetPathTargetPath = new ColumnHeader();
            panelContainerTargetFileControlMenu = new Panel();
            btnContainerDeleteTargetPath = new FontAwesome.Sharp.IconButton();
            btnContainerAddTargetPathFolder = new FontAwesome.Sharp.IconButton();
            btnContainerAddTargetPathFile = new FontAwesome.Sharp.IconButton();
            panelContainerAccessiblePath = new Panel();
            listViewContainerAccessiblePath = new ListView();
            columnHeaderContainerAccessiblePathAccessiblePath = new ColumnHeader();
            panelContainerAccessibleFolderControlMenu = new Panel();
            btnContainerDeleteAccessiblePath = new FontAwesome.Sharp.IconButton();
            btnContainerAddAccessiblePathFolder = new FontAwesome.Sharp.IconButton();
            btnContainerApply = new Button();
            btnContainerAddAccessiblePathFile = new FontAwesome.Sharp.IconButton();
            panelContainerContainer = new Panel();
            listViewContainerContainer = new ListView();
            columnHeaderContainerContainerContainer = new ColumnHeader();
            panelContainerContainerControlMenu = new Panel();
            btnContainerDeleteContainer = new FontAwesome.Sharp.IconButton();
            btnContainerAddContainer = new FontAwesome.Sharp.IconButton();
            tabPageEventLog = new TabPage();
            panelSideBar.SuspendLayout();
            panelSideMenu.SuspendLayout();
            panelSideMenuHeader.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelContent.SuspendLayout();
            tabControlMainContent.SuspendLayout();
            tabPageFileSystem.SuspendLayout();
            panelListViewFileSystemFile.SuspendLayout();
            panelFileSystemPermissionSetting.SuspendLayout();
            tabControlFileSystemPermission.SuspendLayout();
            tabPageFileSystemPermissionPermission.SuspendLayout();
            tabPageFileSystemPermissionContainer.SuspendLayout();
            tabPageProcess.SuspendLayout();
            tabPageContainer.SuspendLayout();
            panelContainerSetupMenu.SuspendLayout();
            panelContainerTargetPath.SuspendLayout();
            panelContainerTargetFileControlMenu.SuspendLayout();
            panelContainerAccessiblePath.SuspendLayout();
            panelContainerAccessibleFolderControlMenu.SuspendLayout();
            panelContainerContainer.SuspendLayout();
            panelContainerContainerControlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(30, 30, 30);
            panelSideBar.Controls.Add(panelSideMenu);
            panelSideBar.Controls.Add(panelSideMenuHeader);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.Margin = new Padding(4);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(224, 655);
            panelSideBar.TabIndex = 0;
            // 
            // panelSideMenu
            // 
            panelSideMenu.Controls.Add(btnMenuContainer);
            panelSideMenu.Controls.Add(btnMenuProcess);
            panelSideMenu.Controls.Add(btnMenuFileSystem);
            panelSideMenu.Controls.Add(btnMenuDashboard);
            panelSideMenu.Controls.Add(btnMenuEventLog);
            panelSideMenu.Dock = DockStyle.Fill;
            panelSideMenu.Location = new Point(0, 85);
            panelSideMenu.Margin = new Padding(4);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(224, 570);
            panelSideMenu.TabIndex = 6;
            // 
            // btnMenuContainer
            // 
            btnMenuContainer.Dock = DockStyle.Top;
            btnMenuContainer.FlatAppearance.BorderSize = 0;
            btnMenuContainer.FlatStyle = FlatStyle.Flat;
            btnMenuContainer.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuContainer.ForeColor = Color.White;
            btnMenuContainer.IconChar = FontAwesome.Sharp.IconChar.Clone;
            btnMenuContainer.IconColor = Color.White;
            btnMenuContainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuContainer.IconSize = 30;
            btnMenuContainer.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuContainer.Location = new Point(0, 177);
            btnMenuContainer.Margin = new Padding(4);
            btnMenuContainer.Name = "btnMenuContainer";
            btnMenuContainer.Padding = new Padding(19, 0, 0, 0);
            btnMenuContainer.Size = new Size(224, 59);
            btnMenuContainer.TabIndex = 3;
            btnMenuContainer.Tag = "";
            btnMenuContainer.Text = " Container";
            btnMenuContainer.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuContainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuContainer.UseVisualStyleBackColor = true;
            btnMenuContainer.Click += btnMenuContainer_Click;
            // 
            // btnMenuProcess
            // 
            btnMenuProcess.Dock = DockStyle.Top;
            btnMenuProcess.FlatAppearance.BorderSize = 0;
            btnMenuProcess.FlatStyle = FlatStyle.Flat;
            btnMenuProcess.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuProcess.ForeColor = Color.White;
            btnMenuProcess.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            btnMenuProcess.IconColor = Color.White;
            btnMenuProcess.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuProcess.IconSize = 30;
            btnMenuProcess.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuProcess.Location = new Point(0, 118);
            btnMenuProcess.Margin = new Padding(4);
            btnMenuProcess.Name = "btnMenuProcess";
            btnMenuProcess.Padding = new Padding(19, 0, 0, 0);
            btnMenuProcess.Size = new Size(224, 59);
            btnMenuProcess.TabIndex = 2;
            btnMenuProcess.Tag = "";
            btnMenuProcess.Text = " Process";
            btnMenuProcess.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuProcess.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuProcess.UseVisualStyleBackColor = true;
            btnMenuProcess.Click += btnMenuProcess_Click;
            // 
            // btnMenuFileSystem
            // 
            btnMenuFileSystem.Dock = DockStyle.Top;
            btnMenuFileSystem.FlatAppearance.BorderSize = 0;
            btnMenuFileSystem.FlatStyle = FlatStyle.Flat;
            btnMenuFileSystem.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuFileSystem.ForeColor = Color.White;
            btnMenuFileSystem.IconChar = FontAwesome.Sharp.IconChar.FileShield;
            btnMenuFileSystem.IconColor = Color.White;
            btnMenuFileSystem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuFileSystem.IconSize = 30;
            btnMenuFileSystem.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuFileSystem.Location = new Point(0, 59);
            btnMenuFileSystem.Margin = new Padding(4);
            btnMenuFileSystem.Name = "btnMenuFileSystem";
            btnMenuFileSystem.Padding = new Padding(19, 0, 0, 0);
            btnMenuFileSystem.Size = new Size(224, 59);
            btnMenuFileSystem.TabIndex = 1;
            btnMenuFileSystem.Tag = "";
            btnMenuFileSystem.Text = " File System";
            btnMenuFileSystem.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuFileSystem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuFileSystem.UseVisualStyleBackColor = true;
            btnMenuFileSystem.Click += btnMenuFileSystem_Click;
            // 
            // btnMenuDashboard
            // 
            btnMenuDashboard.BackColor = Color.FromArgb(98, 153, 230);
            btnMenuDashboard.Dock = DockStyle.Top;
            btnMenuDashboard.FlatAppearance.BorderSize = 0;
            btnMenuDashboard.FlatStyle = FlatStyle.Flat;
            btnMenuDashboard.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuDashboard.ForeColor = Color.White;
            btnMenuDashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            btnMenuDashboard.IconColor = Color.White;
            btnMenuDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuDashboard.IconSize = 30;
            btnMenuDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuDashboard.Location = new Point(0, 0);
            btnMenuDashboard.Margin = new Padding(4);
            btnMenuDashboard.Name = "btnMenuDashboard";
            btnMenuDashboard.Padding = new Padding(19, 0, 0, 0);
            btnMenuDashboard.Size = new Size(224, 59);
            btnMenuDashboard.TabIndex = 0;
            btnMenuDashboard.Tag = "";
            btnMenuDashboard.Text = " Dashboard";
            btnMenuDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuDashboard.UseVisualStyleBackColor = false;
            btnMenuDashboard.Click += btnMenuDashboard_Click;
            // 
            // btnMenuEventLog
            // 
            btnMenuEventLog.Dock = DockStyle.Bottom;
            btnMenuEventLog.FlatAppearance.BorderSize = 0;
            btnMenuEventLog.FlatStyle = FlatStyle.Flat;
            btnMenuEventLog.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuEventLog.ForeColor = Color.White;
            btnMenuEventLog.IconChar = FontAwesome.Sharp.IconChar.Map;
            btnMenuEventLog.IconColor = Color.White;
            btnMenuEventLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenuEventLog.IconSize = 30;
            btnMenuEventLog.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuEventLog.Location = new Point(0, 511);
            btnMenuEventLog.Margin = new Padding(4);
            btnMenuEventLog.Name = "btnMenuEventLog";
            btnMenuEventLog.Padding = new Padding(19, 0, 0, 0);
            btnMenuEventLog.Size = new Size(224, 59);
            btnMenuEventLog.TabIndex = 4;
            btnMenuEventLog.Tag = "";
            btnMenuEventLog.Text = " Event Log";
            btnMenuEventLog.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuEventLog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuEventLog.UseVisualStyleBackColor = true;
            btnMenuEventLog.Click += btnMenuEventLog_Click;
            // 
            // panelSideMenuHeader
            // 
            panelSideMenuHeader.Controls.Add(labelHorizontalLine1);
            panelSideMenuHeader.Controls.Add(labelProgramName);
            panelSideMenuHeader.Dock = DockStyle.Top;
            panelSideMenuHeader.Location = new Point(0, 0);
            panelSideMenuHeader.Margin = new Padding(4);
            panelSideMenuHeader.Name = "panelSideMenuHeader";
            panelSideMenuHeader.Size = new Size(224, 85);
            panelSideMenuHeader.TabIndex = 0;
            // 
            // labelHorizontalLine1
            // 
            labelHorizontalLine1.BorderStyle = BorderStyle.Fixed3D;
            labelHorizontalLine1.Dock = DockStyle.Bottom;
            labelHorizontalLine1.Location = new Point(0, 82);
            labelHorizontalLine1.Margin = new Padding(4, 0, 4, 0);
            labelHorizontalLine1.Name = "labelHorizontalLine1";
            labelHorizontalLine1.Size = new Size(224, 3);
            labelHorizontalLine1.TabIndex = 2;
            // 
            // labelProgramName
            // 
            labelProgramName.AutoSize = true;
            labelProgramName.BackColor = Color.Transparent;
            labelProgramName.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelProgramName.ForeColor = Color.White;
            labelProgramName.Location = new Point(40, 25);
            labelProgramName.Margin = new Padding(4, 0, 4, 0);
            labelProgramName.Name = "labelProgramName";
            labelProgramName.Size = new Size(134, 32);
            labelProgramName.TabIndex = 1;
            labelProgramName.Text = "SANDCESS";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(33, 33, 33);
            panelTitleBar.Controls.Add(labelMainTitle);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(iconButtonMaximize);
            panelTitleBar.Controls.Add(iconButtonClose);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(224, 0);
            panelTitleBar.Margin = new Padding(4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(990, 85);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // labelMainTitle
            // 
            labelMainTitle.AutoSize = true;
            labelMainTitle.BackColor = Color.Transparent;
            labelMainTitle.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelMainTitle.ForeColor = Color.White;
            labelMainTitle.Location = new Point(17, 25);
            labelMainTitle.Margin = new Padding(4, 0, 4, 0);
            labelMainTitle.Name = "labelMainTitle";
            labelMainTitle.Size = new Size(149, 32);
            labelMainTitle.TabIndex = 2;
            labelMainTitle.Text = "Dashboard";
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(27, 27, 27);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            btnMinimize.IconColor = Color.White;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.IconSize = 20;
            btnMinimize.Location = new Point(837, 0);
            btnMinimize.Margin = new Padding(4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(54, 32);
            btnMinimize.TabIndex = 0;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // iconButtonMaximize
            // 
            iconButtonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonMaximize.BackColor = Color.FromArgb(27, 27, 27);
            iconButtonMaximize.FlatAppearance.BorderSize = 0;
            iconButtonMaximize.FlatStyle = FlatStyle.Flat;
            iconButtonMaximize.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            iconButtonMaximize.IconColor = Color.White;
            iconButtonMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonMaximize.IconSize = 20;
            iconButtonMaximize.Location = new Point(886, 0);
            iconButtonMaximize.Margin = new Padding(4);
            iconButtonMaximize.Name = "iconButtonMaximize";
            iconButtonMaximize.Size = new Size(54, 32);
            iconButtonMaximize.TabIndex = 1;
            iconButtonMaximize.UseVisualStyleBackColor = false;
            iconButtonMaximize.Click += btnMaximize_Click;
            // 
            // iconButtonClose
            // 
            iconButtonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButtonClose.BackColor = Color.FromArgb(27, 27, 27);
            iconButtonClose.FlatAppearance.BorderSize = 0;
            iconButtonClose.FlatStyle = FlatStyle.Flat;
            iconButtonClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            iconButtonClose.IconColor = Color.White;
            iconButtonClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonClose.IconSize = 20;
            iconButtonClose.Location = new Point(936, 0);
            iconButtonClose.Margin = new Padding(4);
            iconButtonClose.Name = "iconButtonClose";
            iconButtonClose.Size = new Size(54, 32);
            iconButtonClose.TabIndex = 2;
            iconButtonClose.UseVisualStyleBackColor = false;
            iconButtonClose.Click += btnClose_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(26, 26, 26);
            panelContent.Controls.Add(tabControlMainContent);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(224, 85);
            panelContent.Margin = new Padding(4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(990, 570);
            panelContent.TabIndex = 2;
            // 
            // tabControlMainContent
            // 
            tabControlMainContent.Appearance = TabAppearance.FlatButtons;
            tabControlMainContent.Controls.Add(tabPageDashboard);
            tabControlMainContent.Controls.Add(tabPageFileSystem);
            tabControlMainContent.Controls.Add(tabPageProcess);
            tabControlMainContent.Controls.Add(tabPageContainer);
            tabControlMainContent.Controls.Add(tabPageEventLog);
            tabControlMainContent.Dock = DockStyle.Fill;
            tabControlMainContent.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabControlMainContent.ImeMode = ImeMode.NoControl;
            tabControlMainContent.ItemSize = new Size(60, 20);
            tabControlMainContent.Location = new Point(0, 0);
            tabControlMainContent.Margin = new Padding(4);
            tabControlMainContent.Name = "tabControlMainContent";
            tabControlMainContent.SelectedIndex = 0;
            tabControlMainContent.Size = new Size(990, 570);
            tabControlMainContent.SizeMode = TabSizeMode.Fixed;
            tabControlMainContent.TabIndex = 0;
            // 
            // tabPageDashboard
            // 
            tabPageDashboard.Location = new Point(4, 24);
            tabPageDashboard.Margin = new Padding(4);
            tabPageDashboard.Name = "tabPageDashboard";
            tabPageDashboard.Padding = new Padding(4);
            tabPageDashboard.RightToLeft = RightToLeft.No;
            tabPageDashboard.Size = new Size(982, 542);
            tabPageDashboard.TabIndex = 0;
            tabPageDashboard.Text = "Dashboard";
            tabPageDashboard.UseVisualStyleBackColor = true;
            // 
            // tabPageFileSystem
            // 
            tabPageFileSystem.Controls.Add(panelListViewFileSystemFile);
            tabPageFileSystem.Controls.Add(panelFileSystemPermissionSetting);
            tabPageFileSystem.Location = new Point(4, 24);
            tabPageFileSystem.Margin = new Padding(4);
            tabPageFileSystem.Name = "tabPageFileSystem";
            tabPageFileSystem.Padding = new Padding(4);
            tabPageFileSystem.Size = new Size(982, 542);
            tabPageFileSystem.TabIndex = 1;
            tabPageFileSystem.Text = "FileSystem";
            tabPageFileSystem.UseVisualStyleBackColor = true;
            // 
            // panelListViewFileSystemFile
            // 
            panelListViewFileSystemFile.Controls.Add(listViewFileSystemFile);
            panelListViewFileSystemFile.Dock = DockStyle.Fill;
            panelListViewFileSystemFile.Location = new Point(4, 4);
            panelListViewFileSystemFile.Name = "panelListViewFileSystemFile";
            panelListViewFileSystemFile.Size = new Size(702, 534);
            panelListViewFileSystemFile.TabIndex = 1;
            // 
            // listViewFileSystemFile
            // 
            listViewFileSystemFile.Columns.AddRange(new ColumnHeader[] { columnHeaderFileSystemFileFileName, columnHeaderFileSystemFileFilePath });
            listViewFileSystemFile.Dock = DockStyle.Fill;
            listViewFileSystemFile.FullRowSelect = true;
            listViewFileSystemFile.Location = new Point(0, 0);
            listViewFileSystemFile.MultiSelect = false;
            listViewFileSystemFile.Name = "listViewFileSystemFile";
            listViewFileSystemFile.Size = new Size(702, 534);
            listViewFileSystemFile.Sorting = SortOrder.Ascending;
            listViewFileSystemFile.TabIndex = 0;
            listViewFileSystemFile.UseCompatibleStateImageBehavior = false;
            listViewFileSystemFile.View = View.Details;
            listViewFileSystemFile.SelectedIndexChanged += listViewFileSystemFile_SelectedIndexChanged;
            // 
            // columnHeaderFileSystemFileFileName
            // 
            columnHeaderFileSystemFileFileName.Text = "File Name";
            columnHeaderFileSystemFileFileName.Width = 200;
            // 
            // columnHeaderFileSystemFileFilePath
            // 
            columnHeaderFileSystemFileFilePath.Text = "File Path";
            columnHeaderFileSystemFileFilePath.Width = 480;
            // 
            // panelFileSystemPermissionSetting
            // 
            panelFileSystemPermissionSetting.Controls.Add(btnFileSystemApply);
            panelFileSystemPermissionSetting.Controls.Add(tabControlFileSystemPermission);
            panelFileSystemPermissionSetting.Dock = DockStyle.Right;
            panelFileSystemPermissionSetting.Location = new Point(706, 4);
            panelFileSystemPermissionSetting.Name = "panelFileSystemPermissionSetting";
            panelFileSystemPermissionSetting.Size = new Size(272, 534);
            panelFileSystemPermissionSetting.TabIndex = 0;
            // 
            // btnFileSystemApply
            // 
            btnFileSystemApply.Dock = DockStyle.Bottom;
            btnFileSystemApply.IconChar = FontAwesome.Sharp.IconChar.None;
            btnFileSystemApply.IconColor = Color.Black;
            btnFileSystemApply.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileSystemApply.Location = new Point(0, 505);
            btnFileSystemApply.Name = "btnFileSystemApply";
            btnFileSystemApply.Size = new Size(272, 29);
            btnFileSystemApply.TabIndex = 1;
            btnFileSystemApply.Text = "Apply";
            btnFileSystemApply.UseVisualStyleBackColor = true;
            btnFileSystemApply.Click += btnFileSystemPermissionApply_Click;
            // 
            // tabControlFileSystemPermission
            // 
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionPermission);
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionContainer);
            tabControlFileSystemPermission.Dock = DockStyle.Fill;
            tabControlFileSystemPermission.Location = new Point(0, 0);
            tabControlFileSystemPermission.Name = "tabControlFileSystemPermission";
            tabControlFileSystemPermission.SelectedIndex = 0;
            tabControlFileSystemPermission.Size = new Size(272, 534);
            tabControlFileSystemPermission.TabIndex = 0;
            // 
            // tabPageFileSystemPermissionPermission
            // 
            tabPageFileSystemPermissionPermission.Controls.Add(checkedListBoxFileSystemNetworkPermission);
            tabPageFileSystemPermissionPermission.Controls.Add(labelFileSystemNetwork);
            tabPageFileSystemPermissionPermission.Controls.Add(checkedListBoxFileSystemProcessPermission);
            tabPageFileSystemPermissionPermission.Controls.Add(labelFileSystemProcess);
            tabPageFileSystemPermissionPermission.Controls.Add(checkedListBoxFileSystemFileSystemPermission);
            tabPageFileSystemPermissionPermission.Controls.Add(labelFileSystemFile);
            tabPageFileSystemPermissionPermission.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPageFileSystemPermissionPermission.Location = new Point(4, 29);
            tabPageFileSystemPermissionPermission.Name = "tabPageFileSystemPermissionPermission";
            tabPageFileSystemPermissionPermission.Padding = new Padding(3);
            tabPageFileSystemPermissionPermission.Size = new Size(264, 501);
            tabPageFileSystemPermissionPermission.TabIndex = 0;
            tabPageFileSystemPermissionPermission.Text = "Permission";
            tabPageFileSystemPermissionPermission.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxFileSystemNetworkPermission
            // 
            checkedListBoxFileSystemNetworkPermission.CheckOnClick = true;
            checkedListBoxFileSystemNetworkPermission.FormattingEnabled = true;
            checkedListBoxFileSystemNetworkPermission.Items.AddRange(new object[] { "Send", "Receive" });
            checkedListBoxFileSystemNetworkPermission.Location = new Point(20, 347);
            checkedListBoxFileSystemNetworkPermission.Name = "checkedListBoxFileSystemNetworkPermission";
            checkedListBoxFileSystemNetworkPermission.Size = new Size(223, 114);
            checkedListBoxFileSystemNetworkPermission.TabIndex = 5;
            // 
            // labelFileSystemNetwork
            // 
            labelFileSystemNetwork.AutoSize = true;
            labelFileSystemNetwork.Location = new Point(20, 324);
            labelFileSystemNetwork.Name = "labelFileSystemNetwork";
            labelFileSystemNetwork.Size = new Size(57, 20);
            labelFileSystemNetwork.TabIndex = 6;
            labelFileSystemNetwork.Text = "Packet";
            // 
            // checkedListBoxFileSystemProcessPermission
            // 
            checkedListBoxFileSystemProcessPermission.CheckOnClick = true;
            checkedListBoxFileSystemProcessPermission.FormattingEnabled = true;
            checkedListBoxFileSystemProcessPermission.Items.AddRange(new object[] { "Create" });
            checkedListBoxFileSystemProcessPermission.Location = new Point(20, 195);
            checkedListBoxFileSystemProcessPermission.Name = "checkedListBoxFileSystemProcessPermission";
            checkedListBoxFileSystemProcessPermission.Size = new Size(223, 114);
            checkedListBoxFileSystemProcessPermission.TabIndex = 3;
            // 
            // labelFileSystemProcess
            // 
            labelFileSystemProcess.AutoSize = true;
            labelFileSystemProcess.Location = new Point(20, 172);
            labelFileSystemProcess.Name = "labelFileSystemProcess";
            labelFileSystemProcess.Size = new Size(65, 20);
            labelFileSystemProcess.TabIndex = 4;
            labelFileSystemProcess.Text = "Process";
            // 
            // checkedListBoxFileSystemFileSystemPermission
            // 
            checkedListBoxFileSystemFileSystemPermission.CheckOnClick = true;
            checkedListBoxFileSystemFileSystemPermission.FormattingEnabled = true;
            checkedListBoxFileSystemFileSystemPermission.Items.AddRange(new object[] { "Read", "Write", "Move" });
            checkedListBoxFileSystemFileSystemPermission.Location = new Point(20, 41);
            checkedListBoxFileSystemFileSystemPermission.Name = "checkedListBoxFileSystemFileSystemPermission";
            checkedListBoxFileSystemFileSystemPermission.Size = new Size(223, 114);
            checkedListBoxFileSystemFileSystemPermission.TabIndex = 0;
            // 
            // labelFileSystemFile
            // 
            labelFileSystemFile.AutoSize = true;
            labelFileSystemFile.Location = new Point(20, 18);
            labelFileSystemFile.Name = "labelFileSystemFile";
            labelFileSystemFile.Size = new Size(34, 20);
            labelFileSystemFile.TabIndex = 2;
            labelFileSystemFile.Text = "File";
            // 
            // tabPageFileSystemPermissionContainer
            // 
            tabPageFileSystemPermissionContainer.Controls.Add(checkedListBoxFileSystemContainer);
            tabPageFileSystemPermissionContainer.Location = new Point(4, 29);
            tabPageFileSystemPermissionContainer.Name = "tabPageFileSystemPermissionContainer";
            tabPageFileSystemPermissionContainer.Padding = new Padding(3);
            tabPageFileSystemPermissionContainer.Size = new Size(264, 501);
            tabPageFileSystemPermissionContainer.TabIndex = 1;
            tabPageFileSystemPermissionContainer.Text = "Container";
            tabPageFileSystemPermissionContainer.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxFileSystemContainer
            // 
            checkedListBoxFileSystemContainer.CheckOnClick = true;
            checkedListBoxFileSystemContainer.Dock = DockStyle.Fill;
            checkedListBoxFileSystemContainer.FormattingEnabled = true;
            checkedListBoxFileSystemContainer.Location = new Point(3, 3);
            checkedListBoxFileSystemContainer.Name = "checkedListBoxFileSystemContainer";
            checkedListBoxFileSystemContainer.SelectionMode = SelectionMode.None;
            checkedListBoxFileSystemContainer.Size = new Size(258, 495);
            checkedListBoxFileSystemContainer.Sorted = true;
            checkedListBoxFileSystemContainer.TabIndex = 1;
            // 
            // tabPageProcess
            // 
            tabPageProcess.Controls.Add(listViewProcessProcess);
            tabPageProcess.Location = new Point(4, 24);
            tabPageProcess.Margin = new Padding(4);
            tabPageProcess.Name = "tabPageProcess";
            tabPageProcess.Padding = new Padding(4);
            tabPageProcess.Size = new Size(982, 542);
            tabPageProcess.TabIndex = 2;
            tabPageProcess.Text = "Process";
            tabPageProcess.UseVisualStyleBackColor = true;
            // 
            // listViewProcessProcess
            // 
            listViewProcessProcess.Columns.AddRange(new ColumnHeader[] { columnHeaderProcessProcessProcessId, columnHeaderProcessProcessProcessName, columnHeaderProcessProcessProcessPath });
            listViewProcessProcess.Dock = DockStyle.Fill;
            listViewProcessProcess.FullRowSelect = true;
            listViewProcessProcess.Location = new Point(4, 4);
            listViewProcessProcess.MultiSelect = false;
            listViewProcessProcess.Name = "listViewProcessProcess";
            listViewProcessProcess.Size = new Size(974, 534);
            listViewProcessProcess.Sorting = SortOrder.Ascending;
            listViewProcessProcess.TabIndex = 0;
            listViewProcessProcess.UseCompatibleStateImageBehavior = false;
            listViewProcessProcess.View = View.Details;
            listViewProcessProcess.DoubleClick += listViewProcessProcess_DoubleClick;
            // 
            // columnHeaderProcessProcessProcessId
            // 
            columnHeaderProcessProcessProcessId.Text = "Process ID";
            columnHeaderProcessProcessProcessId.Width = 90;
            // 
            // columnHeaderProcessProcessProcessName
            // 
            columnHeaderProcessProcessProcessName.Text = "Process Name";
            columnHeaderProcessProcessProcessName.Width = 350;
            // 
            // columnHeaderProcessProcessProcessPath
            // 
            columnHeaderProcessProcessProcessPath.Text = "Process Path";
            columnHeaderProcessProcessProcessPath.Width = 520;
            // 
            // tabPageContainer
            // 
            tabPageContainer.Controls.Add(panelContainerSetupMenu);
            tabPageContainer.Controls.Add(panelContainerContainer);
            tabPageContainer.Location = new Point(4, 24);
            tabPageContainer.Margin = new Padding(4);
            tabPageContainer.Name = "tabPageContainer";
            tabPageContainer.Padding = new Padding(4);
            tabPageContainer.Size = new Size(982, 542);
            tabPageContainer.TabIndex = 3;
            tabPageContainer.Text = "Container";
            tabPageContainer.UseVisualStyleBackColor = true;
            // 
            // panelContainerSetupMenu
            // 
            panelContainerSetupMenu.Controls.Add(panelContainerTargetPath);
            panelContainerSetupMenu.Controls.Add(panelContainerAccessiblePath);
            panelContainerSetupMenu.Dock = DockStyle.Fill;
            panelContainerSetupMenu.Location = new Point(254, 4);
            panelContainerSetupMenu.Name = "panelContainerSetupMenu";
            panelContainerSetupMenu.Size = new Size(724, 534);
            panelContainerSetupMenu.TabIndex = 2;
            // 
            // panelContainerTargetPath
            // 
            panelContainerTargetPath.Controls.Add(listViewContainerTargetPath);
            panelContainerTargetPath.Controls.Add(panelContainerTargetFileControlMenu);
            panelContainerTargetPath.Dock = DockStyle.Fill;
            panelContainerTargetPath.Location = new Point(0, 0);
            panelContainerTargetPath.Name = "panelContainerTargetPath";
            panelContainerTargetPath.Size = new Size(724, 259);
            panelContainerTargetPath.TabIndex = 1;
            // 
            // listViewContainerTargetPath
            // 
            listViewContainerTargetPath.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerTargetPathTargetPath });
            listViewContainerTargetPath.Dock = DockStyle.Fill;
            listViewContainerTargetPath.FullRowSelect = true;
            listViewContainerTargetPath.Location = new Point(0, 0);
            listViewContainerTargetPath.MultiSelect = false;
            listViewContainerTargetPath.Name = "listViewContainerTargetPath";
            listViewContainerTargetPath.Size = new Size(724, 229);
            listViewContainerTargetPath.Sorting = SortOrder.Ascending;
            listViewContainerTargetPath.TabIndex = 6;
            listViewContainerTargetPath.UseCompatibleStateImageBehavior = false;
            listViewContainerTargetPath.View = View.Details;
            // 
            // columnHeaderContainerTargetPathTargetPath
            // 
            columnHeaderContainerTargetPathTargetPath.Text = "Target Path";
            columnHeaderContainerTargetPathTargetPath.Width = 700;
            // 
            // panelContainerTargetFileControlMenu
            // 
            panelContainerTargetFileControlMenu.Controls.Add(btnContainerDeleteTargetPath);
            panelContainerTargetFileControlMenu.Controls.Add(btnContainerAddTargetPathFolder);
            panelContainerTargetFileControlMenu.Controls.Add(btnContainerAddTargetPathFile);
            panelContainerTargetFileControlMenu.Dock = DockStyle.Bottom;
            panelContainerTargetFileControlMenu.Location = new Point(0, 229);
            panelContainerTargetFileControlMenu.Name = "panelContainerTargetFileControlMenu";
            panelContainerTargetFileControlMenu.Size = new Size(724, 30);
            panelContainerTargetFileControlMenu.TabIndex = 5;
            // 
            // btnContainerDeleteTargetPath
            // 
            btnContainerDeleteTargetPath.BackColor = Color.Transparent;
            btnContainerDeleteTargetPath.Dock = DockStyle.Left;
            btnContainerDeleteTargetPath.FlatAppearance.BorderSize = 0;
            btnContainerDeleteTargetPath.FlatStyle = FlatStyle.Flat;
            btnContainerDeleteTargetPath.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerDeleteTargetPath.ForeColor = Color.Transparent;
            btnContainerDeleteTargetPath.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnContainerDeleteTargetPath.IconColor = SystemColors.ControlDarkDark;
            btnContainerDeleteTargetPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerDeleteTargetPath.IconSize = 30;
            btnContainerDeleteTargetPath.Location = new Point(56, 0);
            btnContainerDeleteTargetPath.Margin = new Padding(4);
            btnContainerDeleteTargetPath.Name = "btnContainerDeleteTargetPath";
            btnContainerDeleteTargetPath.Size = new Size(28, 30);
            btnContainerDeleteTargetPath.TabIndex = 8;
            btnContainerDeleteTargetPath.Tag = "";
            btnContainerDeleteTargetPath.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerDeleteTargetPath.UseVisualStyleBackColor = false;
            btnContainerDeleteTargetPath.Click += btnContainerDeleteTargetPath_Click;
            // 
            // btnContainerAddTargetPathFolder
            // 
            btnContainerAddTargetPathFolder.BackColor = Color.Transparent;
            btnContainerAddTargetPathFolder.Dock = DockStyle.Left;
            btnContainerAddTargetPathFolder.FlatAppearance.BorderSize = 0;
            btnContainerAddTargetPathFolder.FlatStyle = FlatStyle.Flat;
            btnContainerAddTargetPathFolder.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerAddTargetPathFolder.ForeColor = Color.Transparent;
            btnContainerAddTargetPathFolder.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnContainerAddTargetPathFolder.IconColor = SystemColors.ControlDarkDark;
            btnContainerAddTargetPathFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerAddTargetPathFolder.IconSize = 30;
            btnContainerAddTargetPathFolder.Location = new Point(28, 0);
            btnContainerAddTargetPathFolder.Margin = new Padding(4);
            btnContainerAddTargetPathFolder.Name = "btnContainerAddTargetPathFolder";
            btnContainerAddTargetPathFolder.Size = new Size(28, 30);
            btnContainerAddTargetPathFolder.TabIndex = 7;
            btnContainerAddTargetPathFolder.Tag = "";
            btnContainerAddTargetPathFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerAddTargetPathFolder.UseVisualStyleBackColor = false;
            btnContainerAddTargetPathFolder.Click += btnContainerAddTargetPathFolder_Click;
            // 
            // btnContainerAddTargetPathFile
            // 
            btnContainerAddTargetPathFile.BackColor = Color.Transparent;
            btnContainerAddTargetPathFile.Dock = DockStyle.Left;
            btnContainerAddTargetPathFile.FlatAppearance.BorderSize = 0;
            btnContainerAddTargetPathFile.FlatStyle = FlatStyle.Flat;
            btnContainerAddTargetPathFile.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerAddTargetPathFile.ForeColor = Color.Transparent;
            btnContainerAddTargetPathFile.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnContainerAddTargetPathFile.IconColor = SystemColors.ControlDarkDark;
            btnContainerAddTargetPathFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerAddTargetPathFile.IconSize = 30;
            btnContainerAddTargetPathFile.Location = new Point(0, 0);
            btnContainerAddTargetPathFile.Margin = new Padding(4);
            btnContainerAddTargetPathFile.Name = "btnContainerAddTargetPathFile";
            btnContainerAddTargetPathFile.Size = new Size(28, 30);
            btnContainerAddTargetPathFile.TabIndex = 6;
            btnContainerAddTargetPathFile.Tag = "";
            btnContainerAddTargetPathFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerAddTargetPathFile.UseVisualStyleBackColor = false;
            btnContainerAddTargetPathFile.Click += btnContainerAddTargetPathFile_Click;
            // 
            // panelContainerAccessiblePath
            // 
            panelContainerAccessiblePath.Controls.Add(listViewContainerAccessiblePath);
            panelContainerAccessiblePath.Controls.Add(panelContainerAccessibleFolderControlMenu);
            panelContainerAccessiblePath.Dock = DockStyle.Bottom;
            panelContainerAccessiblePath.Location = new Point(0, 259);
            panelContainerAccessiblePath.Name = "panelContainerAccessiblePath";
            panelContainerAccessiblePath.Size = new Size(724, 275);
            panelContainerAccessiblePath.TabIndex = 0;
            // 
            // listViewContainerAccessiblePath
            // 
            listViewContainerAccessiblePath.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerAccessiblePathAccessiblePath });
            listViewContainerAccessiblePath.Dock = DockStyle.Fill;
            listViewContainerAccessiblePath.FullRowSelect = true;
            listViewContainerAccessiblePath.Location = new Point(0, 0);
            listViewContainerAccessiblePath.MultiSelect = false;
            listViewContainerAccessiblePath.Name = "listViewContainerAccessiblePath";
            listViewContainerAccessiblePath.Size = new Size(724, 245);
            listViewContainerAccessiblePath.Sorting = SortOrder.Ascending;
            listViewContainerAccessiblePath.TabIndex = 3;
            listViewContainerAccessiblePath.UseCompatibleStateImageBehavior = false;
            listViewContainerAccessiblePath.View = View.Details;
            // 
            // columnHeaderContainerAccessiblePathAccessiblePath
            // 
            columnHeaderContainerAccessiblePathAccessiblePath.Text = "Accessible Path";
            columnHeaderContainerAccessiblePathAccessiblePath.Width = 700;
            // 
            // panelContainerAccessibleFolderControlMenu
            // 
            panelContainerAccessibleFolderControlMenu.Controls.Add(btnContainerDeleteAccessiblePath);
            panelContainerAccessibleFolderControlMenu.Controls.Add(btnContainerAddAccessiblePathFolder);
            panelContainerAccessibleFolderControlMenu.Controls.Add(btnContainerApply);
            panelContainerAccessibleFolderControlMenu.Controls.Add(btnContainerAddAccessiblePathFile);
            panelContainerAccessibleFolderControlMenu.Dock = DockStyle.Bottom;
            panelContainerAccessibleFolderControlMenu.Location = new Point(0, 245);
            panelContainerAccessibleFolderControlMenu.Name = "panelContainerAccessibleFolderControlMenu";
            panelContainerAccessibleFolderControlMenu.Size = new Size(724, 30);
            panelContainerAccessibleFolderControlMenu.TabIndex = 0;
            // 
            // btnContainerDeleteAccessiblePath
            // 
            btnContainerDeleteAccessiblePath.BackColor = Color.Transparent;
            btnContainerDeleteAccessiblePath.Dock = DockStyle.Left;
            btnContainerDeleteAccessiblePath.FlatAppearance.BorderSize = 0;
            btnContainerDeleteAccessiblePath.FlatStyle = FlatStyle.Flat;
            btnContainerDeleteAccessiblePath.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerDeleteAccessiblePath.ForeColor = Color.Transparent;
            btnContainerDeleteAccessiblePath.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnContainerDeleteAccessiblePath.IconColor = SystemColors.ControlDarkDark;
            btnContainerDeleteAccessiblePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerDeleteAccessiblePath.IconSize = 30;
            btnContainerDeleteAccessiblePath.Location = new Point(56, 0);
            btnContainerDeleteAccessiblePath.Margin = new Padding(4);
            btnContainerDeleteAccessiblePath.Name = "btnContainerDeleteAccessiblePath";
            btnContainerDeleteAccessiblePath.Size = new Size(28, 30);
            btnContainerDeleteAccessiblePath.TabIndex = 8;
            btnContainerDeleteAccessiblePath.Tag = "";
            btnContainerDeleteAccessiblePath.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerDeleteAccessiblePath.UseVisualStyleBackColor = false;
            btnContainerDeleteAccessiblePath.Click += btnContainerDeleteAccessiblePath_Click;
            // 
            // btnContainerAddAccessiblePathFolder
            // 
            btnContainerAddAccessiblePathFolder.BackColor = Color.Transparent;
            btnContainerAddAccessiblePathFolder.Dock = DockStyle.Left;
            btnContainerAddAccessiblePathFolder.FlatAppearance.BorderSize = 0;
            btnContainerAddAccessiblePathFolder.FlatStyle = FlatStyle.Flat;
            btnContainerAddAccessiblePathFolder.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerAddAccessiblePathFolder.ForeColor = Color.Transparent;
            btnContainerAddAccessiblePathFolder.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnContainerAddAccessiblePathFolder.IconColor = SystemColors.ControlDarkDark;
            btnContainerAddAccessiblePathFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerAddAccessiblePathFolder.IconSize = 30;
            btnContainerAddAccessiblePathFolder.Location = new Point(28, 0);
            btnContainerAddAccessiblePathFolder.Margin = new Padding(4);
            btnContainerAddAccessiblePathFolder.Name = "btnContainerAddAccessiblePathFolder";
            btnContainerAddAccessiblePathFolder.Size = new Size(28, 30);
            btnContainerAddAccessiblePathFolder.TabIndex = 6;
            btnContainerAddAccessiblePathFolder.Tag = "";
            btnContainerAddAccessiblePathFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerAddAccessiblePathFolder.UseVisualStyleBackColor = false;
            btnContainerAddAccessiblePathFolder.Click += btnContainerAddAccessiblePathFolder_Click;
            // 
            // btnContainerApply
            // 
            btnContainerApply.Dock = DockStyle.Right;
            btnContainerApply.Location = new Point(515, 0);
            btnContainerApply.Name = "btnContainerApply";
            btnContainerApply.Size = new Size(209, 30);
            btnContainerApply.TabIndex = 7;
            btnContainerApply.Text = "Apply";
            btnContainerApply.UseVisualStyleBackColor = true;
            btnContainerApply.Click += btnContainerApply_Click;
            // 
            // btnContainerAddAccessiblePathFile
            // 
            btnContainerAddAccessiblePathFile.BackColor = Color.Transparent;
            btnContainerAddAccessiblePathFile.Dock = DockStyle.Left;
            btnContainerAddAccessiblePathFile.FlatAppearance.BorderSize = 0;
            btnContainerAddAccessiblePathFile.FlatStyle = FlatStyle.Flat;
            btnContainerAddAccessiblePathFile.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerAddAccessiblePathFile.ForeColor = Color.Transparent;
            btnContainerAddAccessiblePathFile.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnContainerAddAccessiblePathFile.IconColor = SystemColors.ControlDarkDark;
            btnContainerAddAccessiblePathFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerAddAccessiblePathFile.IconSize = 30;
            btnContainerAddAccessiblePathFile.Location = new Point(0, 0);
            btnContainerAddAccessiblePathFile.Margin = new Padding(4);
            btnContainerAddAccessiblePathFile.Name = "btnContainerAddAccessiblePathFile";
            btnContainerAddAccessiblePathFile.Size = new Size(28, 30);
            btnContainerAddAccessiblePathFile.TabIndex = 5;
            btnContainerAddAccessiblePathFile.Tag = "";
            btnContainerAddAccessiblePathFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerAddAccessiblePathFile.UseVisualStyleBackColor = false;
            btnContainerAddAccessiblePathFile.Click += btnContainerAddAccessiblePathFile_Click;
            // 
            // panelContainerContainer
            // 
            panelContainerContainer.Controls.Add(listViewContainerContainer);
            panelContainerContainer.Controls.Add(panelContainerContainerControlMenu);
            panelContainerContainer.Dock = DockStyle.Left;
            panelContainerContainer.Location = new Point(4, 4);
            panelContainerContainer.Name = "panelContainerContainer";
            panelContainerContainer.Size = new Size(250, 534);
            panelContainerContainer.TabIndex = 1;
            // 
            // listViewContainerContainer
            // 
            listViewContainerContainer.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerContainerContainer });
            listViewContainerContainer.Dock = DockStyle.Fill;
            listViewContainerContainer.FullRowSelect = true;
            listViewContainerContainer.Location = new Point(0, 0);
            listViewContainerContainer.MultiSelect = false;
            listViewContainerContainer.Name = "listViewContainerContainer";
            listViewContainerContainer.Size = new Size(250, 504);
            listViewContainerContainer.Sorting = SortOrder.Ascending;
            listViewContainerContainer.TabIndex = 4;
            listViewContainerContainer.UseCompatibleStateImageBehavior = false;
            listViewContainerContainer.View = View.Details;
            listViewContainerContainer.SelectedIndexChanged += listViewContainerContainer_SelectedIndexChanged;
            // 
            // columnHeaderContainerContainerContainer
            // 
            columnHeaderContainerContainerContainer.Text = "Container";
            columnHeaderContainerContainerContainer.Width = 230;
            // 
            // panelContainerContainerControlMenu
            // 
            panelContainerContainerControlMenu.Controls.Add(btnContainerDeleteContainer);
            panelContainerContainerControlMenu.Controls.Add(btnContainerAddContainer);
            panelContainerContainerControlMenu.Dock = DockStyle.Bottom;
            panelContainerContainerControlMenu.Location = new Point(0, 504);
            panelContainerContainerControlMenu.Name = "panelContainerContainerControlMenu";
            panelContainerContainerControlMenu.Size = new Size(250, 30);
            panelContainerContainerControlMenu.TabIndex = 2;
            // 
            // btnContainerDeleteContainer
            // 
            btnContainerDeleteContainer.BackColor = Color.Transparent;
            btnContainerDeleteContainer.Dock = DockStyle.Left;
            btnContainerDeleteContainer.FlatAppearance.BorderSize = 0;
            btnContainerDeleteContainer.FlatStyle = FlatStyle.Flat;
            btnContainerDeleteContainer.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerDeleteContainer.ForeColor = Color.Transparent;
            btnContainerDeleteContainer.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnContainerDeleteContainer.IconColor = SystemColors.ControlDarkDark;
            btnContainerDeleteContainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerDeleteContainer.IconSize = 30;
            btnContainerDeleteContainer.Location = new Point(28, 0);
            btnContainerDeleteContainer.Margin = new Padding(4);
            btnContainerDeleteContainer.Name = "btnContainerDeleteContainer";
            btnContainerDeleteContainer.Size = new Size(28, 30);
            btnContainerDeleteContainer.TabIndex = 7;
            btnContainerDeleteContainer.Tag = "";
            btnContainerDeleteContainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerDeleteContainer.UseVisualStyleBackColor = false;
            btnContainerDeleteContainer.Click += btnContainerDeleteContainer_Click;
            // 
            // btnContainerAddContainer
            // 
            btnContainerAddContainer.BackColor = Color.Transparent;
            btnContainerAddContainer.Dock = DockStyle.Left;
            btnContainerAddContainer.FlatAppearance.BorderSize = 0;
            btnContainerAddContainer.FlatStyle = FlatStyle.Flat;
            btnContainerAddContainer.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnContainerAddContainer.ForeColor = Color.Transparent;
            btnContainerAddContainer.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnContainerAddContainer.IconColor = SystemColors.ControlDarkDark;
            btnContainerAddContainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnContainerAddContainer.IconSize = 30;
            btnContainerAddContainer.Location = new Point(0, 0);
            btnContainerAddContainer.Margin = new Padding(4);
            btnContainerAddContainer.Name = "btnContainerAddContainer";
            btnContainerAddContainer.Size = new Size(28, 30);
            btnContainerAddContainer.TabIndex = 6;
            btnContainerAddContainer.Tag = "";
            btnContainerAddContainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContainerAddContainer.UseVisualStyleBackColor = false;
            btnContainerAddContainer.Click += btnContainerAddContainer_Click;
            // 
            // tabPageEventLog
            // 
            tabPageEventLog.Location = new Point(4, 24);
            tabPageEventLog.Margin = new Padding(4);
            tabPageEventLog.Name = "tabPageEventLog";
            tabPageEventLog.Padding = new Padding(4);
            tabPageEventLog.Size = new Size(982, 542);
            tabPageEventLog.TabIndex = 4;
            tabPageEventLog.Text = "EventLog";
            tabPageEventLog.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1214, 655);
            Controls.Add(panelContent);
            Controls.Add(panelTitleBar);
            Controls.Add(panelSideBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "MainWindow";
            Text = "Sandcess";
            FormClosing += MainWindow_FormClosing;
            panelSideBar.ResumeLayout(false);
            panelSideMenu.ResumeLayout(false);
            panelSideMenuHeader.ResumeLayout(false);
            panelSideMenuHeader.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelContent.ResumeLayout(false);
            tabControlMainContent.ResumeLayout(false);
            tabPageFileSystem.ResumeLayout(false);
            panelListViewFileSystemFile.ResumeLayout(false);
            panelFileSystemPermissionSetting.ResumeLayout(false);
            tabControlFileSystemPermission.ResumeLayout(false);
            tabPageFileSystemPermissionPermission.ResumeLayout(false);
            tabPageFileSystemPermissionPermission.PerformLayout();
            tabPageFileSystemPermissionContainer.ResumeLayout(false);
            tabPageProcess.ResumeLayout(false);
            tabPageContainer.ResumeLayout(false);
            panelContainerSetupMenu.ResumeLayout(false);
            panelContainerTargetPath.ResumeLayout(false);
            panelContainerTargetFileControlMenu.ResumeLayout(false);
            panelContainerAccessiblePath.ResumeLayout(false);
            panelContainerAccessibleFolderControlMenu.ResumeLayout(false);
            panelContainerContainer.ResumeLayout(false);
            panelContainerContainerControlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideBar;
        private Panel panelTitleBar;
        private Panel panelSideMenuHeader;
        private Panel panelContent;
        private Label labelProgramName;
        private FontAwesome.Sharp.IconButton btnMenuDashboard;
        private FontAwesome.Sharp.IconButton btnMenuProcess;
        private FontAwesome.Sharp.IconButton btnMenuFileSystem;
        private FontAwesome.Sharp.IconButton btnMenuContainer;
        private FontAwesome.Sharp.IconButton iconButtonClose;
        private FontAwesome.Sharp.IconButton iconButtonMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private Label labelMainTitle;
        private Label labelHorizontalLine1;
        private FontAwesome.Sharp.IconButton btnMenuEventLog;
        private TabControl tabControlMainContent;
        private TabPage tabPageDashboard;
        private TabPage tabPageFileSystem;
        private TabPage tabPageProcess;
        private TabPage tabPageContainer;
        private TabPage tabPageEventLog;
        private Panel panelSideMenu;
        private Panel panelListViewFileSystemFile;
        private ListView listViewFileSystemFile;
        private Panel panelFileSystemPermissionSetting;
        private TabControl tabControlFileSystemPermission;
        private TabPage tabPageFileSystemPermissionPermission;
        private FontAwesome.Sharp.IconButton btnFileSystemApply;
        private ListView listViewProcessProcess;
        private ColumnHeader columnHeaderProcessProcessProcessId;
        private ColumnHeader columnHeaderProcessProcessProcessName;
        private ColumnHeader columnHeaderProcessProcessProcessPath;
        private CheckedListBox checkedListBoxFileSystemFileSystemPermission;
        private Label labelFileSystemFile;
        private ColumnHeader columnHeaderFileSystemFileFileName;
        private ColumnHeader columnHeaderFileSystemFileFilePath;
        private CheckedListBox checkedListBoxFileSystemProcessPermission;
        private Label labelFileSystemProcess;
        private CheckedListBox checkedListBoxFileSystemNetworkPermission;
        private Label labelFileSystemNetwork;
        private Panel panelContainerAccessiblePath;
        private FontAwesome.Sharp.IconButton btnContainerAddAccessiblePathFile;
        private ListView listViewContainerAccessiblePath;
        private ColumnHeader columnHeaderContainerAccessiblePathAccessiblePath;
        private Panel panelContainerAccessibleFolderControlMenu;
        private Button btnContainerApply;
        private FontAwesome.Sharp.IconButton btnContainerAddAccessiblePathFolder;
        private ListView listViewContainerTargetPath;
        private ColumnHeader columnHeaderContainerTargetPathTargetPath;
        private Panel panelContainerTargetFileControlMenu;
        private FontAwesome.Sharp.IconButton btnContainerAddTargetPathFolder;
        private FontAwesome.Sharp.IconButton btnContainerAddTargetPathFile;
        private TabPage tabPageFileSystemPermissionContainer;
        private CheckedListBox checkedListBoxFileSystemContainer;
        private Panel panelContainerContainer;
        private ListView listViewContainerContainer;
        private ColumnHeader columnHeaderContainerContainerContainer;
        private Panel panelContainerContainerControlMenu;
        private FontAwesome.Sharp.IconButton btnContainerDeleteContainer;
        private FontAwesome.Sharp.IconButton btnContainerAddContainer;
        private Panel panelContainerSetupMenu;
        private Panel panelContainerTargetPath;
        private FontAwesome.Sharp.IconButton btnContainerDeleteTargetPath;
        private FontAwesome.Sharp.IconButton btnContainerDeleteAccessiblePath;
    }
}