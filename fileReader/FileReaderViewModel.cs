using MVVM;
using System;
using System.Windows;
using System.Windows.Input;

namespace fileReader
{
    public class ViewModel : ViewModelBase
    {
        private bool _isLoaded = false;
        private bool _isInstantiated = false;
        private Model _model = null;

        private int _var = 300;
        private string _filepath = "";

        public void Initialize()
        {
            // TODO: Add your initialization code here 
            // This method is only called when the application is running
        }

        public ViewModel()
        {
            // TODO: Add your constructor code here
            // The ctor is always called, initialize view model so that it also works in designer
            if (!_isInstantiated)
            {
                _isInstantiated = true;
                _model = new Model();
            }
        }

        public void OnLoaded()
        {
            if (!_isLoaded)
            {
                _isLoaded = true;
                // TODO: Add your loaded code here 
            }
        }
        // ---------------------------------------------- sample properties 
        public int MyProperty
        {
            get { return _var; }
            set { SetProperty(ref _var, value); }
        }

        private CommandAction _cmdClick;

        public ICommand Click => _cmdClick ?? (_cmdClick = new CommandAction(OnClick, OnClickEvaluator));

        private void OnClick(object obj)
        {
            //MessageBox.Show(obj as string);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                FilePath = filename;
            }
        }

        private bool OnClickEvaluator(object obj)
        {
            return (obj as string)?.Length > 0;
        }

        public string FilePath
        {
            get { return _filepath; }
            set { SetProperty(ref _filepath, value); }
        }

    }
}
