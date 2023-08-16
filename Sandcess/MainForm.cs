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



        // main window
        public MainWindow(string[] args)
        {
            InitializeComponent();
            this.Padding = new Padding(1);
            this.BackColor = Color.FromArgb(39, 55, 70);

            AccessController.LoadAccessInfo();
            ContainerController.LoadContainerInfo();


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
                        listViewFileSystemFile.Items.Add(listViewItem);
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            AccessController.SaveAccessInfo();
            ContainerController.SaveContainerInfo();
        }


        private void btnMinimize_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        private void btnMaximize_Click(object sender, EventArgs e) { this.WindowState ^= FormWindowState.Maximized; }
        private void btnClose_Click(object sender, EventArgs e) { Application.Exit(); }
        private void btnMenuDashboard_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Dashboard); }
        private void btnMenuFileSystem_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.FileSystem); }
        private void btnMenuProcess_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Process); }
        private void btnMenuContainer_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.Container); }
        private void btnMenuEventLog_Click(object sender, EventArgs e) { ChangeTabControlContent(ContentIndex.EventLog); }


        // file system - file system
        private void listViewFileSystemFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPermissionCheckedListBox();
            if (listViewFileSystemFile.SelectedItems.Count == 0)
            {
                labelMainTitle.Text = "File System";
                return;
            }
            labelMainTitle.Text = listViewFileSystemFile.SelectedItems[0].Text;

            string path = listViewFileSystemFile.SelectedItems[0].SubItems[1].Text;
            uint permission = AccessController.GetPermission(path);
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
            HashSet<string> currentEnabledContainer = new HashSet<string>(ContainerController.GetContainerListByTargetPath(path));
            int containerIdx = 0;

            foreach (string container in ContainerController.GetContainerList())
            {
                checkedListBoxFileSystemContainer.SetItemChecked(
                    containerIdx,
                    (currentEnabledContainer.Contains(container))
                );
                containerIdx += 1;
            }
        }

        private void ResetPermissionCheckedListBox()
        {
            foreach (CheckedListBox permissionCheckedListBox in new CheckedListBox[]{
                checkedListBoxFileSystemFileSystemPermission,
                checkedListBoxFileSystemProcessPermission,
                checkedListBoxFileSystemNetworkPermission
            })
            {
                permissionCheckedListBox.SelectedItems.Clear();
                for (int idx = 0; idx < permissionCheckedListBox.Items.Count; idx++)
                    permissionCheckedListBox.SetItemChecked(idx, false);
            }
            for (int idx = 0; idx < checkedListBoxFileSystemContainer.Items.Count; idx++)
                checkedListBoxFileSystemContainer.SetItemChecked(idx, false);
        }



        // file system - permission
        private void btnFileSystemPermissionApply_Click(object sender, EventArgs e)
        {
            if (listViewFileSystemFile.SelectedItems.Count == 0)
            {
                MessageBoxController.ShowError("No file chosen.");
                return;
            }
            string path = listViewFileSystemFile.SelectedItems[0].SubItems[1].Text;
            uint permission = 0;
            int currentAccessType = 2/* reserved bit */;

            foreach (CheckedListBox permissionCheckedListBox in new CheckedListBox[]{
                checkedListBoxFileSystemFileSystemPermission,
                checkedListBoxFileSystemProcessPermission,
                checkedListBoxFileSystemNetworkPermission
            })
            {
                for (int idx = 0; idx < permissionCheckedListBox.Items.Count; idx++)
                {
                    if (permissionCheckedListBox.GetItemChecked(idx))
                        permission |= (1u << currentAccessType);
                    currentAccessType += 1;
                }
            }

            if (!AccessController.SetPermission(path, permission))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            AgentController.ShowDefaultToast("Permissions setup is complete.");
        }



        // process - process
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
                listViewFileSystemFile.Items.Add(listViewItem);
                listViewFileSystemFile.Items[
                    listViewFileSystemFile.Items.IndexOf(listViewItem)
                ].Selected = true;
            }
        }



        // container - container
        private void listViewContainerContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewContainerTargetPath.Items.Clear();
            listViewContainerAccessiblePath.Items.Clear();
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                labelMainTitle.Text = "Container";
                return;
            }
            string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
            List<string> targetPathList = ContainerController.GetTargetPathList(container);
            List<string> accessiblePathList = ContainerController.GetAccessiblePathList(container);
            labelMainTitle.Text = container;

            for (int idx = 0; idx < targetPathList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(targetPathList[idx]);
                listViewContainerTargetPath.Items.Add(listViewItem);
            }
            for (int idx = 0; idx < accessiblePathList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(accessiblePathList[idx]);
                listViewContainerAccessiblePath.Items.Add(listViewItem);
            }
        }

        private void btnContainerAddContainer_Click(object sender, EventArgs e)
        {
            if (listViewContainerContainer.Items.Count >= ContainerController.MAXIMUM_CONTAINER_COUNT)
            {
                MessageBoxController.ShowError(
                    "The number of containers cannot exceed " +
                    ContainerController.MAXIMUM_CONTAINER_COUNT.ToString() +
                    "."
                );
                return;
            }

            string container = Interaction.InputBox(
                "Please enter the container name.",
                "Container Name",
                "Container-1",
                (Screen.PrimaryScreen.Bounds.Width / 2) - 250,
                (Screen.PrimaryScreen.Bounds.Height / 2) - 100
            );
            if (!string.IsNullOrWhiteSpace(container))
            {
                if (ContainerController.IsExistsContainer(container))
                {
                    MessageBoxController.ShowError("Container already exists.");
                    return;
                }
                if (!ContainerController.CreateContainer(container))
                {
                    MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                    return;
                }
                ListViewItem listViewItem = new ListViewItem(container);
                listViewContainerContainer.Items.Add(listViewItem);
            }
        }

        private void btnContainerDeleteContainer_Click(object sender, EventArgs e)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
                return;
            string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
            if (!ContainerController.DeleteContainer(container))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            listViewContainerContainer.Items.RemoveAt(
                listViewContainerContainer.SelectedItems[0].Index
            );
        }



        // container - target path
        private void btnContainerAddTargetPathFile_Click(object sender, EventArgs e) { AddTargetPath(true); }

        private void btnContainerAddTargetPathFolder_Click(object sender, EventArgs e) { AddTargetPath(false); }

        private void AddTargetPath(bool openFile)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                MessageBoxController.ShowError("No container chosen.");
                return;
            }
            DialogResult dialogResult;
            string path;

            if (openFile)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                dialogResult = openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                dialogResult = folderBrowserDialog.ShowDialog();
                path = folderBrowserDialog.SelectedPath;
            }

            if (dialogResult == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(path))
                    return;
                if (!openFile && !path.EndsWith("\\"))
                    path += "\\";

                string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
                if (ContainerController.IsExistsTargetPath(container, path))
                {
                    MessageBoxController.ShowError("Target path already exists.");
                    return;
                }
                if (!ContainerController.AddTargetPath(container, path))
                {
                    MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                    return;
                }
                ListViewItem listViewItem = new ListViewItem(path);
                listViewContainerTargetPath.Items.Add(listViewItem);
            }
        }

        private void btnContainerDeleteTargetPath_Click(object sender, EventArgs e)
        {
            if (listViewContainerTargetPath.SelectedItems.Count == 0)
                return;
            string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
            string targetPath = listViewContainerTargetPath.SelectedItems[0].SubItems[0].Text;
            if (!ContainerController.DeleteTargetPath(container, targetPath))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            listViewContainerTargetPath.Items.RemoveAt(
                listViewContainerTargetPath.SelectedItems[0].Index
            );
        }



        // container - accessible path
        private void btnContainerAddAccessiblePathFile_Click(object sender, EventArgs e) { AddAccessiblePath(true); }

        private void btnContainerAddAccessiblePathFolder_Click(object sender, EventArgs e) { AddAccessiblePath(false); }

        private void AddAccessiblePath(bool openFile)
        {
            if (listViewContainerContainer.SelectedItems.Count == 0)
            {
                MessageBoxController.ShowError("No container chosen.");
                return;
            }
            DialogResult dialogResult;
            string path;

            if (openFile)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                dialogResult = openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                dialogResult = folderBrowserDialog.ShowDialog();
                path = folderBrowserDialog.SelectedPath;
            }

            if (dialogResult == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(path))
                    return;
                if (!openFile && !path.EndsWith("\\"))
                    path += "\\";

                string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
                if (ContainerController.IsExistsAccessiblePath(container, path))
                {
                    MessageBoxController.ShowError("Accessible path already exists.");
                    return;
                }
                if (!ContainerController.AddAccessiblePath(container, path))
                {
                    MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                    return;
                }
                ListViewItem listViewItem = new ListViewItem(path);
                listViewContainerAccessiblePath.Items.Add(listViewItem);
            }
        }

        private void btnContainerDeleteAccessiblePath_Click(object sender, EventArgs e)
        {
            if (listViewContainerAccessiblePath.SelectedItems.Count == 0)
                return;
            string container = listViewContainerContainer.SelectedItems[0].SubItems[0].Text;
            string accessiblePath = listViewContainerAccessiblePath.SelectedItems[0].SubItems[0].Text;
            if (!ContainerController.DeleteAccessiblePath(container, accessiblePath))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            listViewContainerAccessiblePath.Items.RemoveAt(
                listViewContainerAccessiblePath.SelectedItems[0].Index
            );
        }



        // tab
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
            listViewFileSystemFile.Items.Clear();
            checkedListBoxFileSystemContainer.Items.Clear();

            ResetPermissionCheckedListBox();
            foreach (string container in ContainerController.GetContainerList())
                checkedListBoxFileSystemContainer.Items.Add(container);
            foreach (string filePath in AccessController.GetPathList())
            {
                ListViewItem listViewItem = new ListViewItem(FileUtils.GetFileName(filePath));
                listViewItem.SubItems.Add(filePath);
                listViewFileSystemFile.Items.Add(listViewItem);
            }
        }

        private void InitializeProcessTab()
        {
            Process[] processList = Process.GetProcesses();
            Hashtable pathHashTable = new Hashtable();

            listViewProcessProcess.Items.Clear();
            for (int idx = 0; idx < processList.Length; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(processList[idx].Id.ToString());

                string path;
                try { path = processList[idx].MainModule.FileName; }
                catch { continue; }
                if (path == null || pathHashTable.ContainsKey(path))
                    continue;

                listViewItem.SubItems.Add(processList[idx].ProcessName);
                listViewItem.SubItems.Add(path);
                listViewProcessProcess.Items.Add(listViewItem);
                pathHashTable.Add(path, true);
            }
        }

        private void InitializeContainerTab()
        {
            listViewContainerContainer.Items.Clear();
            listViewContainerTargetPath.Items.Clear();
            listViewContainerAccessiblePath.Items.Clear();
            foreach (string container in ContainerController.GetContainerList())
            {
                ListViewItem listViewItem = new ListViewItem(container);
                listViewContainerContainer.Items.Add(listViewItem);
            }
        }
    }
}