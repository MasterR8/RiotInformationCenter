using MvvmCommon;
using RiotInformationCenter.DataLayer;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.BusinessLayer
{
    public class ChampionViewModel : ObservableObject
    {
        private Champion _champ;
        public string Version { get; set; }

        private string name;
        public string Name
        {
            get
            {
                if (name == null)
                    name = _champ.Name;
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private string title;
        public string Title
        {
            get
            {
                if (title == null)
                    title = _champ.Title;
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }
        
        public ChampionViewModel(Champion champ, string version)
        {
            _champ = champ;
            Version = version;
        }

        private string squarePictureSource;
        public string SquarePictureSource
        {
            get
            {
                if (squarePictureSource == null)
                {
                    var pictureSource = new PictureSource(Version, _champ);
                    SquarePictureSource = pictureSource.GetSquarePicturePath();
                }
                return squarePictureSource;
            }
            set
            {
                squarePictureSource = value;
                RaisePropertyChanged();
            }
        }

        private string splashSource;
        public string SplashSource
        {
            get
            {
                if (splashSource == null)
                {
                    var pictureSource = new PictureSource(Version, _champ);
                    SplashSource = pictureSource.GetSplashPath();
                }
                return splashSource;
            }
            set { splashSource = value; }
        }
    }
}
