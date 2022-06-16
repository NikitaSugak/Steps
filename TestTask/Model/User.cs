using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTask.Model
{
    internal class User : INotifyPropertyChanged
    {
        private string name;
        public List<int> steps = new List<int>();
        public List<int> rank = new List<int>();
        public List<string> status = new List<string>();
        private int averageOfSteps;
        private int minSteps;
        private int maxSteps;
        private string color;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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

        public int MinSteps
        {
            get { return minSteps; }
            set
            {
                minSteps = value;
                OnPropertyChanged("minSteps");
            }
        }

        public int MaxSteps
        {
            get { return maxSteps; }
            set
            {
                maxSteps = value;
                OnPropertyChanged("maxSteps");
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void setColor()
        {
            if (minSteps * 1.2 < averageOfSteps)
            {
                Color = "Red";
            }
            else if(maxSteps * 0.8  > averageOfSteps)
            {
                Color = "Red";
            }
            else
            {
                Color = "White";
            }
        }
    }
}
