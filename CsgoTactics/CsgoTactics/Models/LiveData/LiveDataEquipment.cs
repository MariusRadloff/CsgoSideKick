using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    class LiveDataEquipment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LiveDataEquipment()
        {
            Name = "no data";
            Type = "no data";
            MaxValue = 0;
            CurrentValue = 0;
            ImagePath = new Uri("ms-appx:///Images/Equipment/NoImage.png");
        }

        public LiveDataEquipment(string name, string type, int maxValue, int currentValue, Uri imagePath)
        {
            Name = name;
            Type = type;
            MaxValue = maxValue;
            CurrentValue = currentValue;
            ImagePath = imagePath;
        }

        private String name;

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        private String type;

        public String Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged();
            }
        }

        private int maxValue;

        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                NotifyPropertyChanged();
            }
        }


        private int currentValue;

        public int CurrentValue
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                NotifyPropertyChanged();
            }
        }

        private Uri imagePath;

        public Uri ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                NotifyPropertyChanged();
            }
        }
    }
}
