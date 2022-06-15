using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TestTask.Model;
using Point = System.Windows.Point;

namespace TestTask.ViewModel
{
    internal class DrawGraph
    {
        const int X0 = 50, Y0 = 500;
        const int XSteps = 50, YSteps = 100;
        const int XDay = 700, YDay = 500;

        private static GeometryGroup graph;
        private static string textDays;

        static double countPixelInOneDay;
        static double countStepsInOnePixel;

        private static Bitmap b;

        public GeometryGroup Graph
        {
            get { return graph; }
            set
            {
                graph = value;
                OnPropertyChanged("Graph");
            }
        }

        public Bitmap B
        {
            get { return b; }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }

        public string TextDays
        {
            get { return textDays; }
            set
            {
                textDays = value;
                OnPropertyChanged("TextDays");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DrawGraph()
        {
            graph = new GeometryGroup();
            textDays = string.Empty;
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

        private static void setText(int countDays)
        {
            textDays = Convert.ToString(countDays);

        }

        private static void drawBestResult(int bestResult, int day)
        {
            EllipseGeometry ellipse = new EllipseGeometry(new Point(X0 + countPixelInOneDay * day, -bestResult / countStepsInOnePixel + Y0), 6, 6);
            graph.Children.Add(ellipse);
        }

        private static void drawWorstResult(int worstResult, int day)
        {
            EllipseGeometry ellipse = new EllipseGeometry(new Point(X0 + countPixelInOneDay * day, -worstResult / countStepsInOnePixel + Y0), 6, 6);
            graph.Children.Add(ellipse);
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

            countPixelInOneDay = getCountPixelInOneDay(XDay - X0, User[indexSelectedUser].steps.Count - 1);
            countStepsInOnePixel = getCountStepsInOnePixel(Y0 - YSteps, User[indexSelectedUser].steps.Max());
                        
            for (int i = 0; i < User[indexSelectedUser].steps.Count - 1; i++)
            {
                graph.Children.Add(new LineGeometry(new Point(X0 + i * countPixelInOneDay, - User[indexSelectedUser].steps[i] / countStepsInOnePixel + Y0), 
                                                    new Point(X0 + (i + 1) * countPixelInOneDay, - User[indexSelectedUser].steps[i + 1] / countStepsInOnePixel + Y0)));
            }

            int bestSteps = User[indexSelectedUser].steps.Max();
            int dayOfBestSteps = User[indexSelectedUser].steps.IndexOf(bestSteps);
            drawBestResult(bestSteps, dayOfBestSteps);

            int worstSteps = User[indexSelectedUser].steps.Min();
            int dayOfWorstSteps = User[indexSelectedUser].steps.IndexOf(worstSteps);
            drawWorstResult(worstSteps, dayOfWorstSteps);
        }



        public void bit()
        {
            Bitmap b = new Bitmap(700, 500);
            using (Graphics g = Graphics.FromImage(b))
            {
                //g.Clear(Color.White);
                g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), 100, 100, 100, 100);
                // что нибудь рисуете
                // g.DrawRectangle(...
            }

        }
    }
}
