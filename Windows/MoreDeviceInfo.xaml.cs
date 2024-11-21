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
using Super_System_Archiwizacji_Sprzetu.Classes;
using Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects;

namespace Super_System_Archiwizacji_Sprzetu.Windows
{
    /// <summary>
    /// Interaction logic for AddNewDevice.xaml
    /// </summary>
    public partial class MoreDeviceInfo : Window
    {
        App app = (App)Application.Current;
        public MoreDeviceInfo(int mode, int device_id = -1) //mode 1-adding, 2-updating
        {

            InitializeComponent();
            try
            {
                if (mode == 1)
                {
                    this.Title += "Adding";
                    ComboBoxDeviceType.ItemsSource = app.DB_interface.GetDataSQL<DeviceType>("Select dtName from DeviceType").Select(d => d.dtName).ToList();
                }
                else if (mode == 2)
                {
                    if (device_id != -1)
                    {
                        this.Title += $"Update id={device_id}";
                        //wczytanie pobranych danych 
                        Device existingDevice = app.DB_interface.GetSingleDataSQL<Device>($"SELECT * FROM Devices WHERE devID = {device_id}");

                    }
                    else
                    {
                        throw new Exception("Błąd w strukturze otwarcia okna, device_id=-1");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            
           
        }
    }
}
