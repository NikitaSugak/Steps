using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal class Main : INotifyPropertyChanged
    {
        private Step selectedUser;

        public ObservableCollection<Step> Steps { get; set; }
        public Step SelectedUser
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
            Steps = getCollectionUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<Step> getCollectionUsers()
        {
            ObservableCollection<Step> users = new ObservableCollection<Step>();

            users.Add(new Step { User = "kojj", AverageOfSteps = 756 });
            users.Add(new Step { User = "konibujj", AverageOfSteps = 8756 });

            return users;
        }
    }
}