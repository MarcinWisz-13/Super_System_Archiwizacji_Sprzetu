using Dapper;
using Microsoft.Data.SqlClient;
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

namespace Super_System_Archiwizacji_Sprzetu.Windows
{
    /// <summary>
    /// Interaction logic for FirstConnection.xaml
    /// </summary>
    public partial class FirstConnection : Window
    {
        string serwer = string.Empty;
        string db_name = string.Empty;
        string user = string.Empty;
        string password = string.Empty; 

        public FirstConnection()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serwer = textBoxSerwer.Text;
                db_name = textBoxDataBase.Text;
                user = textBoxUser.Text;
                password = passwordBoxPassword.Password;

                if (!string.IsNullOrEmpty(serwer) && !string.IsNullOrEmpty(db_name) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                {

                    //using (var connection = new SqlConnection($"Server = {serwer}; Database = {db_name}; User Id = {user}; Password = {password};"))
                    //{
                    //    var sql = "SELECT 1";
                    //    connection.Execute(sql);
                    //}

                    DPAPI_Helper.DPAPI_Helper DPAPI = new DPAPI_Helper.DPAPI_Helper(System.Security.Cryptography.DataProtectionScope.CurrentUser, true, "config.ini");
                    DPAPI.WriteToIni(serwer, "db_server", "DB_CONFIG");
                    DPAPI.WriteToIni(db_name, "db_name", "DB_CONFIG");
                    DPAPI.WriteToIni(user, "db_user", "DB_CONFIG");
                    DPAPI.EncryptToIni(password, "db_password", "DB_CONFIG");

                    MessageBox.Show("Zapisano pomyślnie!");

                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    throw new Exception("Uzupełnij wszystkie pola!");
                }
                    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }
    }
}
