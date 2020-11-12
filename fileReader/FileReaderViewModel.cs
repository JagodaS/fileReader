using MVVM;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace fileReader
{
    public class ViewModel : ViewModelBase
    {
        private bool _isLoaded = false;
        private bool _isInstantiated = false;
        private Model _model = null;

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

        public int FileProcessingProgress
        {
            get { return _model.progress; }
            set { SetProperty(ref _model.progress, value); }
        }

        public string FilePath
        {
            get { return _model.filepath; }
            set { SetProperty(ref _model.filepath, value); }
        }

        private CommandAction _cmdOpenDialog;
        private CommandAction _cmdStart;

        public ICommand OpenDialog => _cmdOpenDialog ?? (_cmdOpenDialog = new CommandAction(GetFilePathFromDialog));
        public ICommand Start => _cmdStart ?? (_cmdStart = new CommandAction(StartLongTask));

        public async void StartLongTask(object obj)
        {
            Task task = Task.Run(() => {
                FileProcessingProgress = 10;
                Thread.Sleep(1000);
                FileProcessingProgress = 30;
                Thread.Sleep(1000);
                FileProcessingProgress = 50;
                Thread.Sleep(1000);
                FileProcessingProgress = 70;
                Thread.Sleep(1000);
                FileProcessingProgress = 85;
                Thread.Sleep(1000);
                FileProcessingProgress = 100;
                MessageBox.Show("Task finished its execution");
                }
                //ExecuteLongProcedure(this, intParam1, intParam2, intParam3)
        );
            await task;
        }


        public void GetFilePathFromDialog(object obj)
        {
            //MessageBox.Show(obj as string);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            FilePath = result == true ? dlg.FileName : "";
        }
    }
}
