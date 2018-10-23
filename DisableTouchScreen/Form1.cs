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
            TrayMenuContext();
        }


        /*
         * 
         */
        private void TrayMenuContext()
        {
            this.notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.DISABLE_TEXT, null, this.DisableTouchScreen_Click);
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.QUIT_TEXT, null, this.QuitApplication_Click);
        }


        /*
         *
         */
        private void DisableTouchScreen_Click(object sender, EventArgs e)
        {
            EnableDisableTouchScreen(Constants.DISABLE_FLAG);
            this.notifyIcon.ContextMenuStrip.Items.Clear();
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.ENABLE_TEXT, null, this.EnableTouchScreen_Click);
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.QUIT_TEXT, null, this.QuitApplication_Click);
            this.notifyIcon.Icon = Properties.Resources.Disable;
        }

        private void EnableTouchScreen_Click(object sender, EventArgs e)
        {
            EnableDisableTouchScreen(Constants.ENABLE_FLAG);
            this.notifyIcon.ContextMenuStrip.Items.Clear();
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.DISABLE_TEXT, null, this.DisableTouchScreen_Click);
            this.notifyIcon.ContextMenuStrip.Items.Add(Constants.QUIT_TEXT, null, this.QuitApplication_Click);
            this.notifyIcon.Icon = Properties.Resources.Enable;
        }


        /*
         * 
         */
        private void QuitApplication_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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
