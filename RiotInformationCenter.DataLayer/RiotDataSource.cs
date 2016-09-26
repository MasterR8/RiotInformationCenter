using System;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.DataLayer
{
    public static class RiotDataSource
    {
        public static ChampionListDto GetChampionList()
        {
            string json = string.Empty;
            try
            {
                json = DownloadJson();
                var championList = Json.Decode<ChampionListDto>(json);
                SaveChampionListToDataBase(championList);
                return championList;
            }
            catch (Exception)
            {
                return ChampionListFromDataBase();
            }

        }

        private static void SaveChampionListToDataBase(ChampionListDto championList)
        {
            using (var database = new RiotInformationCenterContext())
            {
                //database.ChampionListDto.RemoveRange(database.ChampionListDto);
                //database.ChampionListDto.Add(championList);
                //database.SaveChanges();
            }
        }

        private static ChampionListDto ChampionListFromDataBase()
        {
            ChampionListDto championListDto =new ChampionListDto();
            using (var dataBase = new RiotInformationCenterContext())
            {
                //championListDto = dataBase.ChampionListDto.First();
            }
            return championListDto;
        }

        private static string DownloadJson()
        {
            try
            {
                string json;
                using (WebClient webClient = new WebClient())
                {
                    string url =
                        "https://global.api.pvp.net/api/lol/static-data/euw/v1.2/champion?champData=image&api_key=RGAPI-523A7C14-A1F2-4857-8D70-BBE2ACBD0DED";
                    json = webClient.DownloadString(url);
                }
                return json;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
