using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMArch
{
    public class ArchViewModel : BaseViewModel
    {
        private ArchModel _archModel;

        private string _sourceTxt;
        private string _destinationTxt;
        private List<Person> _persons;

        public ArchViewModel()
        {
            _archModel = new ArchModel();
            _simpleCommand = new SimpleCommand(this.SearchText,(obj) => true);
        }

        private ICommand _simpleCommand;

        public ICommand SimpleCommand
        {
            get
            {
               
                return _simpleCommand;
            }

            set
            {
                _simpleCommand = value;
            }
        }

        public string SourceTxt
        {
            get
            {
                return _sourceTxt;
            }

            set
            {
                _sourceTxt = value;
                OnPropertyChanged("SourceTxt");
            }
        }

        public string DestinationTxt
        {
            get
            {
                return _destinationTxt;
            }

            set
            {
                _destinationTxt = value;
                OnPropertyChanged("DestinationTxt");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public List<Person> Persons
        {
            get
            {
                _persons = new List<Person>();
                _persons.Add(new Person { Name = "Mike", Age = 62 });
                _persons.Add(new Person { Name = "Brian", Age = 12 });
                _persons.Add(new Person { Name = "stad", Age = 29 });
                return _persons;
            }

        }



        /// <summary>
        /// Search the search text
        /// </summary>
        public void SearchText(object parameter)
        {
            DestinationTxt = (parameter as TextBox).Text ;
        }
    }
}
