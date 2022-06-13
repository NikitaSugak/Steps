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
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal class Main : INotifyPropertyChanged
    {
        private User selectedUser;

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

        public Main()
        {
            getUsersName();
            getUsersSteps();
            setAverageOfSteps();
            //addUsersToTable();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void getUsersName()
        {
            this.User = new ObservableCollection<User>();

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

        }

        public void setAverageOfSteps()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                this.User[i].AverageOfSteps = (int)this.User[i].steps.Average();
            }
        }

        public string[] getPaths()
        {
            string[] allfiles = Directory.GetFiles("TestData", "*.json", SearchOption.AllDirectories);

            return allfiles;
        }

        public void addUsersToTable()
        {
            //string url = File.ReadAllText("TestData/day1.json");
            //JArray blogPosts = JArray.Parse(url);



            for (int i = 0; i < this.User.Count; i++)
            {

                //this.User.Add(new User { Name = , AverageOfSteps = (Int32)blogPosts[i]["Steps"] });
            }

        }
    }
}