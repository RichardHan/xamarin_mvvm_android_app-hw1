using MvvmCross.Plugins.File;
using Sharks.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharks.Core.Services
{
    public class PetStoreService : IPetStoreService
    {
        private IMvxFileStore _fileStore;

        public PetStoreService(IMvxFileStore fileStore )
        {
            _fileStore = fileStore;
        }
        public List<PetViewModel> GetPets()
        {
            //TODO: Try to read a locally stored pets.json file.
            // if the file does not exist, then return the value we generate. 
            return new List<PetViewModel>
            {
                new PetViewModel { Name = "Kitty", Sex="F", IsNeutered = true },
                new PetViewModel { Name = "Zack", Sex="M", IsNeutered = false },
                new PetViewModel { Name = "Mia", Sex="F", IsNeutered = false },
                new PetViewModel { Name = "Dino", Sex="M", IsNeutered = false },
                new PetViewModel { Name = "Hank", Sex="M", IsNeutered = false }
            };
        }

        public void SavePets(IEnumerable<PetViewModel> pets)
        {
            //TODO: save the pets to a local json file
        }
    }

    public interface IPetStoreService
    {
        List<PetViewModel> GetPets();

        void SavePets(IEnumerable<PetViewModel> pets);
    }
}

