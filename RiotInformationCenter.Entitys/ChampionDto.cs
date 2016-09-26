using System.Collections.Generic;

namespace RiotInformationCenter.Entities
{
    public class ChampionDto
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
    }
}
