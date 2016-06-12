using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.File;
using Sharks.Core.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using MvvmCross.Platform;

namespace Sharks.Core.Services
{
    public interface IPetStoreService
    {
        List<PetViewModel> GetPets();

        void SavePets(IEnumerable<PetViewModel> pets);
    }

    public class PetStoreService : IPetStoreService
    {
        private IMvxFileStore _fileStore;
        private readonly IMvxJsonConverter _jsonConverter;
        private string filePath = "pets.json";

        public PetStoreService(IMvxFileStore fileStore)
        {
            _fileStore = fileStore;
            _jsonConverter = Mvx.Resolve<IMvxJsonConverter>();
            SetupDefaultData();
        }

        private void SetupDefaultData()
        {
            string petsData = LoadPetsDataFromLocalJson();
            if (string.IsNullOrEmpty(petsData))
            {
                // if the file does not exist, then return the value we generate. 
                var defaultData = new List<PetViewModel>
                {
                    new PetViewModel { Name = "Kitty", Sex="F", IsNeutered = true },
                    new PetViewModel { Name = "Zack", Sex="M", IsNeutered = false },
                    new PetViewModel { Name = "Mia", Sex="F", IsNeutered = false },
                    new PetViewModel { Name = "Dino", Sex="M", IsNeutered = false },
                    new PetViewModel { Name = "Hank", Sex="M", IsNeutered = false }
                };
                
                var json = _jsonConverter.SerializeObject(defaultData);
                _fileStore.WriteFile(filePath, json);
            }
        }

        public List<PetViewModel> GetPets()
        {
            // Try to read a locally stored pets.json file.
            string petsData = LoadPetsDataFromLocalJson();
            
            // Covert json string to PetViewModel.
            List<PetViewModel> dataSource =
                _jsonConverter.DeserializeObject<List<PetViewModel>>(petsData);
            return dataSource;
        }

        private string LoadPetsDataFromLocalJson()
        {
            string jsonContent = string.Empty;
            _fileStore.TryReadTextFile(filePath, out jsonContent);
            return jsonContent;
        }

        public void SavePets(IEnumerable<PetViewModel> pets)
        {            
            var json = _jsonConverter.SerializeObject(pets);
            _fileStore.WriteFile(filePath, json);
        }
    }
}

