using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    public class Spot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Spot(String spotId, String spotName, String spotType, String spotDescription)
        {
            this.SpotId = spotId;
            this.SpotName = spotName;
            this.SpotType = spotType;
            this.SpotDescription = spotDescription;
        }

        private string spotId;
        public string SpotId
        {
            get { return spotId; }
            set
            {
                spotId = value;
                NotifyPropertyChanged();
            }
        }

        private string spotName;
        public string SpotName
        {
            get { return spotName; }
            set
            {
                spotName = value;
                NotifyPropertyChanged();
            }
        }

        private string spotType;
        public string SpotType
        {
            get { return spotType; }
            set
            {
                spotType = value;
                NotifyPropertyChanged();
            }
        }

        private string spotDescription;
        public string SpotDescription
        {
            get { return spotDescription; }
            set
            {
                spotDescription = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.SpotName;
        }
    }
}
