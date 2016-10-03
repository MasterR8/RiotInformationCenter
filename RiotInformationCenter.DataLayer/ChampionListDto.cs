using System.Collections.Generic;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.DataLayer
{
    public class ChampionListDto : IToChampionList
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public Dictionary<string,ChampionDto> Data { get; set; }
        public string Format { get; set; }
        public Dictionary<string,string> Keys { get; set; }
        public string Type { get; set; }

        public List<Champion> ToChampionList()
        {
            var championList = new List<Champion>();
            foreach (var championDto in Data.Values)
            {
                championList.Add(championDto.ToChampion());
            }
            return championList;
        }
    }
}
