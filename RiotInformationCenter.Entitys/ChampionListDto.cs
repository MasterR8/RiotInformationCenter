using System.Collections.Generic;

namespace RiotInformationCenter.Entities
{
    public class ChampionListDto
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public Dictionary<string,ChampionDto> Data { get; set; }
        public string Format { get; set; }
        public Dictionary<string,string> Keys { get; set; }
        public string Type { get; set; }
    }
}
