using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;

namespace Sandcess
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private const int borderSize = 1;
        private enum ContentIndex
        {
            Dashboard = 0,
            FileSystem,
            Process,
            Container,
            EventLog,
        };
        private const string currentSelectedFile = "";


        public MainWindow(string[] args)
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);
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


        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 10, 10, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
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
            /*
            if (!AccessController.SetPermission(, ))
            {
                MessageBox.Show(
                    "Cannot connect to driver.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            */
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
            }
            if (contentIndex == ContentIndex.Process)
            {
                Process[] processList = Process.GetProcesses();

                listViewProcessProcess.Items.Clear();
                for (int idx = 0; idx < processList.Length; idx++)
                {
                    ListViewItem listViewItem = new ListViewItem(processList[idx].Id.ToString());

                    listViewItem.SubItems.Add(processList[idx].ProcessName);
                    try { listViewItem.SubItems.Add(processList[idx].MainModule.FileName); }
                    catch { continue; }
                    listViewItem.SubItems.Add("-");

                    listViewProcessProcess.Items.Add(listViewItem);
                }
            }
        }
    }
}