using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Diagnostics;

namespace Breathe
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        private static int interval = 1;
        private static ToastNotifier toastNotifier;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int val = trackBar1.Value;
            int interval = trackBar1.Value;

            string msg = String.Format("Time interval for reminder: {0} minutes", val);
            this.textBox1.Text = msg;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void RepeatingEvent()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(interval*1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           

            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
            //e.SignalTime);

            //var toast_text_arr = System.IO.File.ReadLines(Resource1.quotes).ToArray();
            var toast_text_arr = Resource1.quotes.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string toastXmlString =
$@"<toast><visual>
            <binding template='ToastGeneric'>
            <text>toast title</text>
            <text>2</text>
            </binding>
        </visual></toast>";

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(toastXmlString);
            var toastNotification = new ToastNotification(xmlDoc);
            toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toastNotification);
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            RepeatingEvent();

        }

        //private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    Debug.WriteLine("xxxxxxxx closed");
        //}
        override
        protected void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            Debug.WriteLine("xxxxxxxx closed");
            aTimer.Enabled = false;
            aTimer.Stop();
            aTimer.Dispose();
            
            //System.Windows.Application.Current.Shutdown();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            //Environment.Exit(0);


        }

    }
}
