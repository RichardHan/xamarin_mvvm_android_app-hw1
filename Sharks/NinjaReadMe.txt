
----------------------------------------------------------------------------------------------------
25 May 16 20:35 Add Projects
----------------------------------------------------------------------------------------------------
Sharks.Core project successfully added. (template NinjaCoder.Core.zip)
Sharks.Droid project successfully added. (template NinjaCoder.Droid.zip)
ERROR Sharks.WindowsUniversal not added. exception The system cannot find the file specified. (Exception from HRESULT: 0x80070002) (template NinjaCoder.WindowsUniversal.zip)

----------------------------------------------------------------------------------------------------
Options
----------------------------------------------------------------------------------------------------
MvvmCross framework selected.
NUnit testing framework selected.
Moq mocking framework selected.
iOS View Type Xib selected.

MainViewModel.cs added to Sharks.Core project (template=MvxSampleDataViewModel.t4)
MainView.cs added to Sharks.Droid project (template=SampleDataView.t4)

----------------------------------------------------------------------------------------------------
Nuget Commands
----------------------------------------------------------------------------------------------------

Install-Package MvvmCross -FileConflictAction Overwrite -ProjectName Sharks.Core 
Install-Package Scorchio.NinjaCoder.MvvmCross.Core -FileConflictAction Overwrite -ProjectName Sharks.Core 
Install-Package MvvmCross -FileConflictAction Overwrite -ProjectName Sharks.Droid 
Install-Package Scorchio.NinjaCoder.MvvmCross -FileConflictAction ignore -ProjectName Sharks.Droid 
Install-Package MvvmCross.Plugin.Color -FileConflictAction ignore -ProjectName Sharks.Core
Install-Package MvvmCross.Plugin.Color -FileConflictAction ignore -ProjectName Sharks.Droid


----------------------------------------------------------------------------------------------------
Ninja Coder for MvvmCross and Xamarin Forms v4.1.0
----------------------------------------------------------------------------------------------------

All feedback welcome, please get in touch via twitter.

Issues Log http://github.com/asudbury/NinjaCoderForMvvmCross/issues

Thanks

@asudbury
