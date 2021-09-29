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
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Windows.Threading;
using static ThuatToan.MainWindow;

namespace ThuatToan
{
    public class bubble_sort
    {
        public static void Bubble_sort(double[] array, Canvas canvas1)
        {

            int lenght = array.Length;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght - 1; j++)
                {
                    //Swap_color.start_Swap_Color(canvas1, j);
                    //MainWindow.Refresh();
                    //Thread.Sleep(TimeSpan.FromSeconds(0.2));
                    if (array[j] > array[j + 1])
                    {
                        //Swap_color.sort_Swap_Color(canvas1, j);
                        //MainWindow.Refresh();
                        Thread.Sleep(TimeSpan.FromSeconds(0.2));
                        canvas1.Children[j].SetValue(Rectangle.HeightProperty, array[j + 1]);
                        canvas1.Children[j + 1].SetValue(Rectangle.HeightProperty, array[j]);
                        array[j] = array[j] + array[j + 1];
                        array[j + 1] = array[j] - array[j + 1];
                        array[j] = array[j] - array[j + 1];
                        //MainWindow.Refresh();
                        //Thread.Sleep(TimeSpan.FromSeconds(0.2));
                    }
                    //Swap_color.end_Swap_Color(canvas1, j);
                    //MainWindow.Refresh();
                    //Thread.Sleep(TimeSpan.FromSeconds(0.2));
                }
            }
        }
    }
}
