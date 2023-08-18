using System.Collections;
using System.Diagnostics;

namespace Sandcess
{
	public partial class ProcessForm : Form
	{
		public ProcessForm()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{
			List<Process> processList = new List<Process>(Process.GetProcesses());
			Hashtable pathHashTable = new Hashtable();

			for (int idx = 0; idx < processList.Count; idx++)
			{
				ListViewItem listViewItem = new ListViewItem(processList[idx].Id.ToString());

				string path;
				try { path = processList[idx].MainModule.FileName; }
				catch { continue; }
				if (path == null || pathHashTable.ContainsKey(path))
					continue;

				listViewItem.SubItems.Add(processList[idx].ProcessName);
				listViewItem.SubItems.Add(path);
				listViewProcess.Items.Add(listViewItem);
				pathHashTable.Add(path, true);
			}
		}

		private void listViewProcess_DoubleClick(object sender, EventArgs e)
		{
			if (listViewProcess.SelectedItems.Count == 0)
				return;
			string path = listViewProcess.SelectedItems[0].SubItems[2].Text;
			FileUtils.OpenFileExplorer(path);
		}
	}
}
