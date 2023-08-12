using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.VisualBasic;
using System.Windows.Forms;

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
                checkedListBoxFileSystemFileSystemPermission,
                checkedListBoxFileSystemProcessPermission,
                checkedListBoxFileSystemNetworkPermission
            })
            {
                for (int idx = 0; idx < permissionCheckedBox.Items.Count; idx++)
                {
                    if (permissionCheckedBox.GetItemChecked(idx))
                        permission |= (1u << currentAccessType);
                    currentAccessType += 1;
                }
            }

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
                tabControlFileSystemPermission.SelectedIndex = 0;
                for (int idx = 0; idx < checkedListBoxFileSystemFileSystemPermission.Items.Count; idx++)
                    checkedListBoxFileSystemFileSystemPermission.SetItemChecked(idx, false);
                for (int idx = 0; idx < checkedListBoxFileSystemContainer.Items.Count; idx++)
                    checkedListBoxFileSystemContainer.SetItemChecked(idx, false);
                labelMainTitle.Text = "File System";
                return;
            }
            labelMainTitle.Text = listViewFileSystemFile.SelectedItems[0].Text;

            string path = listViewFileSystemFile.SelectedItems[0].SubItems[1].Text;
            uint permission = (AccessController.accessInfo.ContainsKey(path) ? AccessController.accessInfo[path] : 0u);
            int currentAccessType = 2/* reserved bit */;

            foreach (CheckedListBox permissionCheckedBox in new CheckedListBox[]{
                checkedListBoxFileSystemFileSystemPermission,
                checkedListBoxFileSystemProcessPermission,
                checkedListBoxFileSystemNetworkPermission
            })
            {
                for (int idx = 0; idx < permissionCheckedBox.Items.Count; idx++)
                {
                    permissionCheckedBox.SetItemChecked(idx, (((permission >> currentAccessType) & 1) == 1));
                    currentAccessType += 1;
                }
            }
            HashSet<string> targetContainer = new HashSet<string>(ContainerController.GetContainerListByTargetFile(path));
            int containerIdx = 0;

            foreach (string containerName in ContainerController.containerInfo.Keys)
            {
                checkedListBoxFileSystemContainer.SetItemChecked(
                    containerIdx,
                    (targetContainer.Contains(containerName))
                );
                containerIdx += 1;
            }
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

        private void listViewContainerContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewContainerTargetFile.Items.Clear();
            listViewContainerAccessibleFolder.Items.Clear();
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                labelMainTitle.Text = "Container";
                return;
            }
            string containerName = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
            List<string> targetFileList = ContainerController.containerInfo[containerName].targetFileList;
            List<string> accessibleFolderList = ContainerController.containerInfo[containerName].accessibleFolderList;
            labelMainTitle.Text = containerName;

            for (int idx = 0; idx < targetFileList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(targetFileList[idx]);
                listViewContainerTargetFile.Items.Insert(0, listViewItem);
            }
            for (int idx = 0; idx < accessibleFolderList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(accessibleFolderList[idx]);
                listViewContainerAccessibleFolder.Items.Insert(0, listViewItem);
            }
        }

        private void btnContainerAddContainer_Click(object sender, EventArgs e)
        {
            string containerName = Interaction.InputBox(
                "Please enter the container name.",
                "Container Name",
                "Container-1",
                (Screen.PrimaryScreen.Bounds.Width / 2) - 250,
                (Screen.PrimaryScreen.Bounds.Height / 2) - 100
            );
            if (!string.IsNullOrWhiteSpace(containerName))
            {
                if (ContainerController.containerInfo.ContainsKey(containerName))
                {
                    MessageBox.Show(
                        "Container already exists.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
                ContainerController.containerInfo[containerName] = new ContainerController.CONTAINER_INFO();
                ListViewItem listViewItem = new ListViewItem(containerName);
                listViewContainerContainer.Items.Insert(0, listViewItem);
            }
        }

        private void btnContainerDeleteContainer_Click(object sender, EventArgs e)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
                return;
            ContainerController.containerInfo.Remove(
                listViewContainerContainer.SelectedItems[0].SubItems[0].Text
            );
            listViewContainerContainer.Items.RemoveAt(
                listViewContainerContainer.SelectedItems[0].Index
            );
        }

        private void btnContainerAddTargetFile_Click(object sender, EventArgs e)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "No container chosen.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (string.IsNullOrWhiteSpace(path))
                    return;
                List<string> targetFileList = (
                    ContainerController.containerInfo[
                        listViewContainerContainer.SelectedItems[0].SubItems[0].Text
                    ].targetFileList
                );
                if (targetFileList.Contains(path))
                {
                    MessageBox.Show(
                        "Target file already exists.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
                targetFileList.Add(path);
                ListViewItem listViewItem = new ListViewItem(path);
                listViewContainerTargetFile.Items.Insert(0, listViewItem);
            }
        }

        private void btnContainerDeleteTargetFile_Click(object sender, EventArgs e)
        {
            if (listViewContainerTargetFile.SelectedItems.Count == 0)
                return;
            ContainerController.containerInfo[
                listViewContainerContainer.SelectedItems[0].SubItems[0].Text
            ].targetFileList.Remove(listViewContainerTargetFile.SelectedItems[0].SubItems[0].Text);
            listViewContainerTargetFile.Items.RemoveAt(
                listViewContainerTargetFile.SelectedItems[0].Index
            );
        }

        private void btnContainerAddAccessibleFolder_Click(object sender, EventArgs e)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "No container chosen.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                if (string.IsNullOrWhiteSpace(path))
                    return;
                List<string> accessibleFolderList = (
                    ContainerController.containerInfo[
                        listViewContainerContainer.SelectedItems[0].SubItems[0].Text
                    ].accessibleFolderList
                );
                if (accessibleFolderList.Contains(path))
                {
                    MessageBox.Show(
                        "Accessible folder already exists.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
                accessibleFolderList.Add(path);
                ListViewItem listViewItem = new ListViewItem(path);
                listViewContainerAccessibleFolder.Items.Insert(0, listViewItem);
            }
        }

        private void btnContainerDeleteAccessibleFolder_Click(object sender, EventArgs e)
        {
            if (listViewContainerAccessibleFolder.SelectedItems.Count == 0)
                return;
            ContainerController.containerInfo[
                listViewContainerContainer.SelectedItems[0].SubItems[0].Text
            ].accessibleFolderList.Remove(listViewContainerAccessibleFolder.SelectedItems[0].SubItems[0].Text);
            listViewContainerAccessibleFolder.Items.RemoveAt(
                listViewContainerAccessibleFolder.SelectedItems[0].Index
            );
        }

        private void btnContainerApply_Click(object sender, EventArgs e)
        {

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
                            InitializeFileSystemTab();
                            break;
                        case ContentIndex.Process:
                            title = "Process";
                            InitializeProcessTab();
                            break;
                        case ContentIndex.Container:
                            title = "Container";
                            InitializeContainerTab();
                            break;
                        case ContentIndex.EventLog:
                            title = "Event Log";
                            break;
                    }
                    labelMainTitle.Text = title;
                }
            }
        }

        private void InitializeFileSystemTab()
        {
            tabControlFileSystemPermission.SelectedIndex = 0;
            listViewFileSystemFile.SelectedItems.Clear();
            checkedListBoxFileSystemContainer.Items.Clear();

            for (int idx = 0; idx < checkedListBoxFileSystemFileSystemPermission.Items.Count; idx++)
                checkedListBoxFileSystemFileSystemPermission.SetItemChecked(idx, false);
            foreach (string containerName in ContainerController.containerInfo.Keys)
                checkedListBoxFileSystemContainer.Items.Add(containerName);
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
                listViewProcessProcess.Items.Add(listViewItem);
                pathHasTable.Add(path, true);
            }
        }

        private void InitializeContainerTab()
        {
            listViewContainerContainer.SelectedItems.Clear();
        }
    }
}