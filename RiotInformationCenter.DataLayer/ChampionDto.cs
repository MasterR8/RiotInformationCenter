using System.Collections.Generic;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.DataLayer
{
    public class ChampionDto : IToChampion
    {
        public List<string> Allytips { get; set; }
        public string Blurb { get; set; }
        public List<string> Enemytips { get; set; }
        public int Id { get; set; }
        public string Key { get; set; }
        public string Lore { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Partype { get; set; }
        public List<string> Tags { get; set; }
        public ImageDto Image { get; set; }
        public string Version { get; set; }


        public Champion ToChampion()
        {
            var pictureSource = new PictureSource(this);

            var champ = new Champion
            {
                Name = Name,
                Title = Title,
                SquareImage = pictureSource.GetSquarePicturePath(),
                SplaschImage = pictureSource.GetSplashPath()
            };

            return champ;
        }
    }
}
