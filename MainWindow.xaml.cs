using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Super_System_Archiwizacji_Sprzetu.Classes;
using Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects;
using Super_System_Archiwizacji_Sprzetu.Windows;

namespace Super_System_Archiwizacji_Sprzetu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAddNewDevice(object sender, RoutedEventArgs e)
        {
            MoreDeviceInfo addNewDevice = new MoreDeviceInfo(1);  //mode 1 - adding
            addNewDevice.ShowDialog();
        }

        private void dataGridDevices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGridDevices.SelectedItem is Device selectedDevice)
            {
                MoreDeviceInfo addNewDevice = new MoreDeviceInfo(2, selectedDevice.devID);  //mode 2 - update
                addNewDevice.ShowDialog();
            }

            
        }

        private void EditDictionary_Click(object sender, RoutedEventArgs e)
        {
            // Tworzenie menu kontekstowego
            var contextMenu = new ContextMenu();

            // Dodanie elementów do menu
            var menuItem1 = new MenuItem { Header = "Nazwy urządzeń" };
            menuItem1.Click += (s, args) => { var dic1 = new DictionaryEdit("Nazwy urządzeń"); dic1.ShowDialog(); };

            var menuItem2 = new MenuItem { Header = "Typy urządzeń" };
            menuItem2.Click += (s, args) => { var dic2 = new DictionaryEdit("Typy urządzeń"); dic2.ShowDialog(); };

            var menuItem3 = new MenuItem { Header = "Nazwy części" };
            menuItem3.Click += (s, args) => { var dic3 = new DictionaryEdit("Nazwy części"); dic3.ShowDialog(); };

            var menuItem4 = new MenuItem { Header = "Typy części" };
            menuItem4.Click += (s, args) => { var dic4 = new DictionaryEdit("Typy części"); dic4.ShowDialog(); };

            contextMenu.Items.Add(menuItem1);
            contextMenu.Items.Add(menuItem2);
            contextMenu.Items.Add(menuItem3);
            contextMenu.Items.Add(menuItem4);

            // Wyświetlenie menu przy przycisku
            var button = sender as Button;
            if (button != null)
            {
                contextMenu.PlacementTarget = button; // Umiejscowienie przycisku
                contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom; // Poniżej przycisku
                contextMenu.IsOpen = true; // Otwarcie menu
            }
        }
    }
}