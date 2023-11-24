using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AnalogClock
{
    /**
    This script contains the logic to update the analog clock based on the current system clock.
    It calculates the clock on start and then updates it every second.
    **/

    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Ticker;
            timer.Start();

        }

        /**
        This function acts as a wrapper to call an UpdateClock.
        It is called in the MainWindow loop to update the clock every second
        **/

        private void Ticker(object sender, EventArgs e)
        {
            UpdateClock();

        }

        /**
        This function updates the clock based on the current system time.
        It converts the current digital time in hours, minutes and seconds to degrees on an analog clock.
        Then the function applies a rotation to the hands on the face of the analog clock.
        **/
        
        private void UpdateClock()
        {
            DateTime curentTime = DateTime.Now;

            double hourAngle = (curentTime.Hour % 12 + curentTime.Minute / 60.0) * 30;
            double minuteAngle = curentTime.Minute * 6;
            double secondAngle = curentTime.Second * 6;

            hour.RenderTransform = new RotateTransform(hourAngle, 100, 100);
            minute.RenderTransform = new RotateTransform(minuteAngle, 100, 100);
            second.RenderTransform = new RotateTransform(secondAngle, 100, 100);

        }
    }
}