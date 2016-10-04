using MvvmCommon;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.BusinessLayer
{
    public class ChampionViewModel : ObservableObject
    {
        private readonly Champion _champ;

        private string _name;
        public string Name
        {
            get
            {
                if (_name == null)
                    _name = _champ.Name;
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                if (_title == null)
                    _title = _champ.Title;
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        
        public  ChampionViewModel(Champion champ)
        {
            _champ = champ;
        }

        private string _squareImageSource;
        public string SquareImgaeSource
        {
            get
            {
                if (_squareImageSource == null)
                {
                    SquareImgaeSource = _champ.SquareImage;
                }
                return _squareImageSource;
            }
            set
            {
                _squareImageSource = value;
                RaisePropertyChanged();
            }
        }

        private string _splashImageSource;
        public string SplashImageImageSource
        {
            get
            {
                if (_splashImageSource == null)
                {
                    SplashImageImageSource = _champ.SplaschImage;
                }
                return _splashImageSource;
            }
            set { _splashImageSource = value; }
        }
    }
}
