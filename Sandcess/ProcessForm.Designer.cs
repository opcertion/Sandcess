namespace Sandcess
{
    partial class ProcessForm
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
            panelProcessList = new Panel();
            listViewProcess = new ListView();
            columnHeaderProcessProcessProcessId = new ColumnHeader();
            columnHeaderProcessProcessProcessName = new ColumnHeader();
            columnHeaderProcessProcessProcessPath = new ColumnHeader();
            panelProcessList.SuspendLayout();
            SuspendLayout();
            // 
            // panelProcessList
            // 
            panelProcessList.Controls.Add(listViewProcess);
            panelProcessList.Dock = DockStyle.Fill;
            panelProcessList.Location = new Point(0, 0);
            panelProcessList.Name = "panelProcessList";
            panelProcessList.Size = new Size(800, 450);
            panelProcessList.TabIndex = 0;
            // 
            // listViewProcess
            // 
            listViewProcess.Columns.AddRange(new ColumnHeader[] { columnHeaderProcessProcessProcessId, columnHeaderProcessProcessProcessName, columnHeaderProcessProcessProcessPath });
            listViewProcess.Dock = DockStyle.Fill;
            listViewProcess.FullRowSelect = true;
            listViewProcess.Location = new Point(0, 0);
            listViewProcess.MultiSelect = false;
            listViewProcess.Name = "listViewProcess";
            listViewProcess.Size = new Size(800, 450);
            listViewProcess.Sorting = SortOrder.Ascending;
            listViewProcess.TabIndex = 1;
            listViewProcess.UseCompatibleStateImageBehavior = false;
            listViewProcess.View = View.Details;
            listViewProcess.DoubleClick += listViewProcess_DoubleClick;
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
            // ProcessForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelProcessList);
            Name = "ProcessForm";
            Text = "ProcessForm";
            panelProcessList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelProcessList;
        private ListView listViewProcess;
        private ColumnHeader columnHeaderProcessProcessProcessId;
        private ColumnHeader columnHeaderProcessProcessProcessName;
        private ColumnHeader columnHeaderProcessProcessProcessPath;
    }
}