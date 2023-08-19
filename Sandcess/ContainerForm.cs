using Microsoft.VisualBasic;

namespace Sandcess
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            foreach (string container in ContainerController.GetContainerList())
            {
                ListViewItem listViewItem = new ListViewItem(container);
                listViewContainer.Items.Add(listViewItem);
            }
        }

        private void listViewContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewTargetPath.Items.Clear();
            listViewAccessiblePath.Items.Clear();
            if (listViewContainer.SelectedItems.Count == 0)
                return;
            string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
            List<string> targetPathList = ContainerController.GetTargetPathList(container);
            List<string> accessiblePathList = ContainerController.GetAccessiblePathList(container);

            for (int idx = 0; idx < targetPathList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(targetPathList[idx]);
                listViewTargetPath.Items.Add(listViewItem);
            }
            for (int idx = 0; idx < accessiblePathList.Count; idx++)
            {
                ListViewItem listViewItem = new ListViewItem(accessiblePathList[idx]);
                listViewAccessiblePath.Items.Add(listViewItem);
            }
        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            if (listViewContainer.Items.Count >= ContainerController.MAXIMUM_CONTAINER_COUNT)
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
                listViewContainer.Items.Add(listViewItem);
            }
        }

        private void btnDeleteContainer_Click(object sender, EventArgs e)
        {
            if (listViewContainer.SelectedItems.Count == 0)
                return;
            string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
            List<string> targetPathList = ContainerController.GetTargetPathList(container);
            List<string> accessiblePathList = ContainerController.GetAccessiblePathList(container);

            if (!ContainerController.DeleteContainer(container))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }

            // for update container id
            foreach (string path in targetPathList)
                FileUtils.IsExists(path);
            foreach (string path in accessiblePathList)
                FileUtils.IsExists(path);

            listViewContainer.Items.RemoveAt(
                listViewContainer.SelectedItems[0].Index
            );
        }

        private void btnAddTargetPathFile_Click(object sender, EventArgs e) { AddTargetPath(true); }

        private void btnAddTargetPathFolder_Click(object sender, EventArgs e) { AddTargetPath(false); }

        private void AddTargetPath(bool isFile)
        {
            if (listViewContainer.SelectedItems.Count == 0)
            {
                MessageBoxController.ShowError("No container chosen.");
                return;
            }
            DialogResult dialogResult;
            string path;

            if (isFile)
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
                if (!isFile && !path.EndsWith("\\"))
                    path += "\\";

                string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
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
                listViewTargetPath.Items.Add(listViewItem);
            }
        }

        private void btnDeleteTargetPath_Click(object sender, EventArgs e)
        {
            if (listViewTargetPath.SelectedItems.Count == 0)
                return;
            string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
            string targetPath = listViewTargetPath.SelectedItems[0].SubItems[0].Text;

            if (!ContainerController.DeleteTargetPath(container, targetPath))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            listViewTargetPath.Items.RemoveAt(
                listViewTargetPath.SelectedItems[0].Index
            );
        }

        private void btnAddAccessiblePathFile_Click(object sender, EventArgs e) { AddAccessiblePath(true); }

        private void btnAddAccessiblePathFolder_Click(object sender, EventArgs e) { AddAccessiblePath(false); }

        private void AddAccessiblePath(bool isFile)
        {
            if (listViewContainer.SelectedItems.Count == 0)
            {
                MessageBoxController.ShowError("No container chosen.");
                return;
            }
            DialogResult dialogResult;
            string path;

            if (isFile)
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
                if (!isFile && !path.EndsWith("\\"))
                    path += "\\";

                string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
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
                listViewAccessiblePath.Items.Add(listViewItem);
            }
        }

        private void btnDeleteAccessiblePath_Click(object sender, EventArgs e)
        {
            if (listViewAccessiblePath.SelectedItems.Count == 0)
                return;
            string container = listViewContainer.SelectedItems[0].SubItems[0].Text;
            string accessiblePath = listViewAccessiblePath.SelectedItems[0].SubItems[0].Text;

            if (!ContainerController.DeleteAccessiblePath(container, accessiblePath))
            {
                MessageBoxController.ShowError(MessageBoxController.DRIVER_ERROR);
                return;
            }
            listViewAccessiblePath.Items.RemoveAt(
                listViewAccessiblePath.SelectedItems[0].Index
            );
        }

        private void listViewTargetPath_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTargetPath.SelectedItems.Count == 0)
                return;
            string path = listViewTargetPath.SelectedItems[0].SubItems[0].Text;
            FileUtils.OpenWindowsExplorer(path);
        }

        private void listViewAccessiblePath_DoubleClick(object sender, EventArgs e)
        {
            if (listViewAccessiblePath.SelectedItems.Count == 0)
                return;
            string path = listViewAccessiblePath.SelectedItems[0].SubItems[0].Text;
            FileUtils.OpenWindowsExplorer(path);
        }
    }
}
