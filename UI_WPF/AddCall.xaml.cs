using DAL_INTERFACE;
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
    /// Interaction logic for AddCall.xaml
    /// </summary>
    public partial class AddCall : Window
    {
        public AddCall()
        {
            InitializeComponent();
            Categories();
        }

        public void btnSubmitCall_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = (Category)comboboxCat.SelectedItem;
            DateTime date = datePickerNeeded.SelectedDate.Value;
            ICall dal_addC = Cache.GetCallDalByConfig();
            BL.Call_BL CallBL = new BL.Call_BL(dal_addC);
            bool isAdded = CallBL.AddCallBL(
                selectedCategory,
                txtCallDescription.Text,
                txtCallAddress.Text,
                date
            );
            if (isAdded)
            {
                MessageBox.Show("Call added successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add call. Please try again.");
            }
        }

        private void Categories()
        {
            // Suponiendo que tienes una función que obtiene todas las categorías
            List<String> categories = ["Food", "BabbySitting", "Medical Help", "House Cleanning"]; 
            // Asignamos la lista al ComboBox
            comboboxCat.ItemsSource = categories;

            // Mostrar la propiedad Description en la lista del ComboBox
            comboboxCat.DisplayMemberPath = "Description";

            // Si quieres, puedes usar SelectedValuePath para guardar el Id
            comboboxCat.SelectedValuePath = "Id";
        }
    };
}

