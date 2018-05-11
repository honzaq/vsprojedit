using System.Windows;

namespace vsprojedit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Object to bind the combobox selections to.
        private ViewModelString viewModelString = new ViewModelString();

        public MainWindow()
        {
            // Set the data context for this window.
            DataContext = viewModelString;

            InitializeComponent();
        }
    }
}
