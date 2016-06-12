using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Sharks.Core.ViewModels
{
    public class PetViewModel : BaseViewModel
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        string _sex;
        public string Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value.ToUpper()); }
        }

        bool _isNeutered;
        public bool IsNeutered
        {
            get { return _isNeutered; }
            set
            {
                //if (_sex == value)
                //    return;
                //_sex = value;
                //RaisePropertyChanged(new PropertyChangedEventArgs(nameof(Sex)));

                SetProperty(ref _isNeutered, value);
            }
        }


    }
}
