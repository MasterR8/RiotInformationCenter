using System.Collections.Generic;

namespace RiotInformationCenter.Entitys
{
    public class ChampionListDto
    {
        public string Version { get; set; }
        public Dictionary<string,ChampionDto> Data { get; set; }
        public string Format { get; set; }
        public Dictionary<string,string> Keys { get; set; }
        public string Type { get; set; }
    }
}
