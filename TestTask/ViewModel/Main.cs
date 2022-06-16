using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal class Main : INotifyPropertyChanged
    {
        public static User? selectedUser;

        public static ObservableCollection<User> user;

        public ObservableCollection<User> User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "json files (*.json)|*.json";

            if ((bool)openFileDialog.ShowDialog())
            {
                string[] filenames = openFileDialog.FileNames;

                User = new ObservableCollection<User>();

                getUsersName(filenames[0]);
                getUsersSteps(filenames);
                setAverageOfSteps();
                setMaxSteps();
                setMinSteps();
                setColors();
            }

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

        public void getUsersName(string filename)
        {
            JArray users = JArray.Parse(File.ReadAllText(filename));

            for (int i = 0; i < users.Count; i++)
            {
                this.User.Add(new User { Name = (string)users[i]["User"] });
            }
        }

        public void getUsersSteps(string[] filenames)
        {
            string[] path = filenames.OrderBy(p => int.Parse(p[(filenames[0].LastIndexOf('\\') + 4)..^5])).ToArray();

            for (int i = 0; i < path.Count(); i++)
            {
                JArray records = JArray.Parse(File.ReadAllText(path[i]));

                getUsersInfotmationOfDay(ref records);
            }
        }

        public void getUsersInfotmationOfDay(ref JArray records)
        {
            for (int j = 0; j < records.Count; j++)
            {
                for (int k = 0; k < User.Count; k++)
                {
                    if (User[k].Name == (string)records[j]["User"])
                    {
                        User[k].steps.Add((int)records[j]["Steps"]);
                        User[k].status.Add((string)records[j]["Status"]);
                        User[k].rank.Add((int)records[j]["Rank"]);
                    }
                }
            }
        }

        public void setAverageOfSteps()
        {
            for (int i = 0; i < User.Count; i++)
            {
                User[i].AverageOfSteps = (int)User[i].steps.Average();
            }
        }

        public void setMaxSteps()
        {
            for (int i = 0; i < User.Count; i++)
            {
                User[i].MaxSteps = User[i].steps.Max();
            }
        }

        public void setMinSteps()
        {
            for (int i = 0; i < User.Count; i++)
            {
                 User[i].MinSteps = User[i].steps.Min();
            }
        }

        public void setColors()
        {
            for (int i = 0; i < this.User.Count; i++)
            {
                User[i].setColor();
            }
        }

        public static void saveFile()
        {
            Save.saveInFile(selectedUser);
        }
    }
}