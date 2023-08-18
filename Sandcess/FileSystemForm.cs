
namespace Sandcess
{
	public partial class FileSystemForm : Form
	{
		public FileSystemForm()
		{
			InitializeComponent();

			Initialize();
		}

		public FileSystemForm(string path)
		{
			InitializeComponent();

			ListViewItem listViewItem = new ListViewItem(FileUtils.GetFileName(path));
			listViewItem.SubItems.Add(path);
			listViewFile.Items.Add(listViewItem);
		}

		private void Initialize()
		{
			foreach (string path in AccessController.GetPathList())
			{
				ListViewItem listViewItem = new ListViewItem(FileUtils.GetFileName(path));
				listViewItem.SubItems.Add(path);
				listViewFile.Items.Add(listViewItem);
			}

			foreach (string container in ContainerController.GetContainerList())
				checkedListBoxContainer.Items.Add(container);
		}

		private void listViewFile_SelectedIndexChanged(object sender, EventArgs e)
		{
            foreach (CheckedListBox checkedListBox in new CheckedListBox[]{
                checkedListBoxFilePermission,
                checkedListBoxProcessPermission,
                checkedListBoxNetworkPermission
            })
            {
                checkedListBox.SelectedItems.Clear();
                for (int idx = 0; idx < checkedListBox.Items.Count; idx++)
                    checkedListBox.SetItemChecked(idx, false);
            }
            for (int idx = 0; idx < checkedListBoxContainer.Items.Count; idx++)
                checkedListBoxContainer.SetItemChecked(idx, false);

            if (listViewFile.SelectedItems.Count == 0)
				return;

			string path = listViewFile.SelectedItems[0].SubItems[1].Text;
			uint permission = AccessController.GetPermission(path);
			int currentAccessType = 2;

			foreach (CheckedListBox permissionCheckedBox in new CheckedListBox[]{
				checkedListBoxFilePermission,
				checkedListBoxProcessPermission,
				checkedListBoxNetworkPermission
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
				checkedListBoxContainer.SetItemChecked(
					containerIdx,
					(currentEnabledContainer.Contains(container))
				);
				containerIdx += 1;
			}
		}

		private void btnFileApply_Click(object sender, EventArgs e)
		{
			if (listViewFile.SelectedItems.Count == 0)
			{
				MessageBoxController.ShowError("No file chosen.");
				return;
			}
			string path = listViewFile.SelectedItems[0].SubItems[1].Text;
			uint permission = 0;
			int currentAccessType = 2;

			foreach (CheckedListBox permissionCheckedListBox in new CheckedListBox[]{
				checkedListBoxFilePermission,
				checkedListBoxProcessPermission,
				checkedListBoxNetworkPermission
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
	}
}
