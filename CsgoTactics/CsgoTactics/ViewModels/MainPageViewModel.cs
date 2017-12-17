using CsgoTactics.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Windows.Storage;

namespace CsgoTactics.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private const String FILENAME = "MapsData.xml";

        private Map activeMap = new Map();

        public Map ActiveMap
        {
            get { return activeMap; }
            set { activeMap = value; }
        }


        private ObservableCollection<Map> maps = new ObservableCollection<Map>();
        public ObservableCollection<Map> Maps
        {
            get { return this.maps; }
            set { maps = value; }
        }

        public ObservableCollection<Map> GetMaps()
        {
            GetMapsData();

            return Maps;
        }

        public Map GetMap(string uniqueId)
        {
            GetMapsData();
            // Simple linear search is acceptable for small data sets
            var matches = Maps.Where((group) => group.MapId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public Spot GetSpot(string spotId)
        {
            GetMapsData();
            // Simple linear search is acceptable for small data sets
            var matches = Maps.SelectMany(group => group.MapSpots).Where((item) => item.SpotId.Equals(spotId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public void GetMapsData()
        {
            if (Maps.Count != 0)
                return;
            DeserializeMapsData();
        }

        public async void SerializeMapsData()
        {
            var serializer = new DataContractSerializer(typeof(ObservableCollection<Map>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILENAME, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, Maps);
            }
        }

        public async void DeserializeMapsData()
        {
            var serializer = new DataContractSerializer(typeof(ObservableCollection<Map>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME))
            {
                Maps = (ObservableCollection<Map>)serializer.ReadObject(stream);
            }
        }
    }
}
