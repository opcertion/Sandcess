using System.Runtime.InteropServices;

namespace Sandcess
{
	public partial class MainWindow : Form
	{
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
		private enum CONTENT
		{
			DASHBOARD = 0,
			FILE_SYSTEM,
			PROCESS,
			CONTAINER,
			EVENT_LOG,
		};

		public MainWindow(string[] args)
		{
			InitializeComponent();
			this.Padding = new Padding(1);
			this.BackColor = Color.FromArgb(39, 55, 70);


			AccessController.LoadAccessInfo();
			ContainerController.LoadContainerInfo();


			if (args.Length > 1 && args[0] == "--SetPermission")
			{
				string path = args[1];
				if (FileUtils.IsExists(path))
				{
					SetMainContent(CONTENT.FILE_SYSTEM, new FileSystemForm(path));
					return;
				}
			}
			SetMainContent(CONTENT.DASHBOARD, new DashboardForm());
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

		private void btnMenuDashboard_Click(object sender, EventArgs e) { SetMainContent(CONTENT.DASHBOARD, new DashboardForm()); }
		private void btnMenuFileSystem_Click(object sender, EventArgs e) { SetMainContent(CONTENT.FILE_SYSTEM, new FileSystemForm()); }
		private void btnMenuProcess_Click(object sender, EventArgs e) { SetMainContent(CONTENT.PROCESS, new ProcessForm()); }
		private void btnMenuContainer_Click(object sender, EventArgs e) { SetMainContent(CONTENT.CONTAINER, new ContainerForm()); }
		private void btnMenuEventLog_Click(object sender, EventArgs e) { SetMainContent(CONTENT.EVENT_LOG, new EventLogForm()); }

		private void SetMainContent(CONTENT content, Form contentForm)
		{
			List<string> formTitleList = new List<string> { "Dashboard", "File System", "Process", "Container", "Event Log" };
			labelMainTitle.Text = formTitleList[(int)content];
			
			contentForm.TopLevel = false;
			contentForm.FormBorderStyle = FormBorderStyle.None;
			contentForm.Dock = DockStyle.Fill;

			panelMainContent.Controls.Clear();
			panelMainContent.Controls.Add(contentForm);
			contentForm.Show();

			foreach (Control control in panelSideMenu.Controls)
			{
				control.BackColor = (
					(control.TabIndex == (int)content) ?
					Color.FromArgb(98, 153, 230) :  // selected color
					Color.FromArgb(30, 30, 30)      // default color
				);
			}
		}
	}
}