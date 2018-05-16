using System.Windows;
using VsProjEdit.ViewModels;

namespace VsProjEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Object to bind the combobox selections to.
        private NewProjectViewModel viewModelString = new NewProjectViewModel();

        public MainWindow()
        {
            // Set the data context for this window.
            DataContext = viewModelString;

            InitializeComponent();
        }
    }
}
