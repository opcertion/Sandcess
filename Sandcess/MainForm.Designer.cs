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
            labelTitle = new Label();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            iconButtonMaximize = new FontAwesome.Sharp.IconButton();
            iconButtonClose = new FontAwesome.Sharp.IconButton();
            panelContent = new Panel();
            tabControlMainContent = new TabControl();
            tabPageDashboard = new TabPage();
            tabPageFileSystem = new TabPage();
            panelListViewFileSystemFile = new Panel();
            listViewFileSystemFile = new ListView();
            panelFileSystemPermissionSetting = new Panel();
            btnFileSystemPermissionApply = new FontAwesome.Sharp.IconButton();
            tabControlFileSystemPermission = new TabControl();
            tabPageFileSystemPermissionFile = new TabPage();
            tabPageFileSystemPermissionProcess = new TabPage();
            tabPageFileSystemPermissionNetwork = new TabPage();
            tabPageFileSystemPermissionContainer = new TabPage();
            tabPageProcess = new TabPage();
            listViewProcessProcess = new ListView();
            columnHeaderProcessId = new ColumnHeader();
            columnHeaderProcessName = new ColumnHeader();
            columnHeaderProcessPath = new ColumnHeader();
            columnHeaderProcessContainer = new ColumnHeader();
            tabPageContainer = new TabPage();
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
            tabPageProcess.SuspendLayout();
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
            panelTitleBar.Controls.Add(labelTitle);
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
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(17, 25);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(149, 32);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Dashboard";
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
            listViewFileSystemFile.Dock = DockStyle.Fill;
            listViewFileSystemFile.Location = new Point(0, 0);
            listViewFileSystemFile.Name = "listViewFileSystemFile";
            listViewFileSystemFile.Size = new Size(702, 534);
            listViewFileSystemFile.TabIndex = 0;
            listViewFileSystemFile.UseCompatibleStateImageBehavior = false;
            listViewFileSystemFile.View = View.Details;
            // 
            // panelFileSystemPermissionSetting
            // 
            panelFileSystemPermissionSetting.Controls.Add(btnFileSystemPermissionApply);
            panelFileSystemPermissionSetting.Controls.Add(tabControlFileSystemPermission);
            panelFileSystemPermissionSetting.Dock = DockStyle.Right;
            panelFileSystemPermissionSetting.Location = new Point(706, 4);
            panelFileSystemPermissionSetting.Name = "panelFileSystemPermissionSetting";
            panelFileSystemPermissionSetting.Size = new Size(272, 534);
            panelFileSystemPermissionSetting.TabIndex = 0;
            // 
            // btnFileSystemPermissionApply
            // 
            btnFileSystemPermissionApply.Dock = DockStyle.Bottom;
            btnFileSystemPermissionApply.IconChar = FontAwesome.Sharp.IconChar.None;
            btnFileSystemPermissionApply.IconColor = Color.Black;
            btnFileSystemPermissionApply.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileSystemPermissionApply.Location = new Point(0, 505);
            btnFileSystemPermissionApply.Name = "btnFileSystemPermissionApply";
            btnFileSystemPermissionApply.Size = new Size(272, 29);
            btnFileSystemPermissionApply.TabIndex = 1;
            btnFileSystemPermissionApply.Text = "Permission Apply";
            btnFileSystemPermissionApply.UseVisualStyleBackColor = true;
            // 
            // tabControlFileSystemPermission
            // 
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionFile);
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionProcess);
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionNetwork);
            tabControlFileSystemPermission.Controls.Add(tabPageFileSystemPermissionContainer);
            tabControlFileSystemPermission.Dock = DockStyle.Fill;
            tabControlFileSystemPermission.Location = new Point(0, 0);
            tabControlFileSystemPermission.Name = "tabControlFileSystemPermission";
            tabControlFileSystemPermission.SelectedIndex = 0;
            tabControlFileSystemPermission.Size = new Size(272, 534);
            tabControlFileSystemPermission.TabIndex = 0;
            // 
            // tabPageFileSystemPermissionFile
            // 
            tabPageFileSystemPermissionFile.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPageFileSystemPermissionFile.Location = new Point(4, 29);
            tabPageFileSystemPermissionFile.Name = "tabPageFileSystemPermissionFile";
            tabPageFileSystemPermissionFile.Padding = new Padding(3);
            tabPageFileSystemPermissionFile.Size = new Size(264, 501);
            tabPageFileSystemPermissionFile.TabIndex = 0;
            tabPageFileSystemPermissionFile.Text = "File";
            tabPageFileSystemPermissionFile.UseVisualStyleBackColor = true;
            // 
            // tabPageFileSystemPermissionProcess
            // 
            tabPageFileSystemPermissionProcess.Location = new Point(4, 29);
            tabPageFileSystemPermissionProcess.Name = "tabPageFileSystemPermissionProcess";
            tabPageFileSystemPermissionProcess.Padding = new Padding(3);
            tabPageFileSystemPermissionProcess.Size = new Size(264, 501);
            tabPageFileSystemPermissionProcess.TabIndex = 1;
            tabPageFileSystemPermissionProcess.Text = "Process";
            tabPageFileSystemPermissionProcess.UseVisualStyleBackColor = true;
            // 
            // tabPageFileSystemPermissionNetwork
            // 
            tabPageFileSystemPermissionNetwork.Location = new Point(4, 29);
            tabPageFileSystemPermissionNetwork.Name = "tabPageFileSystemPermissionNetwork";
            tabPageFileSystemPermissionNetwork.Padding = new Padding(3);
            tabPageFileSystemPermissionNetwork.Size = new Size(264, 501);
            tabPageFileSystemPermissionNetwork.TabIndex = 2;
            tabPageFileSystemPermissionNetwork.Text = "Net";
            tabPageFileSystemPermissionNetwork.UseVisualStyleBackColor = true;
            // 
            // tabPageFileSystemPermissionContainer
            // 
            tabPageFileSystemPermissionContainer.Location = new Point(4, 29);
            tabPageFileSystemPermissionContainer.Name = "tabPageFileSystemPermissionContainer";
            tabPageFileSystemPermissionContainer.Padding = new Padding(3);
            tabPageFileSystemPermissionContainer.Size = new Size(264, 501);
            tabPageFileSystemPermissionContainer.TabIndex = 3;
            tabPageFileSystemPermissionContainer.Text = "Container";
            tabPageFileSystemPermissionContainer.UseVisualStyleBackColor = true;
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
            listViewProcessProcess.Columns.AddRange(new ColumnHeader[] { columnHeaderProcessId, columnHeaderProcessName, columnHeaderProcessPath, columnHeaderProcessContainer });
            listViewProcessProcess.Dock = DockStyle.Fill;
            listViewProcessProcess.Location = new Point(4, 4);
            listViewProcessProcess.Name = "listViewProcessProcess";
            listViewProcessProcess.Size = new Size(974, 534);
            listViewProcessProcess.TabIndex = 0;
            listViewProcessProcess.UseCompatibleStateImageBehavior = false;
            listViewProcessProcess.View = View.Details;
            // 
            // columnHeaderProcessId
            // 
            columnHeaderProcessId.Text = "Process ID";
            columnHeaderProcessId.Width = 90;
            // 
            // columnHeaderProcessName
            // 
            columnHeaderProcessName.Text = "Process Name";
            columnHeaderProcessName.Width = 350;
            // 
            // columnHeaderProcessPath
            // 
            columnHeaderProcessPath.Text = "Process Path";
            columnHeaderProcessPath.Width = 350;
            // 
            // columnHeaderProcessContainer
            // 
            columnHeaderProcessContainer.Text = "Container";
            columnHeaderProcessContainer.Width = 200;
            // 
            // tabPageContainer
            // 
            tabPageContainer.Location = new Point(4, 24);
            tabPageContainer.Margin = new Padding(4);
            tabPageContainer.Name = "tabPageContainer";
            tabPageContainer.Padding = new Padding(4);
            tabPageContainer.Size = new Size(982, 542);
            tabPageContainer.TabIndex = 3;
            tabPageContainer.Text = "Container";
            tabPageContainer.UseVisualStyleBackColor = true;
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
            Margin = new Padding(4);
            Name = "MainWindow";
            Text = "Sandcess";
            Resize += Form1_Resize;
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
            tabPageProcess.ResumeLayout(false);
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
        private Label labelTitle;
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
        private TabPage tabPageFileSystemPermissionFile;
        private TabPage tabPageFileSystemPermissionProcess;
        private TabPage tabPageFileSystemPermissionNetwork;
        private TabPage tabPageFileSystemPermissionContainer;
        private FontAwesome.Sharp.IconButton btnFileSystemPermissionApply;
        private ListView listViewProcessProcess;
        private ColumnHeader columnHeaderProcessId;
        private ColumnHeader columnHeaderProcessName;
        private ColumnHeader columnHeaderProcessPath;
        private ColumnHeader columnHeaderProcessContainer;
    }
}