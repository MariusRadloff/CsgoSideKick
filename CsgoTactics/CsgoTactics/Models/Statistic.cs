using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsgoTactics.Models
{
    public class Statistic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Games

        private double totalGames;
        public double TotalGames
        {
            get { return totalGames; }
            set
            {
                totalGames = value;
                NotifyPropertyChanged();

            }
        }

        private double wonGames;
        public double WonGames
        {
            get { return wonGames; }
            set
            {
                wonGames = value;
                NotifyPropertyChanged();
            }
        }

        private double percentWonGames;
        public double PercentWonGames
        {
            get { return percentWonGames; }
            set
            {
                percentWonGames = value;
                NotifyPropertyChanged();
            }
        }

        private double lostGames;
        public double LostGames
        {
            get { return lostGames; }
            set
            {
                lostGames = value;
                NotifyPropertyChanged();
            }
        }

        private double percentLostGames;
        public double PercentLostGames
        {
            get { return percentLostGames; }
            set
            {
                percentLostGames = value;
                NotifyPropertyChanged();
            }
        }

        private double tiedGames;
        public double TiedGames
        {
            get { return tiedGames; }
            set
            {
                tiedGames = value;
                NotifyPropertyChanged();
            }
        }

        private double percentTiedGames;
        public double PercentTiedGames
        {
            get { return percentTiedGames; }
            set
            {
                percentTiedGames = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Rounds

        #region TotalRounds

        private double totalRounds;
        public double TotalRounds
        {
            get { return totalRounds; }
            set
            {
                totalRounds = value;
                NotifyPropertyChanged();

            }
        }

        private double totalCtRounds;
        public double TotalCtRounds
        {
            get { return totalCtRounds; }
            set
            {
                totalCtRounds = value;
                NotifyPropertyChanged();

            }
        }

        private double totalTRounds;
        public double TotalTRounds
        {
            get { return totalTRounds; }
            set
            {
                totalTRounds = value;
                NotifyPropertyChanged();

            }
        }

        #endregion

        #region WonRounds

        private double wonRounds;
        public double WonRounds
        {
            get { return wonRounds; }
            set
            {
                wonRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentWonRounds;
        public double PercentWonRounds
        {
            get { return percentWonRounds; }
            set
            {
                percentWonRounds = value;
                NotifyPropertyChanged();
            }
        }


        private double wonCtRounds;
        public double WonCtRounds
        {
            get { return wonCtRounds; }
            set
            {
                wonCtRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentWonCtRounds;
        public double PercentWonCtRounds
        {
            get { return percentWonCtRounds; }
            set
            {
                percentWonCtRounds = value;
                NotifyPropertyChanged();
            }
        }


        private double wonTRounds;
        public double WonTRounds
        {
            get { return wonTRounds; }
            set
            {
                wonTRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentWonTRounds;
        public double PercentWonTRounds
        {
            get { return percentWonTRounds; }
            set
            {
                percentWonTRounds = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region LostRounds

        private double lostRounds;
        public double LostRounds
        {
            get { return lostRounds; }
            set
            {
                lostRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentLostRounds;
        public double PercentLostRounds
        {
            get { return percentLostRounds; }
            set
            {
                percentLostRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double lostCtRounds;
        public double LostCtRounds
        {
            get { return lostCtRounds; }
            set
            {
                lostCtRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentLostCtRounds;
        public double PercentLostCtRounds
        {
            get { return percentLostCtRounds; }
            set
            {
                percentLostCtRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double lostTRounds;
        public double LostTRounds
        {
            get { return lostTRounds; }
            set
            {
                lostTRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentLostTRounds;
        public double PercentLostTRounds
        {
            get { return percentLostTRounds; }
            set
            {
                percentLostTRounds = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region MvpRounds

        private double mvpRounds;
        public double MvpRounds
        {
            get { return mvpRounds; }
            set
            {
                mvpRounds = value;
                NotifyPropertyChanged();
            }
        }

        private double percentMvpRounds;
        public double PercentMvpRounds
        {
            get { return percentMvpRounds; }
            set
            {
                percentMvpRounds = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Frags

        private double totalFrags;
        public double TotalFrags
        {
            get { return totalFrags; }
            set
            {
                totalFrags = value;
                NotifyPropertyChanged();
            }
        }

        private double hsFrags;
        public double HsFrags
        {
            get { return hsFrags; }
            set
            {
                hsFrags = value;
                NotifyPropertyChanged();
            }
        }

        private double percentHsFrags;
        public double PercentHsFrags
        {
            get { return percentHsFrags; }
            set
            {
                percentHsFrags = value;
                NotifyPropertyChanged();
            }
        }

        private double assists;
        public double Assists
        {
            get { return assists; }
            set
            {
                assists = value;
                NotifyPropertyChanged();
            }
        }

        //private double percentAssists;
        //public double PercentAssists
        //{
        //    get { return percentAssists; }
        //    set
        //    {
        //        percentAssists = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        private double accuracy;
        public double Accuracy
        {
            get { return accuracy; }
            set
            {
                accuracy = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        private void calcPercentages()
        {
            totalGames = wonGames + lostGames + tiedGames;
            totalRounds = wonRounds + lostRounds;
            totalCtRounds = wonCtRounds + lostCtRounds;
            totalTRounds = wonTRounds + lostTRounds;
            wonRounds = wonCtRounds + wonTRounds;
            lostRounds = lostCtRounds + lostTRounds;

            if (totalRounds == 0 || totalCtRounds == 0 || totalTRounds == 0)
            {
                percentWonRounds = 0;
                percentWonCtRounds = 0;
                percentWonTRounds = 0;

                percentLostRounds = 0;
                percentLostCtRounds = 0;
                percentLostTRounds = 0;

                percentMvpRounds = 0;
                
            }
            else
            {
                percentWonRounds = 100 / totalRounds * wonRounds;
                percentWonCtRounds = 100 / totalCtRounds * wonCtRounds;
                percentWonTRounds = 100 / totalTRounds * wonTRounds;

                percentLostRounds = 100 / totalRounds * lostRounds;
                percentLostCtRounds = 100 / totalCtRounds * lostCtRounds;
                percentLostTRounds = 100 / totalTRounds * lostTRounds;

                percentMvpRounds = 100 / totalRounds * mvpRounds;
            }
            if (totalFrags == 0)
            {
                percentHsFrags = 0;
            }
            else
            {
                percentHsFrags = 100 / totalFrags * hsFrags;  
            }
            if (totalGames == 0)
            {
                percentLostGames = 0;
                percentTiedGames = 0;
                percentWonGames = 0;
            }
            else
            {
                percentLostGames = 100 / totalGames * lostGames;
                percentTiedGames = 100 / totalGames * tiedGames;
                percentWonGames = 100 / totalGames * wonGames;
            }
                      
        }
    }
}
