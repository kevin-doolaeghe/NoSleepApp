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
using System.Diagnostics;

namespace NoSleepApp {
    public partial class SleepForm : System.Windows.Forms.Form {

        private bool waiting;
        private readonly BackgroundWorker worker;

        public SleepForm() {
            waiting = false;
            InitializeComponent();

            worker = new() { WorkerReportsProgress = true };
            worker.DoWork += Wait;
            worker.ProgressChanged += UpdateUi;
            worker.RunWorkerCompleted += EnableButton;
        }

        private void Wait(object sender, DoWorkEventArgs e) {
            BackgroundWorker bg = (BackgroundWorker)sender;
            int i = 0;
            while (waiting) {
                bg.ReportProgress(i);

                int j;
                int sleepTime = 300; // 5 minutes
                for (j = 0; j < sleepTime && waiting; j++) {
                    try {
                        Thread.Sleep(1000);
                    } catch (Exception ex) {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void UpdateUi(object sender, ProgressChangedEventArgs e) {
            try {
                SendKeys.Send("^{ESC}");
                Thread.Sleep(100);
                SendKeys.Send("{ESC}");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        private void EnableButton(object sender, RunWorkerCompletedEventArgs e) {
            sleepButton.Enabled = true;
        }

        private void OnSleepButtonClick(object sender, EventArgs e) {
            waiting = true;
            worker.RunWorkerAsync();
            sleepButton.Enabled = false;
        }

        private void OnKeyDownEvent(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.C && e.Control && waiting) {
                waiting = false;
                MessageBox.Show("Application is now disabled.", "Ctrl+C detected !");
            }
        }
    }
}
