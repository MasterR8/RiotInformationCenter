using System.IO;
using System.Net;

namespace RiotInformationCenter.DataLayer
{
    public class PictureSource
    {
        private readonly string _version;
        private readonly ChampionDto _champ;

        public PictureSource(ChampionDto champ)
        {
            _version = champ.Version;
            _champ = champ;
        }

        public string GetSquarePicturePath()
        {
            var pathToImage = ImagePathFor(_champ.Image.Full);
            var link = $"http://ddragon.leagueoflegends.com/cdn/{_version}/img/champion/{_champ.Image.Full}";

            DownloadPictureFormTo(link, pathToImage);

            return pathToImage;
        }

        private void DownloadPictureFormTo(string link, string pathToImage)
        {
            if (!File.Exists(pathToImage))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(link, pathToImage);
                }
            }
        }

        public string GetSplashPath()
        {
            var imageName = $"{_champ.Key}_0.jpg";
            var pathToImage = ImagePathFor(imageName);
            var link = $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{imageName}";

            DownloadPictureFormTo(link, pathToImage);

            return pathToImage;
        }

        private string ImagePathFor(string imageName)
        {
            var directory = Directory.GetCurrentDirectory();
            return Path.Combine(directory,imageName);
        }
    }
}
