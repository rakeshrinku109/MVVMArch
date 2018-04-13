using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMArch
{
    public class ArchModel : DependencyObject,IDataErrorInfo
    {
        private string searchTxt;
        private string propertyName;
        string result = string.Empty;
        public ArchModel()
        {

        }

        public string this[string propertyName]
        {
            get
            {
                
                this.propertyName = propertyName;

                if (string.IsNullOrEmpty(this.propertyName))
                {
                    result = "search text is invalid, please retry";
                }
                
                return result;
            }
        }

        public string Error
        {
            get
            {
                return result;
            }
        }

        public string SearchTxt
        {
            get
            {
                return searchTxt;
            }

            set
            {
                searchTxt = value;
            }
        }
    }
}
