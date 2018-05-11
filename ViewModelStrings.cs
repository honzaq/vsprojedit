using System.ComponentModel;

namespace vsprojedit
{
    class ViewModelString : INotifyPropertyChanged
    {
        /// Need a void constructor in order to use as an object element 
        /// in the XAML.
        public ViewModelString()
        {
        }

        private string _propsTypeString = "(lib)";

        /// String property used in binding examples.
        public string PropsTypeString
        {
            get { return _propsTypeString; }
            set
            {
                if(_propsTypeString != value)
                {
                    _propsTypeString = value;
                    NotifyPropertyChanged("PropsTypeString");
                }
            }
        }

        #region INotifyPropertyChanged Members

        /// Need to implement this interface in order to get data binding
        /// to work properly.
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
