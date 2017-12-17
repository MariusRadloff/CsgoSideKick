using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    class LiveDataScore : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Score
        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                NotifyPropertyChanged();
            }
        }

        private int scoreOwnTeam;
        public int ScoreOwnTeam
        {
            get { return scoreOwnTeam; }
            set
            {
                scoreOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int scoreOpposingTeam;
        public int ScoreOpposingTeam
        {
            get { return scoreOpposingTeam; }
            set
            {
                scoreOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Frags
        private int frags;
        public int Frags
        {
            get { return frags; }
            set
            {
                frags = value;
                NotifyPropertyChanged();
            }
        }

        private int fragsOwnTeam;
        public int FragsOwnTeam
        {
            get { return fragsOwnTeam; }
            set
            {
                fragsOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int fragsOpposingTeam;
        public int FragsOpposingTeam
        {
            get { return fragsOpposingTeam; }
            set
            {
                fragsOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Assits
        private int assists;
        public int Assists
        {
            get { return assists; }
            set
            {
                assists = value;
                NotifyPropertyChanged();
            }
        }

        private int assistsOwnTeam;
        public int AssistsOwnTeam
        {
            get { return assistsOwnTeam; }
            set
            {
                assistsOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int assistsOpposingTeam;
        public int AssistsOpposingTeam
        {
            get { return assistsOpposingTeam; }
            set
            {
                assistsOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Deaths
        private int death;
        public int Death
        {
            get { return death; }
            set
            {
                death = value;
                NotifyPropertyChanged();
            }
        }

        private int deathsOwnTeam;
        public int DeathsOwnTeam
        {
            get { return deathsOwnTeam; }
            set
            {
                deathsOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int deathsOpposingTeam;
        public int DeathsOpposingTeam
        {
            get { return deathsOpposingTeam; }
            set
            {
                deathsOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region BombPlanted
        private int bombPlanted;
        public int BombPlanted
        {
            get { return bombPlanted; }
            set
            {
                bombPlanted = value;
                NotifyPropertyChanged();
            }
        }

        private int bombPlantedOwnTeam;
        public int BombPlantedOwnTeam
        {
            get { return bombPlantedOwnTeam; }
            set
            {
                bombPlantedOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int bombPlantedOpposingTeam;
        public int BombPlantedOpposingTeam
        {
            get { return bombPlantedOpposingTeam; }
            set
            {
                bombPlantedOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region BombDefused
        private int bombDefused;
        public int BombDefused
        {
            get { return bombDefused; }
            set
            {
                bombDefused = value;
                NotifyPropertyChanged();
            }
        }

        private int bombDefusedOwnTeam;
        public int BombDefusedOwnTeam
        {
            get { return bombDefusedOwnTeam; }
            set
            {
                bombDefusedOwnTeam = value;
                NotifyPropertyChanged();
            }
        }

        private int bombDefusedOpposingTeam;
        public int BombDefusedOpposingTeam
        {
            get { return bombDefusedOpposingTeam; }
            set
            {
                bombDefusedOpposingTeam = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
