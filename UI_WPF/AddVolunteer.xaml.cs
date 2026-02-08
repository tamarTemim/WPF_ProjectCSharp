using DAL_INTERFACE;
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
    /// Interaction logic for AddVolunteer.xaml
    /// </summary>
    public partial class AddVolunteer : Window
    {
        public AddVolunteer()
        {
            InitializeComponent();
        }
        private void btnSubmitVolunteer_Click(object sender, RoutedEventArgs e)
        {
            IVolunteer dal_addV = Cache.GetVolunteerDalByConfig();
            BL.Volunteer_BL VolBL = new BL.Volunteer_BL(dal_addV);
            bool isAdded = VolBL.AddVolunteerBL(
                int.Parse(txtTz.Text),
                txtFullName.Text,
                int.Parse(txtPhoneNumber.Text),
                txtEmail.Text,
                txtPassword.Text,
                txtAddres.Text,
                txtJob.Text,
                double.Parse(txtMaxDistance.Text),
                (Entities.DistanceType)Enum.Parse(typeof(Entities.DistanceType), txtDT.Text)
            );
            if(isAdded)
            {
                MessageBox.Show("Volunteer added successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add volunteer. Please try again.");
            }
        }
    }
}
