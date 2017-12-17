using CsgoTactics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.ViewModels
{
    class InGameLivePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private LiveDataBomb bomb;
        public LiveDataBomb Bomb
        {
            get { return bomb; }
            set
            {
                bomb = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<LiveDataEquipment> equipment;
        public ObservableCollection<LiveDataEquipment> Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                NotifyPropertyChanged();
            }
        }

        private LiveDataScore score;

        public LiveDataScore Score
        {
            get { return score; }
            set
            {
                score = value;
                NotifyPropertyChanged();
            }
        }
    }
}
