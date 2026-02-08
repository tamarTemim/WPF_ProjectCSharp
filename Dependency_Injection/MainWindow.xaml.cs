using System.Configuration;
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

namespace Dependency_Injection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IBL _bl;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Llamar desde la configuracion para recibir el nombre del class que quiero
            string dal_Name = ConfigurationManager.AppSettings["DAL"]?? "";
            if (dal_Name == string.Empty) return;
            Type? type = Type.GetType(dal_Name);
            if(type == null) return;
            IDAL_Volunteer obDal = (IDAL_Volunteer)Activator.CreateInstance(type);

            Label l = new Label();
            l.HorizontalAlignment = HorizontalAlignment.Center;
            l.FontSize = 24;
            string blName = ConfigurationManager.AppSettings["BL"] ?? throw new Exception("BL not found");
            Type? typeBl = Type.GetType(blName);
            IBL obBl = (IBL)Activator.CreateInstance(typeBl, obDal);
            l.Content = obBl.GetNumberFromDAL();
            this.AddChild(l);
        }
    }
}