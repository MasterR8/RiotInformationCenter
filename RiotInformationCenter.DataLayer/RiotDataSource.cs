using System;
using System.Net;
using System.Web.Helpers;
using RiotInformationCenter.Entitys;

namespace RiotInformationCenter.DataLayer
{
    public static class RiotDataSource
    {
        public static ChampionListDto GetChampionList()
        {
            string json;
                json = DownloadJson();


            return Json.Decode<ChampionListDto>(json);
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
