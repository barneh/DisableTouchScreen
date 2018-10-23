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

        /*
         *
         */
        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {   
                contextMenuStrip.Show(Control.MousePosition);
            }
        }


        /*
         * 
         */
        private void OnContextMenuItem_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text.Equals(Constants.DISABLE_TEXT))
            {
                EnableDisableTouchScreen(Constants.DISABLE_FLAG);
                contextMenuStrip.Items.Clear();
                contextMenuStrip.Items.Add(Constants.ENABLE_TEXT);
                this.notifyIcon.Icon = Properties.Resources.Disable;
            }
            else
            {
                EnableDisableTouchScreen(Constants.ENABLE_FLAG);
                contextMenuStrip.Items.Clear();
                contextMenuStrip.Items.Add(Constants.DISABLE_TEXT);
                this.notifyIcon.Icon = Properties.Resources.Enable;
            }
           
        }


        /**
         *
         */
        private void EnableDisableTouchScreen(int flag)
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
            pr.StartInfo.Arguments = "/k ipconfig";
            pr.StartInfo.UseShellExecute = false;
            pr.StartInfo.CreateNoWindow = true;
            pr.Start();

            if (flag == Constants.DISABLE_FLAG)
            {
                // here we disable the touch screen
                Console.WriteLine("Disabling the touchscreen!");
            }
            else
            {
                // here we enable the touch screen
                Console.WriteLine("Enabling the touchscreen!");
            }
        }
    }
}
