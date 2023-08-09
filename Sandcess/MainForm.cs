using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;

namespace Sandcess
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private enum ContentIndex
        {
            Dashboard = 0,
            FileSystem,
            Process,
            Container,
            EventLog,
        };


        public MainWindow(string[] args)
        {
            InitializeComponent();
            this.Padding = new Padding(1);
            this.BackColor = Color.FromArgb(39, 55, 70);

            if (args.Length == 0)
                return;

            if (args[0] == "--set")
            {
                ChangeTabControlContent(ContentIndex.FileSystem);
                for (int idx = 1; idx < args.Length; idx++)
                {
                    string path = args[idx];
                    if (FileUtils.IsExists(path))
                    {
                        ListViewItem listViewItem = new ListViewItem(FileUtils.GetFileName(path));
                        listViewItem.SubItems.Add(path);
                        listViewFileSystemFile.Items.Insert(0, listViewItem);
                    }
                }
            }
        }


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0083 /* WM_NCCALCSIZE */ && m.WParam.ToInt32() == 1)
                return;
            base.WndProc(ref m);
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 10, 10, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != 1)
                        this.Padding = new Padding(1);
                    break;
            }
        }


        private void btnMinimize_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }

        private void btnMaximize_Click(object sender, EventArgs e) { this.WindowState ^= FormWindowState.Maximized; }

        private void btnClose_Click(object sender, EventArgs e) { Application.Exit(); }

        private void btnMenuDashboard_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Dashboard); }

        private void btnMenuFileSystem_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.FileSystem); }

        private void btnMenuProcess_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Process); }

        private void btnMenuContainer_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Container); }

        private void btnMenuEventLog_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.EventLog); }

        private void btnFileSystemPermissionApply_Click(object sender, EventArgs e)
        {
            if (listViewFileSystemFile.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "No file chosen.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            string path = listViewFileSystemFile.SelectedItems[0].SubItems[1].Text;
            uint permission = 0u;
            int currentAccessType = 2/* reserved bit */;

            foreach (CheckedListBox permissionCheckedBox in new CheckedListBox[]{
                checkedListBoxFileSystemPermissionFile,
                checkedListBoxProcessPermissionProcess,
                checkedListBoxNetworkPermissionNetwork
            })
            {
                for (int idx = 0; idx < permissionCheckedBox.Items.Count; idx++)
                {
                    if (permissionCheckedBox.GetItemChecked(idx))
                        permission |= (1u << currentAccessType);
                    currentAccessType += 1;
                }
            }

            path = FileUtils.DosPathToNtPath(path);
            if (!AccessController.SetPermission(path, permission))
            {
                MessageBox.Show(
                    "Cannot connect to driver.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            AgentController.ShowDefaultToast("Permissions setup is complete.");
        }

        private void listViewFileSystemFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFileSystemFile.SelectedItems.Count == 0)
            {
                labelTitle.Text = "File System";
                return;
            }
            labelTitle.Text = listViewFileSystemFile.SelectedItems[0].Text;
        }

        private void listViewProcessProcess_DoubleClick(object sender, EventArgs e)
        {
            if (listViewProcessProcess.SelectedItems.Count == 0)
                return;
            string path = listViewProcessProcess.SelectedItems[0].SubItems[2].Text;
            if (FileUtils.IsExists(path))
            {
                ChangeTabControlContent(ContentIndex.FileSystem);
                ListViewItem listViewItem = new ListViewItem(FileUtils.GetFileName(path));
                listViewItem.SubItems.Add(path);
                listViewFileSystemFile.Items.Insert(0, listViewItem);
                listViewFileSystemFile.Items[0].Selected = true;
            }
        }

        private void ChangeTabControlContent(ContentIndex contentIndex)
        {
            tabControlMainContent.SelectedIndex = (int)contentIndex;

            foreach (Control control in panelSideMenu.Controls)
            {
                control.BackColor = (
                    (control.TabIndex == (int)contentIndex) ?
                    Color.FromArgb(98, 153, 230) :  // selected color
                    Color.FromArgb(30, 30, 30)      // default color
                );
                if (control.TabIndex == (int)contentIndex)
                {
                    string title = "Dashboard";
                    switch (contentIndex)
                    {
                        case ContentIndex.FileSystem:
                            title = "File System";
                            break;
                        case ContentIndex.Process:
                            title = "Process";
                            break;
                        case ContentIndex.Container:
                            title = "Container";
                            break;
                        case ContentIndex.EventLog:
                            title = "Event Log";
                            break;
                    }
                    labelTitle.Text = title;
                }
            }
            if (contentIndex == ContentIndex.Process)
                InitializeProcessTab();
        }

        private void InitializeProcessTab()
        {
            Process[] processList = Process.GetProcesses();
            Hashtable pathHasTable = new Hashtable();

            listViewProcessProcess.Items.Clear();
            for (int idx = 0; idx < processList.Length; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(processList[idx].Id.ToString());

                string path;
                try { path = processList[idx].MainModule.FileName; }
                catch { continue; }
                if (path == null || pathHasTable.ContainsKey(path).Equals(true))
                    continue;

                listViewItem.SubItems.Add(processList[idx].ProcessName);
                listViewItem.SubItems.Add(path);
                listViewItem.SubItems.Add("-");
                listViewProcessProcess.Items.Add(listViewItem);
                pathHasTable.Add(path, true);
            }
        }
    }
}