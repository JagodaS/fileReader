namespace fileReader
{
    public class Model
    {
        
        private static bool _isLoaded = false;
        private bool _isInstantiated = false;

        /*private static fileReader.FileReader _view;
         * public void Initialize(fileReader.FileReader view)
        {
            _view = view;
        }
        */
        public Model()
        {
            if (!_isInstantiated)
            {
                // konstruktor jest również wywoływany
                // gdy jest włączony podgląd interfejsu
                _isInstantiated = true;
            }
        }

        public void OnLoaded()
        {
            if (!_isLoaded)
            {
                // Od tego momentu masz dostęp do interfejsu xaml
                _isLoaded = true;
            }
        }
    }

}
