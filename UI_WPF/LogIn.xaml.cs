using DAL_INTERFACE;
using Entities;
using System.Net;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            IVolunteer dal_Log = Cache.GetVolunteerDalByConfig();
            BL.Volunteer_BL VolBL = new BL.Volunteer_BL(dal_Log);
            Volunteer v = new Volunteer()
            { FullName = txtUserName.Text, Password = txtPassword.Password };
            Volunteer currentVol = VolBL.Authenticate(v);
            if (currentVol != null)
            {
                Cache.CurrentVolunteer = currentVol;
                MessageBox.Show($"Welcome {currentVol.FullName}!");
                Window volunteerWindow = new VolunteerWindow();
                volunteerWindow.Show();
                Window.GetWindow(this)?.Close();
            }
            else
                MessageBox.Show("The user doesnt exist, authentication failed!");
        }
    }
}