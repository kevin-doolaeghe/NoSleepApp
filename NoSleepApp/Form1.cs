using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NoSleepApp {
    public partial class Form1 : Form {
        private bool waiting;
        private BackgroundWorker worker;

        public Form1()
        {
            waiting = false;
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Wait;
            worker.ProgressChanged += UpdateCursor;
            worker.RunWorkerCompleted += EnableButton;
        }

        private void Wait(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;
            int i = 0;
            while (waiting)
            {
                bg.ReportProgress(i);
                i += 10;
                Thread.Sleep(10);
            }
        }

        private void UpdateCursor(object sender, ProgressChangedEventArgs e)
        {

            int coef = 2;
            double rad = Math.PI / 180;
            int i = e.ProgressPercentage;
            Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + (int)(coef * Math.Cos(i * rad)), Cursor.Position.Y + (int)(coef * Math.Sin(i * rad)));
        }

        private void EnableButton(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            waiting = true;
            worker.RunWorkerAsync();
            button1.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                waiting = false;
                MessageBox.Show("You pressed Ctrl+C");
            }
        }
    }
}
