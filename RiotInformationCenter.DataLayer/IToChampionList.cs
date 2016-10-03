using System.Collections.Generic;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.DataLayer
{
    public interface IToChampionList
    {
        List<Champion> ToChampionList();
    }
}