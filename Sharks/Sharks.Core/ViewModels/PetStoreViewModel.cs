using MvvmCross.Core.ViewModels;
using Sharks.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sharks.Core.ViewModels
{
    public class PetStoreViewModel : BaseViewModel
    {
        private IPetStoreService _petStoreService;

        public PetStoreViewModel(IPetStoreService petStoreService)
        {
            _petStoreService = petStoreService;
        }
       

        public List<PetViewModel> Pets
        {
            get { return _petStoreService.GetPets(); }            
        }

        public ICommand SaveCommand
        {
            get { return new MvxCommand(() => Save()); }
        }

        private void Save()
        {
            _petStoreService.SavePets(Pets);
        }

    }
}
