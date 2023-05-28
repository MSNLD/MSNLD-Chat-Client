using System.Diagnostics;
using System.Drawing;
using static PInvoke.User32;

namespace MSNLD_Chat_Client
{
    public partial class MainForm : Form
    {
        IntPtr mdiFrame;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            EventHandler? handler = null; // Single use handler.
            handler = (object? s, EventArgs e) =>
            {
                form.WindowState = FormWindowState.Maximized; // Maximise form.
                form.Shown -= handler; // Remove handler (self).
            };
            form.Shown += handler; // Add handler.
            form.MdiParent = this;
            form.Show();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var whisperManager = new WhisperManager();
            whisperManager.WhisperWindowOpened += WhisperManager_WhisperWindowOpened;
            whisperManager.WhisperWindowClosed += WhisperManager_WhisperWindowClosed;
            newToolStripMenuItem_Click(sender, e);
            if (ActiveMdiChild != null) ActiveMdiChild.WindowState = FormWindowState.Maximized;

            // We need to get (and store) the actual MDI frame, rather than the form.
            // The easiest way I can think of to do this, is create a MDIChild form and look at it's parent.
            var tmpForm = new Form();
            tmpForm.ControlBox = false;
            tmpForm.ClientSize = new Size(0, 0);
            // When we set MdiParent, the form will be shown (briefly) - It should not be visible.
            tmpForm.MdiParent = this;
            mdiFrame = GetAncestor(tmpForm.Handle, GetAncestorFlags.GA_PARENT);
            tmpForm.Close(); // We don't need it anymore. GC will clean it up.
        }

        private void WhisperManager_WhisperWindowClosed(object? sender, WhisperEventArgs e)
        {
            treeView1.Nodes[0].Nodes.RemoveByKey(e.hwnd.ToString());
        }

        private void WhisperManager_WhisperWindowOpened(object? sender, WhisperEventArgs e)
        {
            if (treeView1.ImageList == null)
            {
                var icon = Misc.GetAppIcon(e.hwnd);
                var imageList = new ImageList();
                if (icon != null)
                {
                    imageList.Images.Add(new Bitmap(16, 16)); // Blank icon
                    imageList.Images.Add(icon); // Whisper Window icon
                }
                treeView1.ImageList = imageList;
            }
            //this.Icon = Misc.GetAppIcon(e.hwnd); // Steal Whisper Window icon - Just for fun.
            TreeNode subNode = treeView1.Nodes[0].Nodes.Add(e.hwnd.ToString(), e.title, 1);
            subNode.SelectedImageIndex = 1; // Don't change image when selected.

            // Set window flags
            /*var cStyle = (SetWindowLongFlags)GetWindowLong(e.hwnd, WindowLongIndexFlags.GWL_STYLE);
              cStyle &= ~SetWindowLongFlags.WS_EX_NOPARENTNOTIFY;
              cStyle &= ~SetWindowLongFlags.WS_EX_TOOLWINDOW;
              cStyle &= ~SetWindowLongFlags.WS_EX_STATICEDGE;
              cStyle &= ~SetWindowLongFlags.WS_EX_APPWINDOW;
              cStyle &= ~SetWindowLongFlags.WS_POPUP;
              cStyle &= ~SetWindowLongFlags.WS_CHILD;
              cStyle &= ~SetWindowLongFlags.WS_CAPTION;
              SetWindowLong(e.hwnd, WindowLongIndexFlags.GWL_STYLE, cStyle);*/

            // Create parent form
            /*var whisperWindow = new Form();
              whisperWindow.MdiParent = this;
              whisperWindow.Text = utf8WindowText;

              GetWindowRect(lastWindow, out var rect);
              // Set default client size
              whisperWindow.ClientSize = new Size(rect.right - rect.left, rect.bottom - rect.top);
              whisperWindow.Show();
              // In case we are maximised, we need to have the Whisper Window the same size.
              MoveWindow(lastWindow, 0, 0, whisperWindow.ClientSize.Width + 2, whisperWindow.ClientSize.Height + 2, true);
              var thisWindow = lastWindow; // lastWindow will be garbage collected
              whisperWindow.Resize += (s, e) =>
              {
                  MoveWindow(thisWindow, 0, 0, whisperWindow.ClientSize.Width + 2, whisperWindow.ClientSize.Height + 2, true);
              };*/
            SetParent(e.hwnd, mdiFrame);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            IntPtr hwnd;
            try
            {
                hwnd = (IntPtr)Convert.ToInt64(treeView1.SelectedNode.Name);
                SetForegroundWindow(hwnd);
            }
            catch (Exception)
            {
                // One of two things happened
                // - (Likely) Key isn't a valid Int64, so it can't be converted to IntPtr
                // - (Unlikely) Key is a valid Int64, but it's not a valid hwnd.
                return;
            }
        }
    }
}