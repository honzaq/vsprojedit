using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VsProjEdit.Models
{
    class ConfigTypeItem
    {
        public string Name { get; set; }

        public NewProjectModel.EConfigType Id { get; set; }

        public bool IsChecked
        {
            get { return _data.ConfigType.HasFlag(Id); }
            set
            {
                if(value)
                {
                    _data.ConfigType |= Id;
                }
                else
                {
                    _data.ConfigType &= ~Id;
                }
                Debug.Print("New config type: {0}", _data.ConfigType);
                OnPropertyChanged();
            }
        }

        private NewProjectModel _data;
        public ConfigTypeItem(NewProjectModel data, string name, NewProjectModel.EConfigType id)
        {
            _data = data;
            Name = name;
            Id = id;
        }

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
