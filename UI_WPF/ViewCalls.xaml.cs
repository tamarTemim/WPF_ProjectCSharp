using BL;
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
    /// Interaction logic for ViewCalls.xaml
    /// </summary>
    public partial class ViewCalls : Window
    {
        private List<Call> allCalls;
        private ICall dal_call = Cache.GetCallDalByConfig();
        private BL.Call_BL callBL;

        public ViewCalls()
        {
            InitializeComponent();
            LoadCategories();
            LoadCalls();
            
        }
        private void LoadCalls()
        {
           callBL = new BL.Call_BL(dal_call);
            allCalls = callBL.GetAllCallsBL(true);
            CallsDataGrid.ItemsSource = allCalls;
        }

        private void LoadCategories()
        {
            List<Category> categories = WareHouse.DataBase.DicCategories.Values.ToList();
            CategoryFilterComboBox.ItemsSource = categories;
            CategoryFilterComboBox.DisplayMemberPath = "CallType";
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //if(Cache.CurrentVolunteer.Job 
        //    //    != "Director")
        //    {
        //        CategoryFilterComboBox.Visibility = Visibility.Collapsed;

        //    }
        //}
        private void CategoryFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryFilterComboBox.SelectedItem is Category selectedCategory)
            {
                // Filtrar los calls según la categoría
                var filtered = allCalls.Where(c => c.Category.Id == selectedCategory.Id).ToList();
                CallsDataGrid.ItemsSource = filtered;
            }
        }

        private void btnAddCall_Click(object sender, RoutedEventArgs e)
        {
            //Cache cV = new Cache();
            Call selectedItem = (Call)CallsDataGrid.SelectedItem;
            bool add = callBL.addVolunteerIdCall_BL(selectedItem, 1);
            if (add)
                MessageBox.Show("The call was added to you");
            else
                MessageBox.Show("Action failed");
            LoadCalls();
                
        }
    }
}
