"# xamarin_mvvm_android_app-hw1" 


```

Hownwork:

1. Add the "Neutered" check box in the UI, and bind it to the IsNeutered property on the PetViewModel

2. Implement the "Save" button.
For this, we use the ICommand mechanism, which lets us bind an ICommand property to an event. In this case, the Click event of the button.

The project already have basics for this button. Please implement the loading and saving of "pets'json" to the local file store.

```

####1. add PetView.axml 
```
  <CheckBox android:text="Neutered"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            local:MvxBind="Checked IsNeutered"/>
```
    
####2. install MvvmCross.Plugin.Json package via nuget to "Sharks.Droid" project
    
####3. implemt SavePets & GetPets function 
    
  reference:
  [link1](https://github.com/MvvmCross/MvvmCross-Tutorials/blob/master/Sample%20-%20CustomerManagement/CustomerManagement/CustomerManagement/Models/SimpleDataStore.cs) 
  [link2](https://github.com/MvvmCross/MvvmCross-Plugins/tree/master/Json)


```
        public void SavePets(IEnumerable<PetViewModel> pets)
        {
            var fileService = Mvx.Resolve<IMvxFileStore>();
            var serializer = Mvx.Resolve<IMvxJsonConverter>();
            string petsStr = serializer.SerializeObject(pets);
            fileService.WriteFile(filePath, petsStr);
        }
```

```
        public List<PetViewModel> GetPets()
        {
            var fileService = Mvx.Resolve<IMvxFileStore>();
            string content = string.Empty;
            fileService.TryReadTextFile(filePath, out content);

            if (string.IsNullOrEmpty(content))
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
            else
            {
                var serializer = Mvx.Resolve<IMvxJsonConverter>();
                List<PetViewModel> petsObj = serializer.DeserializeObject<List<PetViewModel>>(content);
                return petsObj;
            }
        }
```

####4. update getter for Pets property in PetStoreViewModel  , check is null or not.
```
       private List<PetViewModel> _pets = null;
        public List<PetViewModel> Pets
        {
            get
            {
                if (_pets == null)
                {
                    _pets = _petStoreService.GetPets();
                }

                return _pets;
            }
        }
```
