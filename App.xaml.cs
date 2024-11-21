using System.Configuration;
using System.Data;
using System.Windows;
using Super_System_Archiwizacji_Sprzetu.Windows;
using Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects;


using Microsoft.Data.SqlClient;
using Dapper;
using Super_System_Archiwizacji_Sprzetu.Classes;


namespace Super_System_Archiwizacji_Sprzetu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    
    public partial class App : Application
    {
        private string connectionString;
        public MainWindow _mainWindow;
        public DPAPI_Helper.DPAPI_Helper DPAPI;     //uniwersalny obiekt do operacji z DPAPI 
        public DataBaseInteraction DB_interface;    //uniwersalny obiekt do operacji na bazie 
        public App() 
        {
            DPAPI = new DPAPI_Helper.DPAPI_Helper(System.Security.Cryptography.DataProtectionScope.CurrentUser, true, "config.ini");
        }






        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FirstConnection firstConnection;


            if (string.IsNullOrEmpty(DPAPI.ReadFromIni("db_server", "DB_CONFIG")) || string.IsNullOrEmpty(DPAPI.ReadFromIni("db_name", "DB_CONFIG")) ||
                string.IsNullOrEmpty(DPAPI.ReadFromIni("db_user", "DB_CONFIG")) || string.IsNullOrEmpty(DPAPI.ReadFromIni("db_password", "DB_CONFIG")))
            {
                firstConnection = new FirstConnection();
                bool? result = firstConnection.ShowDialog();
                if (result == false)
                {
                    Shutdown();
                    return;
                }
            }

            _mainWindow = new MainWindow();
            _mainWindow.Show();
            connectionString = @$"Server = {DPAPI.ReadFromIni("db_server", "DB_CONFIG")}; Database = {DPAPI.ReadFromIni("db_name", "DB_CONFIG")}; 
                                  User Id = {DPAPI.ReadFromIni("db_user", "DB_CONFIG")}; Password = {DPAPI.DecryptFromIni("db_password", "DB_CONFIG")};TrustServerCertificate=True;";
            DB_interface = new DataBaseInteraction(connectionString);

            _mainWindow.dataGridDevices.ItemsSource = DB_interface.GetDataSQL<Device>("select * from Devices");
        }




    }

}
