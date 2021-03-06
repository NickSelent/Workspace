﻿using BobNet.model;
using BobNet.utility;
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

namespace BobNet.screen
{
    /// <summary>
    /// Interaction logic for Replicants.xaml
    /// </summary>
    public partial class Replicants : Window
    {
        public Replicants()
        {
            InitializeComponent();
        }

        private void ReplicantsDashboard_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ScreenProperties s = new ScreenProperties()
            {
                ScreenName = this.Name,
                ScreenTop = this.Top.ToString(),
                ScreenLeft = this.Left.ToString()
            };
            WindowManager w = new WindowManager();
            w.WriteToXmlFile(s, true);
        }

        private void ReplicantsDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            WindowManager w = new WindowManager();
            List<ScreenProperties> s = w.LoadData(this.Name);

            if (s.Count > 0)
            {
                this.Top = int.Parse(s[0].ScreenTop);
                this.Left = int.Parse(s[0].ScreenLeft);
            }

            ReplicantsManager b = new ReplicantsManager();
            List<ReplicantsProperties> eList = b.LoadData();

            replicantsList.ItemsSource = eList;
        }

        private void ReplicantsDashboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
