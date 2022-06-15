using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal class Main : INotifyPropertyChanged
    {
        private User? selectedUser;

        public ObservableCollection<User> User { get; set; }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Main()
        {
            this.User = new ObservableCollection<User>();

            getUsersName();
            getUsersSteps();
            setAverageOfSteps();
            setMaxSteps();
            setMinSteps();

            if (SelectedUser != null)
            {
                DrawGraph.setGraph(User, SelectedUser);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

                if (SelectedUser != null)
                {
                    DrawGraph.setGraph(User, SelectedUser);
                }
            }
        }

        public void getUsersName()
        {
            JArray users = JArray.Parse(File.ReadAllText("TestData/day1.json"));

            for (int i = 0; i < users.Count; i++)
            {
                this.User.Add(new User { Name = (string)users[i]["User"] });
            }
        }

        public void getUsersSteps()
        {
            string[] path = getPaths().OrderBy(p => int.Parse(p[12..^5])).ToArray();

            for (int i = 0; i < path.Count(); i++)
            {
                JArray records = JArray.Parse(File.ReadAllText(path[i]));

                getUsersStepsOfDay(ref records);
            }
        }

        public void getUsersStepsOfDay(ref JArray records)
        {
            for (int j = 0; j < records.Count; j++)
            {
                for (int k = 0; k < this.User.Count; k++)
                {
                    if (this.User[k].Name == (string)records[j]["User"])
                    {
                        this.User[k].steps.Add((int)records[j]["Steps"]);
                    }
                }
            }
        }
        public void setAverageOfSteps()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                this.User[i].AverageOfSteps = (int)this.User[i].steps.Average();
            }
        }

        public void setMaxSteps()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                this.User[i].MaxSteps = this.User[i].steps.Max();
            }
        }

        public void setMinSteps()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                this.User[i].MinSteps = this.User[i].steps.Min();
            }
        }

        public string[] getPaths()
        {
            string[] allfiles = Directory.GetFiles("TestData", "*.json", SearchOption.AllDirectories);

            return allfiles;
        }

        public void setColors()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                this.User[i].setColor();
            }
        }

    }
}