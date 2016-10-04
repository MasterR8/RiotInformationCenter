using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using MvvmCommon;
using RiotInformationCenter.DataLayer;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.BusinessLayer
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<ChampionViewModel> _championList;
        public void InitializationChampionList()
        {
            var champions = GetChampionList();
            ChampionList = new ObservableCollection<ChampionViewModel>();
            foreach (var champ in champions.OrderBy(champ => champ.Name))
            {
                var championVm = new ChampionViewModel(champ);
                ChampionList.Add(championVm);
            }
        }

        private List<Champion> GetChampionList()
        {
            List<Champion> championList = new List<Champion>();
            try
            {
                championList = RiotDataSource.GetChampionList();
            }
            catch (WebException)
            {
                throw;
            }
            return championList;
        }

        public ObservableCollection<ChampionViewModel> ChampionList
        {
            get { return _championList; }
            set
            {
                _championList = value;
                RaisePropertyChanged();
            }
        }
    }
}
