using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;


namespace TimeLord_Konevskii.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        public DispatcherTimer DispatcherTimer = new DispatcherTimer();
        public float full_second = 0;
        public bool start_stopwatch = false;
        public Stopwatch()
        {
            InitializeComponent();

            DispatcherTimer.Tick += TimerSecond;
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, System.EventArgs e)
        {
            full_second++;

            float hours = (int)(full_second / 60 / 60);
            float minuts = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 60 * 60) - (minuts * 60);

            string s_second = seconds.ToString();
            if (seconds < 10) s_second = "0" + seconds;

            string s_minuts = minuts.ToString();
            if (minuts < 10) s_minuts = "0" + minuts;

            string s_hours = hours.ToString();
            if (hours < 10) s_hours = "0" + hours;

            time.Content = s_hours + ":" + s_minuts + ":" + s_second;
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (start_stopwatch == false)
            {
                full_second = 0;
                DispatcherTimer.Start();
                start_stopwatch = true;
                start.Content = "Стоп";
            }
            else
            {
                DispatcherTimer.Stop();
                start_stopwatch = false;
                start.Content = "Начать";
            }
        }
    }
}
