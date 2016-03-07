using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    [Flags]
    enum Styles
    {
        ShowBorder = 1,        
        ShowCaption = 2,       
        ShowToolbox = 4      
    }  

    class FlagDemo
    {
        public static void Execute() 
        {
            Styles Style = Styles.ShowBorder | Styles.ShowCaption;
            Console.WriteLine(Style.ToString());
            Style = Style & (~Styles.ShowBorder);
            Console.WriteLine(Style.ToString());

        }
    }
}
