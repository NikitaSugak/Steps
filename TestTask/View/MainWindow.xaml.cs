using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTask.ViewModel;
using TestTask;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuSaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (Main.selectedUser != null)
            {
                Main.saveFile();
            }
            else
            {
                MessageBox.Show("User not selected.\n Please select User");
            }
        }
        private void menuSaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            if (Main.selectedUser != null)
            {
                Save.path = Save.getFileName();
                Main.saveFile();
            }
            else
            {
                MessageBox.Show("User not selected.\nPlease select User");
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
