using Entities;
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

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for VolunteerPage.xaml
    /// </summary>
    public partial class VolunteerWindow : Window
    {
        public VolunteerWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Cache.CurrentVolunteer?.Job == "Director")
            {
                btnAddCall.Visibility = Visibility.Visible;
            }
            else 
                btnAddCall.Visibility = Visibility.Collapsed;
        }

        private void BtnViewCalls_Click(object sender, RoutedEventArgs e)
        {
            Window viewCalls = new ViewCalls();
            viewCalls.Show();
            Window.GetWindow(this)?.Close();
        }

        private void BtnAddCall_Click(object sender, RoutedEventArgs e)
        {
            Window addCall = new AddCall();
            addCall.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
