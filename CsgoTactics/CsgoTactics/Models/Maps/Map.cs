    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    public class Map : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Map()
        {
            this.MapId = "keine Angabe";
            this.MapName = "keine Angabe";
            this.MapType = "keine Angabe";
            this.MapTeam = "keine Angabe";
            this.MapImagePath = "keine Angabe";
            this.MapIconImagePath = "keine Angabe";
            this.MapDescription = "keine Angabe";
            this.MapSpots = new ObservableCollection<Spot>();
            this.MapStat = new Statistic();
        }

        public Map(String mapId, String mapname, String mapType, String mapTeam, String mapImagePath, String mapIconImagePath, String mapDescription)
        {
            this.MapId = mapId;
            this.MapName = mapname;
            this.MapType = mapType;
            this.MapTeam = mapTeam;
            this.MapImagePath = mapImagePath;
            this.MapIconImagePath = mapIconImagePath;
            this.MapDescription = mapDescription;
            this.MapSpots = new ObservableCollection<Spot>();
            this.MapStat = new Statistic();
        }

        public Map(String mapId, String mapname, String mapType, String mapTeam, String mapImagePath, String mapIconImagePath, String mapDescription, ObservableCollection<Spot> mapSpots, Statistic mapStatistic)
        {
            this.MapId = mapId;
            this.MapName = mapname;
            this.MapType = mapType;
            this.MapTeam = mapTeam;
            this.MapImagePath = mapImagePath;
            this.MapIconImagePath = mapIconImagePath;
            this.MapDescription = mapDescription;
            this.MapSpots = mapSpots;
            this.MapStat = mapStatistic;
        }

        private string mapId;
        public string MapId
        {
            get { return mapId; }
            set
            {
                mapId = value;
                NotifyPropertyChanged();
            }
        }

        private string mapName;
        public string MapName
        {
            get { return mapName; }
            set
            {
                mapName = value;
                NotifyPropertyChanged();
            }
        }

        private string mapType;
        public string MapType
        {
            get { return mapType; }
            set
            {
                mapType = value;
                NotifyPropertyChanged();
            }
        }

        private string mapTeam;
        public string MapTeam
        {
            get { return mapTeam; }
            set
            {
                mapTeam = value;
                NotifyPropertyChanged();
            }
        }

        private string mapImagePath;
        public string MapImagePath
        {
            get { return mapImagePath; }
            set
            {
                mapImagePath = value;
                NotifyPropertyChanged();
            }
        }

        private string mapIconImagePath;
        public string MapIconImagePath
        {
            get { return mapIconImagePath; }
            set
            {
                mapIconImagePath = value;
                NotifyPropertyChanged();
            }
        }

        private string mapDescription;
        public string MapDescription
        {
            get { return mapDescription; }
            set
            {
                mapDescription = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Spot> mapSpots;
        public ObservableCollection<Spot> MapSpots
        {
            get { return mapSpots; }
            set
            {
                mapSpots = value;
                NotifyPropertyChanged();
            }
        }

        private Statistic mapStat;
        public Statistic MapStat
        {
            get { return mapStat; }
            set { mapStat = value; }
        }

        public override string ToString()
        {
            return this.MapName;
        }
    }
}
