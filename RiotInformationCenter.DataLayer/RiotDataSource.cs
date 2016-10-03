using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.DataLayer
{
    public static class RiotDataSource
    {
        public static List<Champion> GetChampionList()
        {
            try
            {
                var championList = GetChampionListDto().ToChampionList();
                DataBaseHandler.SaveChampionListToDataBase(championList);
                return championList;
            }
            catch (Exception)
            {
                throw new WebException("No connection to the Server");
            }
        }

        private static ChampionListDto GetChampionListDto()
        {
            string json;
            try
            {
                json = DownloadJson();
                var championList = Json.Decode<ChampionListDto>(json);

                foreach (var champ in championList.Data.Values)
                {
                    champ.Version = championList.Version;
                }

                return championList;
            }
            catch (Exception)
            {
                throw new WebException("No connection to the Server");
            }
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
                throw new WebException();
            }
        }
    }

    public static class DataBaseHandler
    {
        public static void SaveChampionListToDataBase(List<Champion> championChampionList)
        {
            throw new NotImplementedException();
        }
    }
}
