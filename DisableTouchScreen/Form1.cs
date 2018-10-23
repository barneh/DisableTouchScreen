using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisableTouchScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            Hide();
            notifyIcon.Visible = true;

        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {   
                contextMenuStrip.Show(Control.MousePosition);
            }
        }

        private void OnContextMenuItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            if(clickedItem.Text.Equals(Constants.ENABLE_TEXT))
            {
                EnableTouchScreen();
                contextMenuStrip.Items.Clear();
                contextMenuStrip.Items.Add(Constants.DISABLE_TEXT);
            }
            else
            {
                DisableTouchScreen();
                contextMenuStrip.Items.Clear();
                contextMenuStrip.Items.Add(Constants.ENABLE_TEXT);
            }
           
        }

        private void EnableTouchScreen()
        {
            /*
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD");
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = "devcon disable ''HID\\VID_03EB & PID_8B0D & MI_01''";
            startInfo.Verb = "runas";
            p.StartInfo = startInfo;
            p.Start();
            */
            Process pr = new Process();
            pr.StartInfo.FileName = "cmd.exe";
            //pr.StartInfo.Arguments = "/k ipconfig";
            pr.StartInfo.Arguments = "/k C:/DisableTouchScreen/touchscreen.bat";
            pr.StartInfo.UseShellExecute = false;
            pr.StartInfo.CreateNoWindow = true;
            pr.Start();
        }

        private void DisableTouchScreen()
        {
            //devcon enable '%touchscreenid%')";
        }
    }
}
