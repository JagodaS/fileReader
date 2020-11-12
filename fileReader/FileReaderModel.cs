using System;

namespace fileReader
{
    public class Model
    {
        private static bool _isLoaded = false;
        private bool _isInstantiated = false;

        public string filepath = "";
        public int progress = 0;

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
                _isLoaded = true;
            }
        }

        
    }

}
