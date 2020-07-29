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
using Tulpep.NotificationWindow;
using System.Windows.Controls.Primitives;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Foundation;
using System.Windows.Threading;

namespace Breathe
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        //private static int interval = 1;
        private static ToastNotifier toastNotifier;
        //private static int i =1;
        //private static PopupNotifier popupNotifier;
        //private static NotifyIcon notification;
        private const String APP_ID = "Microsoft.Samples.DesktopToastsSample";
        
        String image_base_dir =@"C:\Users\samudbha\source\repos\Breathe\Breathe\Resources";

        private String[] image_arr = { "kawaii_robot.png", "cloud.png", "butterfly.jpg", "star.png", "rocket.png" };
        String[] toast_text_arr;
        int counter = 0;
        Form2 form2 = new Form2();


        public Form1()
        {
            InitializeComponent();
            //// Register COM server and activator type
            //DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();
            //// Construct the visuals of the toast (using Notifications library)
            //ToastContent toastContent = new ToastContentBuilder()
            //    .AddToastActivationInfo("action=viewConversation&conversationId=5", ToastActivationType.Foreground)
            //    .AddText("Hello world!")
            //    .GetToastContent();

            //// And create the toast notification
            //var toast = new ToastNotification(toastContent.GetXml());

            //// And then show it
            //DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
            this.toast_text_arr = Resource1.quotes.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (String x in toast_text_arr)
            {
                Debug.WriteLine("xxx " + x);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //int val = trackBar1.Value;
            //int interval = trackBar1.Value;
          

         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void RepeatingEvent(int interval)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(interval * 1000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //notification = new NotifyIcon()
            //{
            //    Visible = true,
            //    //Icon = System.Drawing.SystemIcons.Information,
            //    Icon = Icon.FromHandle(Resource1.smiley_face_1.GetHicon()),


            //    // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
            //    // optional - BalloonTipTitle = "My Title",
            //    BalloonTipText = "my long description...7",


            //};
            //notification.ShowBalloonTip(1000);




            //            string toastXmlString =
            //$@"<toast><visual>
            //            <binding template='ToastImageAndText01'>
            //            <image src = Res></image>
            //            <text>7</text>
            //            </binding>
            //        </visual></toast>";

            //            var xmlDoc = new XmlDocument();
            //            xmlDoc.LoadXml(toastXmlString);
            //            var toastNotification = new ToastNotification(xmlDoc);

            //toastNotifier = ToastNotificationManager.CreateToastNotifier("Microsoft.Samples.DesktopToastsSample");

            //toastNotification.Failed += (a, b) => { textBox1.Text = "toast failed"; };


            //toastNotifier.Show(toastNotification);
            //this.textBox1.Text = i.ToString();
            //i++;

            //popupNotifier = new PopupNotifier();
            //popupNotifier.Image = Resource1.smiley_face_1;
            //popupNotifier.TitleText = "title";
            //popupNotifier.ContentText = "content";
            //popupNotifier.Popup();
            var imageloc = new System.Uri(this.image_base_dir + "/"+ this.image_arr[counter % 5]);

            ToastContent toastContent = new ToastContentBuilder()
                .AddToastActivationInfo("action=viewConversation&conversationId=5", ToastActivationType.Foreground)
                .AddText(this.toast_text_arr[this.counter%5]).AddInlineImage(imageloc).GetToastContent();
            counter++;


            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());
            //toast.Activated += showVideo(null, null);
            //toast.Activated += ToastNotification_Activated;
            

            // And then show it
            DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);

        }

        private TypedEventHandler<ToastNotification, object> showVideo(object sender, object args)
        {
            throw new NotImplementedException();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            RepeatingEvent(this.trackBar1.Value);

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
            //notification.Visible = false;
            //notification.Dispose();
         


            //System.Windows.Application.Current.Shutdown(); //crashes in prod
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private TypedEventHandler<ToastNotification, object>  showVideo(ToastNotification sender, object args)
        {

            /*his.form2 = new Form2();*/
            form2.Activate();
            return null;
        }
        private void ToastActivated(ToastNotification sender, object e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                this.Activate();
                //Output.Text = "The user activated the toast.";
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*his.form2 = new Form2();*/
            form2.Show();
            form2.Activate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
        System.Diagnostics.Process.Start(@"https://powerva.microsoft.com/canvas?cci_bot_id=5d769307-c43f-4cc4-a983-62ebc2c040ca&cci_tenant_id=72f988bf-86f1-41af-91ab-2d7cd011db47"); 
        }
    }
}
