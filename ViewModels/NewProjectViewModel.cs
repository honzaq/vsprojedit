using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VsProjEdit.Models;

namespace VsProjEdit.ViewModels
{
    class NewProjectViewModel : INotifyPropertyChanged
    {
        private NewProjectModel _newProj = new NewProjectModel();

        public ObservableCollection<PropsTypeItem> PropsTypes { get; set; }
        public ObservableCollection<ConfigTypeItem> ConfigTypes { get; set; }

        #region Constructor
        public NewProjectViewModel()
        {
            PropsTypes = new ObservableCollection<PropsTypeItem>();
            ConfigTypes = new ObservableCollection<ConfigTypeItem>();
            CreateProjectCmd = new RelayCommand(_newProj.Create, null);
            Name = "test1";
            FillPropsTypes();
            FillConfigTypes();
        }
        #endregion

        #region FillData
        protected void FillPropsTypes()
        {
            PropsTypes.Add(new PropsTypeItem("(lib)", NewProjectModel.EPropsType.lib));
            PropsTypes.Add(new PropsTypeItem("(dll)", NewProjectModel.EPropsType.dll));
            PropsTypes.Add(new PropsTypeItem("(headers only)", NewProjectModel.EPropsType.headers_only));
            PropsTypes.Add(new PropsTypeItem("(dll dependent)", NewProjectModel.EPropsType.dll_dependent));
            PropsTypes.Add(new PropsTypeItem("(test)", NewProjectModel.EPropsType.test));
        }

        public void FillConfigTypes()
        {
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Debug lib x86", NewProjectModel.EConfigType.Debug_lib_x86));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Release lib x86", NewProjectModel.EConfigType.Release_lib_x86));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Debug lib x64", NewProjectModel.EConfigType.Debug_lib_x64));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Release lib x64", NewProjectModel.EConfigType.Release_lib_x64));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Debug x86", NewProjectModel.EConfigType.Debug_x86));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Release x86", NewProjectModel.EConfigType.Release_x86));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Debug x64", NewProjectModel.EConfigType.Debug_x64));
            ConfigTypes.Add(new ConfigTypeItem(_newProj, "Release x64", NewProjectModel.EConfigType.Release_x64));
        }
        #endregion

        #region Binding

        // Name
        public string Name
        {
            get { return _newProj.Name; }
            set
            {
                _newProj.Name = value;
                OnPropertyChanged();
            }
        }

        // Combo Property Type
        PropsTypeItem _selectedPropsType;
        public PropsTypeItem SelectedPropsType
        {
            get { return _selectedPropsType; }
            set
            {
                _selectedPropsType = value;
                _newProj.PropsType = _selectedPropsType.Id;
                Debug.Print("New props type: {0}", _selectedPropsType.Id);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand CreateProjectCmd { get; internal set; }

        #endregion

        #region INotifyPropertyChanged Members

        /// Need to implement this interface in order to get data binding
        /// to work properly.
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
