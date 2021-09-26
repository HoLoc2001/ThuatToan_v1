﻿using System;
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

namespace ThuatToan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void EmptyDelegate();
        int Number;
        double[] array;
        double countWidth = 0;
        Random rand = new Random();


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        

        private void btnSortLinkedList_Click(object sender, RoutedEventArgs e)
        {
                Stopwatch start = new Stopwatch();
                start.Start();
                ArrayToLinkedList();
                start.Stop();
                MessageBox.Show($"{start.Elapsed.Seconds} giay, {start.Elapsed.Milliseconds} mili giay");
           
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            random();
            
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           if(NumberTextBox.Text != " " && !string.IsNullOrEmpty(NumberTextBox.Text) && double.TryParse(NumberTextBox.Text, out double b)) {sliderNumber.Value = Convert.ToDouble(NumberTextBox.Text);}
        }

        private void sliderNumber_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Number = Convert.ToInt32(sliderNumber.Value);
            random();
        }


        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch start = new Stopwatch();
            start.Start();
            bubble_sort.Bubble_sort(array,canvas1);
            //BubbleSorted();
            start.Stop();
            MessageBox.Show($"{start.Elapsed.Seconds} giay, {start.Elapsed.Milliseconds} mili giay");
        }

        void random()
        {
            if (canvas1 != null) { canvas1.Children.Clear(); }
            countWidth = 0;
            int maxWidth = 1160;
            int maxHieght = 550;
            array = new double[Number];
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    double int_rand = rand.NextDouble() + rand.Next(1, maxHieght);
                    if (!array.Contains(int_rand))
                    {
                        array[i] = int_rand;
                        break;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Rectangle rtgNext = new Rectangle();
                rtgNext.Width = maxWidth / Number;
                rtgNext.Height = array[i];
                rtgNext.Fill = new SolidColorBrush(Colors.Black);
                Canvas.SetLeft(rtgNext, countWidth);
                Canvas.SetBottom(rtgNext, 0);
                canvas1.Children.Add(rtgNext);
                countWidth = countWidth + (maxWidth / (double)Number);
            }
        }
        void BubbleSorted()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        canvas1.Children[j].SetValue(Rectangle.HeightProperty, array[j + 1]);
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        canvas1.Children[j + 1].SetValue(Rectangle.HeightProperty, array[j]);
                        Thread.Sleep(TimeSpan.FromSeconds(0.5));
                        array[j] = array[j] + array[j + 1];
                        array[j + 1] = array[j] - array[j + 1];
                        array[j] = array[j] - array[j + 1];
                    }
                }
            }
        }
        void ArrayToLinkedList()
        {
            SinglyLinkedList Linked_List = new SinglyLinkedList();
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                Linked_List.InsertLast(Linked_List, array[i]);
            }
            Linked_List.BubbleSort(Linked_List, canvas1);
        }
        
        public static void Refresh()
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new EmptyDelegate(delegate { }));
        }
    }
}
