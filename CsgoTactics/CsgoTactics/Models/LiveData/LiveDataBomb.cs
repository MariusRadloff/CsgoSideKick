using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    class LiveDataBomb : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LiveDataBomb()
        {
            TotalTime = 0;
            CurrentTime = 0;
            IsPlanted = false;
        }

        public LiveDataBomb(int totalTime, int currentTime, bool isPlanted)
        {
            TotalTime = totalTime;
            CurrentTime = currentTime;
            IsPlanted = isPlanted;
        }

        private int totalTime;

        public int TotalTime
        {
            get { return totalTime; }
            set
            {
                totalTime = value;
                NotifyPropertyChanged();
            }
        }

        private int currentTime;

        public int CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                NotifyPropertyChanged();
            }
        }

        private bool isPlanted;

        public bool IsPlanted
        {
            get { return isPlanted; }
            set
            {
                isPlanted = value;
                NotifyPropertyChanged();
            }
        }
    }
}
