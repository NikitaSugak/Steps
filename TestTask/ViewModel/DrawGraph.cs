using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TestTask.Model;

namespace TestTask.ViewModel
{
    internal class DrawGraph
    {
        const int X0 = 50, Y0 = 500;
        const int XSteps = 50, YSteps = 100;
        const int XDay = 700, YDay = 500;

        private static GeometryGroup graph;

        public GeometryGroup Graph
        {
            get { return graph; }
            set
            {
                graph = value;
                OnPropertyChanged("Graph");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DrawGraph()
        {
            graph = new GeometryGroup();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private static double getCountPixelInOneDay(int lenghtDaysLine, int countDay)
        {
            return (double)lenghtDaysLine / countDay;
        }

        private static double getCountStepsInOnePixel(int lenghtSrepsLine, int countSteps)
        {
            return (double)countSteps / lenghtSrepsLine;
        }

        private static void cleanGraph()
        {
            graph.Children.Clear();
        }

        private static void setCoordinatesLines()
        {
            graph.Children.Add(new LineGeometry(new Point(X0, Y0), new Point(XSteps, YSteps)));
            graph.Children.Add(new LineGeometry(new Point(X0, Y0), new Point(XDay, YDay)));
        }

        private static void setText()
        {
            string testString = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";

            // Create the initial formatted text string.


            //System.Windows.Shapes.Shape shape = System.Windows.Shapes.;  

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), 8);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.RoundAnchor;
            Petzold.

            //graph.Children.Add(testString);
        }

        private static int getIndexSelectedUser(ref ObservableCollection<User> User, ref User SelectedUser)
        {
            for (int i = 0; i < User.Count; i++)
            {
                if (User[i].Name == SelectedUser.Name)
                {
                    return i;
                }
            }

            return 0;
        }

        public static void setGraph(ObservableCollection<User> User, User SelectedUser)
        {
            cleanGraph();

            setCoordinatesLines();

            int indexSelectedUser = getIndexSelectedUser(ref User, ref SelectedUser);

            double countPixelInOneDay = getCountPixelInOneDay(XDay - X0, User[indexSelectedUser].steps.Count - 1);
            double countStepsInOnePixel = getCountStepsInOnePixel(Y0 - YSteps, User[indexSelectedUser].steps.Max());
                        
            for (int i = 0; i < User[indexSelectedUser].steps.Count - 1; i++)
            {
                graph.Children.Add(new LineGeometry(new Point(X0 + i * countPixelInOneDay, - User[indexSelectedUser].steps[i] / countStepsInOnePixel + Y0), 
                                                    new Point(X0 + (i + 1) * countPixelInOneDay, - User[indexSelectedUser].steps[i + 1] / countStepsInOnePixel + Y0)));
            }
        }
    }
}
