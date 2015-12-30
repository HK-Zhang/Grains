using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckyDraw
{
    public partial class Form1 : Form
    {
        private List<string> EmpLst = new List<string>();
        private List<string> luckerLst = new List<string>();
        Predicate<string> prid;
        Action<object> act;
        bool flgStop = false;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (btnControl.Text == "STOP")
            {
                funStop();
            }
            else 
            {
                funStart();
            }
            
        }

        private void funStart() 
        {
            btnControl.Text = "STOP";
            flgStop = false;

            SynchronizationContext uiContext = SynchronizationContext.Current;
            Thread thread = new Thread(run);
            thread.Start(uiContext);
            

        }

        private int returnRandom()
        {
            int size = EmpLst.Count;
            Random rad = new Random();
            return rad.Next(0, size - 1);
        }

        private void funStop()
        {
            flgStop = true;

            int RanKey = returnRandom();
            lblLucky.Text = EmpLst[RanKey];
            
            outPutResult(EmpLst[RanKey]);
            luckerLst.Add(EmpLst[RanKey]);
            EmpLst.Remove(EmpLst[RanKey]);

            btnControl.Text = "START";

        }

        private void outPutResult(string cnt) 
        {
            StreamWriter sw = new StreamWriter("lucky.csv", true);
            try
            {
                sw.WriteLine(cnt);
            }
            finally
            {
                sw.Close();
            }

        }

        private void loadList() 
        {
            StreamReader sr = new StreamReader("list.csv", Encoding.Default);

            try
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    EmpLst.Add(line);
                }
            }
            finally
            {
                sr.Close();
            }

            sr = new StreamReader("lucky.csv", Encoding.Default);
            try
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    luckerLst.Add(line);
                }
            }
            finally
            {
                sr.Close();
            }

        }

        private void initialize() 
        {
            loadList();
            EmpLst.RemoveAll(prid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            prid = delegate(string cur)
            {
                return luckerLst.Contains(cur);
            };

            act = str => { lblLucky.Text = str as string; };
       

            initialize();

        }

        private void run(object state)
        {
            SynchronizationContext uiContext = state as SynchronizationContext;

            while (!flgStop)
            {
                //uiContext.Post(updateUI, EmpLst[returnRandom()]);
                uiContext.Post(par => { act(par); }, EmpLst[returnRandom()]);

                Thread.Sleep(100);
            }
        }

        private void updateUI(object state) 
        {
            act(state);
        }
    }
}
