using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Model
{
    internal class Step : INotifyPropertyChanged
    {
        private string user;
        private int averageOfSteps;

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public int AverageOfSteps
        {
            get { return averageOfSteps; }
            set
            {
                averageOfSteps = value;
                OnPropertyChanged("Avg of steps");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
