using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace WpfLab1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string aktczas = string.Empty;
        public Window1()
        {
            InitializeComponent();
            //tick stopwatch
            dt.Tick += new EventHandler(dt_Tick);
            //interwały ticku
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void dt_Tick(object sender, EventArgs e)
        {
            //program sprawdza czy stoper działa
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                aktczas = string.Format("{0:00}:{1:00}:{2:00}",ts.Minutes,ts.Seconds,ts.Milliseconds/10);
                //wyświetlenie czasu w okienku
                zegarText.Text = aktczas;
            }
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            sw.Start();
            dt.Start();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
            elapsedtimeitem.Items.Add(aktczas);
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            zegarText.Text = "00:00:00";
        }
    }
}
