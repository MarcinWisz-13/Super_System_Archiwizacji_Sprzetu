using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_System_Archiwizacji_Sprzetu.Classes.DB_Objects
{
    class Device
    {
        public int devID { get; set; } 
        public string devName {  get; set; }
        public int devType { get; set; }
        public string devNote { get; set; }
        public string devSerialNumber { get; set; }
        public string devCustomer {  get; set; }
        public string devInvoice { get; set; }
        public string devSellDate { get; set; }
        public string devWhoBuild { get; set; }
        public string devWhenBuild { get; set; }


        public Device() 
        {
            
        }
    }
}
