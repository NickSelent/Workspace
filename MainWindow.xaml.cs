using BobNet.model;
using BobNet.screen;
using BobNet.utility;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BobNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sweep sweep;
        DispatcherTimer t = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };

        Replicants rWin = new Replicants();
        Bogie eWin = new Bogie();
        Resources sWin = new Resources();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            sweep = new Sweep(MainCanvas, RadarScreen);
            
            
            t.Tick += FrameTick;
            t.Start();
        }

        private void FrameTick(object sender, EventArgs e)
        {
            sweep.Move();
            t.Interval = TimeSpan.FromMilliseconds(Framejack.Value);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }



        private void Enemy2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eWin.IsVisible.Equals(false))
                eWin.Show();
            else
                eWin.Hide();
        }

        private void Enemy1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eWin.IsVisible.Equals(false))
                eWin.Show();
            else
                eWin.Hide();
        }

        private void Resources1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sWin.IsVisible.Equals(false))
                sWin.Show();
            else
                sWin.Hide();
        }

        private void Resources2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sWin.IsVisible.Equals(false))
                sWin.Show();
            else
                sWin.Hide();
        }

        private void Resources3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sWin.IsVisible.Equals(false))
                sWin.Show();
            else
                sWin.Hide();
        }

        private void Bob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (rWin.IsVisible.Equals(false))
                rWin.Show();
            else
                rWin.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowManager w = new WindowManager();
            List<ScreenProperties> s = w.LoadData(this.Name);

            if (s.Count > 0)
            {
                this.Top = int.Parse(s[0].ScreenTop);
                this.Left = int.Parse(s[0].ScreenLeft);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rWin.Close(); //otherwise the exe hangs around
            eWin.Close();
            sWin.Close();

            ScreenProperties s = new ScreenProperties()
            {
                ScreenName = this.Name,
                ScreenTop = this.Top.ToString(),
                ScreenLeft = this.Left.ToString()
            };
            WindowManager w = new WindowManager();
            w.WriteToXmlFile(s, true);

        }

        








    }
}
