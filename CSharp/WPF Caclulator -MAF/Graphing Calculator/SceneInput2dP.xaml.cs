﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace GraphCalc
{
    /// <summary>
    /// Interaction logic for SceneInput2dP.xaml
    /// </summary>
    public partial class SceneInput2dP : System.Windows.Controls.UserControl
    {
        public SceneInput2dP()
        {
            InitializeComponent();
            GraphIt.Click += new RoutedEventHandler(GraphIt_Click);
            Spiral.Click += new RoutedEventHandler(Spiral_Click);
            Elipse.Click += new RoutedEventHandler(Elipse_Click);
           
            //EquationX.Text = System.AppDomain.CurrentDomain.Id.ToString()+ "/" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
        }

        void Elipse_Click(object sender, RoutedEventArgs e)
        {
            EquationX.Text = "4cos(t)";
            EquationY.Text = "3sin(t)";

            //UI Thread are shared with Main Form Thread ID.
            //throw new Exception();

            //Thread t1 = new Thread(new ThreadStart(throwEx));
            //t1.Start();

        }

        void throwEx() 
        {
            //int a = 1;
            throw new Exception();
        }

        void Spiral_Click(object sender, RoutedEventArgs e)
        {
            EquationX.Text = "sin(t)*t/pi";
            EquationY.Text = "cos(t)*t/pi";
        }

        void GraphIt_Click(object sender, RoutedEventArgs e)
        {
            Display.Children.Clear();
            Grapher grapher = new Grapher();
            Display.Children.Add(grapher.Show2DP(this.EquationX.Text,this.EquationY.Text));
        }
    }
}
