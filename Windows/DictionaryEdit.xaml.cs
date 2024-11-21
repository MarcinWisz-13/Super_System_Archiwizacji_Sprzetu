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
using Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects;

namespace Super_System_Archiwizacji_Sprzetu.Windows
{
    /// <summary>
    /// Interaction logic for DictionaryEdit.xaml
    /// </summary>
    public partial class DictionaryEdit : Window
    {
        public string DictionaryName { get; set; } = string.Empty;
        App app = (App)Application.Current;

        private static readonly Dictionary<string, string> DictionaryTypeMapping = new()
    {
        { "Nazwy urządzeń", "DeviceNames" },
        { "Typy urządzeń", "DeviceType" } // Dodaj kolejne mapowania tutaj
    };

       

        public DictionaryEdit(string dic_name, ) 
        {
            InitializeComponent();
            
            DictionaryName = dic_name;
            DataContext = this;
            try
            {
                if (!DictionaryTypeMapping.TryGetValue(dic_name, out var type))
                    throw new ArgumentException($"Nieobsługiwana nazwa słownika: {type}");

                


                //dataGridDictionary.ItemsSource 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void AddText_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
