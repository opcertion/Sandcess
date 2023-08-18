namespace Sandcess
{
    partial class ContainerForm
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
            btnAddContainer = new FontAwesome.Sharp.IconButton();
            panelContainerControlMenu = new Panel();
            btnDeleteContainer = new FontAwesome.Sharp.IconButton();
            btnDeleteAccessiblePath = new FontAwesome.Sharp.IconButton();
            btnAddAccessiblePathFolder = new FontAwesome.Sharp.IconButton();
            btnAddAccessiblePathFile = new FontAwesome.Sharp.IconButton();
            panelAccessiblePath = new Panel();
            listViewAccessiblePath = new ListView();
            columnHeaderContainerAccessiblePathAccessiblePath = new ColumnHeader();
            panelAccessiblePathControlMenu = new Panel();
            btnDeleteTargetPath = new FontAwesome.Sharp.IconButton();
            btnAddTargetPathFolder = new FontAwesome.Sharp.IconButton();
            listViewTargetPath = new ListView();
            columnHeaderContainerTargetPathTargetPath = new ColumnHeader();
            panelTargetPathControlMenu = new Panel();
            btnAddTargetPathFile = new FontAwesome.Sharp.IconButton();
            panelTargetPath = new Panel();
            panelContainerList = new Panel();
            listViewContainer = new ListView();
            columnHeaderContainerContainerContainer = new ColumnHeader();
            panelContainerControlMenu.SuspendLayout();
            panelAccessiblePath.SuspendLayout();
            panelAccessiblePathControlMenu.SuspendLayout();
            panelTargetPathControlMenu.SuspendLayout();
            panelTargetPath.SuspendLayout();
            panelContainerList.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddContainer
            // 
            btnAddContainer.BackColor = Color.Transparent;
            btnAddContainer.Dock = DockStyle.Left;
            btnAddContainer.FlatAppearance.BorderSize = 0;
            btnAddContainer.FlatStyle = FlatStyle.Flat;
            btnAddContainer.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddContainer.ForeColor = Color.Transparent;
            btnAddContainer.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnAddContainer.IconColor = SystemColors.ControlDarkDark;
            btnAddContainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddContainer.IconSize = 30;
            btnAddContainer.Location = new Point(0, 0);
            btnAddContainer.Margin = new Padding(4);
            btnAddContainer.Name = "btnAddContainer";
            btnAddContainer.Size = new Size(28, 30);
            btnAddContainer.TabIndex = 6;
            btnAddContainer.Tag = "";
            btnAddContainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddContainer.UseVisualStyleBackColor = false;
            btnAddContainer.Click += btnAddContainer_Click;
            // 
            // panelContainerControlMenu
            // 
            panelContainerControlMenu.Controls.Add(btnDeleteContainer);
            panelContainerControlMenu.Controls.Add(btnAddContainer);
            panelContainerControlMenu.Dock = DockStyle.Bottom;
            panelContainerControlMenu.Location = new Point(0, 608);
            panelContainerControlMenu.Name = "panelContainerControlMenu";
            panelContainerControlMenu.Size = new Size(250, 30);
            panelContainerControlMenu.TabIndex = 2;
            // 
            // btnDeleteContainer
            // 
            btnDeleteContainer.BackColor = Color.Transparent;
            btnDeleteContainer.Dock = DockStyle.Left;
            btnDeleteContainer.FlatAppearance.BorderSize = 0;
            btnDeleteContainer.FlatStyle = FlatStyle.Flat;
            btnDeleteContainer.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteContainer.ForeColor = Color.Transparent;
            btnDeleteContainer.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDeleteContainer.IconColor = SystemColors.ControlDarkDark;
            btnDeleteContainer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteContainer.IconSize = 30;
            btnDeleteContainer.Location = new Point(28, 0);
            btnDeleteContainer.Margin = new Padding(4);
            btnDeleteContainer.Name = "btnDeleteContainer";
            btnDeleteContainer.Size = new Size(28, 30);
            btnDeleteContainer.TabIndex = 7;
            btnDeleteContainer.Tag = "";
            btnDeleteContainer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteContainer.UseVisualStyleBackColor = false;
            btnDeleteContainer.Click += btnDeleteContainer_Click;
            // 
            // btnDeleteAccessiblePath
            // 
            btnDeleteAccessiblePath.BackColor = Color.Transparent;
            btnDeleteAccessiblePath.Dock = DockStyle.Left;
            btnDeleteAccessiblePath.FlatAppearance.BorderSize = 0;
            btnDeleteAccessiblePath.FlatStyle = FlatStyle.Flat;
            btnDeleteAccessiblePath.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteAccessiblePath.ForeColor = Color.Transparent;
            btnDeleteAccessiblePath.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDeleteAccessiblePath.IconColor = SystemColors.ControlDarkDark;
            btnDeleteAccessiblePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteAccessiblePath.IconSize = 30;
            btnDeleteAccessiblePath.Location = new Point(56, 0);
            btnDeleteAccessiblePath.Margin = new Padding(4);
            btnDeleteAccessiblePath.Name = "btnDeleteAccessiblePath";
            btnDeleteAccessiblePath.Size = new Size(28, 30);
            btnDeleteAccessiblePath.TabIndex = 8;
            btnDeleteAccessiblePath.Tag = "";
            btnDeleteAccessiblePath.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteAccessiblePath.UseVisualStyleBackColor = false;
            btnDeleteAccessiblePath.Click += btnDeleteAccessiblePath_Click;
            // 
            // btnAddAccessiblePathFolder
            // 
            btnAddAccessiblePathFolder.BackColor = Color.Transparent;
            btnAddAccessiblePathFolder.Dock = DockStyle.Left;
            btnAddAccessiblePathFolder.FlatAppearance.BorderSize = 0;
            btnAddAccessiblePathFolder.FlatStyle = FlatStyle.Flat;
            btnAddAccessiblePathFolder.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddAccessiblePathFolder.ForeColor = Color.Transparent;
            btnAddAccessiblePathFolder.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddAccessiblePathFolder.IconColor = SystemColors.ControlDarkDark;
            btnAddAccessiblePathFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddAccessiblePathFolder.IconSize = 30;
            btnAddAccessiblePathFolder.Location = new Point(28, 0);
            btnAddAccessiblePathFolder.Margin = new Padding(4);
            btnAddAccessiblePathFolder.Name = "btnAddAccessiblePathFolder";
            btnAddAccessiblePathFolder.Size = new Size(28, 30);
            btnAddAccessiblePathFolder.TabIndex = 6;
            btnAddAccessiblePathFolder.Tag = "";
            btnAddAccessiblePathFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddAccessiblePathFolder.UseVisualStyleBackColor = false;
            btnAddAccessiblePathFolder.Click += btnAddAccessiblePathFolder_Click;
            // 
            // btnAddAccessiblePathFile
            // 
            btnAddAccessiblePathFile.BackColor = Color.Transparent;
            btnAddAccessiblePathFile.Dock = DockStyle.Left;
            btnAddAccessiblePathFile.FlatAppearance.BorderSize = 0;
            btnAddAccessiblePathFile.FlatStyle = FlatStyle.Flat;
            btnAddAccessiblePathFile.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddAccessiblePathFile.ForeColor = Color.Transparent;
            btnAddAccessiblePathFile.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAddAccessiblePathFile.IconColor = SystemColors.ControlDarkDark;
            btnAddAccessiblePathFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddAccessiblePathFile.IconSize = 30;
            btnAddAccessiblePathFile.Location = new Point(0, 0);
            btnAddAccessiblePathFile.Margin = new Padding(4);
            btnAddAccessiblePathFile.Name = "btnAddAccessiblePathFile";
            btnAddAccessiblePathFile.Size = new Size(28, 30);
            btnAddAccessiblePathFile.TabIndex = 5;
            btnAddAccessiblePathFile.Tag = "";
            btnAddAccessiblePathFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddAccessiblePathFile.UseVisualStyleBackColor = false;
            btnAddAccessiblePathFile.Click += btnAddAccessiblePathFile_Click;
            // 
            // panelAccessiblePath
            // 
            panelAccessiblePath.Controls.Add(listViewAccessiblePath);
            panelAccessiblePath.Controls.Add(panelAccessiblePathControlMenu);
            panelAccessiblePath.Dock = DockStyle.Fill;
            panelAccessiblePath.Location = new Point(250, 314);
            panelAccessiblePath.Name = "panelAccessiblePath";
            panelAccessiblePath.Size = new Size(871, 324);
            panelAccessiblePath.TabIndex = 2;
            // 
            // listViewAccessiblePath
            // 
            listViewAccessiblePath.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerAccessiblePathAccessiblePath });
            listViewAccessiblePath.Dock = DockStyle.Fill;
            listViewAccessiblePath.FullRowSelect = true;
            listViewAccessiblePath.Location = new Point(0, 0);
            listViewAccessiblePath.MultiSelect = false;
            listViewAccessiblePath.Name = "listViewAccessiblePath";
            listViewAccessiblePath.Size = new Size(871, 294);
            listViewAccessiblePath.Sorting = SortOrder.Ascending;
            listViewAccessiblePath.TabIndex = 3;
            listViewAccessiblePath.UseCompatibleStateImageBehavior = false;
            listViewAccessiblePath.View = View.Details;
            // 
            // columnHeaderContainerAccessiblePathAccessiblePath
            // 
            columnHeaderContainerAccessiblePathAccessiblePath.Text = "Accessible Path";
            columnHeaderContainerAccessiblePathAccessiblePath.Width = 700;
            // 
            // panelAccessiblePathControlMenu
            // 
            panelAccessiblePathControlMenu.Controls.Add(btnDeleteAccessiblePath);
            panelAccessiblePathControlMenu.Controls.Add(btnAddAccessiblePathFolder);
            panelAccessiblePathControlMenu.Controls.Add(btnAddAccessiblePathFile);
            panelAccessiblePathControlMenu.Dock = DockStyle.Bottom;
            panelAccessiblePathControlMenu.Location = new Point(0, 294);
            panelAccessiblePathControlMenu.Name = "panelAccessiblePathControlMenu";
            panelAccessiblePathControlMenu.Size = new Size(871, 30);
            panelAccessiblePathControlMenu.TabIndex = 0;
            // 
            // btnDeleteTargetPath
            // 
            btnDeleteTargetPath.BackColor = Color.Transparent;
            btnDeleteTargetPath.Dock = DockStyle.Left;
            btnDeleteTargetPath.FlatAppearance.BorderSize = 0;
            btnDeleteTargetPath.FlatStyle = FlatStyle.Flat;
            btnDeleteTargetPath.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteTargetPath.ForeColor = Color.Transparent;
            btnDeleteTargetPath.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDeleteTargetPath.IconColor = SystemColors.ControlDarkDark;
            btnDeleteTargetPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteTargetPath.IconSize = 30;
            btnDeleteTargetPath.Location = new Point(56, 0);
            btnDeleteTargetPath.Margin = new Padding(4);
            btnDeleteTargetPath.Name = "btnDeleteTargetPath";
            btnDeleteTargetPath.Size = new Size(28, 30);
            btnDeleteTargetPath.TabIndex = 8;
            btnDeleteTargetPath.Tag = "";
            btnDeleteTargetPath.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteTargetPath.UseVisualStyleBackColor = false;
            btnDeleteTargetPath.Click += btnDeleteTargetPath_Click;
            // 
            // btnAddTargetPathFolder
            // 
            btnAddTargetPathFolder.BackColor = Color.Transparent;
            btnAddTargetPathFolder.Dock = DockStyle.Left;
            btnAddTargetPathFolder.FlatAppearance.BorderSize = 0;
            btnAddTargetPathFolder.FlatStyle = FlatStyle.Flat;
            btnAddTargetPathFolder.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddTargetPathFolder.ForeColor = Color.Transparent;
            btnAddTargetPathFolder.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddTargetPathFolder.IconColor = SystemColors.ControlDarkDark;
            btnAddTargetPathFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddTargetPathFolder.IconSize = 30;
            btnAddTargetPathFolder.Location = new Point(28, 0);
            btnAddTargetPathFolder.Margin = new Padding(4);
            btnAddTargetPathFolder.Name = "btnAddTargetPathFolder";
            btnAddTargetPathFolder.Size = new Size(28, 30);
            btnAddTargetPathFolder.TabIndex = 7;
            btnAddTargetPathFolder.Tag = "";
            btnAddTargetPathFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddTargetPathFolder.UseVisualStyleBackColor = false;
            btnAddTargetPathFolder.Click += btnAddTargetPathFolder_Click;
            // 
            // listViewTargetPath
            // 
            listViewTargetPath.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerTargetPathTargetPath });
            listViewTargetPath.Dock = DockStyle.Fill;
            listViewTargetPath.FullRowSelect = true;
            listViewTargetPath.Location = new Point(0, 0);
            listViewTargetPath.MultiSelect = false;
            listViewTargetPath.Name = "listViewTargetPath";
            listViewTargetPath.Size = new Size(871, 284);
            listViewTargetPath.Sorting = SortOrder.Ascending;
            listViewTargetPath.TabIndex = 6;
            listViewTargetPath.UseCompatibleStateImageBehavior = false;
            listViewTargetPath.View = View.Details;
            // 
            // columnHeaderContainerTargetPathTargetPath
            // 
            columnHeaderContainerTargetPathTargetPath.Text = "Target Path";
            columnHeaderContainerTargetPathTargetPath.Width = 700;
            // 
            // panelTargetPathControlMenu
            // 
            panelTargetPathControlMenu.Controls.Add(btnDeleteTargetPath);
            panelTargetPathControlMenu.Controls.Add(btnAddTargetPathFolder);
            panelTargetPathControlMenu.Controls.Add(btnAddTargetPathFile);
            panelTargetPathControlMenu.Dock = DockStyle.Bottom;
            panelTargetPathControlMenu.Location = new Point(0, 284);
            panelTargetPathControlMenu.Name = "panelTargetPathControlMenu";
            panelTargetPathControlMenu.Size = new Size(871, 30);
            panelTargetPathControlMenu.TabIndex = 5;
            // 
            // btnAddTargetPathFile
            // 
            btnAddTargetPathFile.BackColor = Color.Transparent;
            btnAddTargetPathFile.Dock = DockStyle.Left;
            btnAddTargetPathFile.FlatAppearance.BorderSize = 0;
            btnAddTargetPathFile.FlatStyle = FlatStyle.Flat;
            btnAddTargetPathFile.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddTargetPathFile.ForeColor = Color.Transparent;
            btnAddTargetPathFile.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            btnAddTargetPathFile.IconColor = SystemColors.ControlDarkDark;
            btnAddTargetPathFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddTargetPathFile.IconSize = 30;
            btnAddTargetPathFile.Location = new Point(0, 0);
            btnAddTargetPathFile.Margin = new Padding(4);
            btnAddTargetPathFile.Name = "btnAddTargetPathFile";
            btnAddTargetPathFile.Size = new Size(28, 30);
            btnAddTargetPathFile.TabIndex = 6;
            btnAddTargetPathFile.Tag = "";
            btnAddTargetPathFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddTargetPathFile.UseVisualStyleBackColor = false;
            btnAddTargetPathFile.Click += btnAddTargetPathFile_Click;
            // 
            // panelTargetPath
            // 
            panelTargetPath.Controls.Add(listViewTargetPath);
            panelTargetPath.Controls.Add(panelTargetPathControlMenu);
            panelTargetPath.Dock = DockStyle.Top;
            panelTargetPath.Location = new Point(250, 0);
            panelTargetPath.Name = "panelTargetPath";
            panelTargetPath.Size = new Size(871, 314);
            panelTargetPath.TabIndex = 3;
            // 
            // panelContainerList
            // 
            panelContainerList.Controls.Add(listViewContainer);
            panelContainerList.Controls.Add(panelContainerControlMenu);
            panelContainerList.Dock = DockStyle.Left;
            panelContainerList.Location = new Point(0, 0);
            panelContainerList.Name = "panelContainerList";
            panelContainerList.Size = new Size(250, 638);
            panelContainerList.TabIndex = 4;
            // 
            // listViewContainer
            // 
            listViewContainer.Columns.AddRange(new ColumnHeader[] { columnHeaderContainerContainerContainer });
            listViewContainer.Dock = DockStyle.Fill;
            listViewContainer.FullRowSelect = true;
            listViewContainer.Location = new Point(0, 0);
            listViewContainer.MultiSelect = false;
            listViewContainer.Name = "listViewContainer";
            listViewContainer.Size = new Size(250, 608);
            listViewContainer.Sorting = SortOrder.Ascending;
            listViewContainer.TabIndex = 4;
            listViewContainer.UseCompatibleStateImageBehavior = false;
            listViewContainer.View = View.Details;
            listViewContainer.SelectedIndexChanged += listViewContainer_SelectedIndexChanged;
            // 
            // columnHeaderContainerContainerContainer
            // 
            columnHeaderContainerContainerContainer.Text = "Container";
            columnHeaderContainerContainerContainer.Width = 230;
            // 
            // ContainerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 638);
            Controls.Add(panelAccessiblePath);
            Controls.Add(panelTargetPath);
            Controls.Add(panelContainerList);
            Name = "ContainerForm";
            Text = "ContainerForm";
            panelContainerControlMenu.ResumeLayout(false);
            panelAccessiblePath.ResumeLayout(false);
            panelAccessiblePathControlMenu.ResumeLayout(false);
            panelTargetPathControlMenu.ResumeLayout(false);
            panelTargetPath.ResumeLayout(false);
            panelContainerList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnAddContainer;
        private Panel panelContainerControlMenu;
        private FontAwesome.Sharp.IconButton btnDeleteContainer;
        private FontAwesome.Sharp.IconButton btnDeleteAccessiblePath;
        private FontAwesome.Sharp.IconButton btnAddAccessiblePathFolder;
        private FontAwesome.Sharp.IconButton btnAddAccessiblePathFile;
        private Panel panelAccessiblePath;
        private ListView listViewAccessiblePath;
        private ColumnHeader columnHeaderContainerAccessiblePathAccessiblePath;
        private Panel panelAccessiblePathControlMenu;
        private FontAwesome.Sharp.IconButton btnDeleteTargetPath;
        private FontAwesome.Sharp.IconButton btnAddTargetPathFolder;
        private ListView listViewTargetPath;
        private ColumnHeader columnHeaderContainerTargetPathTargetPath;
        private Panel panelTargetPathControlMenu;
        private FontAwesome.Sharp.IconButton btnAddTargetPathFile;
        private Panel panelTargetPath;
        private Panel panelContainerList;
        private ListView listViewContainer;
        private ColumnHeader columnHeaderContainerContainerContainer;
    }
}