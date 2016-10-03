using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCommon;
using RiotInformationCenter.DataLayer;
using RiotInformationCenter.Entities;

namespace RiotInformationCenter.BusinessLayer
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<ChampionViewModel> championList;

        public MainWindowViewModel()
        {
            InitializationChampionList();
        }

        private void InitializationChampionList()
        {
            var championList = GetChampionList();
            ChampionList = new ObservableCollection<ChampionViewModel>();
            foreach (var champ in championList.OrderBy(champ => champ.Name))
            {
                var championVm = new ChampionViewModel(champ);
                ChampionList.Add(championVm);
            }
        }

        private List<Champion> GetChampionList()
        {
            var championListDto = RiotDataSource.GetChampionList();

            return championListDto;
        }

        public ObservableCollection<ChampionViewModel> ChampionList
        {
            get { return championList; }
            set
            {
                championList = value;
                RaisePropertyChanged();
            }
        }
    }
}
