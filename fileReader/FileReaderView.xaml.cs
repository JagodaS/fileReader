using System.Windows;

namespace fileReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FileReader : Window
    {
        protected ViewModel ViewModel => (ViewModel)Resources[nameof(ViewModel)];

        public FileReader()
        {
            InitializeComponent();
            // LayoutRoot.DataContext = this;
            ViewModel.Initialize();
            Loaded += (s, e) => ViewModel.OnLoaded();
            //Unloaded += (s, e) => ViewModel.OnUnloaded();

        }
    }
}
