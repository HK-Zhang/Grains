using System;
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

namespace GraphCalc
{
    /// <summary>
    /// Interaction logic for TestPop.xaml
    /// </summary>
    public partial class TestPop : System.Windows.Window
    {
        public TestPop()
        {
            InitializeComponent();

            this.MemLabel.Text = System.AppDomain.CurrentDomain.Id.ToString() + "/" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
        }


    }
}
