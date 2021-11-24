using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8
{
    public partial class MainWindow : Form
    {
        System.Threading.Thread t;
        Random NOT_8 = new Random();
        System.Media.SoundPlayer eightplayer = new System.Media.SoundPlayer(Properties.Resources.eight);
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.Sleep(1000);
            this.Hide();
            eightplayer.LoadAsync();
            t = new System.Threading.Thread(runRandom8Check);
            t.Start();
        }

        public void runRandom8Check()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => runRandom8Check()));
                return;
            }
            System.Threading.Thread.Sleep(10000);
            while (true)
            {
                double eight = NOT_8.Next(0,10) / 10 + 8;
                //double eight = 8.5;

                switch (eight)
                {
                    case 8.5:
                        showWindow();
                        break;
                    case 8.2:
                        notifyIcon8.Visible = true;
                        notifyIcon8.ShowBalloonTip(2500, "8", "8", ToolTipIcon.None);
                        System.Threading.Thread.Sleep(3100);
                        notifyIcon8.Visible = false;
                        break;
                    default:
                        break;

                }

                System.Threading.Thread.Sleep(30000);
            }
        }

        private void showWindow()
        {
            //if (this.InvokeRequired)
            //{
                this.Invoke(new MethodInvoker(() => showWindowRestart()));
                //return;
            //}
        }

        private void showWindowRestart()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Refresh();
            eightplayer.PlaySync();
            System.Threading.Thread.Sleep(300);
            this.Hide();
        }
    }
}
