using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTask.Model
{
    internal class User : INotifyPropertyChanged
    {
        private string name;
        public List<int> steps = new List<int>();
        private int averageOfSteps;

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
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
