using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Registration.Web.DAL
{
    class CustomerDAL
    {
        private string FindCustomer(string FileName)
        {
            try
            {
                char[] array = FileName.ToCharArray();
                Array.Reverse(array);
                string[] JsonFileType = new string(array).ToString().Split('_');
                char[] array2 = JsonFileType[0].ToCharArray();
                Array.Reverse(array2);
                string DBJsonFileType = new string(array2).ToString();
                return new string(array2);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
