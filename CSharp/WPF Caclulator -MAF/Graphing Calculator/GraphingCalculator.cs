using System;
using System.Collections.Generic;
using System.Text;
using AddInView;
using System.AddIn;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;

namespace GraphCalc
{
    [AddIn("Graphing Calculator")]
    public class GraphingCalculator : VisualCalculator
    {
        IList<Operation> _ops;
        List<byte[]> _leaks;
        Grapher _grapher;

        public GraphingCalculator()
        {

            //System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Dispatcher.CurrentDispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(CurrentDispatcher_UnhandledException);
            _ops = new List<Operation>();
            _ops.Add(new Operation("2D Graph", 0));
            _ops.Add(new Operation("2D Parametric Graph", 0));
            _ops.Add(new Operation("3D Parametric Graph", 0));
            _grapher = new Grapher();
            _leaks = new List<byte[]>();


        }

        void CurrentDispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            e.Handled = true;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
         
            //System.AppDomain.Unload(System.AppDomain.CurrentDomain);
        }

        ~GraphingCalculator()
        {
        }

      
        public override string Name
        {
            get { return "Graphing Calculator"; }
        }

        public override IList<Operation> Operations
        {
            get { return _ops; }
        }


        public override System.Windows.FrameworkElement Operate(Operation op, double[] operands)
        {
           switch (op.Name)
            {
                
                case "2D Graph":
                    return new SceneInput2D();
                case "2D Parametric Graph":
                    return new SceneInput2dP();
                case "3D Parametric Graph":
                    return new SceneInput3D();
                default:
                    TextBox t = new TextBox();
                    t.Text = "Hello there";
                    return t;

            }
            
        }
    }
}
